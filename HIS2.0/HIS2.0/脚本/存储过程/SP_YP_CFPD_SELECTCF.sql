IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YP_CFPD_SELECTCF' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YP_CFPD_SELECTCF
GO

  
CREATE PROCEDURE SP_YP_CFPD_SELECTCF 
 (    
 @execdept int,--ִ�п���  
 @zdmc varchar(30),--�������
 @KDKS VARCHAR(1000),--��������
 @KDYS VARCHAR(1000),--����ҽ��
 @FUNNAME VARCHAR(30),--
 @CFRQ1 VARCHAR(30),--��������
 @CFRQ2 VARCHAR(30),
 @SHBZ INT,--��˱�־
 @jgbm bigint --��������
 )   
as  
/*-------------  
���Ҵ���  
-------------*/  

declare @ss varchar(8000)

--��֤��������ת������
declare @ts int
declare @table varchar(30)
declare @table1 varchar(30)
set @table='mz_hjb'
set @table1='mz_hjb_mx'
set @ts=(select cast(config as int) from jc_config where id=13)
if DATEADD(DD,-1*@ts,getdate())>@CFRQ1
begin
  set @table='vi_mz_hjb'
  set @table1='vi_mz_hjb_mx'
end



set @ss=' select '''' ���,1 ѡ�� , '''' ��,zdmc �������,'''' ����ʱ��, yzmc+''  ''+gg as ҽ������,
cast(cast(cast(yl as float) as varchar(30))+rtrim(yldw) as varchar(15)) as ����,
rtrim(pcmc)  Ƶ�� ,yfmc �÷�,cast(ts as float) ����,zt ����,
dbo.fun_getempname(ysdm) ����ҽ��,
cast(cast(dj as float) as varchar(30)) ����,cast(js as varchar(10)) ����,
cast(cast(sl as float) as varchar(30))+'' ''+dw ����,cast(je as float)  ���,
dbo.fun_getdeptname(zxks) ִ�п���,
(case when bsfbz=1 then ''��'' else '''' end) �շ�,''ͨ��'' as ͨ��,''��ͨ��'' ��ͨ��,bpsbz Ƥ�Ա�־,
bzby �Ա�ҩ,fzxh �����������,
pxxh �������,cfrq as ��������,a.hjid,xmid as ��Ŀid,dbo.fun_getdeptname(a.ksdm) ��������,
dbo.fun_getempname(HJY) ����Ա,brxm ��������,dbo.FUN_ZY_SEEKSEXNAME(xb) �Ա�,
dbo.fun_zy_age(csrq,3,getdate()) ����,jtdz ��ͥסַ,brlxfs ��ϵ��ʽ
  from '+@table+' a inner join '+@table1+' b  
 on a.hjid=b.hjid inner join mzys_jzjl c on a.jzid=c.jzid
 inner join yy_brxx d on a.brxxid=d.brxxid
where cfrq>='''+@cfrq1+''' and cfrq<='''+@cfrq2+''' and a.BSCBZ=0  and xmly=1   '
if @kdks<>''
  set @ss=@ss+' and ksdm in('+@kdks+')'
if @KDYS<>''
  set @ss=@ss+' and ysdm in('+@KDYS+')'
if @zdmc<>''
  set @ss=@ss+' and zdmc like ''%'+@zdmc+'%'''

set @ss=@ss+' order by a.ghxxid,a.hjid,pxxh'
print @ss
exec(@ss)

