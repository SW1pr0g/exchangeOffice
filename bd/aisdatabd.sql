-- MySQL dump 10.13  Distrib 5.7.12, for Win32 (AMD64)
--
-- Host: 127.0.0.1    Database: aisdatabd
-- ------------------------------------------------------
-- Server version	5.6.23-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `date_birth` date DEFAULT NULL,
  `seriesDoc` int(11) DEFAULT NULL,
  `numberDoc` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idnew_table_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'афафа','фафа','фафаф','2022-01-01',4567,123456);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currency_values`
--

DROP TABLE IF EXISTS `currency_values`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currency_values` (
  `id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `value` double DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currency_values`
--

LOCK TABLES `currency_values` WRITE;
/*!40000 ALTER TABLE `currency_values` DISABLE KEYS */;
INSERT INTO `currency_values` VALUES (1,'USD',1020.5),(2,'EUR',5000),(3,'GBP',789),(4,'CHF',623.569),(5,'JPY',1500.6);
/*!40000 ALTER TABLE `currency_values` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencycourse`
--

DROP TABLE IF EXISTS `currencycourse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currencycourse` (
  `id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `summsale` double DEFAULT NULL,
  `summpurchase` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currencycourse`
--

LOCK TABLES `currencycourse` WRITE;
/*!40000 ALTER TABLE `currencycourse` DISABLE KEYS */;
INSERT INTO `currencycourse` VALUES (1,'USD',77.12,79.81),(2,'EUR',88.47,90.47),(3,'GBP',105.37,107.4),(4,'CHF',85.45,87.46),(5,'JPY',66.32,68.31);
/*!40000 ALTER TABLE `currencycourse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchased`
--

DROP TABLE IF EXISTS `purchased`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchased` (
  `id` int(11) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `summ` double DEFAULT NULL,
  `currency` varchar(1) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchased`
--

LOCK TABLES `purchased` WRITE;
/*!40000 ALTER TABLE `purchased` DISABLE KEYS */;
/*!40000 ALTER TABLE `purchased` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `saled`
--

DROP TABLE IF EXISTS `saled`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `saled` (
  `id` int(11) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `summ` double DEFAULT NULL,
  `currency` varchar(1) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `saled`
--

LOCK TABLES `saled` WRITE;
/*!40000 ALTER TABLE `saled` DISABLE KEYS */;
/*!40000 ALTER TABLE `saled` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'cashier','cashier','Воробьева Е.С.','cashier'),(2,'administrator','admin','Минин С.В.','admin');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'aisdatabd'
--

--
-- Dumping routines for database 'aisdatabd'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-15  7:49:41
