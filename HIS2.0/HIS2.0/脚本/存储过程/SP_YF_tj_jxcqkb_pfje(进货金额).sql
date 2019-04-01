

  IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_tj_jxcqkb_pfje' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_tj_jxcqkb_pfje
GO
  
create PROCEDURE SP_YF_tj_jxcqkb_pfje    
 ( @year int,     
   @month INTEGER,    
   @deptid integer,    
   @yplx integer    
 )     
as    
BEGIN    
 declare @id int    
 declare @yjid UNIQUEIDENTIFIER    
 declare @count INT     
 declare @sqyear int;    
 declare @sqmonth int;    
    
 DECLARE @stmt varchar(1000); --����SQL�ı�    
    
 --������ʱ��    
   create TABLE #TEMP    
   (    
      ID INTEGER IDENTITY (1, 1) NOT NULL ,    
	  wldw int,    
      xmmc varchar(200),    
	   je decimal(18,2),    
	   ywlx char(3),    
	   sortid int default 0 not null,    
	   jdfx int default 0 not null,    
	   jhje decimal(18,2) --default 0 not null    
       
   )     
       
   create  TABLE #TEMP1    
   (    
      ID INTEGER IDENTITY (1, 1) NOT NULL ,    
      xmmc varchar(200),    
   je decimal(18,2),    
   jhje decimal(18,2), --default 0 not null,    
   xmmc1 varchar(200),    
   je1 decimal(18,2),    
   jhje1 decimal(18,2) --default 0 not null    
   )     
       
       
  create  TABLE #DJMX    
   (    
       CJID INT,    
	   zy varchar(200),    
	   wldw int,    
	   shrq varchar(50),    
	   RCKFS INT,    
	   YWLX CHAR(3),    
	   YPSL DECIMAL(18,3),    
	   ypdw varchar(10),    
	   lsje DECIMAL(18,3),    
	   lsj decimal(18,4),    
	   jhje decimal(18,3)    
       
   )     
     --�����½�ID    
   create TABLE #YJB(YJID UNIQUEIDENTIFIER )    
begin    
         
set @sqyear=@year;    
set @sqmonth=@month-1;    
if @month=1     
begin    
  set @sqyear=@sqyear-1;    
  set @sqmonth=12;    
end     
    
 --����ǲ�ѯ�걨��     
 if @month=0     
 begin    
  set @sqyear=@year-1;    
  set @sqmonth=12    
 end     
/*    
set @yjid=(select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid );    
if @yjid is null      
  set @yjid=0;    
*/    
--����ǲ�ѯ�걨��     
 if @month=0     
    begin    
  insert into #yjb select id from yp_kjqj where kjnf=@year  and deptid=@deptid    
  if year(getdate())=@year insert into #yjb select dbo.FUN_GETEMPTYGUID()    
    end    
 else    
 begin    
  insert into #yjb select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid    
  if @@rowcount=0 insert into #yjb select dbo.FUN_GETEMPTYGUID()    
    end    
    
--��ѯ��ϸ���    
if @yplx=0     
begin    
    insert into #DJMX(wldw,ywlx,lsje,jhje)     
    select a.wldw,a.ywlx,sum(lsje),sum(JHJE)    
    from vi_yf_dj a(nolock),vi_yf_djmx b(nolock)     
    where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID()) IN(SELECT YJID FROM #YJB) and a.deptid=@deptid and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))      
    group by a.wldw,a.ywlx    
end    
else    
begin    
    insert into #DJMX(wldw,ywlx,lsje,jhje)     
    select a.wldw,a.ywlx,sum(lsje),sum(JHJE)    
    from vi_yf_dj a(nolock),vi_yf_djmx b(nolock),yp_ypcjd c (nolock)    
    where a.id=b.djid and b.cjid=c.cjid and c.n_yplx=@yplx and isnull(yjid,dbo.FUN_GETEMPTYGUID()) IN(SELECT YJID FROM #YJB) and a.deptid=@deptid and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))      
    group by a.wldw,a.ywlx    
end    
     
     
     
 --���ڽ��    
set @count=(select count(*) from Yp_kjqj where  kjnf=@sqyear and kjyf=@sqmonth and deptid=@deptid);    
if @count=0     
 insert into #temp(xmmc,je,ywlx,sortid,jdfx,jhje)values('���ڽ��',0,'000',0,0,0)    
else    
begin    
 if @yplx=0     
     insert into #temp(xmmc,je,ywlx,sortid,jdfx,jhje) select '���ڽ��',round(sum(jclsje),2),'000',0,0,sum(round(JCJHJE,2)) from YF_YMJC where  nf=@sqyear and yf=@sqmonth and deptid=@deptid;    
 else    
     insert into #temp(xmmc,je,ywlx,sortid,jdfx,jhje) select '���ڽ��',round(sum(jclsje),2),'000',0,0,sum(round(JCJHJE,2)) from YF_YMJC a,vi_yp_ypcd b where a.cjid=b.cjid and b.yplx=@yplx and nf=@sqyear and yf=@sqmonth and deptid=@deptid;    
end    
    
    
insert into #temp(wldw,xmmc,je,jhje,ywlx) select 0, ywmc,0,0,ywlx from yF_ywlx where ywzt=1 and ywlx not in('008','012','005');    
    
declare @t_wldw int    
declare @t_ywlx char(3)    
declare @t_je decimal(15,3)    
declare @t_jhje decimal(15,3)    
declare t cursor local for    
     select wldw,ywlx,round(sum(lsje),2) je,round(sum(jhje),2) jhje from #DJMX where ywlx not in('008','012','005') group by wldw,ywlx    
open  t    
fetch next from t into @t_wldw,@t_ywlx,@t_je,@t_jhje    
while @@FETCH_STATUS=0    
begin    
   if @t_ywlx='001' or @t_ywlx='002'      
       update #TEMP set je=je+@t_je,jhje=jhje+@t_jhje where ywlx=@t_ywlx;    
   else    
     begin    
   insert into #TEMP(wldw,xmmc,je,ywlx,jhje)values(@t_wldw,dbo.fun_yf_ywlx(@t_ywlx),@t_je,@t_ywlx,@t_jhje);    
     end    
fetch next from t into @t_wldw,@t_ywlx,@t_je,@t_jhje    
end    
    
    
--����ǲ�ѯ�걨��     
if @month=0    
begin    
  --if year(getdate())=@year    
    -- set @month=month(getdate())    
  --else    
     set @month=12    
end     
    
  --���ڽ��    
set @count=0;    
set @count=(select count(*) from Yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid);    
if @count is null     
 set @count=0;    
    
    
if @count=0     
begin    
    if @yplx=0     
  insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '���ڽ��',cast(sum(round(kcl*lsj/dwbl,2)) as decimal(15,2)),cast(sum(round(kcl*JHJ/dwbl,2)) as decimal(15,2)),'999',1000,1  from yf_kcph a,yp_ypcjd b     
  where a.cjid=b.cjid and deptid=@deptid;    
    else    
  insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '���ڽ��',cast(sum(round(kcl*lsj/dwbl,2)) as decimal(15,2)),cast(sum(round(kcl*JHJ/dwbl,2)) as decimal(15,2)),'999',1000,1  from yf_kcph a,yp_ypcjd b     
  where a.cjid=b.cjid and deptid=@deptid and b.n_yplx=@yplx;    
end    
else    
begin    
    if @yplx=0     
     insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '���ڽ��',sum(jclsje),sum(round(JCJHJE,2)),'999',1000,1 from Yf_YMJC     
  where nf=@year and yf=@month and deptid=@deptid;    
    else    
     insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '���ڽ��',sum(jclsje),sum(round(JCJHJE,2)),'999',1000,1 from Yf_YMJC a,vi_yp_ypcd b     
  where a.cjid=b.cjid and b.yplx=@yplx and nf=@year and yf=@month and deptid=@deptid;    
end     
    
    
update #temp set xmmc='�ڳ�¼��',je=je,sortid=1,jdfx=0 where ywlx='009';    
update #temp set xmmc='ҩƷ�ɹ�',je=je,sortid=2,jdfx=0 where ywlx='001';    
update #temp set xmmc='ҩƷ�˻�',je=je*(-1),jhje=jhje*(-1),sortid=3,jdfx=0 where ywlx='002';    
update #temp set xmmc=dbo.fun_getdeptname(wldw)+'��ҩ',je=je,sortid=3,jdfx=0 where ywlx='024';    
update #temp set xmmc=rtrim(dbo.fun_getdeptname(wldw))+'��ҩ',je=je,sortid=4,jdfx=0 where ywlx='016';    
update #temp set xmmc='��'+rtrim(dbo.fun_getdeptname(wldw))+'����',je=je,sortid=5,jdfx=0 where ywlx='015';    
update #temp set xmmc=dbo.fun_yp_ghdw(wldw)+'���',je=je,sortid=6,jdfx=0 where ywlx='019';    
--update #temp set xmmc='ҩƷ����',je=je,sortid=7,jdfx=0 where ywlx='007';    
update a set xmmc=b.ywjc,je=je,sortid=7,jdfx=0 from #temp a inner join YF_YWLX b  on a.ywlx=b.ywlx where a.ywlx='007';
--update #temp set xmmc='��������',je=je,sortid=8,jdfx=0 where ywlx='005' and je>=0;    
--update #temp set xmmc='�����������',je=je,sortid=9,jdfx=0 where ywlx='012' and je>=0;    
insert into #temp(xmmc,je,jhje,ywlx,sortid,jdfx)
select  'ҩƷ��ӯ',sum(je) je,SUM(JHJE),'008',10,0 from (
select sum(lsje) je,0 jhje from #djmx where ywlx='008' and lsje>0  
union all
select 0 je,sum(jhje) jhje from #djmx where ywlx='008' and jhje>0
) a 
    
insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '�����������',0,0,'012',9,0  
insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '��������',0,0,'005',8,0  
update a set a.je=coalesce((select sum(lsje) from #djmx where ywlx='012' and lsje>0),0) from #temp a where a.jdfx=0 and ywlx='012'
update a set a.jhje=coalesce((select sum(jhje) from #djmx where ywlx='012' and jhje>0),0) from #temp a where a.jdfx=0 and ywlx='012'
update a set a.je=coalesce((select sum(lsje) from #djmx where ywlx='005' and lsje>0),0) from #temp a where a.jdfx=0 and ywlx='005'
update a set a.jhje=coalesce((select sum(jhje) from #djmx where ywlx='005' and jhje>0),0) from #temp a where a.jdfx=0 and ywlx='005'




update #temp set xmmc='������'+dbo.fun_getdeptname(wldw),je=je,sortid=20,jdfx=1 where ywlx='003';    
update #temp set xmmc='��'+dbo.fun_getdeptname(wldw),je=je,sortid=21,jdfx=1 where ywlx='004';    
update #temp set xmmc=dbo.fun_getdeptname(wldw)+'��ҩ',je=je,sortid=22,jdfx=1 where ywlx='014';    
update #temp set xmmc=dbo.fun_getdeptname(wldw)+'����ҩ��ҩ',je=je,sortid=22,jdfx=1 where ywlx='022';    
  
update #temp set xmmc=dbo.fun_getdeptname(wldw)+xmmc,je=je,sortid=22,jdfx=1 where ywlx='023';    --xmmc=dbo.fun_getdeptname(wldw)+'Сҩ����ҩ',
update #temp set xmmc='���ﴦ������',je=je,sortid=23,jdfx=1 where ywlx='017';    
update #temp set xmmc='���ﴦ����¼����',je=je,sortid=25,jdfx=1 where ywlx='018';    
update #temp set xmmc='סԺ��������',je=je,sortid=24,jdfx=1 where ywlx='020';    
update #temp set xmmc='סԺ������¼����',je=je,sortid=25,jdfx=1 where ywlx='021';    
update #temp set xmmc='������������',je=je,sortid=26,jdfx=1 where ywlx='025';    
update #temp set xmmc='����Ƽ���',je=je,sortid=27,jdfx=1 where ywlx='026';    
--insert into #temp(xmmc,je,sortid,jdfx,ywlx)select 'ҩƷ���۽��',round(sum(je),2),23,1,'xxx' from #temp where ywlx in('023','017','018','020','021','025','026');    
--delete from #temp where ywlx in('023','017','018','020','021','025','026');    
--update #temp set xmmc='ҩƷ����',je=je,sortid=28,jdfx=1 where ywlx='006';   
update a set xmmc=b.ywjc,je=je,sortid=28,jdfx=1 from #temp a inner join yf_ywlx b on a.ywlx=b.ywlx where a.ywlx='006';
 
--update #temp set xmmc='������ʧ',je=abs(je),jhje=jhje*(-1),sortid=29,jdfx=1 where ywlx='005' and je<0;    
--update #temp set xmmc='�����������',je=abs(je),jhje=jhje*(-1),sortid=30,jdfx=1 where ywlx='012' and je<0;    
--insert into #temp(xmmc,je,jhje,ywlx,sortid,jdfx) select 'ҩƷ�̿�',round(abs(sum(lsje)),2) je,0,'008',31,1 from #djmx where ywlx='008' and lsje<0;    
--insert into #temp(xmmc,je,jhje,ywlx,sortid,jdfx) select 'ҩƷ�̿�',0 je,abs(sum(jhje)),'008',31,1 from #djmx where ywlx='008' and jhje<0;    

insert into #temp(xmmc,je,jhje,ywlx,sortid,jdfx)
select 'ҩƷ�̿�',round(abs(sum(je)),2) je,round(abs(sum(JHje)),2),'008',31,1 from (
select sum(lsje) je,0 jhje from #djmx where ywlx='008' and lsje<0
union all
select 0 je,sum(jhje) jhje from #djmx where  ywlx='008' and jhje<0
) a 


    
insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '�����������',0,0,'012',30,1  
insert into #TEMP(xmmc,je,jhje,ywlx,sortid,jdfx) select '������ʧ',0,0,'005',29,1 
update a set a.je=coalesce((select abs(sum(lsje)) from #djmx where ywlx='012' and lsje<0),0) from #temp a where a.jdfx=1 and ywlx='012'
update a set a.jhje=coalesce((select abs(sum(jhje)) from #djmx where ywlx='012' and jhje<0),0) from #temp a where a.jdfx=1 and ywlx='012'
update a set a.je=coalesce((select abs(sum(lsje)) from #djmx where ywlx='005' and lsje<0),0) from #temp a where a.jdfx=1 and ywlx='005'
update a set a.jhje=coalesce((select abs(sum(jhje)) from #djmx where ywlx='005' and jhje<0),0) from #temp a where a.jdfx=1 and ywlx='005'

    
    
insert into #TEMP1(xmmc,je,jhje) select xmmc,je,jhje from #TEMP where ((je<>0 or jhje<>0 )and jdfx=0) or ywlx='000' order by sortid    
declare @i int
set @i=0    
while(@i<=80)
begin
set @i=@i+1
insert into #temp1(xmmc,je,xmmc1,je1)values('',0,'',0);    
end
    
insert into #TEMP1(xmmc,je,jhje,xmmc1,je1,jhje1)     
select '�跽С��',sum(je),sum(jhje),'',0,0 from #TEMP where jdfx=0 and ywlx<>'000'    
    
    
    
--�����������    
declare @t2_xmmc varchar(200)    
declare @t2_je decimal(18,2)    
declare @t2_jhje decimal(18,2)    
set @id=1;    
declare t2 cursor local for select xmmc,je,coalesce(jhje,0) from #TEMP   
where ((je<>0 or jhje<>0) and jdfx=1) or ywlx='999'  order by sortid    
open t2    
fetch next from t2 into @t2_xmmc,@t2_je,@t2_jhje    
while @@FETCH_STATUS=0    
begin    
      set @id=@id+1;    
      update #TEMP1 set xmmc1=@t2_xmmc,je1=@t2_je,jhje1=@t2_jhje where id=@id;    
      if @t2_xmmc<>'���ڽ��'    
 update #TEMP1 set xmmc1='����С��',je1=je1+@t2_je,jhje1=jhje1+@t2_jhje where xmmc='�跽С��';    
      fetch next from t2 into @t2_xmmc,@t2_je,@t2_jhje    
end     
    
    
--��跽�ĺϼ���    
insert into #TEMP1(xmmc,je,jhje)select '�ϼ�',coalesce(sum(je),0),coalesce(sum(jhje),0) from #TEMP1 where xmmc<>'�跽С��';    
    
--������ĺϼ�����������    
declare @je1 decimal(18,2)    
declare @jhje1 decimal(18,2)    
select @je1=sum(coalesce(je1,0)),@jhje1=sum(coalesce(jhje1,0)) from #TEMP1 where xmmc1<>'����С��'    
    
update #TEMP1 set xmmc1='�ϼ�',je1=coalesce(@je1,0),jhje1=coalesce(@jhje1,0) where xmmc='�ϼ�'   
    
    
--select (case when (xmmc='ҩƷ�ɹ�' or xmmc='ҩƷ�˻�') then rtrim(xmmc)+'(�������:'+rtrim(coalesce(je,0)-coalesce(jhje,0))+')' else xmmc end ) ��Ŀ1,(case when xmmc='' then null else coalesce(je,0) end) ���1,xmmc1 ��Ŀ2,(case when xmmc1 is null then null else coalesce
--(  
--je1,0) end) ���2 from #TEMP1 where xmmc<>'' or (xmmc='' and xmmc1<>'') order by id    
select      
xmmc ��Ŀ1,    
jhje �������1,    
(case when xmmc='' then null else coalesce(je,0) end) ���۽��1,    
(case when xmmc='' then null else (coalesce(je,0)-coalesce(jhje,0)) end) ������1,    
xmmc1 ��Ŀ2,    
jhje1 �������2,    
(case when xmmc1 is null then null else coalesce(je1,0) end) ���۽��2,     
(case when xmmc1 is null then null else (coalesce(je1,0)-coalesce(jhje1,0)) end) ������2 
from #TEMP1 where xmmc<>'' or (xmmc='' and xmmc1<>'') order by id    
    
    
END     
end  
    