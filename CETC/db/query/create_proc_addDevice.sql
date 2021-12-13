DROP PROCEDURE IF EXISTS p_addDevice;
DELIMITER $
CREATE PROCEDURE p_addDevice(IN ln VARCHAR(20), IN dn VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;
DECLARE SQL_FOR_UPDATE_device_config VARCHAR(1000);
DECLARE SQL_FOR_UPDATE_device_info VARCHAR(1000);
DECLARE SQL_FOR_UPDATE_device_info_threshold VARCHAR(1000);
DECLARE i INT DEFAULT 1;

START TRANSACTION;

-- device_config
SET SQL_FOR_UPDATE_device_config=CONCAT('UPDATE device_config SET `DeviceStatus_', dn, '`=1 WHERE LineNO=', ln, ';');
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
-- INSERT INTO tb1 () SELECT * FROM tb2;
SET SQL_FOR_UPDATE_device_info='INSERT INTO device_info (LineNO, DeviceNO, DeviceStatus, ValidParaCount';
WHILE i<=64 DO
	 SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ', Para', i);
	 SET i=i+1;
END WHILE;
SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ') SELECT LineNO, DeviceNO, DeviceStatus, ValidParaCount');
SET i=1;
WHILE i<=64 DO
	 SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ', Para', i, 'Default');
END WHILE;
SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, 'FROM device WHERE DeviceNO=', dn);
SET @sql=SQL_FOR_UPDATE_device_info;
SELECT SQL_FOR_UPDATE_device_info;
PREPARE stmt FROM @sql;
EXECUTE stmt;
CASE ROW_COUNT()
WHEN 0 THEN 
	 SET ifAffectedRow=0;
ELSE 
	 ALTER TABLE device_info AUTO_INCREMENT=1;
END CASE;

-- device_info_threshold
SET SQL_FOR_UPDATE_device_info_threshold='INSERT INTO device_info_threshold (LineNO, DeviceNO, DeviceStatus, ValidParaCount';
WHILE i<=64 DO
	 SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ', Para', i);
	 SET i=i+1;
END WHILE;
SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ') SELECT LineNO, DeviceNO, DeviceStatus, ValidParaCount');
SET i=1;
WHILE i<=64 DO
	 SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, ', Para', i, 'Default');
END WHILE;
SET SQL_FOR_UPDATE_device_info=CONCAT(SQL_FOR_UPDATE_device_info, 'FROM device WHERE DeviceNO=', dn);
SET @sql=SQL_FOR_UPDATE_device_info;
SELECT SQL_FOR_UPDATE_device_info;
PREPARE stmt FROM @sql;
EXECUTE stmt;
CASE ROW_COUNT()
WHEN 0 THEN 
	 SET ifAffectedRow=0;
ELSE 
	 ALTER TABLE device_info AUTO_INCREMENT=1;
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