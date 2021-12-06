DROP PROCEDURE IF EXISTS initDtProductionLine;
CREATE PROCEDURE `initDtProductionLine`()
BEGIN
	SELECT * FROM productionline;
END