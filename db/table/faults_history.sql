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

 Date: 13/12/2021 17:01:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for faults_history
-- ----------------------------
DROP TABLE IF EXISTS `faults_history`;
CREATE TABLE `faults_history`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `LineNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `DeviceNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FaultNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FaultTime` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of faults_history
-- ----------------------------
INSERT INTO `faults_history` VALUES (1, '002', '004', '2', '2021-09-01 08:30:35');
INSERT INTO `faults_history` VALUES (2, '002', '005', '1', '2021-09-02 10:02:09');
INSERT INTO `faults_history` VALUES (3, '002', '006', '3', '2021-09-03 20:45:20');
INSERT INTO `faults_history` VALUES (4, '002', '004', '2', '2021-09-04 15:08:49');
INSERT INTO `faults_history` VALUES (5, '002', '005', '1', '2021-09-05 11:32:56');
INSERT INTO `faults_history` VALUES (6, '009', '008', '4', '2021-09-06 13:34:12');
INSERT INTO `faults_history` VALUES (7, '010', '011', '2', '2021-09-07 12:17:14');
INSERT INTO `faults_history` VALUES (8, '011', '101', '1', '2021-09-08 17:14:36');
INSERT INTO `faults_history` VALUES (9, '004', '010', '4', '2021-11-02 11:32:56');
INSERT INTO `faults_history` VALUES (10, '005', '013', '2', '2021-11-02 15:08:49');
INSERT INTO `faults_history` VALUES (11, '001', '003', '1', '2021-11-01 08:30:35');
INSERT INTO `faults_history` VALUES (12, '002', '005', '1', '2021-11-01 10:02:09');
INSERT INTO `faults_history` VALUES (13, '004', '010', '4', '2021-11-02 11:32:40');
INSERT INTO `faults_history` VALUES (14, '005', '013', '2', '2021-11-02 15:08:55');
INSERT INTO `faults_history` VALUES (15, '002', '004', '3', '2021-11-02 15:08:56');
INSERT INTO `faults_history` VALUES (16, '003', '007', '2', '2021-11-01 20:45:20');
INSERT INTO `faults_history` VALUES (17, '001', '003', '1', '2021-11-22 08:30:22');
INSERT INTO `faults_history` VALUES (18, '001', '003', '1', '2021-11-14 08:30:22');
INSERT INTO `faults_history` VALUES (19, '001', '003', '1', '2021-11-15 08:30:22');
INSERT INTO `faults_history` VALUES (20, '001', '003', '1', '2021-11-16 08:30:22');
INSERT INTO `faults_history` VALUES (21, '001', '003', '1', '2021-11-15 20:30:22');
INSERT INTO `faults_history` VALUES (22, '002', '005', '1', '2021-11-01 10:02:09');

SET FOREIGN_KEY_CHECKS = 1;
