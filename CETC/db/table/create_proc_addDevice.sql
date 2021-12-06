DROP PROCEDURE IF EXISTS p_deleteDevice;
DELIMITER $
CREATE PROCEDURE p_deleteDevice(IN ln VARCHAR(20), IN dn VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;
DECLARE SQL_FOR_UPDATE VARCHAR(100);
DECLARE i INT DEFAULT 1;

START TRANSACTION;

-- device_config
SET SQL_FOR_UPDATE=CONCAT('UPDATE device_config SET `DeviceStatus_', dn, '`=1 WHERE LineNO=', ln, ';');
SET @sql=SQL_FOR_UPDATE_device_config;
PREPARE stmt FROM @sql;
EXECUTE stmt;
-- 使用PREPARE，获取ROW_COUNT必须要在DEALLOCATE释放sql语句之前
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		BEGIN END;
END CASE;	
DEALLOCATE PREPARE stmt;

-- device_info

-- INSERT INTO device_info (LineNO, DeviceNO, DeviceStatus, ValidParaCount, Para1, Para2, Para3, Para4, Para5, )
-- CASE ROW_COUNT()
-- 	WHEN 0 THEN 
-- 		SET ifAffectedRow=0;
-- 	ELSE 
-- 		ALTER TABLE device_info AUTO_INCREMENT=1;
-- END CASE;

SET SQL_FOR_UPDATE='INSERT INTO device_info (LineNO, DeviceNO, DeviceStatus, ValidParaCount';
WHILE i<=64 DO
	SET SQL_FOR_UPDATE=CONCAT(SQL_FOR_UPDATE, ', Para', i);
	SET i=i+1;
END WHILE;
SET SQL_FOR_UPDATE=CONCAT(SQL_FOR_UPDATE, ') SELECT LineNO, DeviceNO, DeviceStatus, ValidParaCount');
SET i=1;
WHILE i<=64 DO
	SET SQL_FOR_UPDATE=CONCAT(SQL_FOR_UPDATE, ', Para', i, 'Default');
END WHILE;
SET SQL_FOR_UPDATE=CONCAT(SQL_FOR_UPDATE, 'FROM device WHERE DeviceNO=', dn);
SET @sql=SQL_FOR_UPDATE;
SELECT SQL_FOR_UPDATE;
PREPARE stmt FROM @sql;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info AUTO_INCREMENT=1;
EXECUTE stmt;

-- device_info_threshold
DELETE FROM device_info_threshold WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_threshold AUTO_INCREMENT=1;
END CASE;

-- device_info_paranameandsuffix
DELETE FROM device_info_paranameandsuffix WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;
END CASE;

-- faults_config
DELETE FROM faults_config WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE faults_config AUTO_INCREMENT=1;
END CASE;

IF(ifAffectedRow=1) THEN 
	COMMIT;
	SELECT ifAffectedRow INTO ifRowAffected;
ELSE 
	ROLLBACK;
END IF;

END$
DELIMITER ;