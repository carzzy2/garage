-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 07, 2020 at 08:07 AM
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
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `cus_id` bigint(20) NOT NULL,
  `fullname` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `cus_tel` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `cus_email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `cus_address` text COLLATE utf8_unicode_ci NOT NULL,
  `cus_idcard` varchar(13) COLLATE utf8_unicode_ci NOT NULL,
  `car_symptoms` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`cus_id`, `fullname`, `cus_tel`, `cus_email`, `cus_address`, `cus_idcard`, `car_symptoms`) VALUES
(63724380058295, 'อานนท์ เอกตาแสง', '0875452136', 'anan@gmail.com', 'ขอนแก่น', '1125457854215', 'สตาร์ทไม่ติด'),
(63724453058391, 'นันทิดา ศรีจำปา', '0871242211', 'user@gmail.com', '125/10 ต.ในเมือง อ.เมือง จ.ขอนแก่น', '2142136548542', 'เปลี่ยนน้ำมันเครื่อง');

-- --------------------------------------------------------

--
-- Table structure for table `get_spares`
--

CREATE TABLE `get_spares` (
  `get_id` bigint(20) NOT NULL,
  `get_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `get_spares`
--

INSERT INTO `get_spares` (`get_id`, `get_date`, `ver_id`) VALUES
(63724453350030, '2020-05-07 13:02:30', 63724453154029);

-- --------------------------------------------------------

--
-- Table structure for table `pay`
--

CREATE TABLE `pay` (
  `pay_id` bigint(20) NOT NULL,
  `pay_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `price` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `pay`
--

INSERT INTO `pay` (`pay_id`, `pay_date`, `ver_id`, `price`) VALUES
(63724453489748, '2020-05-07 13:04:49', 63724453154029, 500);

-- --------------------------------------------------------

--
-- Table structure for table `quotation`
--

CREATE TABLE `quotation` (
  `quo_id` bigint(20) NOT NULL,
  `quo_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `price` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `quotation`
--

INSERT INTO `quotation` (`quo_id`, `quo_date`, `ver_id`, `price`) VALUES
(63724453289959, '2020-05-07 13:01:29', 63724453154029, 500);

-- --------------------------------------------------------

--
-- Table structure for table `repairs`
--

CREATE TABLE `repairs` (
  `rep_id` bigint(20) NOT NULL,
  `rep_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `detail` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `repairs`
--

INSERT INTO `repairs` (`rep_id`, `rep_date`, `ver_id`, `detail`) VALUES
(63724453468490, '2020-05-07 13:04:28', 63724453154029, 'เปลี่ยนน้ำมันเครื่องให้ลูกค้าเรียบร้อย เปลี่ยนน้ำมันเครื่องอีกครั้งเมื่อเข็มไมล์ครบ 310000 กิโลเมตร');

-- --------------------------------------------------------

--
-- Table structure for table `spares`
--

CREATE TABLE `spares` (
  `spares_id` bigint(20) NOT NULL,
  `spares_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_qty` int(10) NOT NULL,
  `spares_unit_price` double(10,2) NOT NULL,
  `spares_unit` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_cost_price` double(10,2) NOT NULL,
  `spares_detail` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `spares`
--

INSERT INTO `spares` (`spares_id`, `spares_name`, `spares_qty`, `spares_unit_price`, `spares_unit`, `spares_cost_price`, `spares_detail`) VALUES
(63724379925458, 'แบตเตอรี่', 9, 800.00, 'อัน', 350.00, '-'),
(63724379949688, 'ไดร์ชาร์ท', 8, 12000.00, 'อัน', 8000.00, '-'),
(63724409786861, 'ท่อ', 2, 250.00, 'อัน', 100.00, '-'),
(63724452881326, 'ไส้กรองน้ำมันเครื่อง', 4, 200.00, 'อัน', 150.00, 'Oil Filter'),
(63724453115216, 'น้ำมันเครื่องใหม่', 9, 300.00, 'ขวด', 250.00, '-');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` bigint(20) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `surname` varchar(255) DEFAULT NULL,
  `fullname` varchar(255) DEFAULT NULL,
  `type` varchar(100) DEFAULT NULL,
  `tel` varchar(10) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sex` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `name`, `surname`, `fullname`, `type`, `tel`, `username`, `password`, `sex`) VALUES
(63722315730374, 'อารี', 'แก้วภักดี', 'อารี แก้วภักดี', 'เจ้าของกิจการ', '0921383707', 'admin', '1234', 'หญิง'),
(63722579876780, 'สมชัย', 'ธรรมมะ', 'สมชัย ธรรมมะ', 'ฝ่ายซ่อม', '0804083596', 'user', '1234', 'ชาย');

-- --------------------------------------------------------

--
-- Table structure for table `verify`
--

CREATE TABLE `verify` (
  `ver_id` bigint(20) NOT NULL,
  `ver_date` datetime DEFAULT NULL,
  `status` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `all_price` int(10) DEFAULT NULL,
  `veh_id` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `veh_type` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `veh_symtom` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cus_id` bigint(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `verify`
--

INSERT INTO `verify` (`ver_id`, `ver_date`, `status`, `all_price`, `veh_id`, `veh_type`, `veh_symtom`, `cus_id`) VALUES
(63724453154029, '2020-05-07 13:00:21', 'PAY', 500, 'กข8742', 'โตโยต้า', 'เปลี่ยนน้ำมันเครื่อง', 63724453058391);

-- --------------------------------------------------------

--
-- Table structure for table `verify_item`
--

CREATE TABLE `verify_item` (
  `ver_id` bigint(20) NOT NULL,
  `spares_id` bigint(20) NOT NULL,
  `price` int(10) DEFAULT NULL,
  `num` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `verify_item`
--

INSERT INTO `verify_item` (`ver_id`, `spares_id`, `price`, `num`) VALUES
(63724453154029, 63724452881326, 200, 1),
(63724453154029, 63724453115216, 300, 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`cus_id`);

--
-- Indexes for table `get_spares`
--
ALTER TABLE `get_spares`
  ADD PRIMARY KEY (`get_id`);

--
-- Indexes for table `pay`
--
ALTER TABLE `pay`
  ADD PRIMARY KEY (`pay_id`);

--
-- Indexes for table `quotation`
--
ALTER TABLE `quotation`
  ADD PRIMARY KEY (`quo_id`);

--
-- Indexes for table `repairs`
--
ALTER TABLE `repairs`
  ADD PRIMARY KEY (`rep_id`);

--
-- Indexes for table `spares`
--
ALTER TABLE `spares`
  ADD PRIMARY KEY (`spares_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `verify`
--
ALTER TABLE `verify`
  ADD PRIMARY KEY (`ver_id`);

--
-- Indexes for table `verify_item`
--
ALTER TABLE `verify_item`
  ADD PRIMARY KEY (`ver_id`,`spares_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
