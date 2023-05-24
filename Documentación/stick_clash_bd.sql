-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 24-05-2023 a las 03:16:49
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `stick_clash`
--
CREATE DATABASE IF NOT EXISTS `stick_clash` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `stick_clash`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `player_data`
--

CREATE TABLE IF NOT EXISTS `player_data` (
  `username` varchar(15) NOT NULL,
  `points` int(3) NOT NULL,
  `unlocks` int(2) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ranking`
--

CREATE TABLE IF NOT EXISTS `ranking` (
  `username` varchar(15) NOT NULL,
  `points` int(3) NOT NULL,
  `position` int(5) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `user_id` int(3) NOT NULL AUTO_INCREMENT,
  `role` varchar(10) NOT NULL DEFAULT 'player',
  `status` varchar(9) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT 'activated',
  `username` varchar(15) NOT NULL,
  `password` varchar(20) NOT NULL,
  `create_time` date NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `users`
--

INSERT INTO `users` (`user_id`, `role`, `status`, `username`, `password`, `create_time`) VALUES
(1, 'admin', 'activated', 'admin', 'admin123', '2023-05-01'),
(2, 'admin', 'activated', 'test', 'test123', '2023-05-01'),
(4, 'player', 'suspended', 'player1', '1234', '2023-05-22'),
(6, 'player', 'activated', 'player3', '1234', '2023-05-24'),
(8, 'player', 'activated', 'player4', '1234', '2023-05-24'),
(9, 'player', 'activated', 'player5', '1234', '2023-05-24');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
