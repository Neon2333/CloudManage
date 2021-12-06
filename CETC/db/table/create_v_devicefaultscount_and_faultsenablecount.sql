DROP VIEW IF EXISTS v_devicefaultscount_and_faultsenablecount;
CREATE VIEW v_devicefaultscount_and_faultsenablecount AS
SELECT t2.LineNO, t2.DeviceNO, COUNT(t2.FaultNO) AS DeviceFaultsCount, COUNT(t2.FaultEnable) AS DeviceFaultsEnableCount 
FROM faults AS t1 INNER JOIN faults_config AS t2 ON t1.DeviceNO=t2.DeviceNO AND t1.FaultNO=t2.FaultNO GROUP BY t2.LineNO,t2.DeviceNO;