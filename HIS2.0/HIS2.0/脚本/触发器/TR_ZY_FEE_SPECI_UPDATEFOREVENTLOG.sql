IF  EXISTS (SELECT * FROM SYS.TRIGGERS WHERE OBJECT_ID = OBJECT_ID(N'[DBO].[TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG]'))
DROP TRIGGER [DBO].[TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG]
GO
--Add By Tany 2014-04-16 ״̬��������¼���
CREATE TRIGGER TR_ZY_FEE_SPECI_UPDATEFOREVENTLOG
	ON ZY_FEE_SPECI 
	AFTER UPDATE
AS   
SET NOCOUNT ON

--���ӷ�����Ϣ�¼� Modify By Tany 2014-11-01
IF(UPDATE(charge_bit))
BEGIN
	IF exists(select 1 from inserted where charge_bit=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'n2oFyxx.HIS','ZY_FEE_SPECI',id from inserted 
		where charge_bit=1 
		and (CHARINDEX('��ϵͳ����',isnull(BZ,''))=0 and CHARINDEX('��ʷ��ת��',isnull(BZ,''))=0)--�����ע������ϵͳ���˵Ļ�Ҳ���������ϵͳ����Ҫ������ϵͳҽ������ Modify By Tany 2014-11-23
	end
END

IF(UPDATE(fy_bit))
BEGIN
	IF exists(select 1 from inserted where FY_BIT=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'FYZT','ZY_FEE_SPECI',id from inserted 
		where fy_bit=1
	end
END

--����ɾ�������¼�����Ҫ��ҽ����������� Modify By Tany 2015-06-02
IF(UPDATE(delete_bit))
BEGIN
	IF exists(select 1 from inserted where delete_bit=1)
	begin
		insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
		select 'DEL_DETAILFEE','ZY_FEE_SPECI',id from inserted 
		where delete_bit=1
	end
END