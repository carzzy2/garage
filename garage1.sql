/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50726
Source Host           : localhost:3306
Source Database       : garage1

Target Server Type    : MYSQL
Target Server Version : 50726
File Encoding         : 65001

Date: 2020-04-26 22:19:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for customers
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `cus_id` bigint(20) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `surname` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `fullname` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `tel` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `address` text COLLATE utf8_unicode_ci,
  PRIMARY KEY (`cus_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of customers
-- ----------------------------
INSERT INTO `customers` VALUES ('63722731697322', 'asdas', 'asdas', 'asdas asdas', 'asda', 'asdasd');
INSERT INTO `customers` VALUES ('63722731804616', 'mm,,m,', 'hjhj', 'mm,,m, hjhj', 'sdfsdf', 'sdff');
INSERT INTO `customers` VALUES ('63722731817948', 'dsdfsdfsdf', 'sdfsdf', 'dsdfsdfsdf sdfsdf', 'sdfs', 'sdfsdf');
INSERT INTO `customers` VALUES ('63722731858519', 'aaaa', 'aaa', 'aaaa aaa', 'aa', 'aaa');
INSERT INTO `customers` VALUES ('63722731921447', 'uuuu', 'uuuu', 'uuuu uuuu', 'uu', 'uuu');

-- ----------------------------
-- Table structure for get_spares
-- ----------------------------
DROP TABLE IF EXISTS `get_spares`;
CREATE TABLE `get_spares` (
  `get_id` bigint(20) NOT NULL,
  `get_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`get_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of get_spares
-- ----------------------------
INSERT INTO `get_spares` VALUES ('63723439421425', '2020-04-25 19:23:41', '63723192679341');
INSERT INTO `get_spares` VALUES ('63723439452946', '2020-04-25 19:24:12', '63723191729167');
INSERT INTO `get_spares` VALUES ('63723439464332', '2020-04-25 19:24:24', '63723352298441');

-- ----------------------------
-- Table structure for pay
-- ----------------------------
DROP TABLE IF EXISTS `pay`;
CREATE TABLE `pay` (
  `pay_id` bigint(20) NOT NULL,
  `pay_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `price` int(10) DEFAULT NULL,
  PRIMARY KEY (`pay_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of pay
-- ----------------------------
INSERT INTO `pay` VALUES ('63723509738176', '2020-04-26 14:55:38', '63723192679341', '8000');

-- ----------------------------
-- Table structure for quotation
-- ----------------------------
DROP TABLE IF EXISTS `quotation`;
CREATE TABLE `quotation` (
  `quo_id` bigint(20) NOT NULL,
  `quo_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `price` int(10) DEFAULT NULL,
  PRIMARY KEY (`quo_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of quotation
-- ----------------------------
INSERT INTO `quotation` VALUES ('63723358497899', '2020-04-24 20:54:57', '63723192679341', '8000');
INSERT INTO `quotation` VALUES ('63723361621695', '2020-04-24 21:47:01', '63723192679341', '8000');
INSERT INTO `quotation` VALUES ('63723361754250', '2020-04-24 21:49:14', '63723352298441', '2000');
INSERT INTO `quotation` VALUES ('63723525633049', '2020-04-26 19:20:33', '63723525505517', '2000');

-- ----------------------------
-- Table structure for repairs
-- ----------------------------
DROP TABLE IF EXISTS `repairs`;
CREATE TABLE `repairs` (
  `rep_id` bigint(20) NOT NULL,
  `rep_date` datetime DEFAULT NULL,
  `ver_id` bigint(20) DEFAULT NULL,
  `detail` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`rep_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of repairs
-- ----------------------------
INSERT INTO `repairs` VALUES ('63723449270392', '2020-04-25 22:07:50', '63723352298441', 'fgfdgdfg');
INSERT INTO `repairs` VALUES ('63723449330655', '2020-04-25 22:08:50', '63723192679341', 'dasdfsadf');

-- ----------------------------
-- Table structure for spares
-- ----------------------------
DROP TABLE IF EXISTS `spares`;
CREATE TABLE `spares` (
  `spares_id` bigint(20) NOT NULL,
  `spares_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_qty` int(10) NOT NULL,
  `spares_unit_price` double(10,2) NOT NULL,
  `spares_unit` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `spares_cost_price` double(10,2) NOT NULL,
  `spares_detail` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of spares
-- ----------------------------
INSERT INTO `spares` VALUES ('63722923210711', 'มอเตอร์', '9', '8000.00', 'ชุด', '4000.00', 'แม็กซิส');
INSERT INTO `spares` VALUES ('63722923232866', 'แบตเตอรี่', '19', '2000.00', 'ลูก', '1000.00', 'FB');

-- ----------------------------
-- Table structure for tb_customer
-- ----------------------------
DROP TABLE IF EXISTS `tb_customer`;
CREATE TABLE `tb_customer` (
  `cus_id` bigint(20) NOT NULL,
  `cus_name` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `cus_tel` varchar(10) COLLATE utf8_unicode_ci NOT NULL,
  `cus_email` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `cus_address` text COLLATE utf8_unicode_ci NOT NULL,
  `cus_idcard` varchar(13) COLLATE utf8_unicode_ci NOT NULL,
  `car_symptoms` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of tb_customer
-- ----------------------------
INSERT INTO `tb_customer` VALUES ('63722934136749', 'bank', '0845353332', 'bank@gmail.com', 'ขอนแก่น', '1409901341307', 'สตาร์ทรถไม่ติด');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `user_id` bigint(20) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `surname` varchar(255) DEFAULT NULL,
  `fullname` varchar(255) DEFAULT NULL,
  `type` varchar(10) DEFAULT NULL,
  `tel` varchar(10) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sex` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('63722315730374', 'test', 'asdasd', 'test asdasd', 'user', '0844', 'testt', '', 'หญิง');
INSERT INTO `users` VALUES ('63722579876780', 'admin', 'admin', 'admin admin', 'ฝ่ายซ่อม', '123123', 'qqqq', 'qqqq', 'ชาย');

-- ----------------------------
-- Table structure for verify
-- ----------------------------
DROP TABLE IF EXISTS `verify`;
CREATE TABLE `verify` (
  `ver_id` bigint(20) NOT NULL,
  `ver_date` datetime DEFAULT NULL,
  `status` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `all_price` int(10) DEFAULT NULL,
  `veh_id` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `veh_type` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `veh_symtom` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cus_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`ver_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of verify
-- ----------------------------
INSERT INTO `verify` VALUES ('63723191729167', '2020-04-22 22:46:40', 'GETSPARES', '8000', 'asdasd', 'asda', 'sdasdasd', '63722731817948');
INSERT INTO `verify` VALUES ('63723192679341', '2020-04-22 22:51:26', 'PAY', '8000', 'asdas', 'asdas', 'asdasdasd', '63722731817948');
INSERT INTO `verify` VALUES ('63723352298441', '2020-04-24 19:11:50', 'REPAIR', '2000', 'หกดเกดเ', 'เกด้้', 'ดเกดเก', '63722731804616');
INSERT INTO `verify` VALUES ('63723525505517', '2020-04-26 19:18:32', 'QUOTATION', '2000', 'asd', 'asdas', 'dasdasd', '63722731817948');

-- ----------------------------
-- Table structure for verify_item
-- ----------------------------
DROP TABLE IF EXISTS `verify_item`;
CREATE TABLE `verify_item` (
  `ver_id` bigint(20) NOT NULL,
  `spares_id` bigint(20) NOT NULL,
  `price` int(10) DEFAULT NULL,
  `num` int(10) DEFAULT NULL,
  PRIMARY KEY (`ver_id`,`spares_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of verify_item
-- ----------------------------
INSERT INTO `verify_item` VALUES ('63723191729167', '63722923210711', '8000', '1');
INSERT INTO `verify_item` VALUES ('63723191698018', '63722923232866', '2000', '5');
INSERT INTO `verify_item` VALUES ('63723192554759', '63722923232866', '2000', '1');
INSERT INTO `verify_item` VALUES ('63723192651190', '63722923232866', '2000', '1');
INSERT INTO `verify_item` VALUES ('63723192679341', '63722923210711', '8000', '1');
INSERT INTO `verify_item` VALUES ('63723192790242', '63722923232866', '2000', '1');
INSERT INTO `verify_item` VALUES ('63723352298441', '63722923232866', '2000', '1');
INSERT INTO `verify_item` VALUES ('63723525488917', '63722923232866', '2000', '1');
INSERT INTO `verify_item` VALUES ('63723525488917', '63722923210711', '8000', '1');
INSERT INTO `verify_item` VALUES ('63723525505517', '63722923232866', '2000', '1');
