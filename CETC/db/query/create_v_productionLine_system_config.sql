DROP VIEW IF EXISTS v_productionLine_system_config;
CREATE VIEW v_productionLine_system_config AS
SELECT t1.`NO`, t1.LineNO, t1.LineName, t2.DeviceCount AS DeviceCountEachLine FROM productionline AS t1 INNER JOIN v_device_count_eachline AS t2
ON t1.LineNO=t2.LineNO;

