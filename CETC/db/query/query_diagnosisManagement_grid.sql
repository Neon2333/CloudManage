SELECT t1.`NO`, t2.LineName, t3.DeviceName, t4.FaultName,(CASE WHEN FaultEnable=1 THEN '使能' WHEN FaultEnable=0 THEN '禁止' END) AS FaultEnable
FROM faults_config AS t1
INNER JOIN productionline AS t2	ON t1.LineNO=t2.LineNO 
INNER JOIN device AS t3	ON t1.DeviceNO=t3.DeviceNO 
INNER JOIN faults AS t4	ON t1.FaultNO=t4.FaultNO AND t1.DeviceNO=t4.DeviceNO
ORDER BY t1.`NO`;