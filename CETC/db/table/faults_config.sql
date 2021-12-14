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

 Date: 14/12/2021 11:34:40
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for faults_config
-- ----------------------------
DROP TABLE IF EXISTS `faults_config`;
CREATE TABLE `faults_config`  (
  `NO` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `LineNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `DeviceNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FaultNO` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `FaultEnable` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`NO`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4345 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of faults_config
-- ----------------------------
INSERT INTO `faults_config` VALUES (1, '001', '001', '1', '1');
INSERT INTO `faults_config` VALUES (2, '001', '001', '2', '1');
INSERT INTO `faults_config` VALUES (3, '001', '001', '3', '1');
INSERT INTO `faults_config` VALUES (4, '001', '001', '4', '1');
INSERT INTO `faults_config` VALUES (5, '001', '001', '5', '1');
INSERT INTO `faults_config` VALUES (6, '001', '001', '6', '1');
INSERT INTO `faults_config` VALUES (7, '001', '001', '7', '1');
INSERT INTO `faults_config` VALUES (8, '001', '002', '1', '1');
INSERT INTO `faults_config` VALUES (9, '001', '002', '2', '1');
INSERT INTO `faults_config` VALUES (10, '001', '003', '1', '1');
INSERT INTO `faults_config` VALUES (11, '002', '004', '1', '1');
INSERT INTO `faults_config` VALUES (12, '002', '004', '2', '1');
INSERT INTO `faults_config` VALUES (13, '002', '004', '3', '1');
INSERT INTO `faults_config` VALUES (14, '002', '004', '4', '1');
INSERT INTO `faults_config` VALUES (15, '002', '005', '1', '1');
INSERT INTO `faults_config` VALUES (16, '002', '006', '1', '1');
INSERT INTO `faults_config` VALUES (17, '002', '006', '2', '1');
INSERT INTO `faults_config` VALUES (18, '002', '006', '3', '1');
INSERT INTO `faults_config` VALUES (19, '003', '007', '1', '1');
INSERT INTO `faults_config` VALUES (20, '003', '007', '2', '1');
INSERT INTO `faults_config` VALUES (21, '003', '008', '1', '1');
INSERT INTO `faults_config` VALUES (22, '003', '008', '2', '1');
INSERT INTO `faults_config` VALUES (23, '003', '008', '3', '1');
INSERT INTO `faults_config` VALUES (24, '003', '008', '4', '1');
INSERT INTO `faults_config` VALUES (25, '003', '009', '1', '1');
INSERT INTO `faults_config` VALUES (26, '004', '010', '1', '1');
INSERT INTO `faults_config` VALUES (27, '004', '010', '2', '1');
INSERT INTO `faults_config` VALUES (28, '004', '010', '3', '1');
INSERT INTO `faults_config` VALUES (29, '004', '010', '4', '1');
INSERT INTO `faults_config` VALUES (30, '004', '011', '1', '1');
INSERT INTO `faults_config` VALUES (31, '004', '011', '2', '1');
INSERT INTO `faults_config` VALUES (32, '004', '011', '3', '1');
INSERT INTO `faults_config` VALUES (33, '004', '012', '1', '1');
INSERT INTO `faults_config` VALUES (34, '004', '012', '2', '1');
INSERT INTO `faults_config` VALUES (35, '005', '013', '1', '1');
INSERT INTO `faults_config` VALUES (36, '005', '013', '2', '1');
INSERT INTO `faults_config` VALUES (37, '005', '013', '3', '1');
INSERT INTO `faults_config` VALUES (38, '005', '101', '1', '1');
INSERT INTO `faults_config` VALUES (39, '005', '101', '2', '1');
INSERT INTO `faults_config` VALUES (40, '005', '102', '1', '1');
INSERT INTO `faults_config` VALUES (41, '005', '102', '2', '1');
INSERT INTO `faults_config` VALUES (42, '005', '102', '3', '1');
INSERT INTO `faults_config` VALUES (43, '006', '103', '1', '1');
INSERT INTO `faults_config` VALUES (44, '006', '103', '2', '1');
INSERT INTO `faults_config` VALUES (45, '006', '104', '1', '1');
INSERT INTO `faults_config` VALUES (46, '006', '104', '2', '1');
INSERT INTO `faults_config` VALUES (47, '006', '104', '3', '1');
INSERT INTO `faults_config` VALUES (48, '006', '105', '1', '1');
INSERT INTO `faults_config` VALUES (49, '006', '105', '2', '1');
INSERT INTO `faults_config` VALUES (50, '007', '001', '1', '1');
INSERT INTO `faults_config` VALUES (51, '007', '001', '2', '1');
INSERT INTO `faults_config` VALUES (52, '007', '001', '3', '1');
INSERT INTO `faults_config` VALUES (53, '007', '001', '4', '1');
INSERT INTO `faults_config` VALUES (54, '007', '001', '5', '1');
INSERT INTO `faults_config` VALUES (55, '007', '001', '6', '1');
INSERT INTO `faults_config` VALUES (56, '007', '001', '7', '1');
INSERT INTO `faults_config` VALUES (57, '007', '002', '1', '1');
INSERT INTO `faults_config` VALUES (58, '007', '002', '2', '1');
INSERT INTO `faults_config` VALUES (59, '007', '003', '1', '1');
INSERT INTO `faults_config` VALUES (60, '008', '004', '1', '1');
INSERT INTO `faults_config` VALUES (61, '008', '004', '2', '1');
INSERT INTO `faults_config` VALUES (62, '008', '004', '3', '1');
INSERT INTO `faults_config` VALUES (63, '008', '004', '4', '1');
INSERT INTO `faults_config` VALUES (64, '008', '005', '1', '1');
INSERT INTO `faults_config` VALUES (65, '008', '006', '1', '1');
INSERT INTO `faults_config` VALUES (66, '008', '006', '2', '1');
INSERT INTO `faults_config` VALUES (67, '008', '006', '3', '1');
INSERT INTO `faults_config` VALUES (68, '009', '007', '1', '1');
INSERT INTO `faults_config` VALUES (69, '009', '007', '2', '1');
INSERT INTO `faults_config` VALUES (70, '009', '008', '1', '1');
INSERT INTO `faults_config` VALUES (71, '009', '008', '2', '1');
INSERT INTO `faults_config` VALUES (72, '009', '008', '3', '1');
INSERT INTO `faults_config` VALUES (73, '009', '008', '4', '1');
INSERT INTO `faults_config` VALUES (74, '009', '009', '1', '1');
INSERT INTO `faults_config` VALUES (75, '010', '010', '1', '1');
INSERT INTO `faults_config` VALUES (76, '010', '010', '2', '1');
INSERT INTO `faults_config` VALUES (77, '010', '010', '3', '1');
INSERT INTO `faults_config` VALUES (78, '010', '010', '4', '1');
INSERT INTO `faults_config` VALUES (79, '010', '011', '1', '1');
INSERT INTO `faults_config` VALUES (80, '010', '011', '2', '1');
INSERT INTO `faults_config` VALUES (81, '010', '011', '3', '1');
INSERT INTO `faults_config` VALUES (82, '010', '012', '1', '1');
INSERT INTO `faults_config` VALUES (83, '010', '012', '2', '1');
INSERT INTO `faults_config` VALUES (84, '011', '013', '1', '1');
INSERT INTO `faults_config` VALUES (85, '011', '013', '2', '1');
INSERT INTO `faults_config` VALUES (86, '011', '013', '3', '1');
INSERT INTO `faults_config` VALUES (87, '011', '101', '1', '1');
INSERT INTO `faults_config` VALUES (88, '011', '101', '2', '1');
INSERT INTO `faults_config` VALUES (89, '011', '102', '1', '1');
INSERT INTO `faults_config` VALUES (90, '011', '102', '2', '1');
INSERT INTO `faults_config` VALUES (91, '011', '102', '3', '1');
INSERT INTO `faults_config` VALUES (92, '012', '103', '1', '1');
INSERT INTO `faults_config` VALUES (93, '012', '103', '2', '1');
INSERT INTO `faults_config` VALUES (94, '012', '104', '1', '1');
INSERT INTO `faults_config` VALUES (95, '012', '104', '2', '1');
INSERT INTO `faults_config` VALUES (96, '012', '104', '3', '1');
INSERT INTO `faults_config` VALUES (97, '012', '105', '1', '1');
INSERT INTO `faults_config` VALUES (98, '012', '105', '2', '1');
INSERT INTO `faults_config` VALUES (99, '013', '001', '1', '1');
INSERT INTO `faults_config` VALUES (100, '013', '001', '2', '1');
INSERT INTO `faults_config` VALUES (101, '013', '001', '3', '1');
INSERT INTO `faults_config` VALUES (102, '013', '001', '4', '1');
INSERT INTO `faults_config` VALUES (103, '013', '001', '5', '1');
INSERT INTO `faults_config` VALUES (104, '013', '001', '6', '1');
INSERT INTO `faults_config` VALUES (105, '013', '001', '7', '1');
INSERT INTO `faults_config` VALUES (106, '013', '002', '1', '1');
INSERT INTO `faults_config` VALUES (107, '013', '002', '2', '1');
INSERT INTO `faults_config` VALUES (108, '013', '003', '1', '1');
INSERT INTO `faults_config` VALUES (109, '014', '004', '1', '1');
INSERT INTO `faults_config` VALUES (110, '014', '004', '2', '1');
INSERT INTO `faults_config` VALUES (111, '014', '004', '3', '1');
INSERT INTO `faults_config` VALUES (112, '014', '004', '4', '1');
INSERT INTO `faults_config` VALUES (113, '014', '005', '1', '1');
INSERT INTO `faults_config` VALUES (114, '014', '006', '1', '1');
INSERT INTO `faults_config` VALUES (115, '014', '006', '2', '1');
INSERT INTO `faults_config` VALUES (116, '014', '006', '3', '1');
INSERT INTO `faults_config` VALUES (117, '015', '007', '1', '1');
INSERT INTO `faults_config` VALUES (118, '015', '007', '2', '1');
INSERT INTO `faults_config` VALUES (119, '015', '008', '1', '1');
INSERT INTO `faults_config` VALUES (120, '015', '008', '2', '1');
INSERT INTO `faults_config` VALUES (121, '015', '008', '3', '1');
INSERT INTO `faults_config` VALUES (122, '015', '008', '4', '1');
INSERT INTO `faults_config` VALUES (123, '015', '009', '1', '1');
INSERT INTO `faults_config` VALUES (124, '016', '010', '1', '1');
INSERT INTO `faults_config` VALUES (125, '016', '010', '2', '1');
INSERT INTO `faults_config` VALUES (126, '016', '010', '3', '1');
INSERT INTO `faults_config` VALUES (127, '016', '010', '4', '1');
INSERT INTO `faults_config` VALUES (128, '016', '011', '1', '1');
INSERT INTO `faults_config` VALUES (129, '016', '011', '2', '1');
INSERT INTO `faults_config` VALUES (130, '016', '011', '3', '1');
INSERT INTO `faults_config` VALUES (131, '016', '012', '1', '1');
INSERT INTO `faults_config` VALUES (132, '016', '012', '2', '1');
INSERT INTO `faults_config` VALUES (133, '017', '013', '1', '1');
INSERT INTO `faults_config` VALUES (134, '017', '013', '2', '1');
INSERT INTO `faults_config` VALUES (135, '017', '013', '3', '1');
INSERT INTO `faults_config` VALUES (136, '017', '101', '1', '1');
INSERT INTO `faults_config` VALUES (137, '017', '101', '2', '1');
INSERT INTO `faults_config` VALUES (138, '017', '102', '1', '1');
INSERT INTO `faults_config` VALUES (139, '017', '102', '2', '1');
INSERT INTO `faults_config` VALUES (140, '017', '102', '3', '1');
INSERT INTO `faults_config` VALUES (141, '018', '103', '1', '1');
INSERT INTO `faults_config` VALUES (142, '018', '103', '2', '1');
INSERT INTO `faults_config` VALUES (143, '018', '104', '1', '1');
INSERT INTO `faults_config` VALUES (144, '018', '104', '2', '1');
INSERT INTO `faults_config` VALUES (145, '018', '104', '3', '1');
INSERT INTO `faults_config` VALUES (146, '018', '105', '1', '1');
INSERT INTO `faults_config` VALUES (147, '018', '105', '2', '1');
INSERT INTO `faults_config` VALUES (148, '019', '001', '1', '1');
INSERT INTO `faults_config` VALUES (149, '019', '001', '2', '1');
INSERT INTO `faults_config` VALUES (150, '019', '001', '3', '1');
INSERT INTO `faults_config` VALUES (151, '019', '001', '4', '1');
INSERT INTO `faults_config` VALUES (152, '019', '001', '5', '1');
INSERT INTO `faults_config` VALUES (153, '019', '001', '6', '1');
INSERT INTO `faults_config` VALUES (154, '019', '001', '7', '1');
INSERT INTO `faults_config` VALUES (155, '019', '002', '1', '1');
INSERT INTO `faults_config` VALUES (156, '019', '002', '2', '1');
INSERT INTO `faults_config` VALUES (157, '019', '003', '1', '1');
INSERT INTO `faults_config` VALUES (158, '020', '004', '1', '1');
INSERT INTO `faults_config` VALUES (159, '020', '004', '2', '1');
INSERT INTO `faults_config` VALUES (160, '020', '004', '3', '1');
INSERT INTO `faults_config` VALUES (161, '020', '004', '4', '1');
INSERT INTO `faults_config` VALUES (162, '020', '005', '1', '1');
INSERT INTO `faults_config` VALUES (163, '020', '006', '1', '1');
INSERT INTO `faults_config` VALUES (164, '020', '006', '2', '1');
INSERT INTO `faults_config` VALUES (165, '020', '006', '3', '1');
INSERT INTO `faults_config` VALUES (166, '021', '007', '1', '1');
INSERT INTO `faults_config` VALUES (167, '021', '007', '2', '1');
INSERT INTO `faults_config` VALUES (168, '021', '008', '1', '1');
INSERT INTO `faults_config` VALUES (169, '021', '008', '2', '1');
INSERT INTO `faults_config` VALUES (170, '021', '008', '3', '1');
INSERT INTO `faults_config` VALUES (171, '021', '008', '4', '1');
INSERT INTO `faults_config` VALUES (172, '021', '009', '1', '1');
INSERT INTO `faults_config` VALUES (173, '022', '010', '1', '1');
INSERT INTO `faults_config` VALUES (174, '022', '010', '2', '1');
INSERT INTO `faults_config` VALUES (175, '022', '010', '3', '1');
INSERT INTO `faults_config` VALUES (176, '022', '010', '4', '1');
INSERT INTO `faults_config` VALUES (177, '022', '011', '1', '1');
INSERT INTO `faults_config` VALUES (178, '022', '011', '2', '1');
INSERT INTO `faults_config` VALUES (179, '022', '011', '3', '1');
INSERT INTO `faults_config` VALUES (180, '022', '012', '1', '1');
INSERT INTO `faults_config` VALUES (181, '022', '012', '2', '1');
INSERT INTO `faults_config` VALUES (182, '023', '013', '1', '1');
INSERT INTO `faults_config` VALUES (183, '023', '013', '2', '1');
INSERT INTO `faults_config` VALUES (184, '023', '013', '3', '1');
INSERT INTO `faults_config` VALUES (185, '023', '101', '1', '1');
INSERT INTO `faults_config` VALUES (186, '023', '101', '2', '1');
INSERT INTO `faults_config` VALUES (187, '023', '102', '1', '1');
INSERT INTO `faults_config` VALUES (188, '023', '102', '2', '1');
INSERT INTO `faults_config` VALUES (189, '023', '102', '3', '1');
INSERT INTO `faults_config` VALUES (190, '024', '103', '1', '1');
INSERT INTO `faults_config` VALUES (191, '024', '103', '2', '1');
INSERT INTO `faults_config` VALUES (192, '024', '104', '1', '1');
INSERT INTO `faults_config` VALUES (193, '024', '104', '2', '1');
INSERT INTO `faults_config` VALUES (194, '024', '104', '3', '1');
INSERT INTO `faults_config` VALUES (195, '024', '105', '1', '1');
INSERT INTO `faults_config` VALUES (196, '024', '105', '2', '1');

SET FOREIGN_KEY_CHECKS = 1;
