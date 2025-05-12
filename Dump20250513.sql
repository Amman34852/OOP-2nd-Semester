CREATE DATABASE  IF NOT EXISTS `finalprojectdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `finalprojectdb`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: finalprojectdb
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `complains`
--

DROP TABLE IF EXISTS `complains`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `complains` (
  `complainID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int DEFAULT NULL,
  `date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `description` varchar(200) NOT NULL,
  `problemSolution` varchar(100) DEFAULT NULL,
  `statusID` int DEFAULT '1',
  PRIMARY KEY (`complainID`),
  KEY `employeeID` (`employeeID`),
  KEY `statusID` (`statusID`),
  CONSTRAINT `complains_ibfk_1` FOREIGN KEY (`employeeID`) REFERENCES `employees` (`employeeID`),
  CONSTRAINT `complains_ibfk_2` FOREIGN KEY (`statusID`) REFERENCES `status` (`statusID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `complains`
--

LOCK TABLES `complains` WRITE;
/*!40000 ALTER TABLE `complains` DISABLE KEYS */;
INSERT INTO `complains` VALUES (1,1,'2025-04-17 12:40:06','hsvdeyue',NULL,1);
/*!40000 ALTER TABLE `complains` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customerID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `email` varchar(30) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL,
  `contact` varchar(11) NOT NULL,
  PRIMARY KEY (`customerID`),
  CONSTRAINT `customer_chk_1` CHECK (regexp_like(`name`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `customer_chk_2` CHECK (((`email` like _utf8mb4'%@%') and (`email` like _utf8mb4'%.%'))),
  CONSTRAINT `customer_chk_3` CHECK (((char_length(`password`) >= 8) and regexp_like(`password`,_utf8mb4'[0-9]') and regexp_like(`password`,_utf8mb4'[!@#$%^&*()]'))),
  CONSTRAINT `customer_chk_4` CHECK (regexp_like(`contact`,_utf8mb4'^[0-9]{11}$'))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'hwdgefeiu','yg@df.rfr','sbnduwei%544','09876543213');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerorders`
--

DROP TABLE IF EXISTS `customerorders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerorders` (
  `orderID` int NOT NULL AUTO_INCREMENT,
  `customerID` int DEFAULT NULL,
  `productID` int DEFAULT NULL,
  `quantity` int NOT NULL,
  `shippingInfo` varchar(30) DEFAULT NULL,
  `paymentID` int DEFAULT '8',
  `deliveryStatusID` int DEFAULT NULL,
  PRIMARY KEY (`orderID`),
  KEY `paymentID` (`paymentID`),
  KEY `deliveryStatusID` (`deliveryStatusID`),
  KEY `customerorders_ibfk_3` (`productID`),
  CONSTRAINT `customerorders_ibfk_1` FOREIGN KEY (`paymentID`) REFERENCES `status` (`statusID`),
  CONSTRAINT `customerorders_ibfk_2` FOREIGN KEY (`deliveryStatusID`) REFERENCES `status` (`statusID`),
  CONSTRAINT `customerorders_ibfk_3` FOREIGN KEY (`productID`) REFERENCES `products` (`productID`),
  CONSTRAINT `customerorders_chk_1` CHECK ((`quantity` > 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerorders`
--

LOCK TABLES `customerorders` WRITE;
/*!40000 ALTER TABLE `customerorders` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerorders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employees`
--

DROP TABLE IF EXISTS `employees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employees` (
  `employeeID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `contact` varchar(11) NOT NULL,
  `performanceID` int DEFAULT '1',
  `roleID` int DEFAULT NULL,
  PRIMARY KEY (`employeeID`),
  KEY `performanceID` (`performanceID`),
  KEY `roleID` (`roleID`),
  CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`performanceID`) REFERENCES `performance` (`performanceID`),
  CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`roleID`) REFERENCES `roles` (`roleID`),
  CONSTRAINT `employees_chk_1` CHECK (regexp_like(`name`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `employees_chk_2` CHECK (((`email` like _utf8mb4'%@%') and (`email` like _utf8mb4'%.%'))),
  CONSTRAINT `employees_chk_3` CHECK (((char_length(`password`) >= 8) and regexp_like(`password`,_utf8mb4'[0-9]') and regexp_like(`password`,_utf8mb4'[!@#$%^&*()]'))),
  CONSTRAINT `employees_chk_4` CHECK (regexp_like(`contact`,_utf8mb4'^[0-9]{11}$'))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employees`
--

LOCK TABLES `employees` WRITE;
/*!40000 ALTER TABLE `employees` DISABLE KEYS */;
INSERT INTO `employees` VALUES (1,'ahgsvue','dbvsrriew@g5.com','afcxysdfwiyet%243','09876543212',1,1);
/*!40000 ALTER TABLE `employees` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `finance`
--

DROP TABLE IF EXISTS `finance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `finance` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `transactionType` int DEFAULT NULL,
  `statusID` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `transactionType` (`transactionType`),
  KEY `statusID` (`statusID`),
  CONSTRAINT `finance_ibfk_1` FOREIGN KEY (`transactionType`) REFERENCES `transactionstype` (`transactionID`),
  CONSTRAINT `finance_ibfk_2` FOREIGN KEY (`statusID`) REFERENCES `status` (`statusID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `finance`
--

LOCK TABLES `finance` WRITE;
/*!40000 ALTER TABLE `finance` DISABLE KEYS */;
/*!40000 ALTER TABLE `finance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderrawmaterial`
--

DROP TABLE IF EXISTS `orderrawmaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderrawmaterial` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `RawMaterialID` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `statusID` int DEFAULT '1',
  PRIMARY KEY (`ID`),
  KEY `RawMaterialID` (`RawMaterialID`),
  KEY `statusID` (`statusID`),
  CONSTRAINT `orderrawmaterial_ibfk_1` FOREIGN KEY (`RawMaterialID`) REFERENCES `rawmaterial` (`ID`),
  CONSTRAINT `orderrawmaterial_ibfk_2` FOREIGN KEY (`statusID`) REFERENCES `status` (`statusID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderrawmaterial`
--

LOCK TABLES `orderrawmaterial` WRITE;
/*!40000 ALTER TABLE `orderrawmaterial` DISABLE KEYS */;
/*!40000 ALTER TABLE `orderrawmaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `performance`
--

DROP TABLE IF EXISTS `performance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `performance` (
  `performanceID` int NOT NULL AUTO_INCREMENT,
  `rating` int DEFAULT NULL,
  PRIMARY KEY (`performanceID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `performance`
--

LOCK TABLES `performance` WRITE;
/*!40000 ALTER TABLE `performance` DISABLE KEYS */;
INSERT INTO `performance` VALUES (1,1),(2,2),(3,3),(4,4),(5,5);
/*!40000 ALTER TABLE `performance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `productID` int NOT NULL AUTO_INCREMENT,
  `accessoryName` varchar(30) NOT NULL,
  `color` varchar(30) NOT NULL,
  `quantity` int NOT NULL,
  `quality` varchar(30) NOT NULL,
  `price` int NOT NULL,
  `biketype` varchar(30) NOT NULL,
  PRIMARY KEY (`productID`),
  CONSTRAINT `products_chk_1` CHECK (regexp_like(`accessoryName`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `products_chk_2` CHECK (regexp_like(`color`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `products_chk_3` CHECK (regexp_like(`quantity`,_utf8mb4'[0-9]')),
  CONSTRAINT `products_chk_4` CHECK (regexp_like(`quality`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `products_chk_5` CHECK (regexp_like(`price`,_utf8mb4'[0-9]'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rawmaterial`
--

DROP TABLE IF EXISTS `rawmaterial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rawmaterial` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `price` int DEFAULT NULL,
  PRIMARY KEY (`ID`),
  CONSTRAINT `rawmaterial_chk_1` CHECK (regexp_like(`name`,_utf8mb4'^[A-Za-z]+$')),
  CONSTRAINT `rawmaterial_chk_2` CHECK (regexp_like(`quantity`,_utf8mb4'[0-9]')),
  CONSTRAINT `rawmaterial_chk_3` CHECK (regexp_like(`price`,_utf8mb4'[0-9]'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rawmaterial`
--

LOCK TABLES `rawmaterial` WRITE;
/*!40000 ALTER TABLE `rawmaterial` DISABLE KEYS */;
/*!40000 ALTER TABLE `rawmaterial` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requests`
--

DROP TABLE IF EXISTS `requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requests` (
  `requestID` int NOT NULL AUTO_INCREMENT,
  `employeeID` int DEFAULT NULL,
  `description` varchar(30) DEFAULT NULL,
  `statusID` int DEFAULT NULL,
  PRIMARY KEY (`requestID`),
  KEY `employeeID` (`employeeID`),
  KEY `statusID` (`statusID`),
  CONSTRAINT `requests_ibfk_1` FOREIGN KEY (`employeeID`) REFERENCES `employees` (`employeeID`),
  CONSTRAINT `requests_ibfk_2` FOREIGN KEY (`statusID`) REFERENCES `status` (`statusID`),
  CONSTRAINT `requests_chk_1` CHECK (regexp_like(`description`,_utf8mb4'^[A-Za-z]+$'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requests`
--

LOCK TABLES `requests` WRITE;
/*!40000 ALTER TABLE `requests` DISABLE KEYS */;
/*!40000 ALTER TABLE `requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reviews`
--

DROP TABLE IF EXISTS `reviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reviews` (
  `reviewID` int NOT NULL AUTO_INCREMENT,
  `orderID` int DEFAULT NULL,
  `customerID` int DEFAULT NULL,
  `performanceID` int DEFAULT NULL,
  `comment` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`reviewID`),
  KEY `orderID` (`orderID`),
  KEY `customerID` (`customerID`),
  KEY `performanceID` (`performanceID`),
  CONSTRAINT `reviews_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `customerorders` (`orderID`),
  CONSTRAINT `reviews_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  CONSTRAINT `reviews_ibfk_3` FOREIGN KEY (`performanceID`) REFERENCES `performance` (`performanceID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reviews`
--

LOCK TABLES `reviews` WRITE;
/*!40000 ALTER TABLE `reviews` DISABLE KEYS */;
/*!40000 ALTER TABLE `reviews` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `roleID` int NOT NULL AUTO_INCREMENT,
  `role` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`roleID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'shopkeeper'),(2,'supervisor'),(3,'Manager'),(4,'HR'),(5,'Worker');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scrap`
--

DROP TABLE IF EXISTS `scrap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `scrap` (
  `scrapID` int NOT NULL AUTO_INCREMENT,
  `weight` int DEFAULT NULL,
  `statusID` int DEFAULT NULL,
  `price` int DEFAULT NULL,
  PRIMARY KEY (`scrapID`),
  KEY `statusID` (`statusID`),
  CONSTRAINT `scrap_ibfk_1` FOREIGN KEY (`statusID`) REFERENCES `status` (`statusID`),
  CONSTRAINT `scrap_chk_1` CHECK (regexp_like(`weight`,_utf8mb4'[0-9]')),
  CONSTRAINT `scrap_chk_2` CHECK (regexp_like(`price`,_utf8mb4'[0-9]'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scrap`
--

LOCK TABLES `scrap` WRITE;
/*!40000 ALTER TABLE `scrap` DISABLE KEYS */;
/*!40000 ALTER TABLE `scrap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `status` (
  `statusID` int NOT NULL AUTO_INCREMENT,
  `status` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`statusID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `status`
--

LOCK TABLES `status` WRITE;
/*!40000 ALTER TABLE `status` DISABLE KEYS */;
INSERT INTO `status` VALUES (1,'pending'),(2,'Answered'),(3,'in progress'),(4,'Delivered'),(5,'Returned'),(6,'On the way'),(7,'paid '),(8,'UNpaid ');
/*!40000 ALTER TABLE `status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactionstype`
--

DROP TABLE IF EXISTS `transactionstype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactionstype` (
  `transactionID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`transactionID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactionstype`
--

LOCK TABLES `transactionstype` WRITE;
/*!40000 ALTER TABLE `transactionstype` DISABLE KEYS */;
INSERT INTO `transactionstype` VALUES (1,'rawmaterial'),(2,'product sale ');
/*!40000 ALTER TABLE `transactionstype` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-13  0:31:34
