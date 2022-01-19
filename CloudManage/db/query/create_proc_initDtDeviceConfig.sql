DROP PROCEDURE IF EXISTS initDtDeviceConfig()
CREATE PROCEDURE initDtDeviceConfig()
BEGIN
	SELECT * FROM device_config;

END