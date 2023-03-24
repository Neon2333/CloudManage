SELECT * FROM faults_current WHERE faults_current.`NO` NOT IN (
SELECT t1.`NO` FROM faults_current AS t1, faults_history AS t2 WHERE
t1.LineNO=t2.LineNO AND t1.DeviceNO=t2.DeviceNO AND t1.FaultNO=t2.FaultNO AND t1.FaultTime=t2.FaultTime);
