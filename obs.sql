-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: obs
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bolum`
--

DROP TABLE IF EXISTS `bolum`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bolum` (
  `bolum_no` int NOT NULL AUTO_INCREMENT,
  `bolum_ad` varchar(255) NOT NULL,
  PRIMARY KEY (`bolum_no`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bolum`
--

LOCK TABLES `bolum` WRITE;
/*!40000 ALTER TABLE `bolum` DISABLE KEYS */;
INSERT INTO `bolum` VALUES (1,'Bilgisayar Programcılığı'),(2,'Bilgi Yönetimi'),(3,'Kontrol ve Otomasyon'),(4,'Turizm ve Otelcilik'),(6,'Aşçılık');
/*!40000 ALTER TABLE `bolum` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ders`
--

DROP TABLE IF EXISTS `ders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ders` (
  `ders_no` int NOT NULL AUTO_INCREMENT,
  `ders_ad` varchar(255) NOT NULL,
  `ogrt_no` varchar(255) NOT NULL,
  `sinif_no` varchar(255) NOT NULL,
  PRIMARY KEY (`ders_no`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ders`
--

LOCK TABLES `ders` WRITE;
/*!40000 ALTER TABLE `ders` DISABLE KEYS */;
INSERT INTO `ders` VALUES (10,'Görsel Programlama II','20','2'),(11,'İleri Web Programlama','23','2'),(12,'İçerik Yönetim Sistemi','23','2'),(13,'Nesne Tabanlo Programlama II','21','2'),(14,'Python Programlama','21','2'),(15,'Proje Uygulamaları','22','2'),(16,'Mobil Programlama','22','2');
/*!40000 ALTER TABLE `ders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kul_bilgi`
--

DROP TABLE IF EXISTS `kul_bilgi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kul_bilgi` (
  `kul_id` int NOT NULL AUTO_INCREMENT,
  `kul_tc` varchar(11) NOT NULL,
  `kul_sif` varchar(255) NOT NULL,
  `kul_gorev` varchar(255) NOT NULL,
  PRIMARY KEY (`kul_id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kul_bilgi`
--

LOCK TABLES `kul_bilgi` WRITE;
/*!40000 ALTER TABLE `kul_bilgi` DISABLE KEYS */;
INSERT INTO `kul_bilgi` VALUES (3,'admin','123','admin'),(20,'123123','123','öğretmen'),(26,'36397451514','123','öğrenci'),(42,'1231231','1231231','öğretmen'),(43,'1231232','1231232','öğretmen'),(44,'1231233','1231233','öğretmen'),(45,'1231234','1231234','öğretmen'),(46,'1231231231','1231231231','öğrenci'),(47,'1231231232','1231231232','öğrenci'),(48,'1231231233','1231231233','öğrenci'),(49,'1231231234','1231231234','öğrenci'),(50,'1231231235','1231231235','öğrenci'),(51,'1231231236','1231231236','öğrenci'),(52,'1231231237','1231231237','öğrenci'),(53,'1231231238','1231231238','öğrenci'),(54,'1231231239','1231231239','öğrenci'),(55,'1231231240','1231231240','öğrenci');
/*!40000 ALTER TABLE `kul_bilgi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `not_bilgi`
--

DROP TABLE IF EXISTS `not_bilgi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `not_bilgi` (
  `not_no` int NOT NULL AUTO_INCREMENT,
  `ogr_no` varchar(255) NOT NULL,
  `ders_no` varchar(255) NOT NULL,
  `not_not` varchar(255) NOT NULL,
  `not_tur` int DEFAULT NULL,
  PRIMARY KEY (`not_no`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `not_bilgi`
--

LOCK TABLES `not_bilgi` WRITE;
/*!40000 ALTER TABLE `not_bilgi` DISABLE KEYS */;
INSERT INTO `not_bilgi` VALUES (18,'13','10','100',0),(19,'13','10','100',1),(20,'13','10','100',2),(21,'28','11','100',0),(24,'13','15','75',0),(25,'13','15','75',1),(26,'13','15','100',2);
/*!40000 ALTER TABLE `not_bilgi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `not_t`
--

DROP TABLE IF EXISTS `not_t`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `not_t` (
  `not_no` int NOT NULL,
  `not_ad` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`not_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `not_t`
--

LOCK TABLES `not_t` WRITE;
/*!40000 ALTER TABLE `not_t` DISABLE KEYS */;
INSERT INTO `not_t` VALUES (0,'Vize'),(1,'Final'),(2,'Proje');
/*!40000 ALTER TABLE `not_t` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ogr_bilgi`
--

DROP TABLE IF EXISTS `ogr_bilgi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ogr_bilgi` (
  `ogr_no` int NOT NULL AUTO_INCREMENT,
  `ogr_tc` varchar(255) NOT NULL,
  `ogr_isim` varchar(255) NOT NULL,
  `ogr_soyisim` varchar(255) NOT NULL,
  `ogr_telefon` varchar(255) NOT NULL,
  `sinif_no` int DEFAULT NULL,
  PRIMARY KEY (`ogr_no`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ogr_bilgi`
--

LOCK TABLES `ogr_bilgi` WRITE;
/*!40000 ALTER TABLE `ogr_bilgi` DISABLE KEYS */;
INSERT INTO `ogr_bilgi` VALUES (13,'36397451514','Ümit','Can','05616111749',2),(28,'1231231231','Emre','Bişgün','05100000001',2),(29,'1231231232','Burak','Arıcı','05100000002',2),(30,'1231231233','Olcay','Berberoğlu','05100000003',2),(31,'1231231234','Umut','Karabacak','05100000004',2),(32,'1231231235','Yusuf','Güner','05100000005',2),(33,'1231231236','Muhammet Emre','Gül','05100000006',2),(34,'1231231237','Emirhan','Çalışkan','05100000007',2),(35,'1231231238','Kamil','Ercan','05100000008',2),(36,'1231231239','Umut','Gözen','05100000009',4),(37,'1231231240','Faruk','Saygılı','05100000010',1);
/*!40000 ALTER TABLE `ogr_bilgi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ogrt_bilgi`
--

DROP TABLE IF EXISTS `ogrt_bilgi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ogrt_bilgi` (
  `ogrt_no` int NOT NULL AUTO_INCREMENT,
  `ogrt_tc` varchar(255) NOT NULL,
  `ogrt_isim` varchar(255) NOT NULL,
  `ogrt_soyisim` varchar(255) NOT NULL,
  `ogrt_telefon` varchar(255) NOT NULL,
  PRIMARY KEY (`ogrt_no`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ogrt_bilgi`
--

LOCK TABLES `ogrt_bilgi` WRITE;
/*!40000 ALTER TABLE `ogrt_bilgi` DISABLE KEYS */;
INSERT INTO `ogrt_bilgi` VALUES (18,'123123','Bayram','İnesillioğlu','123123'),(20,'1231231','Sultan Mehtap','İzmirliAyan','05000000001'),(21,'1231232','Murat','Aslanyürek','05000000002'),(22,'1231233','Selçuk','Özkan','05000000003'),(23,'1231234','Emine','Tunçel','05000000004');
/*!40000 ALTER TABLE `ogrt_bilgi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sinif`
--

DROP TABLE IF EXISTS `sinif`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sinif` (
  `sinif_no` int NOT NULL AUTO_INCREMENT,
  `sinif_ad` varchar(255) NOT NULL,
  `bolum_no` varchar(255) NOT NULL,
  PRIMARY KEY (`sinif_no`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sinif`
--

LOCK TABLES `sinif` WRITE;
/*!40000 ALTER TABLE `sinif` DISABLE KEYS */;
INSERT INTO `sinif` VALUES (1,'Bilgisayar Programcılığı 1','1'),(2,'Bilgisayar Programcılığı 2','1'),(3,'Bilgi Yönetimi 1','2'),(4,'Bilgi Yönetimi 2','2'),(5,'Aşçılık 1','6');
/*!40000 ALTER TABLE `sinif` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-06 20:44:52
