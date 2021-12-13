DROP PROCEDURE IF EXISTS p_addLine;
DELIMITER $
CREATE PROCEDURE p_addLine(IN ln VARCHAR(20), IN lname VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow TINYINT(1) DEFAULT 1;	
START TRANSACTION;

-- productionline
INSERT INTO productionline (LineNO, LineName) VALUES (ln, lname);
IF(ROW_COUNT()=0) THEN
	SET ifAffectedRow=0;
ELSE
	ALTER TABLE productionline AUTO_INCREMENT=1;
END IF;

-- device_config
INSERT INTO device_config (LineNO) VALUES (ln);
IF(ROW_COUNT()=0) THEN
	SET ifAffectedRow=0;
ELSE
	ALTER TABLE device_config AUTO_INCREMENT=1;
END IF;

-- -- device_info 
-- DELETE FROM device_info WHERE LineNO=ln;
-- IF(ROW_COUNT()=0) THEN
-- 	SET ifAffectedRow=0;
-- 	ALTER TABLE device_info AUTO_INCREMENT=1;
-- END IF;
-- 
-- -- device_info_paranameandsuffix
-- DELETE FROM device_info_paranameandsuffix WHERE LineNO=ln;
-- IF(ROW_COUNT()=0) THEN 
-- 	SET ifAffectedRow=0;
-- 	ALTER TABLE device_info_paranameandsuffix AUTO_INCREMENT=1;
-- END IF;
-- 
-- -- device_info_threshold
-- DELETE FROM device_info_threshold WHERE LineNO=ln;
-- IF(ROW_COUNT()=0) THEN 
-- 	SET ifAffectedRow=0;
-- 	ALTER TABLE device_info_threshold AUTO_INCREMENT=1;
-- END IF;
-- 
-- -- faults_config
-- DELETE FROM faults_config WHERE LineNO=ln;
-- IF(ROW_COUNT()=0) THEN 
-- 	SET ifAffectedRow=0;
-- 	ALTER TABLE device_config AUTO_INCREMENT=1;
-- END IF;

IF(ifAffectedRow=1) THEN
	COMMIT;
	SELECT ifAffectedRow INTO ifRowAffected;
ELSE
	ROLLBACK;
END IF;
END$
DELIMITER ;


