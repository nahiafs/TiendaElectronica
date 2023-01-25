-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-01-2023 a las 22:37:20
-- Versión del servidor: 10.4.25-MariaDB
-- Versión de PHP: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `tiendainformatica`
--
drop database if exists tiendainformatica;
create database tiendainformatica;
use tiendainformatica;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tcategoria`
--

CREATE TABLE `tcategoria` (
  `categoria` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `tcategoria`
--

INSERT INTO `tcategoria` (`categoria`, `Borrado`) VALUES
('Auriculares', 0),
('Mandos', 0),
('Monitor', 0),
('Ratón', 0),
('Teclado', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tfactura`
--

CREATE TABLE `tfactura` (
  `CodFactura` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `Cliente` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `FechaFactura` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` varchar(1) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tlineafactura`
--

CREATE TABLE `tlineafactura` (
  `CodFactura` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `Producto` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Cantidad` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Total` varchar(25) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tproducto`
--

CREATE TABLE `tproducto` (
  `CodProducto` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `Nombre` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Marca` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Categoria` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Precio` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Estado` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Imagen` text COLLATE utf8_unicode_ci NOT NULL,
  `Borrado` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `tproducto`
--

INSERT INTO `tproducto` (`CodProducto`, `Nombre`, `Marca`, `Categoria`, `Precio`, `Estado`, `Imagen`, `Borrado`) VALUES
('cod001', 'Logitech G535 Wireless', 'Logitech', 'Auriculares', '130', 'Nuevo', 'https://thumb.pccomponentes.com/w-530-530/articles/1031/10319718/1936-logitech-g535-wireless-auriculares-gaming-inalambricos-negros-para-pc-ps4-ps5.jpg', '0'),
('cod002', 'Xiaomi Redmi Buds 3 Lite', 'Xiaomi', 'Auriculares', '20', 'Segunda mano', 'https://img.pccomponentes.com/articles/1001/10011243/1210-xiaomi-redmi-buds-3-lite-auriculares-bluetooth-negros.jpg', '0'),
('cod003', 'Tempest GHS301 Barbarian', 'Tempest', 'Auriculares', '42', 'Nuevo', 'https://img.pccomponentes.com/articles/25/253099/tempest-ghs301-barbarian-auriculares-gaming-71-rgb-pc-ps4-45521ba6-a86a-476c-b41c-b745ed768f49.jpg', '0'),
('cod004', 'Nacon GC-200WL', 'Nacon', 'Mandos', '45', 'Nuevo', 'https://img.pccomponentes.com/articles/15/151043/1751-nacon-gc-200wl-mando-inalambrico-pc-negro-comprar.jpg', '0'),
('cod005', 'Logitech G29 Driving Force', 'Logitech', 'Mandos', '200', 'Segunda mano', 'https://img.pccomponentes.com/articles/8/84483/171-logitech-g29-driving-force-para-ps5-ps4-ps3-pc-comprar.jpg', '0'),
('cod006', 'LG Ultragear 27GN650-B 27\"', 'LG', 'Monitor', '230', 'Nuevo', 'https://img.pccomponentes.com/articles/40/401106/1368-lg-ultragear-27gn650-b-27-led-ips-fullhd-144hz-g-sync-compatible.jpg', '0'),
('cod007', 'MSI PRO MP341CQ 34\"', 'MSI', 'Monitor', '350', 'Nuevo', 'https://img.pccomponentes.com/articles/1026/10269976/1709-msi-pro-mp341cq-34-led-uwqhd-100hz-curva.jpg', '0'),
('cod008', 'Logitech G203', 'Logitech', 'Ratón', '23', 'Nuevo', 'https://img.pccomponentes.com/articles/28/287353/logitech-g203-lightsync-2nd-gen-raton-gaming-8000dpi-rgb-negro.jpg', '0'),
('cod009', 'Trust GXT 165', 'Trust', 'Ratón', '30', 'Nuevo', 'https://img.pccomponentes.com/articles/32/321942/1819-trust-gxt-165-celox-rgb-raton-gaming-10000dpi.jpg', '0'),
('cod010', 'Trust GXT 835', 'Trust', 'Teclado', '20', 'Nuevo', 'https://img.pccomponentes.com/articles/31/317164/1189-trust-gxt-835-azor-teclado-gaming-rgb.jpg', '0'),
('cod011', 'MSI Vigor GK71', 'MSI', 'Teclado', '100', 'Nuevo', 'https://img.pccomponentes.com/articles/1060/10608771/1698-msi-vigor-gk71-sonic-teclado-mecanico-gaming-rgb-switch-red-review.jpg', '0');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tusuario`
--

CREATE TABLE `tusuario` (
  `CodUsuario` varchar(6) COLLATE utf8_unicode_ci NOT NULL,
  `Nick` varchar(30) COLLATE utf8_unicode_ci NOT NULL,
  `Pass` varchar(15) COLLATE utf8_unicode_ci NOT NULL,
  `Rol` varchar(10) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=DYNAMIC;

--
-- Volcado de datos para la tabla `tusuario`
--

INSERT INTO `tusuario` (`CodUsuario`, `Nick`, `Pass`, `Rol`) VALUES
('cod001', 'admin', 'admin', 'admin');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tcategoria`
--
ALTER TABLE `tcategoria`
  ADD PRIMARY KEY (`categoria`),
  ADD UNIQUE KEY `categoria` (`categoria`);

--
-- Indices de la tabla `tfactura`
--
ALTER TABLE `tfactura`
  ADD PRIMARY KEY (`CodFactura`),
  ADD KEY `usuario` (`Cliente`);

--
-- Indices de la tabla `tlineafactura`
--
ALTER TABLE `tlineafactura`
  ADD PRIMARY KEY (`CodFactura`,`Producto`),
  ADD KEY `producto` (`Producto`);

--
-- Indices de la tabla `tproducto`
--
ALTER TABLE `tproducto`
  ADD PRIMARY KEY (`CodProducto`),
  ADD KEY `Categoria` (`Categoria`);

--
-- Indices de la tabla `tusuario`
--
ALTER TABLE `tusuario`
  ADD PRIMARY KEY (`CodUsuario`),
  ADD UNIQUE KEY `nick` (`Nick`),
  ADD KEY `nick_2` (`Nick`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
