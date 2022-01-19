DROP PROCEDURE IF EXISTS insertFaultsHistory;
CREATE PROCEDURE insertFaultsHistory(valLineNO VARCHAR(20), valDeviceNO VARCHAR(20), valFaultNO VARCHAR(20), valFaultTime VARCHAR(20))
BEGIN
	INSERT INTO faults_history (LineNO, DeviceNO, FaultNO, FaultTime) VALUES (valLineNO, valDeviceNO, valFaultNO, valFaultTime);
END