/*
Created: 2013-06-12
Modified: 2014-03-20
Model: MySQL 5.5
Database: MySQL 5.5
*/



-- Create tables section -------------------------------------------------

-- Table dostawca

CREATE TABLE dostawca
(
  id_firmy Int NOT NULL AUTO_INCREMENT,
  nazwa Char(100),
  miejscowosc Char(100),
  kod_pocztowy Char(10),
  ulica Char(100),
  wojewodztwo Char(100),
  telefon Char(20),
  fax Char(20),
  www Char(100),
  prezes Char(100),
  e_mail Char(100),
  id_term Int,
 PRIMARY KEY (id_firmy),
 UNIQUE id_dostawcy (id_firmy)
)
;

-- Table zasoby

CREATE TABLE zasoby
(
  id_zasobu Int NOT NULL AUTO_INCREMENT,
  nazwa_zasobu Text,
  id_firmy Int,
 PRIMARY KEY (id_zasobu),
 UNIQUE id_zasobu (id_zasobu)
)
;

-- Table odlewnie

CREATE TABLE odlewnie
(
  id_odlewni Int NOT NULL AUTO_INCREMENT,
  nazwa_odlewni Char(20),
  Attribute2 Char(20),
 UNIQUE id_odlewni (id_odlewni)
)
;

-- Table technologia

CREATE TABLE technologia
(
  id_technologia Int NOT NULL AUTO_INCREMENT,
  nazwa_technologii Char(100),
  id_odlewni Int,
 PRIMARY KEY (id_technologia),
 UNIQUE id_technologia (id_technologia)
)
;

-- Table tworzywo

CREATE TABLE tworzywo
(
  id_tworzywo Int NOT NULL AUTO_INCREMENT,
  nazwa_tworzywa Char(20),
  id_odlewni Int,
 PRIMARY KEY (id_tworzywo),
 UNIQUE Attribute1 (id_tworzywo)
)
;

-- Table patenty

CREATE TABLE patenty
(
  numer_wynalazku Int NOT NULL,
  data_rozpoczecia Char(10),
  data_zakonczenia Char(10),
  data_zgloszenia Char(10),
  symbol_patentowy Char(20),
  tytul_polski Text,
  tytul_angielski Text,
  opis_polski Text,
  opis_angielski Text,
  osrodek_opracowujacy Char(30),
  url Char(50)
)
  COMMENT = 'tabela innowacji zbiera informacje dotyczace nowych wynalazkow'
;

ALTER TABLE patenty ADD PRIMARY KEY (numer_wynalazku)
;

ALTER TABLE patenty ADD UNIQUE id_innowacji (numer_wynalazku)
;

-- Table publikacje

CREATE TABLE publikacje
(
  id_publikacji Int NOT NULL AUTO_INCREMENT,
  rok_publikacji Char(20),
  tytul_polski Text,
  tytul_zagraniczny Text,
  streszczenie_pol Text,
  streszczenie_ang Text,
  zrodlo_publikacji Char(150),
 PRIMARY KEY (id_publikacji),
 UNIQUE id_publikacji (id_publikacji)
)
  COMMENT = 'tabela zbiera informacje na temat publikacji ktore dotycza konkretnej innowacji'
;

-- Table autorzy

CREATE TABLE autorzy
(
  id_autora Int NOT NULL AUTO_INCREMENT,
  imie Char(20),
  nazwisko Char(30),
  afiliacja Char(50),
  funkcja Char(20),
 PRIMARY KEY (id_autora),
 UNIQUE id_autora (id_autora)
)
  COMMENT = 'autorzy innowacji, ich dane oraz relacje innowacji ktorych dotyczy oraz publikacji na ich temat'
;

-- Table odlewnia

CREATE TABLE odlewnia
(
  id_odlewni Int NOT NULL AUTO_INCREMENT,
  nazwa Char(100),
  miejscowosc Char(100),
  kod_pocztowy Char(10),
  ulica Char(100),
  telefon Char(20),
  fax Char(20),
  www Char(100),
  e_mail Char(100),
 PRIMARY KEY (id_odlewni),
 UNIQUE id_odlewni (id_odlewni)
)
;

-- Table typ_firmy

CREATE TABLE typ_firmy
(
  id_term Int NOT NULL AUTO_INCREMENT,
  nazwa Char(50),
 PRIMARY KEY (id_term),
 UNIQUE id_term (id_term)
)
;

-- Table slowa_kluczowe

CREATE TABLE slowa_kluczowe
(
  id_deskryptora Int NOT NULL AUTO_INCREMENT,
  nazwa_deskryptora Char(100),
 PRIMARY KEY (id_deskryptora),
 UNIQUE id_deskryptora (id_deskryptora)
)
;

-- Table odlewnia_tagi

CREATE TABLE odlewnia_tagi
(
  id_deskryptora Int,
  id_odlewni Int
)
;

-- Table dostawca_tagi

CREATE TABLE dostawca_tagi
(
  id_firmy Int,
  id_deskryptora Int
)
;

-- Table publikacje_tagi

CREATE TABLE publikacje_tagi
(
  id_publikacji Int,
  id_deskryptora Int
)
;

-- Table publikacja_autor

CREATE TABLE publikacja_autor
(
  id_publikacji Int,
  id_autora Int
)
;

-- Table patent_autor

CREATE TABLE patent_autor
(
  id_autora Int,
  numer_wynalazku Int
)
;

-- Table patenty_tagi

CREATE TABLE patenty_tagi
(
  numer_wynalazku Int,
  id_deskryptora Int
)
;

-- Table patenty_publikacja

CREATE TABLE patenty_publikacja
(
  numer_wynalazku Int,
  id_publikacji Int
)
;

-- Create relationships section ------------------------------------------------- 

ALTER TABLE zasoby ADD CONSTRAINT zaopatruje_w_zasoby FOREIGN KEY (id_firmy) REFERENCES dostawca (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE dostawca_tagi ADD CONSTRAINT  FOREIGN KEY (id_firmy) REFERENCES dostawca (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE dostawca_tagi ADD CONSTRAINT firma_zajmuje_sie FOREIGN KEY (id_deskryptora) REFERENCES slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE odlewnia_tagi ADD CONSTRAINT  FOREIGN KEY (id_deskryptora) REFERENCES slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE odlewnia_tagi ADD CONSTRAINT  FOREIGN KEY (id_odlewni) REFERENCES odlewnia (id_odlewni) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE dostawca ADD CONSTRAINT termin_wyszukiwania FOREIGN KEY (id_term) REFERENCES typ_firmy (id_term) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE technologia ADD CONSTRAINT korzysta_z_technologii FOREIGN KEY (id_odlewni) REFERENCES odlewnia (id_odlewni) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE tworzywo ADD CONSTRAINT używa_tworzywa FOREIGN KEY (id_odlewni) REFERENCES odlewnia (id_odlewni) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE publikacje_tagi ADD CONSTRAINT  FOREIGN KEY (id_publikacji) REFERENCES publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE publikacje_tagi ADD CONSTRAINT publikacja_jest_opisana_tagami FOREIGN KEY (id_deskryptora) REFERENCES slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE publikacja_autor ADD CONSTRAINT  FOREIGN KEY (id_publikacji) REFERENCES publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE publikacja_autor ADD CONSTRAINT publikacja_posiada_autorow FOREIGN KEY (id_autora) REFERENCES autorzy (id_autora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patent_autor ADD CONSTRAINT patent_posiada_autorow FOREIGN KEY (id_autora) REFERENCES autorzy (id_autora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patent_autor ADD CONSTRAINT  FOREIGN KEY (numer_wynalazku) REFERENCES patenty (numer_wynalazku) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patenty_tagi ADD CONSTRAINT  FOREIGN KEY (numer_wynalazku) REFERENCES patenty (numer_wynalazku) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patenty_tagi ADD CONSTRAINT patent_jest_opisany_tagami FOREIGN KEY (id_deskryptora) REFERENCES slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patenty_publikacja ADD CONSTRAINT patent_ma_publikacje FOREIGN KEY (numer_wynalazku) REFERENCES patenty (numer_wynalazku) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE patenty_publikacja ADD CONSTRAINT publikacja_na_temat FOREIGN KEY (id_publikacji) REFERENCES publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;


