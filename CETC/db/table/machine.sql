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

 Date: 13/12/2021 17:01:14
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for machine
-- ----------------------------
DROP TABLE IF EXISTS `machine`;
CREATE TABLE `machine`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `MachineNO` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `MachineName` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 16 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of machine
-- ----------------------------
INSERT INTO `machine` VALUES (1, '001', 'ZJ17');
INSERT INTO `machine` VALUES (2, '002', 'ZJ19');
INSERT INTO `machine` VALUES (3, '003', 'ZJ112');
INSERT INTO `machine` VALUES (4, '004', 'ZJ116');
INSERT INTO `machine` VALUES (5, '005', 'ZJ118');
INSERT INTO `machine` VALUES (6, '006', 'ZJ119');
INSERT INTO `machine` VALUES (7, '101', 'ZB25');
INSERT INTO `machine` VALUES (8, '102', 'ZB28');
INSERT INTO `machine` VALUES (9, '103', 'ZB45');
INSERT INTO `machine` VALUES (10, '104', 'ZB47');
INSERT INTO `machine` VALUES (11, '105', 'ZB48');
INSERT INTO `machine` VALUES (12, '106', 'ZB415');
INSERT INTO `machine` VALUES (13, '107', 'ZB416');
INSERT INTO `machine` VALUES (14, '108', 'ZB417');
INSERT INTO `machine` VALUES (15, '109', 'ZB418');

SET FOREIGN_KEY_CHECKS = 1;
