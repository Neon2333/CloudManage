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

 Date: 13/12/2021 17:00:45
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for faults
-- ----------------------------
DROP TABLE IF EXISTS `faults`;
CREATE TABLE `faults`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `DeviceNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FaultNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `FaultName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 59 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of faults
-- ----------------------------
INSERT INTO `faults` VALUES (1, '001', '1', '相机故障');
INSERT INTO `faults` VALUES (2, '001', '2', '电源故障');
INSERT INTO `faults` VALUES (3, '001', '3', '输出信号故障');
INSERT INTO `faults` VALUES (4, '001', '4', '故障001-4');
INSERT INTO `faults` VALUES (5, '001', '5', '故障001-5');
INSERT INTO `faults` VALUES (6, '001', '6', '故障001-6');
INSERT INTO `faults` VALUES (7, '001', '7', '故障001-7');
INSERT INTO `faults` VALUES (8, '002', '1', '故障002-1');
INSERT INTO `faults` VALUES (9, '002', '2', '故障002-2');
INSERT INTO `faults` VALUES (10, '003', '1', '故障003-1');
INSERT INTO `faults` VALUES (11, '004', '1', '故障004-1');
INSERT INTO `faults` VALUES (12, '004', '2', '故障004-2');
INSERT INTO `faults` VALUES (13, '004', '3', '故障004-3');
INSERT INTO `faults` VALUES (14, '004', '4', '故障004-4');
INSERT INTO `faults` VALUES (15, '005', '1', '故障005-1');
INSERT INTO `faults` VALUES (16, '006', '1', '故障006-1');
INSERT INTO `faults` VALUES (17, '006', '2', '故障006-2');
INSERT INTO `faults` VALUES (18, '006', '3', '故障006-3');
INSERT INTO `faults` VALUES (19, '007', '1', '故障007-1');
INSERT INTO `faults` VALUES (20, '007', '2', '故障007-2');
INSERT INTO `faults` VALUES (21, '008', '1', '故障008-1');
INSERT INTO `faults` VALUES (22, '008', '2', '故障008-2');
INSERT INTO `faults` VALUES (23, '008', '3', '故障008-3');
INSERT INTO `faults` VALUES (24, '008', '4', '故障008-4');
INSERT INTO `faults` VALUES (25, '009', '1', '故障009-1');
INSERT INTO `faults` VALUES (26, '010', '1', '故障010-1');
INSERT INTO `faults` VALUES (27, '010', '2', '故障010-2');
INSERT INTO `faults` VALUES (28, '010', '3', '故障010-3');
INSERT INTO `faults` VALUES (29, '010', '4', '故障010-4');
INSERT INTO `faults` VALUES (30, '011', '1', '故障011-1');
INSERT INTO `faults` VALUES (31, '011', '2', '故障011-2');
INSERT INTO `faults` VALUES (32, '011', '3', '故障011-3');
INSERT INTO `faults` VALUES (33, '012', '1', '故障012-1');
INSERT INTO `faults` VALUES (34, '012', '2', '故障012-2');
INSERT INTO `faults` VALUES (35, '013', '1', '故障013-1');
INSERT INTO `faults` VALUES (36, '013', '2', '故障013-2');
INSERT INTO `faults` VALUES (37, '013', '3', '故障013-3');
INSERT INTO `faults` VALUES (38, '014', '1', '故障014-1');
INSERT INTO `faults` VALUES (39, '014', '2', '故障014-2');
INSERT INTO `faults` VALUES (40, '015', '1', '故障015-1');
INSERT INTO `faults` VALUES (41, '016', '1', '故障016-1');
INSERT INTO `faults` VALUES (42, '016', '2', '故障016-2');
INSERT INTO `faults` VALUES (43, '017', '1', '故障017-1');
INSERT INTO `faults` VALUES (44, '017', '2', '故障017-2');
INSERT INTO `faults` VALUES (45, '018', '1', '故障018-1');
INSERT INTO `faults` VALUES (46, '018', '2', '故障018-2');
INSERT INTO `faults` VALUES (47, '101', '1', '故障101-1');
INSERT INTO `faults` VALUES (48, '101', '2', '故障101-2');
INSERT INTO `faults` VALUES (49, '102', '1', '故障102-1');
INSERT INTO `faults` VALUES (50, '102', '2', '故障102-2');
INSERT INTO `faults` VALUES (51, '102', '3', '故障102-3');
INSERT INTO `faults` VALUES (52, '103', '1', '故障103-1');
INSERT INTO `faults` VALUES (53, '103', '2', '故障103-2');
INSERT INTO `faults` VALUES (54, '104', '1', '故障104-1');
INSERT INTO `faults` VALUES (55, '104', '2', '故障104-2');
INSERT INTO `faults` VALUES (56, '104', '3', '故障104-3');
INSERT INTO `faults` VALUES (57, '105', '1', '故障105-1');
INSERT INTO `faults` VALUES (58, '105', '2', '故障105-2');

SET FOREIGN_KEY_CHECKS = 1;
