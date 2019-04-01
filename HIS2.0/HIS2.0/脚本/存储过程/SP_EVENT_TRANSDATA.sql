IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_EVENT_TRANSDATA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_EVENT_TRANSDATA]
GO
CREATE PROCEDURE [dbo].[SP_EVENT_TRANSDATA]  
as   
begin  
/*  
CREATE BY TANY 2016-01-12  
�ò���ת��EVENTLOG����  
*/  
 declare @oldrowcount bigint   
 declare @newrowcount bigint   
 declare @date datetime  
 declare @day int  
  
 set @day=3
 set @date=convert(datetime,dateadd(dd,-@day,getdate()))   
----------------------------------------------------------------  
 
 begin tran  
 --ת�Ʊ�  
 insert into eventlog_h(ID, EVENT, CATEGORY, BIZID, MESSAGE, TS, ENABLE, RETURNDESC, FINISH, FINISH_DATE)  
 select ID, EVENT, CATEGORY, BIZID, MESSAGE, TS, ENABLE, RETURNDESC, FINISH, FINISH_DATE
 from eventlog   
 where ts<@date
 set @oldrowcount = @@rowcount  
 --ɾ����  
 delete eventlog where ts<@date
 set @newrowcount = @@rowcount  
 --�˶�ת�Ƽ�¼��  
 if(@oldrowcount <> @newrowcount)  
 begin  
  rollback  
  return  
 end  
 commit  
----------------------------------------------------------------  
  
 begin tran  
 --ת�Ʊ�  
 insert into eventlog_mz_h(ID, EVENT, CATEGORY, BIZID, MESSAGE, TS, ENABLE, RETURNDESC, FINISH, FINISH_DATE)  
 select ID, EVENT, CATEGORY, BIZID, MESSAGE, TS, ENABLE, RETURNDESC, FINISH, FINISH_DATE
 from eventlog_mz   
 where ts<@date
 set @oldrowcount = @@rowcount  
 --ɾ����  
 delete eventlog_mz where ts<@date
 set @newrowcount = @@rowcount  
 --�˶�ת�Ƽ�¼��  
 if(@oldrowcount <> @newrowcount)  
 begin  
  rollback  
  return  
 end  
 commit   

end  

GO


