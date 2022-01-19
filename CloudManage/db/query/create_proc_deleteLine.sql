DROP PROCEDURE IF EXISTS p_deleteLine;
DELIMITER $
CREATE PROCEDURE p_deleteLine(IN ln VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN

DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;
DECLARE SQL_FOR_UPDATE_device_config VARCHAR(100);

START TRANSACTION;

-- productionline
DELETE FROM productionline WHERE LineNO=ln;
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		ALTER TABLE productionline AUTO_INCREMENT=1;
-- 		ALTER TABLE device_info DROP `id`;
-- 		ALTER TABLE device_info ADD `id` INT(10) NOT NULL AUTO_INCREMENT FIRST;
END CASE;

-- device_config
DELETE FROM device_config WHERE LineNO=ln;
CASE ROW_COUNT()
	WHEN 0 THEN 
		SET ifAffectedRow=0;
	ELSE 
		ALTER TABLE device_config AUTO_INCREMENT=1;
-- 		ALTER TABLE device_info DROP `id`;
-- 		ALTER TABLE device_info ADD `id` INT(10) NOT NULL AUTO_INCREMENT FIRST;
END CASE;

-- device_info 
DELETE FROM device_info WHERE LineNO=ln;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info AUTO_INCREMENT=1;
END CASE;

-- device_info_paranameandsuffix
DELETE FROM device_info_paranameandsuffix WHERE LineNO=ln;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;
END CASE;

-- device_info_threshold
DELETE FROM device_info_threshold WHERE LineNO=ln;
CASE ROW_COUNT()
WHEN 0 THEN 
	SET ifAffectedRow=0;
ELSE 
	ALTER TABLE device_info_threshold AUTO_INCREMENT=1;
END CASE;

-- faults_config
DELETE FROM faults_config WHERE LineNO=ln;
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


