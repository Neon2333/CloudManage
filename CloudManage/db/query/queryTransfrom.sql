SELECT t1.LineNO,t2.DeviceNO,t3.FaultNO
FROM productionline AS t1, device AS t2, faults AS t3
WHERE t1.LineName='1号车' AND t2.DeviceName='模盒缺支检测' AND t3.FaultName='故障003-1';