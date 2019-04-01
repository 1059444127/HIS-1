IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SP_MZYS_SelectYZxm]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_MZYS_SelectYZxm] 
GO
create PROCEDURE SP_MZYS_SelectYZxm  
 (      
   @all int ,--����ҩƷ����Ŀ  1 ���� 0  ʵʱ��ѯ ���¸��� @all=0 ʱ��Ч    
   @xmly int, --0 ȫ�� 1 ҩƷ 2 ��Ŀ      
   @zyyf int,--�Ƿ����סԺҩ�� 1 ����    
   @execdept int , --ִ�п���,  
   @deptid int,--��ǰ���� Modify by Tany 2009-02-09 ���ڿ���ҩ����Ӧ  
   @pym varchar(50),    
   @wbm varchar(50),    
   @itemname varchar(50),  
   @jgbm bigint, --��������    
   @kzsj smallint, --����ʱ�� 1��ʾ����ʱ��  
   @funname varchar(50)  
 )     
as    
/*-------------    
������Ŀ��ҩƷ    
-------------*/    
--exec SP_MZYS_SelectYZxm 1,0,0,0,0,'','','' ,1003 ,1,''  
declare @s1 varchar(5000)    
declare @s2 varchar(5000)    
declare @s3 varchar(5000)    
declare @top varchar(30)    
set @top=''  
declare @strkcl varchar(20)  
declare @jzks smallint  
set @jzks=0  
--Add By Zj 2012-02-29  
declare @xnkclconfig int   
 set @xnkclconfig=0  
--Add By Zj 2012-05-09 ���ƿ�����ҩ  
declare @ksyyxz varchar(200)  
if EXISTS(select CONFIG from JC_CONFIG where ID=3038)  
 set @ksyyxz=(select CONFIG from JC_CONFIG where ID=3038)  
if @ksyyxz='1'  
 set @ksyyxz=' and a.cjid not in ( select cjid from jc_yp_dept where dept_id='+cast(@deptid as varchar(50))+') '  
else  
 set @ksyyxz=''  
if EXISTS(select dept_id from JC_DEPT_TYPE_RELATION where dept_id=@deptid and type_code='003')  
 set @jzks=1  
if @all=0 and (@pym<>'' or @wbm<>'' or @itemname<>'')    
   set @top=' top 50 '    
--����ҽ��վ�Ƿ�����ҩ������  
  
if EXISTS(select CONFIG from JC_CONFIG where ID=3029)  
   set @xnkclconfig=(select CONFIG from JC_CONFIG where ID=3029)  
--������������� ����kcl  
if @xnkclconfig=0  
  set @strkcl='kcl'  
else  
  set @strkcl='xnkcl'  
    
BEGIN     
	--kslx2 �޸�Ϊ  ''����ҩ��'' kslx2��whzxyy������ǰ̨���˴�д������
  set @s1=' select '+@top+' null ���,0 �ײ�,(rtrim(a.yppm)+isnull(ypspmbz,'''') +''  ''+s_ypgg) ��Ŀ����,s_ypjx ���� , a.ggid as  yzid,a.yppm as yzmc,   
  lsj ����,rtrim(s_ypdw) ��λ,rtrim(cast(cast('+@strkcl+' as float) as varchar(50)))+rtrim(dbo.fun_yp_ypdw(zxdw)) ���,    
  '''' ҽ������,dbo.fun_getdeptname(deptid) ִ�п���,deptid zxksid,b.pym ƴ����,b.wbm �����,a.cjid ��Ŀid,1 ��Ŀ��Դ ,  
  statitem_code,''����ҩ��'' kslx2,a.ggid,len(pym) bmcd   
 from VI_YF_KCMX a (nolock),yp_ypbm b  (nolock)     
    where a.ggid=b.ggid and a.bdelete_kc=0 '    
   if rtrim(@funname)='Fun_ts_mzys_blcflr' set @s1=@s1+ ' and '+@strkcl+'>0 ' --�������������ҽ����������¼�� �Ͳ����ƿ��������0��ҽ��  
   if rtrim(@pym)<>'' set @s1=@s1+' and b.pym like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s1=@s1+' and wbm like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s1=@s1+' and ypbm like ''%'+@itemname+'%'''    
   --Add By Zj 2012-05-10   
   if RTRIM(@ksyyxz)<>'' set @s1=@s1+@ksyyxz  
     
   if @execdept>0 and @zyyf=0    
  set @s1=@s1+' and deptid='+cast(@execdept as varchar(10))+''    
   if @all<>1 --��������ʱ    
   begin    
   if @zyyf=1    
        set @s1=@s1+' and kslx2=''סԺҩ��'''    
   else     
       set @s1=@s1+' and kslx2=''����ҩ��'''    
   end    
  
   --���ݵ�ǰ���ҵ�ҩ����Ӧ��ϵ�����ҿ��Ի��۵�ҩ��  
    
   set @s1=@s1+' and deptid in (select drugstore_id from   
 jc_dept_drugstore where delete_bit=0 and dept_id='+cast(@deptid as varchar(10))+' and  convert(nvarchar,getdate(),108)>=convert(nvarchar,kssj,108)  
  and convert(nvarchar,getdate(),108)<=convert(nvarchar,jssj,108) )'    
  
    
   set @s2='select distinct '+@top+' null ���,0 �ײ�,rtrim(c.order_name)+'' ''+isnull(c.bz,'''') as  ��Ŀ����,'''' ����, c.order_id as yzid,c.order_name as yzmc,    
   E.price ����,rtrim(item_unit) ��λ,null ���,    
   '''' ҽ������,dbo.fun_getdeptname(f.exec_dept) ִ�п���,f.exec_dept as zxksid,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,a.item_id ��Ŀid,2 ��Ŀ��Դ ,  
   statitem_code,'''' kslx2 ,0 ggid ,len(c.py_code) bmcd  
   from jc_hsitem a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=0  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join JC_STAT_ITEM d on a.statitem_code=d.code   
   inner join jc_hsitemprice e(nolock) on a.item_id=e.hsitemid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
   where c.delete_bit=0 and  (  
 (f.JGBM is null and e.jgbm='+cast(@jgbm as varchar(30))+') or (f.jgbm='+cast(@jgbm as varchar(30))+' and e.jgbm='+cast(@jgbm as varchar(30))+')   
 )'  
  
   if rtrim(@pym)<>'' set @s2=@s2+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s2=@s2+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s2=@s2+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
   set @s2=@s2+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
    set @s2=@s2+'union all select distinct '+@top+' null ���,0 �ײ�,rtrim(c.order_name)+'' ''+isnull(c.bz,'''') as  ��Ŀ����,'''' ����, c.order_id as yzid,c.order_name as yzmc,    
   E.price ����,rtrim(item_unit) ��λ,null ���,    
   '''' ҽ������,dbo.fun_getdeptname(f.exec_dept) ִ�п���,f.exec_dept as zxksid,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,a.item_id ��Ŀid,2 ��Ŀ��Դ ,  
   statitem_code,'''' kslx2 ,0 ggid ,len(c.py_code) bmcd  
   from jc_hsitem a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=0  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join JC_STAT_ITEM d on a.statitem_code=d.code   
   inner join jc_hsitemprice e(nolock) on a.item_id=e.hsitemid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
   where c.delete_bit=0 and  (  
   (  
 f.jgbm <>'+cast(@jgbm as varchar(30))+' and e.jgbm<>'+cast(@jgbm as varchar(30))+' and f.order_id not in(select order_id from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id and b.jgbm='+cast(@jgbm as varchar(30))+')  
 )   
 )'  
  
   if rtrim(@pym)<>'' set @s2=@s2+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s2=@s2+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s2=@s2+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
   set @s2=@s2+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
  
    
   set @s3='select distinct '+@top+' null ���,item_id �ײ�,''[�ײ�] ''+rtrim(order_name) ��Ŀ����,'''' ����, c.order_id as yzid,c.order_name as yzmc,    
   e.price ����,rtrim(item_unit) ��λ,null ���,    
   '''' ҽ������,dbo.fun_getdeptname(f.exec_dept) ִ�п���,f.exec_dept as zxksid,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,item_id ��Ŀid,2 ��Ŀ��Դ,  
   '''' statitem_code, '''' kslx2,0 ggid  ,len(c.py_code) bmcd  
   from jc_tc_t a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=1  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join jc_tcprice e on a.item_id=e.tcid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
    where c.delete_bit=0 and  (  
 (f.JGBM is null and e.jgbm='+cast(@jgbm as varchar(30))+') or (f.jgbm='+cast(@jgbm as varchar(30))+' and e.jgbm='+cast(@jgbm as varchar(30))+')   
  )'  
     
 if rtrim(@pym)<>'' set @s3=@s3+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s3=@s3+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s3=@s3+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
      set @s3=@s3+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
     set @s3=@s3+' union all select distinct '+@top+' null ���,item_id �ײ�,''[�ײ�] ''+rtrim(order_name) ��Ŀ����,'''' ����, c.order_id as yzid,c.order_name as yzmc,    
   e.price ����,rtrim(item_unit) ��λ,null ���,    
   '''' ҽ������,dbo.fun_getdeptname(f.exec_dept) ִ�п���,f.exec_dept as zxksid,rtrim(c.py_code) ƴ����,rtrim(c.wb_code) �����,item_id ��Ŀid,2 ��Ŀ��Դ,  
   '''' statitem_code, '''' kslx2,0 ggid  ,len(c.py_code) bmcd  
   from jc_tc_t a(nolock) inner join  jc_hoi_hdi b(nolock) on a.item_id=b.hditem_id and b.tc_flag=1  
   inner join jc_hoitemdiction c(nolock) on b.hoitem_id=c.order_id   
   inner join jc_tcprice e on a.item_id=e.tcid  
   left join (select a.*,jgbm from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id  ) f on c.order_id=f.order_id  
    where c.delete_bit=0 and  (  
 (  
 f.jgbm <>'+cast(@jgbm as varchar(30))+' and e.jgbm<>'+cast(@jgbm as varchar(30))+' and f.order_id not in(select order_id from jc_hoi_dept a inner join jc_dept_property b on a.exec_dept=b.dept_id and b.jgbm='+cast(@jgbm as varchar(30))+')  
 ) )'  
     
 if rtrim(@pym)<>'' set @s3=@s3+' and  c.py_code like '''+@pym+'%'''    
   if rtrim(@wbm)<>'' set @s3=@s3+' and c.wb_code like '''+@wbm+'%'''    
   if rtrim(@itemname)<>'' set @s3=@s3+' and c.order_name like ''%'+@itemname+'%'''    
   if @execdept>0    
      set @s3=@s3+' and f.exec_dept='+cast(@execdept as varchar(10))+''    
  
    
  
if @all=1     
begin    
 exec(@s1+' union all '+@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 print @s1+' union all '+@s2+' union all '+@s3    
 return    
end     
    
if @xmly=1    
begin    
  exec(@s1)    
  --print(@s1)    
  return    
end    
    
if @xmly=2    
begin    
 exec(@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 --print(@s2+' union all '+@s3)    
 return    
end    
    
if @xmly=0    
begin    
 exec(@s1+' union all '+@s2+' union all '+@s3+' ORDER BY STATITEM_CODE ASC')    
 --print @s1+' union all '+@s2+' union all '+@s3    
 return    
end    
END  
    
    