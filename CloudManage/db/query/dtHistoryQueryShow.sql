SELECT t1.`NO`,t2.LineName,t3.DeviceName,t4.FaultName,t1.FaultTime
FROM faults_history AS t1 
INNER JOIN productionline AS t2 
INNER JOIN device AS t3
INNER JOIN faults AS t4
ON t1.LineNO=t2.LineNO
AND t1.DeviceNO=t3.DeviceNO
AND t1.DeviceNO=t4.DeviceNO
AND t1.FaultNO=t4.FaultNO
ORDER BY t1.`NO`;