IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yf_select_Message]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yf_select_Message]
GO
CREATE PROCEDURE [dbo].[sp_yf_select_Message]
(
 @dept_id_ly varchar(20) ,--��ҩ����
 @DEPTID int,--����ID
 @FYBZ smallint,--��ҩ���  
 @SWHERE varchar(200),--��������
 @MESSAGETYPE smallint,--��Ϣ���� 0 ��ҩ 1 ��ҩ
 @funname varchar(50) --��������
)  
as

declare @ss varchar(8000)
declare @ltbz int

begin
   set @ss='select apply_id,apply_date,apply_nurse,b.dept_ly,group_id,memo,dbo.fun_getempname(cast(apply_nurse as int)) ������,'+
	'msg_type,lyflcode from jc_dept_property a ,zy_apply_drug b where a.dept_id=b.dept_ly and b.delete_bit=0 '+
	' and execdept_id='+cast(@deptid as varchar(20))+''
   if @fybz=0 
      set @ss=@ss+' and isnull(group_id,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID() '
   if @fybz=1 
      set @ss=@ss+' and isnull(group_id,dbo.FUN_GETEMPTYGUID())<>dbo.FUN_GETEMPTYGUID()'
   if  @dept_id_ly>0
      set @ss=@ss+' and dept_ly='''+rtrim(@dept_id_ly)+''''
   if @funname in ('Fun_ts_yf_zyfy_tld_by','Fun_ts_yf_zyfy_tld_by_jz')--Modify By Tany 2015-05-05 ���Ӽ��˵���������
		set @ss=@ss+' and lyflcode in(select code from JC_YPLYFLK where bybz=1) '
   else 
		set @ss=@ss+' and (lyflcode in(select code from JC_YPLYFLK where bybz<>1) or lyflcode=''99'')'
   --��ҩ����ҩ�Ƿ�ֿ�
   set @ltbz=(select zt from yk_config where bh='114' AND DEPTID=@DEPTID);
   if @ltbz is null 
     set @ltbz=0

   if @ltbz=1 
     set @ss=@ss+' and msg_type='+cast(@messagetype as varchar(10))
   else 
   if @messagetype=1 and @ltbz=0
     set @ss=@ss+' and msg_type=33'

   
   if rtrim(@swhere)<>'' 
     set @ss=@ss+@swhere
  
   set @ss=@ss+' order by  apply_date'
   print @ss
   exec(@ss)
END


GO


