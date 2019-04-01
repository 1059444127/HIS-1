IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SP_YJ_SELECT_MZ]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE SP_YJ_SELECT_MZ
GO 
CREATE PROCEDURE [dbo].[SP_YJ_SELECT_MZ]            
 (              
 @execdept int,--ִ�п���            
 @blh varchar(50),--�Һ���ϢID            
 @BRXXID UNIQUEIDENTIFIER,            
 @RQLX INT,-- 0 �շ����� 1ȷ������            
 @RQ1 varchar(30),--            
 @RQ2 varchar(30),--            
 @BRXM VARCHAR(50),            
 @FPH VARCHAR(50),            
 @jgbm bigint ,            
 @tmdybz smallint,--�����ӡ��־            
 @btf int            
 )             
as            
/*-------------            
exec SP_YJ_SELECT_MZ 0,null,null,0,'2010-05-30 00:00:01','2010-05-30 23:00:00','','',1001 ,0,0    
���ӱ걾����ʱ���ѯ�� Modify By Daniel 2015-02-03         
-------------*/            
--ֻ��ʾ��ִ�е���Ŀ onece007 2012-06-20 ���            
declare @yjbz int            
set @yjbz= (select YJ_FLAG from JC_DEPT_PROPERTY where DEPT_ID=@execdept)--end            
declare @s1 varchar(8000)            
declare @s2 varchar(8000)            
set @s1='select null ���,0 ѡ��,a.blh �����,a.fph ��Ʊ��,brxm ����,rtrim(pm) ��Ŀ����,gg ���,            
cast(dj as decimal(15,2)) ����,cast(cast(sl as float) as varchar(30)) ����,dw ��λ,            
cast(je as decimal(15,2))  ���,a.sfrq �շ�ʱ��,dbo.fun_getdeptname(a.ksdm) ��������,dbo.fun_getempname(a.ysdm) ����ҽ��            
,dbo.fun_getdeptname(a.zxks) Ĭ��ִ�п���,QRSJ ȷ��ʱ��,dbo.fun_getempname(qrdjy) ȷ����,dbo.fun_getdeptname(qrks) ȷ�Ͽ���,a.cfid,cfmxid,tcid,qrks qrksid   ,b.ZT   ,e.kh ����       
from mz_cfb a(NOLOCK)  inner join mz_cfb_mx b(NOLOCK)             
on a.cfid=b.cfid inner join mz_fpb c(NOLOCK) on a.fpid=c.fpid    
inner join mz_ghxx d (NOLOCK) on a.ghxxid = d.ghxxid 
inner join YY_KDJB e (NOLOCK) on d.kdjid = e.kdjid        
where  tcid=0  and xmly<>1  and c.bghpbz=0  '            
--ֻ��ʾ��ִ�е���Ŀ onece007 2012-06-20 ���begin            
if @yjbz=1            
 set @s1=@s1+' and a.zxks='+cast(@execdept as varchar(50))--end            
if @blh<>''            
 set @s1=@s1+' and a.blh='''+@blh+''''            
if @brxxid<>dbo.FUN_GETEMPTYGUID()            
 set @s1=@s1+' and a.brxxid='''+cast(@brxxid  as varchar(100))+''''            
if @rqlx=0                
 set @s1=@s1+' and bqrbz=0 and a.sfrq>='''+@RQ1+''' and a.sfrq<='''+@rq2+''' and             
  (a.zxks='+cast(@execdept as varchar(20))+'  or a.zxks<=0 ) '            
else             
begin            
 if @rqlx=1            
 set @s1=@s1+' and bqrbz=1 and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+'''  and qrks='+cast(@execdept as varchar(20))            
 else             
    set @s1=@s1+' and bqrbz=1 and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+''' and qrks<>'+cast(@execdept as varchar(20))            
end             
IF @BRXM<>'' AND @BRXM LIKE '%[0-9a-zA-Z]%'            
    SET @S1=@S1+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or dbo.GETPYWB(C.BRXM,0) like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @BRXM<>'' AND @BRXM NOT LIKE '%[0-9a-zA-Z]%'        
 SET @s1 = @s1 + ' AND ( C.BRXM like ''%' + CAST(@BRXM AS VARCHAR(30)) + '%'')'         
IF @FPH<>''            
  set @s1=@s1+' and A.FPH='''+cast(@FPH  as varchar(30))+''''            
if @btf=1             
    set @s1=@s1+' and je<0 '            
set @s2='select null ���,0 ѡ��,a.blh �����,a.fph ��Ʊ��,brxm ����,rtrim(item_name) ��Ŀ����,null ���,            
cast(cast(sum(je)/js as float) as decimal(15,2)) ����,cast(cast(b.js as float) as varchar(30)) ����,rtrim(item_unit) ��λ,            
cast(sum(je) as decimal(15,2))  ���,a.sfrq �շ�ʱ��,dbo.fun_getdeptname(a.ksdm) ��������,dbo.fun_getempname(a.ysdm) ����ҽ��            
,dbo.fun_getdeptname(a.zxks) Ĭ��ִ�п���,QRSJ ȷ��ʱ��,dbo.fun_getempname(qrdjy) ȷ����,dbo.fun_getdeptname(qrks) ȷ�Ͽ���,a.cfid,dbo.FUN_GETEMPTYGUID() cfmxid,tcid,qrks qrksid ,b.ZT ,f.kh ����               
from mz_cfb a(NOLOCK)  inner join mz_cfb_mx b (NOLOCK)            
on a.cfid=b.cfid inner join mz_fpb c(NOLOCK) on a.fpid=c.fpid left join jc_tc_t d(NOLOCK) on b.tcid=d.item_id   
inner join mz_ghxx e (NOLOCK) on a.ghxxid = e.ghxxid 
inner join YY_KDJB f (NOLOCK) on e.kdjid = f.kdjid              
where  tcid>0  and xmly<>1   '            
if @blh<>''            
 set @s2=@s2+' and a.blh='''+@blh+''''            
if @brxxid<>dbo.FUN_GETEMPTYGUID()            
 set @s2=@s2+' and a.brxxid='''+cast(@brxxid as varchar(100))+''''            
if @rqlx=0            
 set @s2=@s2+' and bqrbz=0 and a.sfrq>='''+@RQ1+''' and a.sfrq<='''+@rq2+''' and             
   (a.zxks='+cast(@execdept as varchar(20))+'  or a.zxks<=0 ) '            
else             
begin            
  if @rqlx=1            
 set @s2=@s2+' and bqrbz=1  and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+'''  and qrks='+cast(@execdept as varchar(20))            
  else             
    set @s2=@s2+' and bqrbz=1  and QRSJ>='''+@RQ1+''' and QRSJ<='''+@rq2+''' and qrks<>'+cast(@execdept as varchar(20))            
end         
IF @BRXM<>'' AND @BRXM LIKE '%[0-9a-zA-Z]%'            
    SET @S2=@S2+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or dbo.GETPYWB(C.BRXM,0) like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @BRXM<>'' AND @BRXM NOT LIKE '%[0-9a-zA-Z]%'        
 SET @S2 = @S2 + ' AND ( C.BRXM like ''%' + CAST(@BRXM AS VARCHAR(30)) + '%'')'            
--IF @BRXM<>''            
--  SET @S2=@S2+' AND ( C.BRXM like ''%'+CAST(@BRXM AS VARCHAR(30))+'%'' or  dbo.GETPYWB(C.BRXM,0)like ''%'+@brxm+'%''  or  dbo.GETPYWB(C.BRXM,1) like ''%'+@brxm+'%'')'            
IF @FPH<>''            
  set @s2=@s2+' and A.FPH='''+cast(@FPH  as varchar(30))+''''            
set @s2=@s2+' group by a.cfid,tcid,a.blh,a.fph,brxm,item_name,js,item_unit,a.ksdm,a.ysdm,a.zxks,a.sfrq,QRSJ,qrks,qrdjy ,b.ZT ,f.kh '            
            
if @btf=1            
  set @s2=@s2+' having sum(je)<0 '         
  PRINt(@s1+' union all '+@s2 +' order by ��Ʊ�� ')    
exec(@s1+' union all '+@s2 +' order by ��Ʊ�� ')            
declare @jyks varchar(50)            
declare @qfks varchar(50)            
set @jyks=(select config from jc_config where id=10005)            
set @qfks=(select config from jc_config where id=10004)            
if  PATINDEX('%'+rtrim(@execdept)+'%',@qfks)>0  and  (@blh<>'' or @brxxid<>dbo.FUN_GETEMPTYGUID() or @FPH<>'')            
begin            
DECLARE @LGBR VARCHAR(225)          
SET @LGBR = (SELECT CONFIG FROM dbo.JC_CONFIG WHERE id=10018)           
IF(@LGBR='0')          
begin          
  set @s1='            
   select '''' ���,blh �����,brxm ����,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա�,            
   dbo.fun_zy_age(csrq,3,getdate()) ����,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  ��Ŀ����,sl ����,dw ��λ,je ���    
   ,dbo.fun_getdeptname(zxks) ִ�п���,SQRQ as ����ʱ��,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''��ɫ''            
   WHEN ''brown'' then ''��ɫ''            
   WHEN ''blue'' then ''��ɫ''            
   WHEN ''black'' then ''��ɫ''            
   WHEN ''purple'' then ''��ɫ''            
   WHEN ''green'' then ''��ɫ''            
   WHEN ''gray'' THEN ''��ɫ''              
   WHEN ''orange'' THEN ''�ٺ�ɫ''             
   WHEN ''yellow'' THEN ''��ɫ''             
   ELSE  color.COLOR  END            
   ) COLOR,              
   rtrim(d.name) AS ��������,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) �걾,        
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as ���,txm ����,  a.BBCJSJ as �걾�ɼ�ʱ��, a.BBJJSJ as �걾����ʱ��,         
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) ѡ��,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) ����            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   where zxks in( '+cast(@jyks as varchar(30)) +') and sfrq>='''+@rq1+''' and sfrq<='''+@rq2+''' and bsfbz=1 and bqxsfbz=0 and a.bscbz=0 '          
   if @blh<>''--and e.flid is not null            
  set @s1=@s1+' and blh='''+@blh+''''            
   if @BRXXID<>dbo.FUN_GETEMPTYGUID()            
  set @s1=@s1+' and b.brxxid='''+cast(@BRXXID as varchar(100))+''''            
   if @FPH<>''            
        set @s1=@s1+' and A.yzid in(select hjid from mz_cfb where fph='''+cast(@FPH  as varchar(30))+''')'            
   if @tmdybz=0            
  set @s1=@s1+' and txm is null '            
   else            
       set @s1=@s1+' and txm is not null '    
        PRINt(@s1+' order by b.brxxid,txm,e.flid,d.name,SAMP_NAME')        
   exec(@s1+' order by b.brxxid,txm,e.flid,d.name,SAMP_NAME')           
end            
ELSE           
BEGIN          
SET @s1='select DISTINCT * from (          
   select '''' ���,blh �����,brxm ����,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա�,            
   dbo.fun_zy_age(csrq,3,getdate()) ����,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  ��Ŀ����,sl ����,dw ��λ,je ���,dbo.fun_getdeptname(zxks) ִ�п���,SQRQ as ����ʱ��,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''��ɫ''            
   WHEN ''brown'' then ''��ɫ''            
   WHEN ''blue'' then ''��ɫ''            
   WHEN ''black'' then ''��ɫ''            
   WHEN ''purple'' then ''��ɫ''            
   WHEN ''green'' then ''��ɫ''            
   WHEN ''gray'' THEN ''��ɫ''              
   WHEN ''orange'' THEN ''�ٺ�ɫ''             
   WHEN ''yellow'' THEN ''��ɫ''             
   ELSE  color.COLOR  END            
   ) COLOR,             
   rtrim(d.name) AS ��������,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) �걾,      
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as ���,txm ����,            
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) ѡ��,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) ����            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   where zxks in( '+cast(@jyks as varchar(30)) +') and sfrq>='''+@rq1+''' and sfrq<='''+@rq2+''' and bsfbz=1 and bqxsfbz=0 and a.bscbz=0            
   union all           
   select '''' ���,a.blh �����,brxm ����,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա�,            
   dbo.fun_zy_age(csrq,3,getdate()) ����,(case when item_alias='''' or item_alias is null then sqnr else item_alias end)  ��Ŀ����,sl ����,dw ��λ,je ���,dbo.fun_getdeptname(zxks) ִ�п���,SQRQ as ����ʱ��,a.BQSBZ,            
   (            
   CASE color.COLOR             
   WHEN ''red'' then ''��ɫ''            
   WHEN ''brown'' then ''��ɫ''            
   WHEN ''blue'' then ''��ɫ''            
   WHEN ''black'' then ''��ɫ''            
   WHEN ''purple'' then ''��ɫ''            
   WHEN ''green'' then ''��ɫ''            
   WHEN ''gray'' THEN ''��ɫ''              
   WHEN ''orange'' THEN ''�ٺ�ɫ''             
   WHEN ''yellow'' THEN ''��ɫ''             
   ELSE  color.COLOR  END            
   ) COLOR,             
   rtrim(d.name) AS ��������,        
   rtrim(isnull(case when rtrim(a.bbmc)='''' then null else  rtrim(a.bbmc) end,SAMP_NAME)) �걾,        
           
   isnull(cast(e.flid as varchar(100)),a.yjsqid) as ���,txm ����,            
   (case when txm is null  then cast(1 as smallint) else cast(0 as smallint) end) ѡ��,yjsqid,a.brxxid,dbo.fun_getdeptname(sqks) ����            
   from yj_mzsq  a inner join yy_brxx b on a.brxxid=b.brxxid             
   left join (select b.COLOR,a.YZXMID from JC_JYBBFLMX a inner join  JC_JYBBFL b on a.FLID = b.ID) color on a.yzxmid=color.yzxmid            
   left join (select a.*,b.SAMP_NAME from jc_assay a left join LS_AS_SAMPLE b on a.bbid=b.SAMP_code) c on a.yzxmid=c.yzid            
   left join jc_jcclassdiction d on c.hylxid=d.id             
   left join JC_JYBBFLMX e on a.yzxmid=e.yzxmid            
   left join jc_jyxm_bm F on a.yzxmid=f.hoitem_id and f.delete_bit=0           
   INNER JOIN MZ_QUARTERS h ON a.GHXXID = h.GHXXID AND h.STATE=0          
   where zxks in( '+cast(@jyks as varchar(30)) +') and a.bscbz=0) aa where 1=1 '            
   if @blh<>''--and e.flid is not null            
  set @s1=@s1+' and �����='''+@blh+''''            
   if @BRXXID<>dbo.FUN_GETEMPTYGUID()            
  set @s1=@s1+' and brxxid='''+cast(@BRXXID as varchar(100))+''''            
   if @FPH<>''            
        set @s1=@s1+' and yzid in(select hjid from mz_cfb where fph='''+cast(@FPH  as varchar(30))+''')'            
   if @tmdybz=0            
  set @s1=@s1+' and ���� is null '            
   else            
        set @s1=@s1+' and ���� is not null '           
     PRINT(@s1+' order by  brxxid,����')        
   exec(@s1+' order by  brxxid,����')              
 end          
             
end 