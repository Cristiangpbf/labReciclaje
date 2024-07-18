-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 17-07-2024 a las 20:50:38
-- Versión del servidor: 8.0.38
-- Versión de PHP: 8.1.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `laborato_labreciclaje`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `id` int NOT NULL,
  `nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `descripcion` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `estado` int NOT NULL,
  `color` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `icon` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `puntaje` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`id`, `nombre`, `descripcion`, `estado`, `color`, `icon`, `puntaje`) VALUES
(1, 'Papel', '', 1, '#FFEB3B', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/papel.png', 0),
(2, 'Cartón', '', 1, '#4CAF50', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/carton.png', 0),
(3, 'Tetrapack', '', 1, '#2196F3', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/tetrapak.png', 0),
(4, 'Botellas PET', '', 1, '#8BC34A', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/plastico.png', 0),
(5, 'Plástico', '', 1, '#9E9E9E', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/plastico.png', 0),
(6, 'Electrónicos', '', 1, '#FF5722', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/electronicos.png', 0),
(7, 'Radiografías', '', 1, '#F44336', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/xray.png', 0),
(8, 'Vidrio', '', 1, '#607D8B', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/vidrio.png', 0),
(9, 'Metales', '', 1, '#E0E0E0', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/metal.png', 0),
(10, 'Aceite usado', '', 1, '#795548', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/aceite.png', 0),
(11, 'CDs', '', 1, '#9C27B0', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/cds.png', 0),
(12, 'Orgánicos', '', 1, '#FFEB3B', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/icon/organico.png', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `centro`
--

CREATE TABLE `centro` (
  `id` int NOT NULL,
  `nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `direccion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `latitud` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `longitud` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `descripcion` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `imagen` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `estado` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `centro`
--

INSERT INTO `centro` (`id`, `nombre`, `direccion`, `latitud`, `longitud`, `descripcion`, `imagen`, `estado`) VALUES
(1, 'CEGAM', 'Eloy Alfaro OE7-71 Amancay y 4ta transversal, sector la Santiago (Sur).', '-0.2526567797490508', '-78.5412729806928', 'CEGAM \"Eloy Alfaro\"', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/centro/cegameloyalfaro.png', 1),
(2, 'CEGAM', 'La Delicia en el barrio la Cristianía 2, Eloy Alfaro y de los Aceitunos (Norte).', '-0.11416982840163852', '-78.4743045274341', 'CEGAM \"La Delicia\"', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/centro/cegamdelicia.png', 1),
(3, 'CEGAM', 'Manuela Sáenz en la avenida 24 de mayo, s/n y Pichincha (Centro).', '-0.22949635050413883', '-78.51158586267587', 'CEGAM \"Manuela Sáenz\"', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/centro/cegammanuelasaenz.png', 1),
(4, 'CEGAM', 'Tumbaco en la parroquia de Pifo, sector Chaupimolino, Pasaje los Eucaliptos.', '-0.2209031392700848', '-78.34038347954163', 'CEGAM \"Tumbaco\"', 'https://laboratoriodereciclaje.org/LabReciclajeWebService/centro/cegamtumbaco.png', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `id` int NOT NULL,
  `idUsuario` int NOT NULL,
  `nombres` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `apellidos` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `estado` int NOT NULL,
  `puntos` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cuenta`
--

INSERT INTO `cuenta` (`id`, `idUsuario`, `nombres`, `apellidos`, `email`, `estado`, `puntos`) VALUES
(1, 1, 'Admin', 'Admin', 'admin@gmail.com.ec', 1, 0),
(6, 12, 'Cristian Eduardo', 'Guamba Muñoz', 'cristiangpbf@gmail.com', 1, 0),
(7, 13, 'Gissela Anabel', 'Tipan Umatambo', 'gisselatipan8@gmail.com', 1, 0),
(8, 14, 'Ambar', 'Columba', 'ambar123@hotmail.com', 1, 0),
(9, 15, 'Orlando', 'Cando', 'ocando@gmail.com', 1, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `noticia`
--

CREATE TABLE `noticia` (
  `id` int NOT NULL,
  `titulo` varchar(255) COLLATE utf8mb3_unicode_ci NOT NULL,
  `descripcion` varchar(255) COLLATE utf8mb3_unicode_ci NOT NULL,
  `fecha` date NOT NULL,
  `estado` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;

--
-- Volcado de datos para la tabla `noticia`
--

INSERT INTO `noticia` (`id`, `titulo`, `descripcion`, `fecha`, `estado`) VALUES
(1, 'Reciclaje: Una responsabilidad de todos', 'Reciclar es una manera sencilla de proteger nuestro planeta. Cada pequeño esfuerzo cuenta.', '2024-07-14', 1),
(2, 'Beneficios del reciclaje', 'El reciclaje ayuda a reducir la contaminación, conserva los recursos naturales y ahorra energía.', '2024-07-13', 1),
(3, 'Recicla hoy para un mejor mañana', 'Cada material reciclado puede convertirse en algo nuevo. ¡Haz tu parte y recicla!', '2024-07-11', 1),
(4, 'Pequeñas acciones, grandes cambios', 'El reciclaje puede empezar en casa. Separa tus residuos y contribuye a un planeta más limpio.', '2024-07-09', 1),
(5, 'No lo arruines; los buenos planetas son difíciles de encontrar', 'Debemos proteger y preservar los recursos naturales, reducir la contaminación y actuar de manera sostenible para asegurar un futuro habitable para las próximas generaciones.', '2024-07-04', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `objeto`
--

CREATE TABLE `objeto` (
  `id` int NOT NULL,
  `idCategoria` int DEFAULT NULL,
  `nombre` varchar(255) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `objeto`
--

INSERT INTO `objeto` (`id`, `idCategoria`, `nombre`) VALUES
(1, 1, 'Revista'),
(71, 1, 'Periódico'),
(72, 1, 'Papel blanco'),
(73, 2, 'Cubetas de huevo'),
(74, 3, 'Tetrabrik'),
(75, 4, 'Botellas PET'),
(76, 5, 'Plásticos flexibles (fundas, bolsas de snacks)'),
(77, 5, 'Plásticos rígidos (como de shampoo, yogurt)'),
(78, 6, 'Electrónicos grandes o pequeños'),
(79, 6, 'Cables'),
(80, 6, 'Celulares'),
(81, 6, 'Tabletas'),
(82, 6, 'Computadoras'),
(83, 7, 'Placas de radiografías'),
(84, 8, 'Envases de vidrio'),
(85, 9, 'Latas'),
(86, 10, 'Aceite usado de cocina'),
(87, 5, 'Ecoladrillos'),
(88, 5, 'Eco botellas'),
(89, 5, 'Botellas de amor'),
(90, 11, 'CDs'),
(91, 12, 'Orgánicos de origen vegetal'),
(92, 12, 'Cáscaras de huevo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `id` int NOT NULL,
  `usuario` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `estado` int NOT NULL,
  `privilegio` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id`, `usuario`, `password`, `estado`, `privilegio`) VALUES
(1, 'admin', '21232f297a57a5a743894a0e4a801fc3', 1, 1),
(12, 'cristiangpbf', '5137502f23caa3c35ac27a8fb96073a7', 1, 1),
(13, 'Gissela Tipan', 'ddd66c7f31bbbb42978e8b692feb03a8', 1, 1),
(14, 'acolumba', 'e74831912fbf5236d5777abde418ac63', 1, 1),
(15, 'ocando', 'ee8b580755a0e232b5909ac7ee1fb065', 1, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `centro`
--
ALTER TABLE `centro`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idUsuario` (`idUsuario`);

--
-- Indices de la tabla `noticia`
--
ALTER TABLE `noticia`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `objeto`
--
ALTER TABLE `objeto`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idCategoria` (`idCategoria`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `centro`
--
ALTER TABLE `centro`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `noticia`
--
ALTER TABLE `noticia`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `objeto`
--
ALTER TABLE `objeto`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=93;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `cuenta_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`id`);

--
-- Filtros para la tabla `objeto`
--
ALTER TABLE `objeto`
  ADD CONSTRAINT `objeto_ibfk_1` FOREIGN KEY (`idCategoria`) REFERENCES `categoria` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
