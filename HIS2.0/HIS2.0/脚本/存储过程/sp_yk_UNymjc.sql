if exists(select 1 from sysobjects where name = 'sp_yk_UNymjc' and type = 'P')
	drop procedure sp_yk_UNymjc
go	

CREATE PROCEDURE sp_yk_UNymjc  --ȡ����ĩ���  
(  
 @deptid integer,  
 @DJSJ VARCHAR(30),  
 @DJY INTEGER,  
 @ERR_CODE INTEGER output,  
    @ERR_TEXT VARCHAR(100) output  
)  
as  
  
p1:begin  
 declare @yjid UNIQUEIDENTIFIER   
 declare @bbk smallint  
  
 set @yjid=dbo.FUN_GETEMPTYGUID();  
 set @Err_Code=-1;  
 set @Err_Text='';  
   
declare @tx_deptid int--ѭ���������  
  
create table #temp(deptid int)  
insert into #temp  
select dept_id from jc_dept_property where dept_id in(select deptid from yp_yjks_gx where p_deptid=@deptid)  
if @@rowcount=0  
  insert into #temp select @deptid  
--���Ҽ�ѭ��  
declare tx cursor local for  select deptid from #temp  
open  tx  
fetch next from tx into  @tx_deptid  
while @@FETCH_STATUS=0  
begin  
   --ȡ�����һ���½��ID  
  select TOP 1 @yjid=id,@bbk=bbk from yp_kjqj where deptid=@tx_deptid  order by id desc   
  if @yjid is null  
   set @yjid=dbo.FUN_GETEMPTYGUID()  
  set @bbk=coalesce(@bbk,0)  
  if @yjid=dbo.FUN_GETEMPTYGUID() or @yjid is null  
   begin  
     SET @ERR_TEXT='��Ĳ�������,��Ϊϵͳ��û���й��½�';  
     return;  
  end  
  
  if @bbk=1   
   BEGIN  
     SET @ERR_TEXT=dbo.fun_getdeptname(@tx_deptid)+'���������ѱ�ת����ʷ��¼����,����ȡ��';  
     return;  
  END       
    
  --���µ�����Ϣ  
  update yk_dj set yjid=null where deptid=@tx_deptid and yjid=@yjid  ;   
  update yf_fy set yjid=null where deptid=@tx_deptid and yjid=@yjid;   
  update yf_tld set yjid=null where deptid=@tx_deptid and yjid=@yjid;   
  delete from yk_ymjc where deptid=@tx_deptid and yjid=@yjid;   
  --ɾ���½��¼  
  delete from yp_kjqj where deptid=@tx_deptid and id=@yjid;  
    
   --ɾ���м������
   if exists(select 1 from sysobjects where name = 'YP_TJ_YMJCMX' and type = 'U')
   begin
	 delete from YP_TJ_YMJCMX where YJID = @yjid
   end 
 
  set @err_code=0;  
  set @err_text='�ϴ��½��ѱ�ȡ��';  
fetch next from tx into  @tx_deptid  
end   
  
end   
  