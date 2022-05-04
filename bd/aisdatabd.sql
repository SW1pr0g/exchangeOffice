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
  `u_num` int(11) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `date_birth` date DEFAULT NULL,
  `seriesDoc` int(11) DEFAULT NULL,
  `numberDoc` int(11) DEFAULT NULL,
  PRIMARY KEY (`u_num`),
  UNIQUE KEY `idnew_table_UNIQUE` (`u_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (176141,'Харитонова','Жанна','Евсеевна','2005-12-24',6176,648955),(193630,'Киселева','Клавдия','Петровна','1995-05-06',8389,963078),(195264,'Хохлов','Ярослав','Серапионович','2001-09-02',5942,290558),(302868,'Ершова','Гелена','Игоревна','1997-07-14',7252,906370),(383873,'Кулакова','Симма','Артемовна','1996-07-12',7883,797062),(396226,'Абрамов','Алексей','Вадимович','2003-07-31',2514,583914),(443849,'Белов','Фёдор','Александрович','2003-09-15',1727,649849),(453737,'Воробьёв','Устин','Олегович','1993-04-02',1665,752408),(465662,'Морозов','Давид','Евсеевич','1997-07-24',2191,591113),(545407,'Беляков','Вячеслав','Германнович','1990-01-01',6055,265055),(549831,'Кудряшов','Евгений','Александрович','2003-02-11',4887,855122),(549842,'Козлов','Леонид','Дмитриевич','2000-01-01',3423,372426),(575240,'Бирюков','Евгений','Евгеньевич','2000-06-09',8618,587246),(621195,'Зиновьев','Владислав','Тимурович','2002-06-08',7623,488572),(636512,'Щербин','Артём','Федросович','1996-06-22',1567,214315),(699505,'Порядин','Алексей','Евгеньевич','2004-03-17',4125,213654),(748652,'Мельникова','Ангелина','Богдановна','2003-09-18',5560,702155),(765508,'Соболева','Харитина','Серапионовна','1993-11-11',4650,971154),(795628,'Волков','Вениамин','Фролович','1997-01-03',9605,858705),(802615,'Евгеньев','Александр','Леванович','1993-12-28',1438,813522),(815302,'Дмитриев','Гордей','Робертович','2004-07-30',4706,750909),(836583,'Бобылёв','Рубен','Максимович','2004-09-06',4126,285169),(838609,'Донченко','Иван','Андреевич','1992-06-11',6538,430164),(895128,'Ситникова','Дарьяна','Артемовна','2000-03-06',6729,962758),(940943,'Щукина','Варвара','Геннадиевна','1990-08-03',5114,439435),(954830,'Мыльников','Данила','Алексеевич','2003-05-05',8525,868595),(988926,'Кулагина','Юлия','Анатольевна','1991-07-11',7474,646359);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currency_values`
--

DROP TABLE IF EXISTS `currency_values`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currency_values` (
  `u_num` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `value` double DEFAULT NULL,
  PRIMARY KEY (`u_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currency_values`
--

LOCK TABLES `currency_values` WRITE;
/*!40000 ALTER TABLE `currency_values` DISABLE KEYS */;
INSERT INTO `currency_values` VALUES (392,'JPY',1508.6),(756,'CHF',623.569),(826,'GBP',1000),(840,'USD',2122.752),(978,'EUR',5140);
/*!40000 ALTER TABLE `currency_values` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `currencycourse`
--

DROP TABLE IF EXISTS `currencycourse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `currencycourse` (
  `u_num` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `summsale` double DEFAULT NULL,
  `summpurchase` double DEFAULT NULL,
  PRIMARY KEY (`u_num`),
  UNIQUE KEY `id_UNIQUE` (`u_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `currencycourse`
--

LOCK TABLES `currencycourse` WRITE;
/*!40000 ALTER TABLE `currencycourse` DISABLE KEYS */;
INSERT INTO `currencycourse` VALUES (392,'JPY',66.33,68.31),(756,'CHF',85.45,87.46),(826,'GBP',105.37,107.4),(840,'USD',79.35,79.84),(978,'EUR',88.43,90.47);
/*!40000 ALTER TABLE `currencycourse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operations`
--

DROP TABLE IF EXISTS `operations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operations` (
  `u_num` int(11) NOT NULL,
  `surname` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `patronymic` varchar(45) DEFAULT NULL,
  `type` varchar(9) DEFAULT NULL,
  `value` varchar(1) DEFAULT NULL,
  `quantity` double DEFAULT NULL,
  `summ` double DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`u_num`),
  UNIQUE KEY `id_UNIQUE` (`u_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operations`
--

LOCK TABLES `operations` WRITE;
/*!40000 ALTER TABLE `operations` DISABLE KEYS */;
INSERT INTO `operations` VALUES (864695,'Порядин','Алексей','Евгеньевич','Покупка','$',500,39920,'2022-05-03 18:16:18');
/*!40000 ALTER TABLE `operations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `otchets_quantity`
--

DROP TABLE IF EXISTS `otchets_quantity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `otchets_quantity` (
  `id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `otchets_quantity`
--

LOCK TABLES `otchets_quantity` WRITE;
/*!40000 ALTER TABLE `otchets_quantity` DISABLE KEYS */;
INSERT INTO `otchets_quantity` VALUES (1,23);
/*!40000 ALTER TABLE `otchets_quantity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `u_num` int(11) NOT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`u_num`),
  UNIQUE KEY `id_UNIQUE` (`u_num`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'administrator','admin','Минин С. В.','admin'),(2,'muhina2004','20040730','Мухина Е. Е.','admin'),(3,'dbdtop','ass','Кузьмин Д. А.','cashier'),(4,'ivan1','12345','Иванов И. И.','cashier');
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

-- Dump completed on 2022-05-04  7:51:24
