DROP PROCEDURE IF EXISTS judgeIfExistInFaultHistory;
CREATE PROCEDURE judgeIfExistInFaultHistory(valLineNO VARCHAR(20), valDeviceNO VARCHAR(20), valFaultNO VARCHAR(20), valFaultTime VARCHAR(20))
BEGIN
-- DECLARE SQL_FOR_SELECT varchar(255);
-- SET SQL_FOR_SELECT=CONCAT('SELECT COUNT(t1.`NO`) FROM faults_history AS t1 WHERE t1.LineNO=', valLineNO, ' AND t1.DeviceNO=', valDeviceNO, ' AND t1.FaultNO=', valFaultNO, ' AND t1.FaultTime=', valFaultTime, ';');

SELECT COUNT(t1.`NO`) 
FROM faults_history AS t1 
WHERE t1.LineNO=valLineNO AND t1.DeviceNO=valDeviceNO AND t1.FaultNO=valFaultNO AND t1.FaultTime=valFaultTime;

-- SET @sql=SQL_FOR_SELECT;
-- PREPARE stmt FROM @sql;
-- EXECUTE stmt;
-- DEALLOCATE PREPARE stmt;
END