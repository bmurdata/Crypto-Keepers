/****** Object:  StoredProcedure [dbo].[alertbot]    Script Date: 3/12/2021 9:23:25 AM ******/

CREATE PROCEDURE [dbo].[alertbot]
AS
select top 1 types.typename, concern, flags.flagname, priorities.priorityname, entities.entityname, coins.coinname from alerts left outer JOIN types ON alerts.type=types.id left outer JOIN flags ON alerts.type=flags.id left outer JOIN priorities ON alerts.type=priorities.id left outer JOIN entities ON alerts.type=entities.id left outer JOIN coins ON alerts.type=coins.id ORDER BY alerts.id DESC