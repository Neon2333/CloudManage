/*
 Navicat Premium Data Transfer

 Source Server         : learning
 Source Server Type    : MySQL
 Source Server Version : 50726
 Source Host           : localhost:3306
 Source Schema         : cloud_manage

 Target Server Type    : MySQL
 Target Server Version : 50726
 File Encoding         : 65001

 Date: 13/12/2021 17:00:25
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for device_info_machine
-- ----------------------------
DROP TABLE IF EXISTS `device_info_machine`;
CREATE TABLE `device_info_machine`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `DeviceNO` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `MachineNO` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LocationX` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LocationY` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of device_info_machine
-- ----------------------------
INSERT INTO `device_info_machine` VALUES (1, '101', '101', '550', '554');
INSERT INTO `device_info_machine` VALUES (2, '101', '105', '550', '770');
INSERT INTO `device_info_machine` VALUES (3, '101', '103', '1198', '554');

SET FOREIGN_KEY_CHECKS = 1;
