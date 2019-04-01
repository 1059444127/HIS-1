if exists (select * from sysobjects 
           where name = N'SP_YF_SELECT_MZCF_CX'
           and type = 'P')
   drop proc SP_YF_SELECT_MZCF_CX
go
  /*
  exec SP_YF_SELECT_MZCF_CX 'Fun_ts_yf_mzcfcx',424,'','','',2,'','',0,0,'2014/10/1 0:00:00','2014/10/2 23:59:59',0,1,'',1,0,0
  */
create PROCEDURE [dbo].[SP_YF_SELECT_MZCF_CX]  
 (  
  @functionName varchar(30),--���캯��  
 @deptid INTEGER,--ҩ������  
 @blh varchar(50),--������  
 @hzxm varchar(12),--��������  
 @FPH varchar(50),    --��Ʊ��  
    @klx int,  
 @kh  varchar(50),  
    @zdmc varchar(50),   
    @je1 decimal(15,1),  
    @je2 decimal(15,1),  
 @QRRQ1 VARCHAR(30),--��ҩ����  
 @QRRQ2 VARCHAR(30),--��ҩ����  
 @QRCZYH INT,--��ҩ����Ա  
 @fybz smallint,--��ҩ��־  
    @where varchar(500),  
 @bk int,  
    @ksdm int,  
    @ysdm int  
 )   
as  
begin  
    
 declare @table_fy varchar(100);  
 declare @table_fymx varchar(100);  
 declare @ssql varchar(8000);  
 declare @tlfl varchar(30)  
  
 SET @table_fy='vi_YF_FY';  
 SET @table_fymx='vi_YF_FYMX';   
IF @bk=1   
begin  
   SET @table_fy='vi_YF_FY';  
   SET @table_fymx='vi_YF_FYMX'  
end  
  
create table #TEMP  
(  
ID  UNIQUEIDENTIFIER,  
xh UNIQUEIDENTIFIER,  
binid UNIQUEIDENTIFIER,  
fph varchar(50),  
��Ŀ varchar(50),   
zje decimal(15,1),  
jzje decimal(15,1),  
yhje decimal(15,1),  
zfje decimal(15,1),  
hzxm varchar(50),  
blh varchar(50),  
xb varchar(50),  
nl varchar(50),  
zdmc varchar(60),  
ksdm int,  
���� varchar(50),  
ysdm int,  
ҽ�� varchar(50),  
lrrq datetime,  
czyh int,  
¼��Ա varchar(20),  
sfrq datetime,  
sfczy int,  
�շ�Ա varchar(20),  
qrrq datetime,  
qrczyh int,  
��ҩԱ  varchar(20),  
pyczyh int,  
��ҩԱ  varchar(20),  
cflx  varchar(10),  
jssjh  varchar(50),  
patid UNIQUEIDENTIFIER,  
pyckdm  varchar(10),  
fyckdm varchar(10),  
��ҩ varchar(20),  
��ҩ  varchar(20)  ,
������ varchar(100),
fpid varchar(100),
bz varchar(500),
bz2 varchar(100),
CSRQ datetime
)   
  
  
set @tlfl=(select config from jc_config where id=8017)  
  
set @ssql='insert into #temp(ID,xh,binid,fph,��Ŀ,zje,jzje,yhje,zfje,hzxm,blh,xb,nl,zdmc,ksdm,����,ysdm,ҽ��,lrrq,czyh,¼��Ա,sfrq,sfczy,�շ�Ա,  
qrrq,qrczyh,��ҩԱ,pyczyh,��ҩԱ,cflx,jssjh,patid,pyckdm,fyckdm,��ҩ,��ҩ,������,fpid,bz,bz2,csrq)  
select A.ID,cfxh,patid,a.fph ,coalesce(dbo.fun_gettjdxm(cflx),'''') ��Ŀ,a.zje ,a.jzje,a.yhje,a.zfje, hzxm ,patientno ,xb ,  
dbo.fun_zy_age(csrq,3,skrq) nl,b.zdmc ,a.ksdm ,coalesce(dbo.fun_getdeptname(a.ksdm),'''') ����,a.ysdm,coalesce(dbo.fun_getempname(a.ysdm),'''') ҽ��,  
a.skrq,a.sky,'''' ¼��Ա,a.skrq,a.sky, '''' �շ�Ա,a.fyrq,a.fyr,dbo.fun_getempname(a.fyr) ��ҩԱ,pyr,dbo.fun_getempname(a.pyr) ��ҩԱ,cflx,a.jssjh,a.patid,  
coalesce(pyckh,'''') pyckdm,coalesce(fyckh,'''') fyckdm, ''��'' ��ҩ,'''' ��ҩ   
,a.cfxh,a.cfxh
,null,null,null
from '+ RTRIM(@table_fy)+' a(nolock) left join MZYS_JZJL b on a.PATID=b.BRXXID and  a.YSDM=b.JSYSDM  and a.ghxh=b.ghxxid where jzcfbz=0 '  
  --inner join MZYS_JZJL->left join MZYS_JZJL  Modify by jchl
if @deptid>0  
  set @ssql=@ssql+' and a.deptid='+cast(@deptid as varchar(20))  
  
if @blh<>''  
     set @ssql=@ssql+' and a.patientno='''+cast(@blh as varchar(50))+''' ';  
  
if rtrim(@hzxm)<>''  
      set @ssql=@ssql+' and (A.hzxm like ''%'+@hzxm+'%'' or dbo.getpywb(A.hzxm,0)='''+@hzxm+'''  or dbo.getpywb(A.hzxm,1)='''+@hzxm+''' )';  
  
if @fph<>''  
     set @ssql=@ssql+' and A.fph='''+cast(@fph as varchar(30))+''' '  
  
if @klx>0 and @kh<>''  
      set @ssql=@ssql+' and A.ghxh in (select ghxxid from vi_mz_ghxx a,yy_kdjb b where a.brxxid=b.brxxid and b.klx='+cast(@klx as varchar(10))+' and kh='''+cast(@kh as varchar(40))+''')';  
     
if rtrim(@zdmc)<>''   
     set @ssql=@ssql+' and b.zdmc like ''%'+@zdmc+'%''';  
  
if @je1>0  
     set @ssql=@ssql+' and zje>='+cast(@je1 as varchar(20))+' ';  
if @je2>0  
     set @ssql=@ssql+' and zje<='+cast(@je2 as varchar(20))+' ';  
     
if rtrim(@QRRQ1)<>''   
     set @ssql=@ssql+'  and a.fyrq>='''+@QRRQ1+''' and a.fyrq<='''+@QRRQ2+'''';  
  
if @QRCZYH<>0   
     set @ssql=@ssql+' and a.fyr='+cast(@QRCZYH as char(12))+' ';  
  
if @ksdm<>0   
     set @ssql=@ssql+' and a.ksdm='+cast(@ksdm as char(12))+' ';  
  
if @ysdm<>0   
     set @ssql=@ssql+' and a.ysdm='+cast(@ysdm as char(12))+' ';  
  
--set @ssql=@ssql+' order by a.fph';  
--set @ssql=@ssql+' and a.ksdm not in (50,56,138)';  
     
exec(@ssql)  
  
print @ssql  
  
set @ssql='select ''0'' ���, ��ҩ,  
psbz Ƥ��,  
a.fph ��Ʊ��, ��Ŀ,cast(zje as float) �ܽ��,hzxm ����,s_ypjx ����,yphh ����,c.s_yppm+isnull(ypspmbz,'''') Ʒ��,b.ypspm ��Ʒ��,  
b.ypgg ���,ypcj ����,b.lsj ����,0 ���,cast(ypsl as float) ����,cfts ����,b.ypdw ��λ,cast(round(lsje,3) as float)���,  
(case when lsje>0 then yf+'' ''+cast((case when Isnumeric(jl)=0 then  '''' else cast(jl as float) end) as varchar(100))+coalesce(jldw,'''')+''/��  ''+pc else '''' end) ʹ�÷���,  
blh �����,xb �Ա�,coalesce(nl,'''') ����,coalesce(zdmc,'''') ���,����, ҽ��,��ҩ,yf �÷�,  
pc Ƶ��,(case when jl='''' then ''0'' else jl end) ����,jldw ������λ,ts ����,  
zbz ���־,pxxh �������,  
lrrq ¼������, ¼��Ա,sfrq �շ�����, �շ�Ա,qrrq ��ҩ����,  ��ҩԱ, ��ҩԱ,a.id ������, a.cflx,a.jssjh,b.cfxh,   
patid,ksdm,ysdm,coalesce(sfczy,0) sfczy,coalesce(qrczyh,0) qrczyh ,coalesce(pyczyh,0) pyczyh ,coalesce(pyckdm,'''') ��ҩ����,coalesce(fyckdm,'''') ��ҩ����,a.jzje ���ʽ��,a.yhje �Żݽ��,a.zfje �Ը����,b.cjid as ypid,ydwbl,cfmxid,b.zt ����,  
b.pfj ������,cast(round(pfje,3) as decimal(15,3)) �������,  
(select RTRIM(cast(execnum as char(10)))+''��/''+RTRIM(cast(cycleday as char(10)))+''��'' from JC_FREQUENCY where name=pc ) ʹ��Ƶ��,  
zje,  
cast(cast(hlxs as float) as varchar(30))+dbo.fun_yp_ypdw(hldw)+''*''+cast(cast((ypsl/ydwbl)*bzsl as float) as varchar(20))+dbo.fun_yp_ypdw(bzdw) ��λ���,  
(case when c.tlfl in '+@tlfl+' then 1 else 0 end) zsyp 
,s_ypjx ����,fpid,jssjh ��Ʊ��ˮ��
,a.bz ��ҩ��ע,bz2 ��ע2,jsypfl ��ע3
from #temp a inner join '+RTRIM(@table_fymx)+' b(nolock) on a.ID=b.fyid   
inner join vi_yp_ypcd c (nolock) on b.cjid=c.cjid  where c.cjid>0 '  
--if @where<>''  
--   set @ssql=@ssql+' and  ('+@where +')'  
  
if @where<>''  
   set @ssql=@ssql+' and a.id in(select fyid from #temp a  
   inner join '+RTRIM(@table_fymx)+' b(nolock) on a.ID=b.fyid   
   inner join vi_yp_ypcd c (nolock) on b.cjid=c.cjid  and ( '+@where+')) '    
  
--set @ssql=@ssql+' order by a.fph,a.id,pxxh'  
set @ssql=@ssql+' order by ����,hzxm'  
  
  
print @ssql  
EXEC (@SSQL)  
  
  
  
  
end  
  
  
  