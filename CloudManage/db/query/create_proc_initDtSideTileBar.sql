DROP PROCEDURE IF EXISTS initDtSideTileBar;
CREATE PROCEDURE initDtSideTileBar()
BEGIN
DECLARE different_device_num INT DEFAULT 0;
DECLARE colname VARCHAR(20);
DECLARE SQL_FOR_SELECT varchar(1000);
DECLARE ii INT(10) DEFAULT 2;

SELECT COUNT(*) INTO different_device_num FROM device;

-- SELECT 打印变量调试
-- SELECT different_device_num;

SET SQL_FOR_SELECT='SELECT device_config.LineNO ,DeviceStatus_001';

a:WHILE ii<=different_device_num DO
	SELECT deviceNO INTO colname FROM device WHERE NO=ii;
	SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, '+DeviceStatus_', colname);
	SET ii=ii+1;
END WHILE;

SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, ' AS DeviceTotalNum FROM device_config');

SET SQL_FOR_SELECT=CONCAT('SELECT t1.LineNO,t2.LineName,t1.DeviceTotalNum FROM (', SQL_FOR_SELECT, ') AS t1 INNER JOIN productionline AS t2 ON t1.LineNO=t2.LineNO;');

-- SELECT SQL_FOR_SELECT;

SET @sql=SQL_FOR_SELECT;
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END