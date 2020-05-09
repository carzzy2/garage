-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 09, 2020 at 10:47 AM
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
  `cus_id` int(11) NOT NULL,
  `fullname` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `cus_tel` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `cus_email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `cus_address` text COLLATE utf8_unicode_ci NOT NULL,
  `cus_idcard` varchar(13) COLLATE utf8_unicode_ci NOT NULL,
  `veh_id` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `veh_type` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`cus_id`, `fullname`, `cus_tel`, `cus_email`, `cus_address`, `cus_idcard`, `veh_id`, `veh_type`) VALUES
(1, 'นางสาวสุธิมา สูงสนิท', '0921548752', 'cus1@gmail.com', '33/7 หมู่ 10 ต.ในเมือง อ.เมือง จ.ขอนแก่น 40000', '1125123665944', 'กข2158', 'Honda'),
(2, 'นายสรวิศ ข้อยุ่น', '0874441236', 'cus2@gmail.com', '125 ต.ในเมือง อ.เมือง จ.ขอนแก่น 40000', '2212541221112', 'ฟบ5697', 'Toyota'),
(3, 'นางสาวปนัดดา ทาสะอาด', '0923665544', 'cus3@gmail.com', '115/10 ต.ในเมือง อ.เมือง จ.ขอนแก่น 40000', '1154444777887', 'บล5411', 'ISUZU'),
(4, 'นายปิยวัฒน์ แสนศรี', '0874441112', 'cus4@gmail.com', '125 หมู่ 5 ต.ในเมือง อ.เมือง จ.ขอนแก่น 40000', '1234567896666', 'คฟ2543', 'HINO'),
(5, 'นางสาวรัชนีกร ไกรสุข', '0874112369', 'cus5@gmail.com', '332 หมู่ 7 ต.กระนวน อ.ซำสูง จ.ขอนแก่น 40170', '1159633333333', 'ลบ2584', 'Ford');

-- --------------------------------------------------------

--
-- Table structure for table `get_spares`
--

CREATE TABLE `get_spares` (
  `get_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `get_date` datetime DEFAULT NULL,
  `ver_id` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `get_spares`
--

INSERT INTO `get_spares` (`get_id`, `get_date`, `ver_id`) VALUES
('GET-000001', '2020-05-09 11:40:34', 'CHK-000001'),
('GET-000002', '2020-05-09 11:40:44', 'CHK-000002'),
('GET-000003', '2020-05-09 11:57:25', 'CHK-000003');

-- --------------------------------------------------------

--
-- Table structure for table `pay`
--

CREATE TABLE `pay` (
  `pay_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `pay_date` datetime DEFAULT NULL,
  `ver_id` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `price` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `pay`
--

INSERT INTO `pay` (`pay_id`, `pay_date`, `ver_id`, `price`) VALUES
('PAY-000001', '2020-05-09 11:50:11', 'CHK-000001', 2000);

-- --------------------------------------------------------

--
-- Table structure for table `quotation`
--

CREATE TABLE `quotation` (
  `quo_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `quo_date` datetime DEFAULT NULL,
  `ver_id` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `price` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `quotation`
--

INSERT INTO `quotation` (`quo_id`, `quo_date`, `ver_id`, `price`) VALUES
('QUO-000001', '2020-05-09 11:32:20', 'CHK-000001', 2000),
('QUO-000002', '2020-05-09 11:32:33', 'CHK-000002', 7000),
('QUO-000003', '2020-05-09 11:41:14', 'CHK-000003', 210),
('QUO-000004', '2020-05-09 11:57:13', 'CHK-000005', 5000);

-- --------------------------------------------------------

--
-- Table structure for table `repairs`
--

CREATE TABLE `repairs` (
  `rep_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `rep_date` datetime DEFAULT NULL,
  `ver_id` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `detail` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `repairs`
--

INSERT INTO `repairs` (`rep_id`, `rep_date`, `ver_id`, `detail`) VALUES
('REP-000001', '2020-05-09 11:46:21', 'CHK-000001', 'แบตเก่าเสื่อม ทำให้ต้องเปลี่ยนตัวใหม่'),
('REP-000002', '2020-05-09 11:47:06', 'CHK-000002', 'แบตเสื่อม ไดร์ชาร์ทพัง');

-- --------------------------------------------------------

--
-- Table structure for table `spares`
--

CREATE TABLE `spares` (
  `spares_id` int(11) NOT NULL,
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
(1, 'แบตเตอรี่', 6, 2000.00, 'กล่อง', 1000.00, '-'),
(2, 'ไดร์ชาร์ท', 9, 5000.00, 'อัน', 3500.00, '-'),
(3, 'ไดสตาร์ท', 10, 3000.00, 'อัน', 2500.00, '-'),
(4, 'คัทเอ๊าไฟตา', 10, 750.00, 'อัน', 500.00, '-'),
(5, 'แพงไดโอต', 10, 800.00, 'อัน', 500.00, '-'),
(6, 'พู่เลย์ไดร์ชาร์ท', 10, 1500.00, 'อัน', 800.00, '-'),
(7, 'ซองถ่าน', 10, 130.00, 'ซอง', 100.00, '-'),
(8, 'สายแพรแตร', 10, 500.00, 'เส้น', 350.00, '-'),
(9, 'สวิทซ์ยกเลี้ยว', 10, 130.00, 'อัน', 85.00, '-'),
(10, 'สายพาน', 10, 100.00, 'เส้น', 80.00, '-'),
(12, 'น้ำมันเครื่อง', 9, 150.00, 'ขวด', 80.00, '-'),
(13, 'ตัวกรอง', 9, 60.00, 'ชิ้น', 45.00, '-');

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
(1, 'อารี', 'แก้วภักดี', 'อารี แก้วภักดี', 'เจ้าของกิจการ', '0921383707', 'admin', '1234', 'หญิง'),
(2, 'สมชัย', 'ธรรมมะ', 'สมชัย ธรรมมะ', 'ฝ่ายซ่อม', '0804083596', 'user', '1234', 'ชาย');

-- --------------------------------------------------------

--
-- Table structure for table `verify`
--

CREATE TABLE `verify` (
  `ver_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `ver_date` datetime DEFAULT NULL,
  `status` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `all_price` int(10) DEFAULT NULL,
  `veh_symtom` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cus_id` bigint(20) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `verify`
--

INSERT INTO `verify` (`ver_id`, `ver_date`, `status`, `all_price`, `veh_symtom`, `cus_id`) VALUES
('CHK-000001', '2020-05-09 11:22:14', 'PAY', 2000, 'รถสตาร์ทติด ไฟหน้าปัดไม่ขึ้น', 1),
('CHK-000002', '2020-05-09 11:23:37', 'REPAIR', 7000, 'หน้าปัดรถ ไม่มีไฟแสดงสถานะเตือนต่างๆก่อนสตาร์ทรถ', 2),
('CHK-000003', '2020-05-09 11:25:09', 'GETSPARES', 210, 'เปลี่ยนน้ำมันเครื่อง', 3),
('CHK-000004', '2020-05-09 11:25:35', 'NEW', 210, 'เปลี่ยนน้ำมันเครื่อง', 1),
('CHK-000005', '2020-05-09 11:47:35', 'QUOTATION', 5000, 'เปลี่ยนแบต', 5);

-- --------------------------------------------------------

--
-- Table structure for table `verify_item`
--

CREATE TABLE `verify_item` (
  `ver_id` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `spares_id` int(11) NOT NULL,
  `price` int(10) DEFAULT NULL,
  `num` int(10) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `verify_item`
--

INSERT INTO `verify_item` (`ver_id`, `spares_id`, `price`, `num`) VALUES
('CHK-000001', 1, 2000, 1),
('CHK-000002', 1, 2000, 1),
('CHK-000002', 2, 5000, 1),
('CHK-000003', 12, 150, 1),
('CHK-000003', 13, 60, 1),
('CHK-000004', 12, 150, 1),
('CHK-000004', 13, 60, 1),
('CHK-000005', 1, 2000, 1),
('CHK-000005', 3, 3000, 1);

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

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `cus_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `spares`
--
ALTER TABLE `spares`
  MODIFY `spares_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2147483647;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
