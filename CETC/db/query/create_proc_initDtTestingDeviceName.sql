DROP PROCEDURE IF EXISTS initDtTestingDeviceName;
CREATE PROCEDURE `initDtTestingDeviceName`()
BEGIN
	SELECT * FROM device;
END