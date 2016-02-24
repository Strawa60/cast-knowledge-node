/*
Created: 2013-06-12
Modified: 2013-06-26
Model: MySQL 5.5
Database: MySQL 5.5
*/

-- Create tables section -------------------------------------------------

-- Table firma

CREATE TABLE firma
(
  id_firmy Int NOT NULL AUTO_INCREMENT,
  nazwa Varchar(50),
  kod_pocztowy Char(6),
  miejscowosc Char(20),
  ulica Char(30),
  telefon Char(30),
  fax Char(30),
  wojewodztwo Char(20),
  prezes Char(30),
  www Char(20),
  e_mail Char(20),
  term_wyszukiwania Char(50),
  is_dostawca Tinyint ZEROFILL NOT NULL,
  is_odlewnia Tinyint ZEROFILL NOT NULL,
 PRIMARY KEY (id_firmy),
 UNIQUE id_dostawcy (id_firmy)
)
;

-- Table zasoby

CREATE TABLE zasoby
(
  id_zasobu Int NOT NULL AUTO_INCREMENT,
  nazwa_zasobu Char(30),
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
  nazwa_technologii Char(30),
  id_firmy Int,
 PRIMARY KEY (id_technologia),
 UNIQUE id_technologia (id_technologia)
)
;

-- Table tworzywo

CREATE TABLE tworzywo
(
  id_tworzywo Int NOT NULL AUTO_INCREMENT,
  nazwa Char(20),
  symbol Char(20),
  id_firmy Int,
 PRIMARY KEY (id_tworzywo),
 UNIQUE Attribute1 (id_tworzywo)
)
;

-- Table innowacje_patenty

CREATE TABLE innowacje_patenty
(
  id_innowacji Int NOT NULL AUTO_INCREMENT,
  rok_rozpoczecia Char(4),
  rok_zakonczenia Char(4),
  nazwa_innowacji Char(20),
  opis_innowacji Text,
  osrodek_opracowujacy Char(30),
  url Char(50),
  id_zakresu Int,
  id_zrodlo Int,
 PRIMARY KEY (id_innowacji),
 UNIQUE id_innowacji (id_innowacji)
)
  COMMENT = 'tabela innowacji zbiera informacje dotyczace nowych wynalazkow'
;

-- Table publikacje

CREATE TABLE publikacje
(
  id_publikacji Int NOT NULL AUTO_INCREMENT,
  rok_publikacji Char(20),
  tytul_polski Text,
  tytul_zagraniczny Text,
  czasopismo Char(50),
  streszczenie_pol Text,
  streszczenie_ang Text,
  nr_vol_issue Char(20),
  strony Char(20),
  url Char(50),
  id_innowacji Int,
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
  id_innowacji Int,
  id_publikacji Int,
 PRIMARY KEY (id_autora),
 UNIQUE id_autora (id_autora)
)
  COMMENT = 'autorzy innowacji, ich dane oraz relacje innowacji ktorych dotyczy oraz publikacji na ich temat'
;

-- Table slowa_kluczowe

CREATE TABLE slowa_kluczowe
(
  id_deskryptora Int NOT NULL AUTO_INCREMENT,
  deskryptor Char(20)
  COMMENT 'słowo kluczowe',
  id_innowacji Int
  COMMENT 'id innowacji ktorej dotyczy deskryptor',
  id_publikacji Int
  COMMENT 'id publickacji w ktorej wystepuje/dotyczy dany deskryptor',
 PRIMARY KEY (id_deskryptora),
 UNIQUE id_deskryptora (id_deskryptora)
)
;

-- Table zakres

CREATE TABLE zakres
(
  id_zakresu Int NOT NULL AUTO_INCREMENT,
  nazwa_zakresu Char(20),
 PRIMARY KEY (id_zakresu),
 UNIQUE id_zakresu (id_zakresu)
)
;

-- Table zrodlo

CREATE TABLE zrodlo
(
  id_zrodlo Int NOT NULL AUTO_INCREMENT,
  zrodlo_nazwa Char(50),
  kryterium Char(20),
 PRIMARY KEY (id_zrodlo),
 UNIQUE id_zrodlo (id_zrodlo)
)
;

-- Create relationships section ------------------------------------------------- 

ALTER TABLE zasoby ADD CONSTRAINT dostawca_oferuje FOREIGN KEY (id_firmy) REFERENCES firma (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE technologia ADD CONSTRAINT odlewnia_wykorzustuje FOREIGN KEY (id_firmy) REFERENCES firma (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE tworzywo ADD CONSTRAINT odlewnia_wytwarza FOREIGN KEY (id_firmy) REFERENCES firma (id_firmy) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE autorzy ADD CONSTRAINT autorzy_innowacji FOREIGN KEY (id_innowacji) REFERENCES innowacje_patenty (id_innowacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE autorzy ADD CONSTRAINT autorzy_publikacji FOREIGN KEY (id_publikacji) REFERENCES publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE slowa_kluczowe ADD CONSTRAINT deskryptory_innowacji FOREIGN KEY (id_innowacji) REFERENCES innowacje_patenty (id_innowacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE slowa_kluczowe ADD CONSTRAINT deskryptory_publikacji FOREIGN KEY (id_publikacji) REFERENCES publikacje (id_publikacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE innowacje_patenty ADD CONSTRAINT innowacja_zakresu FOREIGN KEY (id_zakresu) REFERENCES zakres (id_zakresu) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE innowacje_patenty ADD CONSTRAINT zrodlo_innowacji FOREIGN KEY (id_zrodlo) REFERENCES zrodlo (id_zrodlo) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE publikacje ADD CONSTRAINT publikacja_dotyczy_innowacji FOREIGN KEY (id_innowacji) REFERENCES innowacje_patenty (id_innowacji) ON DELETE NO ACTION ON UPDATE NO ACTION
;


