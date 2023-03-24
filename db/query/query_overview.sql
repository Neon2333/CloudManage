SELECT LineName, 
(CASE WHEN COUNT(FaultTime)>0 THEN '异常' 
WHEN COUNT(FaultTime)=0 THEN '正常'
END) AS LineStatus
FROM productionline AS t1 LEFT JOIN faults_history AS t2
ON t1.LineNO=t2.LineNO
GROUP BY LineName
ORDER BY t1.`NO`;
