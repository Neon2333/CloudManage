DROP PROCEDURE IF EXISTS p_deleteDevice;
CREATE PROCEDURE p_deleteDevice(IN ln VARCHAR(20), IN dn VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;
DECLARE SQL_FOR_UPDATE_device_config VARCHAR(100);

START TRANSACTION;

SET SQL_FOR_UPDATE_device_config=CONCAT('UPDATE device_config SET `DeviceStatus_', dn, '`=0 WHERE LineNO=', ln, ';');
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

DELETE FROM device_info WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		ALTER TABLE device_info AUTO_INCREMENT=1;
END CASE;

DELETE FROM device_info_threshold WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_threshold AUTO_INCREMENT=1;
END CASE;

DELETE FROM device_info_paranameandsuffix WHERE LineNO=ln AND DeviceNO=dn;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;
END CASE;

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

END