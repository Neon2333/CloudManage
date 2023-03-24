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

 Date: 13/12/2021 17:01:20
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for productionline
-- ----------------------------
DROP TABLE IF EXISTS `productionline`;
CREATE TABLE `productionline`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `LineNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LineName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`NO`) USING BTREE,
  UNIQUE INDEX `NO`(`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 29 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of productionline
-- ----------------------------
INSERT INTO `productionline` VALUES (2, '002', '2号车');
INSERT INTO `productionline` VALUES (3, '003', '3号车');
INSERT INTO `productionline` VALUES (4, '004', '4号车');
INSERT INTO `productionline` VALUES (5, '005', '5号车');
INSERT INTO `productionline` VALUES (6, '006', '6号车');
INSERT INTO `productionline` VALUES (7, '007', '7号车');
INSERT INTO `productionline` VALUES (8, '008', '8号车');
INSERT INTO `productionline` VALUES (9, '009', '9号车');
INSERT INTO `productionline` VALUES (10, '010', '10号车');
INSERT INTO `productionline` VALUES (11, '011', '11号车');
INSERT INTO `productionline` VALUES (12, '012', '12号车');
INSERT INTO `productionline` VALUES (13, '013', '13号车');
INSERT INTO `productionline` VALUES (14, '014', '14号车');
INSERT INTO `productionline` VALUES (15, '015', '15号车');
INSERT INTO `productionline` VALUES (16, '016', '16号车');
INSERT INTO `productionline` VALUES (17, '017', '17号车');
INSERT INTO `productionline` VALUES (18, '018', '18号车');
INSERT INTO `productionline` VALUES (19, '019', '19号车');
INSERT INTO `productionline` VALUES (20, '020', '20号车');
INSERT INTO `productionline` VALUES (21, '021', '21号车');
INSERT INTO `productionline` VALUES (22, '022', '22号车');
INSERT INTO `productionline` VALUES (23, '023', '23号车');
INSERT INTO `productionline` VALUES (24, '024', '24号车');
INSERT INTO `productionline` VALUES (28, '001', '1号车');

SET FOREIGN_KEY_CHECKS = 1;
