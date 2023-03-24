SELECT DISTINCT t1.DeviceNO,t2.DeviceName,
(CASE WHEN t1.DeviceStatus=1 THEN '正常'
WHEN t1.DeviceStatus=0 THEN '异常'
END) AS DeviceStatus,
t3.Para1Name, t1.Para1,
t3.Para2Name, t1.Para2,
t3.Para3Name, t1.Para3,
t3.Para4Name, t1.Para4,
t3.Para5Name, t1.Para5
FROM device_info AS t1 INNER JOIN device AS t2 ON t1.DeviceNO=t2.DeviceNO
INNER JOIN device_info_paranameandsuffix AS t3 ON t1.DeviceNO=t3.DeviceNO
WHERE t1.LineNO='001'
ORDER BY t1.`NO`;