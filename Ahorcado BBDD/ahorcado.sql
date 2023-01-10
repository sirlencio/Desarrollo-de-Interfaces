-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.31 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para ahorcado
DROP DATABASE IF EXISTS `ahorcado`;
CREATE DATABASE IF NOT EXISTS `ahorcado` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ahorcado`;

-- Volcando estructura para tabla ahorcado.biblioteca
DROP TABLE IF EXISTS `biblioteca`;
CREATE TABLE IF NOT EXISTS `biblioteca` (
  `categoria` varchar(50) DEFAULT NULL,
  `palabra` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ahorcado.biblioteca: ~4 rows (aproximadamente)
DELETE FROM `biblioteca`;
INSERT INTO `biblioteca` (`categoria`, `palabra`) VALUES
	('animales', 'perro'),
	('animales', 'gato'),
	('animales', 'loro'),
	('colores', 'rojo');

-- Volcando estructura para tabla ahorcado.puntuaciones
DROP TABLE IF EXISTS `puntuaciones`;
CREATE TABLE IF NOT EXISTS `puntuaciones` (
  `id_user` varchar(50) NOT NULL DEFAULT '',
  `categoria` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `nrondas` int NOT NULL,
  `puntuacion` int NOT NULL DEFAULT '0',
  `fecha` varchar(50) NOT NULL,
  KEY `FK` (`id_user`),
  CONSTRAINT `FK` FOREIGN KEY (`id_user`) REFERENCES `usuarios` (`nombre`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ahorcado.puntuaciones: ~0 rows (aproximadamente)
DELETE FROM `puntuaciones`;

-- Volcando estructura para tabla ahorcado.usuarios
DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `nombre` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8_general_ci NOT NULL,
  `pwd` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `super` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`nombre`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8_general_ci;

-- Volcando datos para la tabla ahorcado.usuarios: ~2 rows (aproximadamente)
DELETE FROM `usuarios`;
INSERT INTO `usuarios` (`nombre`, `pwd`, `super`) VALUES
	('admin', 'admin', 1),
	('carlos', 'admin', 0);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
