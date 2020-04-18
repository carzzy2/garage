/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50726
Source Host           : localhost:3306
Source Database       : garage1

Target Server Type    : MYSQL
Target Server Version : 50726
File Encoding         : 65001

Date: 2020-04-19 00:22:28
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
INSERT INTO `users` VALUES ('63722579876780', 'asdasdasd', 'asdasd', 'asdasdasd asdasd', 'user', '123123', 'qqqq', 'qqqq', 'ชาย');
