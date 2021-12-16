DROP PROCEDURE IF EXISTS p_addLine;
DELIMITER $
CREATE PROCEDURE p_addLine(IN ln VARCHAR(20), IN lname VARCHAR(20), OUT ifRowAffected INT(1))
BEGIN
DECLARE ifAffectedRow INT(1) DEFAULT 1;	
START TRANSACTION;

-- productionline
INSERT INTO productionline (LineNO, LineName) VALUES (ln, lname);
IF(ROW_COUNT()=0) THEN
	SET ifAffectedRow=0;
END IF;

-- device_config
INSERT INTO device_config (LineNO) VALUES (ln);
IF(ROW_COUNT()=0) THEN
	SET ifAffectedRow=0;
END IF;

IF(ifAffectedRow=1) THEN
	COMMIT;
	SELECT ifAffectedRow INTO ifRowAffected;
ELSE
	ROLLBACK;
END IF;
END$
DELIMITER ;


