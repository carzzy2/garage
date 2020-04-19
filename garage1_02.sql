-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 19, 2020 at 06:21 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `garage1`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_customer`
--

CREATE TABLE `tb_customer` (
  `cus_id` bigint(20) NOT NULL,
  `cus_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `cus_tel` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `cus_email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `cus_address` text COLLATE utf8_unicode_ci NOT NULL,
  `cus_idcard` varchar(13) COLLATE utf8_unicode_ci NOT NULL,
  `car_symptoms` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tb_customer`
--

INSERT INTO `tb_customer` (`cus_id`, `cus_name`, `cus_tel`, `cus_email`, `cus_address`, `cus_idcard`, `car_symptoms`) VALUES
(63722934136749, 'bank', '0845353332', 'bank@gmail.com', 'ขอนแก่น', '1409901341307', 'สตาร์ทรถไม่ติด');

-- --------------------------------------------------------

--
-- Table structure for table `tb_spares`
--

CREATE TABLE `tb_spares` (
  `spares_id` bigint(20) NOT NULL,
  `spares_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_qty` int(10) NOT NULL,
  `spares_unit_price` double(10,2) NOT NULL,
  `spares_unit` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_cost_price` double(10,2) NOT NULL,
  `spares_detail` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tb_spares`
--

INSERT INTO `tb_spares` (`spares_id`, `spares_name`, `spares_qty`, `spares_unit_price`, `spares_unit`, `spares_cost_price`, `spares_detail`) VALUES
(63722923210711, 'มอเตอร์', 10, 8000.00, 'ชุด', 4000.00, 'แม็กซิส'),
(63722923232866, 'แบตเตอรี่', 20, 2000.00, 'ลูก', 1000.00, 'FB');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` bigint(20) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `surname` varchar(255) DEFAULT NULL,
  `fullname` varchar(255) DEFAULT NULL,
  `type` varchar(20) DEFAULT NULL,
  `tel` varchar(10) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sex` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `name`, `surname`, `fullname`, `type`, `tel`, `username`, `password`, `sex`) VALUES
(63722892691970, 'บังอร', 'หลวงภักดี', 'บังอร หลวงภักดี', 'เจ้าของกิจการ', '0921383707', 'boss', '1234', 'หญิง'),
(63722899629848, 'พิรชัย', 'ชัยจินดา', 'พิรชัย ชัยจินดา', 'ฝ่ายซ่อม', '0874222222', 'user', '1234', 'ชาย');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_customer`
--
ALTER TABLE `tb_customer`
  ADD PRIMARY KEY (`cus_id`);

--
-- Indexes for table `tb_spares`
--
ALTER TABLE `tb_spares`
  ADD PRIMARY KEY (`spares_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
