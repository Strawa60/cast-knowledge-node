/*
Created: 2013-06-12
Modified: 2014-06-01
Model: MySQL 5.5
Database: MySQL 5.5
*/



-- Create tables section -------------------------------------------------

-- Table Dostawca

CREATE TABLE Dostawca
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
  e_mail Char(100),
  prezes Char(100),
  zasoby Text,
  typ_firmy Char(100),
 PRIMARY KEY (id_firmy),
 UNIQUE id_dostawcy (id_firmy)
)
;

-- Table Patenty

CREATE TABLE Patenty
(
  id_patentu Int NOT NULL AUTO_INCREMENT,
  numer_wynalazku Char(100),
  data_rozpoczecia Char(100),
  data_zakonczenia Char(100),
  data_zgloszenia Char(100),
  symbol_patentowy Text,
  tytul_polski Text,
  tytul_angielski Text,
  opis_polski Text,
  opis_angielski Text,
  osrodek_opracowujacy Char(100),
  url Char(100),
 PRIMARY KEY (id_patentu),
 UNIQUE id_patentu (id_patentu)
)
  COMMENT = 'tabela innowacji zbiera informacje dotyczace nowych wynalazkow'
;

-- Table Publikacje

CREATE TABLE Publikacje
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

-- Table Autorzy

CREATE TABLE Autorzy
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

-- Table Odlewnia

CREATE TABLE Odlewnia
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
  nazwa_technologii Char(100),
  nazwa_tworzywa Char(100),
 PRIMARY KEY (id_odlewni),
 UNIQUE id_odlewni (id_odlewni)
)
;

-- Table Odlewnia_tagi

CREATE TABLE Odlewnia_tagi
(
  id Int NOT NULL AUTO_INCREMENT,
  id_odlewni Int,
  id_deskryptora Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Dostawca_tagi

CREATE TABLE Dostawca_tagi
(
  id Int NOT NULL AUTO_INCREMENT,
  id_firmy Int,
  id_deskryptora Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Publikacje_tagi

CREATE TABLE Publikacje_tagi
(
  id Int NOT NULL AUTO_INCREMENT,
  id_publikacji Int,
  id_deskryptora Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Publikacja_autor

CREATE TABLE Publikacja_autor
(
  id Int NOT NULL AUTO_INCREMENT,
  id_publikacji Int,
  id_autora Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Patent_autor

CREATE TABLE Patent_autor
(
  id Int NOT NULL AUTO_INCREMENT,
  id_autora Int,
  id_patentu Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Patenty_tagi

CREATE TABLE Patenty_tagi
(
  id Int NOT NULL AUTO_INCREMENT,
  id_deskryptora Int,
  id_patentu Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Patenty_publikacja

CREATE TABLE Patenty_publikacja
(
  id Int NOT NULL AUTO_INCREMENT,
  id_publikacji Int,
  id_patentu Int,
 PRIMARY KEY (id),
 UNIQUE id (id)
)
;

-- Table Slowa_kluczowe

CREATE TABLE Slowa_kluczowe
(
  id_deskryptora Int NOT NULL AUTO_INCREMENT,
  nazwa Char(100),
 PRIMARY KEY (id_deskryptora),
 UNIQUE id_deskryptora (id_deskryptora)
)
;

-- Create relationships section ------------------------------------------------- 

ALTER TABLE Dostawca_tagi ADD CONSTRAINT  FOREIGN KEY (id_firmy) REFERENCES Dostawca (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Odlewnia_tagi ADD CONSTRAINT  FOREIGN KEY (id_odlewni) REFERENCES Odlewnia (id_odlewni) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Publikacje_tagi ADD CONSTRAINT  FOREIGN KEY (id_publikacji) REFERENCES Publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Publikacja_autor ADD CONSTRAINT  FOREIGN KEY (id_publikacji) REFERENCES Publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Publikacja_autor ADD CONSTRAINT publikacja_posiada_autorow FOREIGN KEY (id_autora) REFERENCES Autorzy (id_autora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patent_autor ADD CONSTRAINT patent_posiada_autorow FOREIGN KEY (id_autora) REFERENCES Autorzy (id_autora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patenty_publikacja ADD CONSTRAINT publikacja_na_temat FOREIGN KEY (id_publikacji) REFERENCES Publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patenty_tagi ADD CONSTRAINT  FOREIGN KEY (id_deskryptora) REFERENCES Slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Dostawca_tagi ADD CONSTRAINT  FOREIGN KEY (id_deskryptora) REFERENCES Slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Odlewnia_tagi ADD CONSTRAINT  FOREIGN KEY (id_deskryptora) REFERENCES Slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Publikacje_tagi ADD CONSTRAINT  FOREIGN KEY (id_deskryptora) REFERENCES Slowa_kluczowe (id_deskryptora) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patenty_tagi ADD CONSTRAINT  FOREIGN KEY (id_patentu) REFERENCES Patenty (id_patentu) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patent_autor ADD CONSTRAINT  FOREIGN KEY (id_patentu) REFERENCES Patenty (id_patentu) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Patenty_publikacja ADD CONSTRAINT  FOREIGN KEY (id_patentu) REFERENCES Patenty (id_patentu) ON DELETE NO ACTION ON UPDATE NO ACTION
;


