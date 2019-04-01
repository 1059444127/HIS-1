IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_YK_DJ_INSERTFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_YK_DJ_INSERTFOREVENTLOG]
GO
--Add By Tany 2014-04-16 ״̬��������¼���
CREATE TRIGGER [dbo].[TR_YK_DJ_INSERTFOREVENTLOG]
	ON [dbo].[YK_DJ] 
	AFTER INSERT,UPDATE
AS   
SET NOCOUNT ON

declare @shbz int
declare @ywlx varchar(3)

select @shbz=shbz,@ywlx=ywlx from inserted

if(UPDATE(shbz))
begin
	if(@ywlx in ('001','002') and @shbz=0)
	begin
	
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YK_DJ','YK_DJ',ID from inserted

	end
	--else if(@ywlx not in ('001','002') and @shbz=1)
	else if(@ywlx not in ('001','002','009','012') and @shbz=1)
	begin
	
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YK_DJ','YK_DJ',ID from inserted
	end
	
	--Add By Tany 2015-03-04 ����ҩ�����쵥
	--update By py 2015-05-11 ����ҩ�����쵥 @shbz=1ʱ����
	if(@ywlx in ('004') and @shbz=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'YP_QLD_ZNYK','YK_DJ',ID from inserted
	end
end



