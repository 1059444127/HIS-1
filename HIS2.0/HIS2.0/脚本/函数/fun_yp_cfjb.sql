IF  EXISTS (SELECT name FROM  sysobjects 
	   WHERE  name = N'fun_yp_cfjb' 
	   AND 	  type = 'FN')
  drop FUNCTION fun_yp_cfjb
go 
CREATE FUNCTION [fun_yp_cfjb] (@cfjb INT)  
RETURNS nvarchar(50) AS  
BEGIN 
 DECLARE  @mc varchar(50)
 if @cfjb=1
   set @mc='������ҽʦ'
 if @cfjb=2
   set @mc='��������ҽʦ'
 if @cfjb=3
   set @mc='����ҽʦ'
 if @cfjb=4
   set @mc='����ҽʦ'
 RETURN(@mc)
END


