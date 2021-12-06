DROP PROCEDURE IF EXISTS queryDtHistoryValid;
CREATE PROCEDURE queryDtHistoryValid()
BEGIN
SELECT t1.* FROM faults_current AS t1 
INNER JOIN faults_config AS t2 
ON t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO AND t1.FaultNO=t2.FaultNO AND t2.FaultEnable='1';
END