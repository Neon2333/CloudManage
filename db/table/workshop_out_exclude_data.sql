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

 Date: 13/12/2021 17:01:38
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for workshop_out_exclude_data
-- ----------------------------
DROP TABLE IF EXISTS `workshop_out_exclude_data`;
CREATE TABLE `workshop_out_exclude_data`  (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `packer_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `device_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `shift_no` int(11) NULL DEFAULT NULL,
  `date_time` datetime(6) NOT NULL,
  `output_data` int(11) NULL DEFAULT NULL,
  `exclude_data` int(11) NULL DEFAULT NULL,
  `work_date` date NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 64 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of workshop_out_exclude_data
-- ----------------------------
INSERT INTO `workshop_out_exclude_data` VALUES (1, '001', '001', 1, '2021-10-01 00:00:00.000000', 2154, 120, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (2, '001', '001', 2, '2021-10-01 17:06:21.000000', 3020, 98, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (3, '001', '001', 3, '2021-10-01 17:07:12.000000', 3201, 78, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (4, '001', '002', 1, '2021-10-01 17:07:53.000000', 1890, 298, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (5, '001', '002', 2, '2021-10-01 17:08:38.000000', 2098, 20, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (6, '001', '002', 3, '2021-10-01 17:09:01.000000', 3560, 28, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (7, '002', '001', 1, '2021-10-01 17:09:38.000000', 1902, 10, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (8, '002', '001', 2, '2021-10-01 17:09:58.000000', 9800, 122, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (9, '002', '001', 3, '2021-10-01 17:10:26.000000', 1900, 18, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (10, '002', '002', 1, '2021-10-01 17:10:51.000000', 2000, 15, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (11, '002', '002', 2, '2021-10-01 17:11:09.000000', 3000, 28, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (12, '002', '002', 3, '2021-10-01 17:11:33.000000', 4900, 120, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (13, '003', '001', 1, '2021-10-01 17:12:15.000000', 4500, 230, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (14, '003', '001', 2, '2021-10-01 17:12:40.000000', 9800, 34, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (15, '003', '001', 3, '2021-10-01 17:13:02.000000', 5700, 56, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (16, '003', '002', 1, '2021-10-01 17:13:30.000000', 1890, 203, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (17, '003', '002', 2, '2021-10-01 17:13:53.000000', 9000, 234, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (18, '003', '002', 3, '2021-10-01 17:14:11.000000', 5600, 267, '2021-10-01');
INSERT INTO `workshop_out_exclude_data` VALUES (19, '001', '001', 1, '2021-10-02 17:04:43.000000', 3278, 120, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (20, '001', '001', 2, '2021-10-02 17:06:21.000000', 4562, 98, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (21, '001', '001', 3, '2021-10-02 17:07:12.000000', 5620, 78, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (22, '001', '002', 1, '2021-10-02 17:07:53.000000', 3890, 298, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (23, '001', '002', 2, '2021-10-02 17:08:38.000000', 4780, 20, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (24, '001', '002', 3, '2021-10-02 17:09:01.000000', 5290, 28, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (25, '002', '001', 1, '2021-10-02 17:09:38.000000', 4389, 10, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (26, '002', '001', 2, '2021-10-02 17:09:58.000000', 3900, 122, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (27, '002', '001', 3, '2021-10-02 17:10:26.000000', 8700, 18, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (28, '002', '002', 1, '2021-10-02 17:10:51.000000', 3200, 15, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (29, '002', '002', 2, '2021-10-02 17:11:09.000000', 3800, 28, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (30, '002', '002', 3, '2021-10-02 17:11:33.000000', 8900, 120, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (31, '003', '001', 1, '2021-10-02 17:12:15.000000', 9800, 230, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (32, '003', '001', 2, '2021-10-02 17:12:40.000000', 8700, 34, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (33, '003', '001', 3, '2021-10-02 17:13:02.000000', 8700, 56, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (34, '003', '002', 1, '2021-10-02 17:13:30.000000', 6700, 203, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (35, '003', '002', 2, '2021-10-02 17:13:53.000000', 9088, 234, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (36, '003', '002', 3, '2021-10-02 17:14:11.000000', 8700, 267, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (37, '001', '001', 1, '2021-10-02 17:04:43.000000', 7600, 120, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (38, '001', '001', 2, '2021-10-02 17:06:21.000000', 6800, 98, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (39, '001', '001', 3, '2021-10-02 17:07:12.000000', 3201, 78, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (40, '001', '002', 1, '2021-10-02 17:07:53.000000', 1890, 298, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (41, '001', '002', 2, '2021-10-02 17:08:38.000000', 2098, 20, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (42, '001', '002', 3, '2021-10-02 17:09:01.000000', 4780, 28, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (43, '002', '001', 1, '2021-10-02 17:09:38.000000', 3490, 10, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (44, '002', '001', 2, '2021-10-02 17:09:58.000000', 12000, 122, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (45, '002', '001', 3, '2021-10-02 17:10:26.000000', 5690, 18, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (46, '002', '002', 1, '2021-10-02 17:10:51.000000', 8900, 15, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (47, '002', '002', 2, '2021-10-02 17:11:09.000000', 4590, 28, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (48, '002', '002', 3, '2021-10-02 17:11:33.000000', 6790, 120, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (49, '003', '001', 1, '2021-10-02 17:12:15.000000', 5680, 230, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (50, '003', '001', 2, '2021-10-02 17:12:40.000000', 9800, 34, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (51, '003', '001', 3, '2021-10-02 17:13:02.000000', 8790, 56, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (52, '003', '002', 1, '2021-10-02 17:13:30.000000', 2840, 203, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (53, '003', '002', 2, '2021-10-02 17:13:53.000000', 5690, 234, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (54, '003', '002', 3, '2021-10-02 17:14:11.000000', 5600, 267, '2021-10-02');
INSERT INTO `workshop_out_exclude_data` VALUES (55, '004', '010', 1, '2021-11-10 09:36:20.000000', 5800, 298, '2021-11-10');
INSERT INTO `workshop_out_exclude_data` VALUES (56, '004', '010', 2, '2021-11-10 09:36:58.000000', 7690, 283, '2021-11-10');
INSERT INTO `workshop_out_exclude_data` VALUES (57, '004', '010', 1, '2021-11-11 09:37:27.000000', 8600, 332, '2021-11-11');
INSERT INTO `workshop_out_exclude_data` VALUES (58, '004', '010', 2, '2021-11-11 09:38:39.000000', 3890, 122, '2021-11-11');
INSERT INTO `workshop_out_exclude_data` VALUES (59, '004', '001', 1, '2021-12-03 11:17:07.000000', 12009, 320, '2021-12-03');
INSERT INTO `workshop_out_exclude_data` VALUES (60, '001', '001', 1, '2021-12-24 08:09:35.156486', 921, 921, '2021-12-24');
INSERT INTO `workshop_out_exclude_data` VALUES (61, '001', '002', 1, '2021-12-24 08:09:35.167884', 922, 922, '2021-12-24');
INSERT INTO `workshop_out_exclude_data` VALUES (62, '001', '001', 2, '2021-12-24 16:13:21.274594', 1729, 1729, '2021-12-24');
INSERT INTO `workshop_out_exclude_data` VALUES (63, '001', '002', 2, '2021-12-24 16:13:21.288431', 1728, 1728, '2021-12-24');

SET FOREIGN_KEY_CHECKS = 1;
