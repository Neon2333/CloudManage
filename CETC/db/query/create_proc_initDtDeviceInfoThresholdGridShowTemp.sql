DROP PROCEDURE IF EXISTS initDtDeviceInfoThresholdGridShowTemp;
CREATE PROCEDURE initDtDeviceInfoThresholdGridShowTemp(IN cmdFlag int(10), IN lNO VARCHAR(10), IN dNO VARCHAR(10))
BEGIN
DECLARE vpcEach INT(10) DEFAULT 1;		-- 每台设备有效参数个数
DECLARE colname1 VARCHAR(20);					-- Para1Name
DECLARE colname2 VARCHAR(20);					-- Para1Suffix
DECLARE colname3 VARCHAR(20);					-- Para1Min
DECLARE colname4 VARCHAR(20);					-- Para1Max
DECLARE ii INT(10) DEFAULT 1;
DECLARE SQL_FOR_SELECT varchar(10000);	-- 最终的sql语句

SELECT Max(ValidParaCount) FROM device_info_threshold INTO vpcEach;	-- 这里用各个设备参数个数最大值决定表中Para的个数，参数个数小于Max(ValidParaCount)的列将会是'\'，
																																		-- 代码中转化为dtDeviceInfoThresholdGridShow时再根据每个设备的ValidParaCount转化

SET SQL_FOR_SELECT='SELECT t1.LineNO, t3.LineName, t1.DeviceNO, t4.DeviceName, t1.ValidParaCount';
a:WHILE ii<=vpcEach DO
	SET colname1=CONCAT(', t2.Para', ii, 'Name');
	SET colname2=CONCAT(', t2.Para', ii, 'Suffix');
	SET colname3=CONCAT(', t1.Para', ii, 'Min');
	SET colname4=CONCAT(', t1.Para', ii, 'Max');
	
	SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, colname1, colname2, colname3, colname4);
	SET ii=ii+1;
END WHILE;

CASE cmdFlag
WHEN 0 THEN  
SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, ' FROM device_info_threshold AS t1 INNER JOIN device_info_paranameandsuffix AS t2 ON t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO INNER JOIN productionline AS t3 ON t1.LineNO=t3.LineNO INNER JOIN device AS t4 ON t1.DeviceNO=t4.DeviceNO;');
WHEN 1 THEN
SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, ' FROM device_info_threshold AS t1 INNER JOIN device_info_paranameandsuffix AS t2 ON t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO INNER JOIN productionline AS t3 ON t1.LineNO=t3.LineNO INNER JOIN device AS t4 ON t1.DeviceNO=t4.DeviceNO WHERE t1.DeviceNO=', dNO);
WHEN 2 THEN
SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, ' FROM device_info_threshold AS t1 INNER JOIN device_info_paranameandsuffix AS t2 ON t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO INNER JOIN productionline AS t3 ON t1.LineNO=t3.LineNO INNER JOIN device AS t4 ON t1.DeviceNO=t4.DeviceNO WHERE t1.LineNO=', lNO);
WHEN 3 THEN 
SET SQL_FOR_SELECT=CONCAT(SQL_FOR_SELECT, ' FROM device_info_threshold AS t1 INNER JOIN device_info_paranameandsuffix AS t2 ON t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO INNER JOIN productionline AS t3 ON t1.LineNO=t3.LineNO INNER JOIN device AS t4 ON t1.DeviceNO=t4.DeviceNO WHERE t1.LineNO=', lNO, ' AND t1.DeviceNO=',  dNO);
END CASE;

SET @sql=SQL_FOR_SELECT;
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

END