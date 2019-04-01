IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_ts_update_logExec' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_ts_update_logExec
GO


CREATE  PROCEDURE [dbo].SP_ts_update_logExec  
 (  
	@id UNIQUEIDENTIFIER,
	@err_code INT OUTPUT,
	@err_text varchar(50) OUTPUT
 )   
  
   
AS  
--��Ϣ����
declare @cznr varchar(300)
declare @ymc varchar(100)
declare @yzj varchar(200)
declare @mbjgbm bigint
declare @bwcbz smallint
declare @bscbz smallint
--Ŀ�������IP
declare @servername varchar(30)

BEGIN  
set @err_code=-1
set @err_text=''
select @cznr=cznr,@ymc=ymc,@yzj=yzj,@mbjgbm=mbjgbm,@bwcbz=bwcbz,@bscbz=bscbz from ts_update_log where id=@id
select @servername=ipaddr from jc_jgbm where jgbm=@mbjgbm
if (@servername='' or @servername is null)  begin  set @err_text='û���ҵ���������'+@mbjgbm+'����Ӧ��Ŀ�������IP'  end



set @err_code=0
set @err_text='ִ�гɹ�'
	
END  
  

  