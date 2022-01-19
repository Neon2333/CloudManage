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

 Date: 13/12/2021 17:00:59
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for faults_current
-- ----------------------------
DROP TABLE IF EXISTS `faults_current`;
CREATE TABLE `faults_current`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `LineNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeviceNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FaultNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FaultTime` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of faults_current
-- ----------------------------
INSERT INTO `faults_current` VALUES (2, '002', '005', '1', '2021-11-01 10:02:09');
INSERT INTO `faults_current` VALUES (3, '003', '007', '2', '2021-11-01 20:45:20');
INSERT INTO `faults_current` VALUES (4, '004', '010', '4', '2021-11-02 11:32:40');
INSERT INTO `faults_current` VALUES (5, '005', '013', '2', '2021-11-02 15:08:55');

SET FOREIGN_KEY_CHECKS = 1;
