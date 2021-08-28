-- MySQL Script generated by MySQL Workbench
-- Wed Aug  5 16:15:46 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mybutikdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mybutikdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mybutikdb` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `mybutikdb` ;

-- -----------------------------------------------------
-- Table `mybutikdb`.`MJESTO`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`MJESTO` (
  `PostanskiBroj` VARCHAR(20) NOT NULL,
  `NazivMjesta` VARCHAR(50) NOT NULL,
  `Drzava` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`PostanskiBroj`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`BUTIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`BUTIK` (
  `IdButika` INT NOT NULL AUTO_INCREMENT,
  `JIB` CHAR(13) NOT NULL,
  `MaticniBroj` CHAR(7) NOT NULL,
  `Naziv` VARCHAR(50) NOT NULL,
  `Adresa` VARCHAR(70) NOT NULL,
  `Telefon` VARCHAR(20) NOT NULL,
  `MJESTO_PostanskiBroj` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdButika`),
  INDEX `fk_BUTIK_MJESTO1_idx` (`MJESTO_PostanskiBroj` ASC) VISIBLE,
  CONSTRAINT `fk_BUTIK_MJESTO1`
    FOREIGN KEY (`MJESTO_PostanskiBroj`)
    REFERENCES `mybutikdb`.`MJESTO` (`PostanskiBroj`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ARTIKAL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ARTIKAL` (
  `SifraArtikla` VARCHAR(20) NOT NULL,
  `Naziv` VARCHAR(50) NOT NULL,
  `JedCijena` DECIMAL(6,2) NOT NULL,
  `BrojDostupnih` INT NOT NULL,
  `Velicina` VARCHAR(5) NOT NULL,
  `BUTIK_IdButika` INT NOT NULL,
  PRIMARY KEY (`SifraArtikla`, `Velicina`, `BUTIK_IdButika`),
  INDEX `fk_ARTIKAL_BUTIK1_idx` (`BUTIK_IdButika` ASC) VISIBLE,
  CONSTRAINT `fk_ARTIKAL_BUTIK1`
    FOREIGN KEY (`BUTIK_IdButika`)
    REFERENCES `mybutikdb`.`BUTIK` (`IdButika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`DOBAVLJAC`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`DOBAVLJAC` (
  `JIB` CHAR(13) NOT NULL,
  `Adresa` VARCHAR(70) NOT NULL,
  `Telefon` VARCHAR(20) NOT NULL,
  `Naziv` VARCHAR(50) NOT NULL,
  `MJESTO_PostanskiBroj` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`JIB`),
  INDEX `fk_DOBAVLJAC_MJESTO1_idx` (`MJESTO_PostanskiBroj` ASC) VISIBLE,
  CONSTRAINT `fk_DOBAVLJAC_MJESTO1`
    FOREIGN KEY (`MJESTO_PostanskiBroj`)
    REFERENCES `mybutikdb`.`MJESTO` (`PostanskiBroj`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`OSOBA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`OSOBA` (
  `JMB` CHAR(13) NOT NULL,
  `Ime` VARCHAR(50) NOT NULL,
  `Prezime` VARCHAR(50) NOT NULL,
  `Adresa` VARCHAR(70) NOT NULL,
  `DatumRodjenja` DATE NOT NULL,
  PRIMARY KEY (`JMB`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ZAPOSLENJE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ZAPOSLENJE` (
  `BrojUgovora` INT NOT NULL AUTO_INCREMENT,
  `DatumOd` DATE NOT NULL,
  `DatumDo` DATE NULL,
  `Plata` DECIMAL(6,2) NULL,
  `Tekst` VARCHAR(1000) NULL,
  `BUTIK_IdButika` INT NOT NULL,
  PRIMARY KEY (`BrojUgovora`),
  INDEX `fk_ZAPOSLENJE_BUTIK1_idx` (`BUTIK_IdButika` ASC) VISIBLE,
  CONSTRAINT `fk_ZAPOSLENJE_BUTIK1`
    FOREIGN KEY (`BUTIK_IdButika`)
    REFERENCES `mybutikdb`.`BUTIK` (`IdButika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`DIREKTOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`DIREKTOR` (
  `OSOBA_JMB` CHAR(13) NOT NULL,
  `ZAPOSLENJE_BrojUgovora` INT NOT NULL,
  PRIMARY KEY (`OSOBA_JMB`),
  INDEX `fk_DIREKTOR_ZAPOSLENJE1_idx` (`ZAPOSLENJE_BrojUgovora` ASC) VISIBLE,
  CONSTRAINT `fk_DIREKTOR_OSOBA2`
    FOREIGN KEY (`OSOBA_JMB`)
    REFERENCES `mybutikdb`.`OSOBA` (`JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DIREKTOR_ZAPOSLENJE1`
    FOREIGN KEY (`ZAPOSLENJE_BrojUgovora`)
    REFERENCES `mybutikdb`.`ZAPOSLENJE` (`BrojUgovora`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`KNJIGOVODJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`KNJIGOVODJA` (
  `OSOBA_JMB` CHAR(13) NOT NULL,
  `KnjigovodstveniBiro` VARCHAR(45) NOT NULL,
  `Ugovor` VARCHAR(255) NULL,
  `DIREKTOR_OSOBA_JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`OSOBA_JMB`),
  INDEX `fk_KNJIGOVODJA_DIREKTOR1_idx` (`DIREKTOR_OSOBA_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_HONORARNI_OSOBA1`
    FOREIGN KEY (`OSOBA_JMB`)
    REFERENCES `mybutikdb`.`OSOBA` (`JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_KNJIGOVODJA_DIREKTOR1`
    FOREIGN KEY (`DIREKTOR_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`DIREKTOR` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`BILANS_STANJA_I_BILANS_USPJEHA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`BILANS_STANJA_I_BILANS_USPJEHA` (
  `IdBSP` INT NOT NULL,
  `IzvještajORashodima` VARCHAR(5000) NULL,
  `IzvjestajOPrihodima` VARCHAR(5000) NULL,
  PRIMARY KEY (`IdBSP`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`NARUDZBA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`NARUDZBA` (
  `BrojFakture` INT NOT NULL AUTO_INCREMENT,
  `Datum` DATE NOT NULL,
  `CijenaBezPoreza` DECIMAL(7,2) NOT NULL,
  `Porez(%)` DECIMAL(5,2) NOT NULL,
  `CijenaDostave` DECIMAL(6,2) NOT NULL,
  `UkupnaCijena` DECIMAL(7,2) NOT NULL,
  `DOBAVLJAC_JIB` CHAR(13) NOT NULL,
  `DIREKTOR_OSOBA_JMB1` CHAR(13) NOT NULL,
  `KNJIGOVODJA_OSOBA_JMB` CHAR(13) NOT NULL,
  `BILANS_STANJA_I_BILANS_USPJEHA_IdBSP` INT NOT NULL,
  PRIMARY KEY (`BrojFakture`),
  INDEX `fk_NARUDZBA_PROIZVODJAC1_idx` (`DOBAVLJAC_JIB` ASC) VISIBLE,
  INDEX `fk_NARUDZBA_DIREKTOR2_idx` (`DIREKTOR_OSOBA_JMB1` ASC) VISIBLE,
  INDEX `fk_NARUDZBA_KNJIGOVODJA1_idx` (`KNJIGOVODJA_OSOBA_JMB` ASC) VISIBLE,
  INDEX `fk_NARUDZBA_BILANS_STANJA_I_BILANS_USPJEHA1_idx` (`BILANS_STANJA_I_BILANS_USPJEHA_IdBSP` ASC) VISIBLE,
  CONSTRAINT `fk_NARUDZBA_PROIZVODJAC1`
    FOREIGN KEY (`DOBAVLJAC_JIB`)
    REFERENCES `mybutikdb`.`DOBAVLJAC` (`JIB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_NARUDZBA_DIREKTOR2`
    FOREIGN KEY (`DIREKTOR_OSOBA_JMB1`)
    REFERENCES `mybutikdb`.`DIREKTOR` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_NARUDZBA_KNJIGOVODJA1`
    FOREIGN KEY (`KNJIGOVODJA_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`KNJIGOVODJA` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_NARUDZBA_BILANS_STANJA_I_BILANS_USPJEHA1`
    FOREIGN KEY (`BILANS_STANJA_I_BILANS_USPJEHA_IdBSP`)
    REFERENCES `mybutikdb`.`BILANS_STANJA_I_BILANS_USPJEHA` (`IdBSP`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ARTIKLI_KOD_DOBAVLJACA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ARTIKLI_KOD_DOBAVLJACA` (
  `SifraArtikla` VARCHAR(20) NOT NULL,
  `Velicina` VARCHAR(55) NOT NULL,
  `Naziv` VARCHAR(50) NULL,
  `JedCijena` DECIMAL(6,2) NULL,
  `BrojDostupnih` INT NULL,
  PRIMARY KEY (`SifraArtikla`, `Velicina`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`STAVKA_NARUDZBE`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`STAVKA_NARUDZBE` (
  `NARUDZBA_BrojFakture` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  `JedCijena` DOUBLE NOT NULL,
  `ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` VARCHAR(20) NOT NULL,
  `ARTIKLI_KOD_DOBAVLJACA_Velicina` VARCHAR(55) NOT NULL,
  PRIMARY KEY (`NARUDZBA_BrojFakture`, `ARTIKLI_KOD_DOBAVLJACA_SifraArtikla`, `ARTIKLI_KOD_DOBAVLJACA_Velicina`),
  INDEX `fk_ARTIKAL_has_NARUDZBA_NARUDZBA1_idx` (`NARUDZBA_BrojFakture` ASC) VISIBLE,
  INDEX `fk_STAVKA_NARUDZBE_ARTIKLI_KOD_DOBAVLJACA1_idx` (`ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` ASC, `ARTIKLI_KOD_DOBAVLJACA_Velicina` ASC) VISIBLE,
  CONSTRAINT `fk_ARTIKAL_has_NARUDZBA_NARUDZBA1`
    FOREIGN KEY (`NARUDZBA_BrojFakture`)
    REFERENCES `mybutikdb`.`NARUDZBA` (`BrojFakture`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_STAVKA_NARUDZBE_ARTIKLI_KOD_DOBAVLJACA1`
    FOREIGN KEY (`ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` , `ARTIKLI_KOD_DOBAVLJACA_Velicina`)
    REFERENCES `mybutikdb`.`ARTIKLI_KOD_DOBAVLJACA` (`SifraArtikla` , `Velicina`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`BANKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`BANKA` (
  `IdBanke` INT NOT NULL AUTO_INCREMENT,
  `MJESTO_PostanskiBroj` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`IdBanke`),
  INDEX `fk_BANKA_MJESTO1_idx` (`MJESTO_PostanskiBroj` ASC) VISIBLE,
  CONSTRAINT `fk_BANKA_MJESTO1`
    FOREIGN KEY (`MJESTO_PostanskiBroj`)
    REFERENCES `mybutikdb`.`MJESTO` (`PostanskiBroj`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`RACUN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`RACUN` (
  `BrojRacuna` INT NOT NULL,
  `BANKA_IdBanke` INT NOT NULL,
  `DOBAVLJAC_JIB` CHAR(13) NOT NULL,
  PRIMARY KEY (`BrojRacuna`),
  INDEX `fk_RACUN_BANKA1_idx` (`BANKA_IdBanke` ASC) VISIBLE,
  INDEX `fk_RACUN_DOBAVLJAC1_idx` (`DOBAVLJAC_JIB` ASC) VISIBLE,
  CONSTRAINT `fk_RACUN_BANKA1`
    FOREIGN KEY (`BANKA_IdBanke`)
    REFERENCES `mybutikdb`.`BANKA` (`IdBanke`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RACUN_DOBAVLJAC1`
    FOREIGN KEY (`DOBAVLJAC_JIB`)
    REFERENCES `mybutikdb`.`DOBAVLJAC` (`JIB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ISPLATA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ISPLATA` (
  `RACUN_ZA_KUPCA_IdRacuna` INT NOT NULL,
  `RACUN_BrojRacuna` INT NOT NULL,
  PRIMARY KEY (`RACUN_ZA_KUPCA_IdRacuna`, `RACUN_BrojRacuna`),
  INDEX `fk_ISPLATA_RACUN_ZA_KUPCA1_idx` (`RACUN_ZA_KUPCA_IdRacuna` ASC) VISIBLE,
  CONSTRAINT `fk_ISPLATA_RACUN_ZA_KUPCA1`
    FOREIGN KEY (`RACUN_ZA_KUPCA_IdRacuna`)
    REFERENCES `mybutikdb`.`RACUN_ZA_KUPCA` (`IdRacuna`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`IZNOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`IZNOS` (
  `BrojIsplate` INT NOT NULL,
  `Datum` DATE NOT NULL,
  `UkupnaCijena` DOUBLE NOT NULL,
  PRIMARY KEY (`BrojIsplate`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`RADNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`RADNIK` (
  `OSOBA_JMB` CHAR(13) NOT NULL,
  `DIREKTOR_OSOBA_JMB` CHAR(13) NOT NULL,
  `ZAPOSLENJE_BrojUgovora` INT NOT NULL,
  PRIMARY KEY (`OSOBA_JMB`),
  INDEX `fk_RADNIK_DIREKTOR1_idx` (`DIREKTOR_OSOBA_JMB` ASC) VISIBLE,
  INDEX `fk_RADNIK_ZAPOSLENJE1_idx` (`ZAPOSLENJE_BrojUgovora` ASC) VISIBLE,
  CONSTRAINT `fk_RADNIK_OSOBA1`
    FOREIGN KEY (`OSOBA_JMB`)
    REFERENCES `mybutikdb`.`OSOBA` (`JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RADNIK_DIREKTOR1`
    FOREIGN KEY (`DIREKTOR_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`DIREKTOR` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RADNIK_ZAPOSLENJE1`
    FOREIGN KEY (`ZAPOSLENJE_BrojUgovora`)
    REFERENCES `mybutikdb`.`ZAPOSLENJE` (`BrojUgovora`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ISPORUKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ISPORUKA` (
  `BrojOtpremnice` INT NOT NULL,
  `Datum` DATE NOT NULL,
  `BUTIK_IdButika` INT NOT NULL,
  `RADNIK_OSOBA_JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`BrojOtpremnice`),
  INDEX `fk_ISPORUKA_BUTIK1_idx` (`BUTIK_IdButika` ASC) VISIBLE,
  INDEX `fk_ISPORUKA_RADNIK1_idx` (`RADNIK_OSOBA_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_ISPORUKA_BUTIK1`
    FOREIGN KEY (`BUTIK_IdButika`)
    REFERENCES `mybutikdb`.`BUTIK` (`IdButika`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ISPORUKA_RADNIK1`
    FOREIGN KEY (`RADNIK_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`RADNIK` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ISPORUKA_STAVKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ISPORUKA_STAVKA` (
  `Kolicina` INT NOT NULL,
  `JedCijena` DECIMAL(6,2) NOT NULL,
  `ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` VARCHAR(20) NOT NULL,
  `ARTIKLI_KOD_DOBAVLJACA_Velicina` VARCHAR(55) NOT NULL,
  `ISPORUKA_BrojOtpremnice` INT NOT NULL,
  PRIMARY KEY (`ARTIKLI_KOD_DOBAVLJACA_SifraArtikla`, `ARTIKLI_KOD_DOBAVLJACA_Velicina`, `ISPORUKA_BrojOtpremnice`),
  INDEX `fk_ISPORUKA_STAVKA_ARTIKLI_KOD_DOBAVLJACA1_idx` (`ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` ASC, `ARTIKLI_KOD_DOBAVLJACA_Velicina` ASC) VISIBLE,
  INDEX `fk_ISPORUKA_STAVKA_ISPORUKA1_idx` (`ISPORUKA_BrojOtpremnice` ASC) VISIBLE,
  CONSTRAINT `fk_ISPORUKA_STAVKA_ARTIKLI_KOD_DOBAVLJACA1`
    FOREIGN KEY (`ARTIKLI_KOD_DOBAVLJACA_SifraArtikla` , `ARTIKLI_KOD_DOBAVLJACA_Velicina`)
    REFERENCES `mybutikdb`.`ARTIKLI_KOD_DOBAVLJACA` (`SifraArtikla` , `Velicina`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ISPORUKA_STAVKA_ISPORUKA1`
    FOREIGN KEY (`ISPORUKA_BrojOtpremnice`)
    REFERENCES `mybutikdb`.`ISPORUKA` (`BrojOtpremnice`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`EVIDENCIJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`EVIDENCIJA` (
  `IdEvidencije` INT NOT NULL AUTO_INCREMENT,
  `SifraArtikla` VARCHAR(20) NOT NULL,
  `Naziv` VARCHAR(50) NOT NULL,
  `Kolicina` INT NOT NULL,
  `Cijena` DOUBLE NOT NULL,
  PRIMARY KEY (`IdEvidencije`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`KUPAC`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`KUPAC` (
  `IdKupca` INT NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(45) NULL,
  `Prezime` VARCHAR(45) NULL,
  PRIMARY KEY (`IdKupca`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`RACUN_ZA_KUPCA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`RACUN_ZA_KUPCA` (
  `IdRacuna` INT NOT NULL AUTO_INCREMENT,
  `UkupnaCijena` DECIMAL(7,2) NOT NULL,
  `Datum` DATE NOT NULL,
  `NacinPlacanja` VARCHAR(45) NOT NULL,
  `Porez(%)` INT GENERATED ALWAYS AS (17) VIRTUAL,
  `KUPAC_IdKupca` INT NOT NULL,
  `KNJIGOVODJA_OSOBA_JMB` CHAR(13) NULL,
  `BILANS_STANJA_I_USPJEHA_IdBSP` INT NULL,
  `RADNIK_OSOBA_JMB` CHAR(13) NOT NULL,
  PRIMARY KEY (`IdRacuna`),
  INDEX `fk_RACUN_ZA_KUPCA_KUPAC1_idx` (`KUPAC_IdKupca` ASC) VISIBLE,
  INDEX `fk_RACUN_ZA_KUPCA_KNJIGOVODJA1_idx` (`KNJIGOVODJA_OSOBA_JMB` ASC) VISIBLE,
  INDEX `fk_RACUN_ZA_KUPCA_BILANS_STANJA_I_USPJEHA1_idx` (`BILANS_STANJA_I_USPJEHA_IdBSP` ASC) VISIBLE,
  INDEX `fk_RACUN_ZA_KUPCA_RADNIK1_idx` (`RADNIK_OSOBA_JMB` ASC) VISIBLE,
  CONSTRAINT `fk_RACUN_ZA_KUPCA_KUPAC1`
    FOREIGN KEY (`KUPAC_IdKupca`)
    REFERENCES `mybutikdb`.`KUPAC` (`IdKupca`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RACUN_ZA_KUPCA_KNJIGOVODJA1`
    FOREIGN KEY (`KNJIGOVODJA_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`KNJIGOVODJA` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RACUN_ZA_KUPCA_BILANS_STANJA_I_USPJEHA1`
    FOREIGN KEY (`BILANS_STANJA_I_USPJEHA_IdBSP`)
    REFERENCES `mybutikdb`.`BILANS_STANJA_I_BILANS_USPJEHA` (`IdBSP`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_RACUN_ZA_KUPCA_RADNIK1`
    FOREIGN KEY (`RADNIK_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`RADNIK` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`STAVKA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`STAVKA` (
  `KUPAC_IdKupca` INT NOT NULL,
  `Kolicina` INT NOT NULL,
  `RACUN_ZA_KUPCA_IdRacuna` INT NOT NULL,
  `Cijena` DECIMAL(6,2) NOT NULL,
  `ARTIKAL_SifraArtikla` VARCHAR(20) NOT NULL,
  `ARTIKAL_Velicina` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`KUPAC_IdKupca`, `RACUN_ZA_KUPCA_IdRacuna`, `ARTIKAL_SifraArtikla`, `ARTIKAL_Velicina`),
  INDEX `fk_KORPA_STAVKA_KUPAC1_idx` (`KUPAC_IdKupca` ASC) VISIBLE,
  INDEX `fk_KORPA_STAVKA_KORPA1_idx` (`RACUN_ZA_KUPCA_IdRacuna` ASC) VISIBLE,
  INDEX `fk_STAVKE_ARTIKAL1_idx` (`ARTIKAL_SifraArtikla` ASC, `ARTIKAL_Velicina` ASC) VISIBLE,
  CONSTRAINT `fk_KORPA_STAVKA_KUPAC1`
    FOREIGN KEY (`KUPAC_IdKupca`)
    REFERENCES `mybutikdb`.`KUPAC` (`IdKupca`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_KORPA_STAVKA_KORPA1`
    FOREIGN KEY (`RACUN_ZA_KUPCA_IdRacuna`)
    REFERENCES `mybutikdb`.`RACUN_ZA_KUPCA` (`IdRacuna`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_STAVKE_ARTIKAL1`
    FOREIGN KEY (`ARTIKAL_SifraArtikla` , `ARTIKAL_Velicina`)
    REFERENCES `mybutikdb`.`ARTIKAL` (`SifraArtikla` , `Velicina`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`ISPLATA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`ISPLATA` (
  `RACUN_ZA_KUPCA_IdRacuna` INT NOT NULL,
  `RACUN_BrojRacuna` INT NOT NULL,
  PRIMARY KEY (`RACUN_ZA_KUPCA_IdRacuna`, `RACUN_BrojRacuna`),
  INDEX `fk_ISPLATA_RACUN_ZA_KUPCA1_idx` (`RACUN_ZA_KUPCA_IdRacuna` ASC) VISIBLE,
  CONSTRAINT `fk_ISPLATA_RACUN_ZA_KUPCA1`
    FOREIGN KEY (`RACUN_ZA_KUPCA_IdRacuna`)
    REFERENCES `mybutikdb`.`RACUN_ZA_KUPCA` (`IdRacuna`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`NACIN_PLACANJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`NACIN_PLACANJA` (
  `IdNP` INT NOT NULL,
  `NacinPlacanja` VARCHAR(50) NOT NULL)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`POVRAT_SREDSTAVA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`POVRAT_SREDSTAVA` (
  `IdPS` INT NOT NULL AUTO_INCREMENT,
  `Iznos` DECIMAL(6,2) NOT NULL,
  PRIMARY KEY (`IdPS`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`REKLAMACIJA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`REKLAMACIJA` (
  `IdReklamacije` INT NOT NULL AUTO_INCREMENT,
  `Datum` DATE NOT NULL,
  `RACUN_ZA_KUPCA_IdRacuna` INT NOT NULL,
  `KNJIGOVODJA_OSOBA_JMB` CHAR(13) NOT NULL,
  `BILANS_STANJA_I_BILANS_USPJEHA_IdBSP` INT NOT NULL,
  `POVRAT_SREDSTAVA_IdPS` INT NULL,
  `RADNIK_OSOBA_JMB` CHAR(13) NOT NULL,
  `RADNIK_BUTIK_IdButika` INT NOT NULL,
  PRIMARY KEY (`IdReklamacije`, `RACUN_ZA_KUPCA_IdRacuna`),
  INDEX `fk_REKLAMACIJA_RACUN_ZA_KUPCA1_idx` (`RACUN_ZA_KUPCA_IdRacuna` ASC) VISIBLE,
  INDEX `fk_REKLAMACIJA_KNJIGOVODJA1_idx` (`KNJIGOVODJA_OSOBA_JMB` ASC) VISIBLE,
  INDEX `fk_REKLAMACIJA_BILANS_STANJA_I_BILANS_USPJEHA1_idx` (`BILANS_STANJA_I_BILANS_USPJEHA_IdBSP` ASC) VISIBLE,
  INDEX `fk_REKLAMACIJA_POVRAT_SREDSTAVA1_idx` (`POVRAT_SREDSTAVA_IdPS` ASC) VISIBLE,
  INDEX `fk_REKLAMACIJA_RADNIK1_idx` (`RADNIK_OSOBA_JMB` ASC, `RADNIK_BUTIK_IdButika` ASC) VISIBLE,
  CONSTRAINT `fk_REKLAMACIJA_RACUN_ZA_KUPCA1`
    FOREIGN KEY (`RACUN_ZA_KUPCA_IdRacuna`)
    REFERENCES `mybutikdb`.`RACUN_ZA_KUPCA` (`IdRacuna`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_REKLAMACIJA_KNJIGOVODJA1`
    FOREIGN KEY (`KNJIGOVODJA_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`KNJIGOVODJA` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_REKLAMACIJA_BILANS_STANJA_I_BILANS_USPJEHA1`
    FOREIGN KEY (`BILANS_STANJA_I_BILANS_USPJEHA_IdBSP`)
    REFERENCES `mybutikdb`.`BILANS_STANJA_I_BILANS_USPJEHA` (`IdBSP`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_REKLAMACIJA_POVRAT_SREDSTAVA1`
    FOREIGN KEY (`POVRAT_SREDSTAVA_IdPS`)
    REFERENCES `mybutikdb`.`POVRAT_SREDSTAVA` (`IdPS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_REKLAMACIJA_RADNIK1`
    FOREIGN KEY (`RADNIK_OSOBA_JMB`)
    REFERENCES `mybutikdb`.`RADNIK` (`OSOBA_JMB`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mybutikdb`.`REKLAMACIJA_has_ARTIKAL`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mybutikdb`.`REKLAMACIJA_has_ARTIKAL` (
  `REKLAMACIJA_IdReklamacije` INT NOT NULL,
  `REKLAMACIJA_RACUN_ZA_KUPCA_IdRacuna` INT NOT NULL,
  `ARTIKAL_SifraArtikla` VARCHAR(20) NOT NULL,
  `JedCijena` DECIMAL(6,2) NOT NULL,
  `ARTIKAL_Velicina` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`REKLAMACIJA_IdReklamacije`, `REKLAMACIJA_RACUN_ZA_KUPCA_IdRacuna`, `ARTIKAL_SifraArtikla`, `ARTIKAL_Velicina`),
  INDEX `fk_REKLAMACIJA_has_ARTIKAL_ARTIKAL1_idx` (`ARTIKAL_SifraArtikla` ASC, `ARTIKAL_Velicina` ASC) VISIBLE,
  INDEX `fk_REKLAMACIJA_has_ARTIKAL_REKLAMACIJA1_idx` (`REKLAMACIJA_IdReklamacije` ASC, `REKLAMACIJA_RACUN_ZA_KUPCA_IdRacuna` ASC) VISIBLE,
  CONSTRAINT `fk_REKLAMACIJA_has_ARTIKAL_REKLAMACIJA1`
    FOREIGN KEY (`REKLAMACIJA_IdReklamacije` , `REKLAMACIJA_RACUN_ZA_KUPCA_IdRacuna`)
    REFERENCES `mybutikdb`.`REKLAMACIJA` (`IdReklamacije` , `RACUN_ZA_KUPCA_IdRacuna`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_REKLAMACIJA_has_ARTIKAL_ARTIKAL1`
    FOREIGN KEY (`ARTIKAL_SifraArtikla` , `ARTIKAL_Velicina`)
    REFERENCES `mybutikdb`.`ARTIKAL` (`SifraArtikla` , `Velicina`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
