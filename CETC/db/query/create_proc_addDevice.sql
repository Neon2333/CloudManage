DROP PROCEDURE IF EXISTS p_addDevice;
DELIMITER $
CREATE PROCEDURE `p_deleteDevice`(IN ln VARCHAR(20), IN dn VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;
DECLARE device_config_rowsCount INT DEFAULT 0;
DECLARE i INT DEFAULT 0;
DECLARE SQL_FOR_ALTER_device_config VARCHAR(100);

START TRANSACTION;

-- device_config
SET SQL_FOR_ALTER_device_config=CONCAT('ALTER TABLE device_config ADD COLUMN DeviceStatus_', dn, ';');
SET @sql=SQL_FOR_UPDATE_device_config;
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

SELECT COUNT(device_config) INTO device_config_rowsCount;

WHILE i < device_config_rowsCount DO
SET SQL_FOR_ALTER_device_config=CONCAT('INSERT INTO device_config (DeviceStatus_', dn, ') VALUES (0);');
SET @sql=SQL_FOR_UPDATE_device_config;
PREPARE stmt FROM @sql;
EXECUTE stmt;
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		BEGIN END;
END CASE;
DEALLOCATE PREPARE stmt;
END WHILE;

-- device_info
DELETE FROM device_info WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		ALTER TABLE device_info AUTO_INCREMENT=1;
END CASE;

-- device_threshold
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