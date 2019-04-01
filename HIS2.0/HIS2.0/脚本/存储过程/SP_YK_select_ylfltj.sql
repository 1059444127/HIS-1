
--exec SP_YK_select_ylfltj 206,'2014-02-11 00:00:01','2014-02-13 23:59:59' ,131,'Fun_ts_yk_tjbb_ylfltj_rk',206
--exec SP_YK_select_ylfltj 206,'2014-02-11 00:00:01','2014-02-13 23:59:59' ,0,'Fun_ts_yk_tjbb_ylfltj_ck',206
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_select_ylfltj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_select_ylfltj
GO
CREATE PROCEDURE SP_YK_select_ylfltj
 (
    @deptid integer,
    @dtp1 datetime,
    @dtp2 datetime,
    @fid bigint,--ͳ�ƵĽڵ�
    @functionname varchar(100), --�ɹ�������ͳ�� 1 ���ⵥ����ͳ��
	@deptid_ck int
 ) 
as

--exec SP_YK_select_ylfltj 98,'2006-01-01','2012-01-01',0,'Fun_ts_yk_tjbb_ylfltj_ck',98
--select * from dbo.fun_tlfl_child(1)


begin

create table #deptid(deptid int)
--��Ҫͳ�ƵĿ���
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID

declare @ss varchar(4000)
declare @sumje decimal(15,2)   --����ͳ�����Ľ��
declare @sumflje decimal(15,2)--ҩ������ܽ��

set @sumje=0
--ͳ�Ʒ��������ҩƷ
select b.ylfl,b.cjid,b.s_ypspm,b.s_yppm,b.s_ypgg,s_ypdw,b.s_sccj,b.lsj,s_ypjx into #ypcd 
from dbo.fun_tlfl_child(@fid) a,vi_yp_ypcd b where a.id=b.ylfl 

create table #temp(cjid int,ypsl decimal(15,2) ,lsje decimal(15,2),jhj decimal(15,4),jhje decimal(15,2)) 

if @functionname='Fun_ts_yk_tjbb_ylfltj_rk'
begin

	set @sumje=(select sum(dbo.FUN_YK_DRT(a.ywlx,lsje)) from vi_yk_dj a,vi_yk_djmx b where  
	a.id=b.djid and a.ywlx in('001','002') and a.deptid in(select deptid from #deptid)   --�ܽ��
	and (
	(djrq>=@dtp1 and djrq<=@dtp2 and a.ywlx in('001','002') ) or 
	(dbo.Fun_GetDate(shrq)>=@dtp1 and dbo.Fun_GetDate(shrq)<=@dtp2 and a.YWLX in('016','009','031','033'))  --033 �Ƽ��ӹ���Ʒ���
	) )
	
	insert into #temp(cjid,ypsl,lsje,JHJ,JHJE)
	select b.cjid,sum(dbo.FUN_YK_DRT(a.ywlx,ypsl)/ydwbl) ypsl,sum(dbo.FUN_YK_DRT(a.ywlx,lsje)) lsje ,JHJ,SUM(dbo.FUN_YK_DRT(a.ywlx,JHJE))  from vi_yk_dj a,vi_yk_djmx b,#ypcd c 
	where 
	a.id=b.djid and b.cjid=c.cjid  and a.deptid in(select deptid from #deptid)
	and (
	(djrq>=@dtp1 and djrq<=@dtp2 and a.ywlx in('001','002') ) or 
	(dbo.Fun_GetDate(shrq)>=@dtp1 and dbo.Fun_GetDate(shrq)<=@dtp2 and a.YWLX in('016','009','031','033'))  --033�Ƽ��ӹ���Ʒ���
	)
	group by b.cjid,B.JHJ--����ҩƷ���������

end 

if @functionname='Fun_ts_yk_tjbb_ylfltj_ck'
begin

	set @sumje=(select sum(dbo.FUN_YK_DRT(a.ywlx,lsje))*(-1) from vi_yk_dj a,vi_yk_djmx b where 
	 dbo.Fun_GetDate(shrq)>=@dtp1 and  dbo.Fun_GetDate(shrq)<=@dtp2 and
	a.id=b.djid and a.ywlx in('003','004','014','022','017','018','020','030','032') and a.deptid in(select deptid from #deptid) ) --�ܽ��  --032ԭ�����ĳ���

	insert into #temp(cjid,ypsl,lsje,JHJ,JHJE)
	select b.cjid,sum(dbo.FUN_YK_DRT(a.ywlx,ypsl)/ydwbl)*(-1) ypsl,sum(dbo.FUN_YK_DRT(a.ywlx,lsje))*(-1) lsje,null,null  
	from vi_yk_dj a,vi_yk_djmx b,#ypcd c where  dbo.Fun_GetDate(shrq)>=@dtp1 and  dbo.Fun_GetDate(shrq)<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('003','004','014','022','017','018','020','030','032') and 
	a.deptid in(select deptid from #deptid) and shbz=1
	group by b.cjid--����ҩƷ���������

end 


set @sumflje=(select sum(lsje) from #temp)

 --�����ϸ���
select b.cjid,s_yppm Ʒ��,s_ypgg ��� ,s_sccj ���� ,cast(jhj as float) ����,b.lsj ���ۼ�,cast(ypsl as float) ���� ,
s_ypdw ��λ,cast(lsje as float) ���,cast(cast(round(lsje/@sumflje,4)*100 as float) as varchar(100))+'%' �ٷֱ�,@sumje �ܽ��,s_ypjx ���� 
from #temp a,#ypcd b where a.cjid=b.cjid order by lsje/@sumflje desc

--������ܽ��  
 create table #ok(id bigint,name varchar(100),lsje decimal(15,2),bfbl varchar(100)) 

declare @lsje decimal(15,2)
declare @id bigint
declare @name varchar(100)
declare t1 cursor for select id,flmc from yp_ylfl where fid=@fid--select ylfl,sum(lsje) lsje from #temp a,#ypcd b where a.cjid=b.cjid group by ylfl  
open t1
fetch next from t1 into @id,@name
while @@FETCH_STATUS=0
begin
   
    set @lsje=(select sum(lsje) lsje from dbo.fun_tlfl_child(@id) a,#ypcd b,#temp c where a.id=b.ylfl and b.cjid=c.cjid )
    insert into #ok(id,name,lsje,bfbl)values(@id,@name,@lsje,0)

fetch next from t1 into @id,@name
end
CLOSE t1
DEALLOCATE t1

insert into #ok(name,lsje,bfbl) select '�ϼ�',sum(lsje),'100%' from #temp

select name ����,lsje ���,cast(cast(round(lsje/@sumflje,4)*100 as float) as varchar(100))+'%' �ٷֱ�,@sumje �ܽ��,id from #ok



if @functionname='Fun_ts_yk_tjbb_ylfltj_rk'
begin
	select (case a.ywlx when '001' then '�ɹ����' when '002' then '�ɹ��˻�' when '016' then '�������' when '009' then '�ڳ����' when '031' then 'ͬ������' 
	 when '033' then '�Ƽ��ӹ���Ʒ���'  else '' end) ���� ,
	s_ypjx ����,s_yppm Ʒ��,s_ypgg ��� ,s_sccj ���� ,b.jhj ����,cast(ypsl as float) ���� ,s_ypdw ��λ,cast(jhje as float) �������,dbo.fun_yp_ghdw(wldw) ������λ,a.djh ���ݺ� 
	from vi_yk_dj a,vi_yk_djmx b,#ypcd c
	 where  
	a.id=b.djid and b.cjid=c.cjid and a.deptid in(select deptid from #deptid)
		and (
	(djrq>=@dtp1 and djrq<=@dtp2 and a.ywlx in('001','002') ) or 
	(dbo.Fun_GetDate(shrq)>=@dtp1 and dbo.Fun_GetDate(shrq)<=@dtp2 and a.YWLX in('016','009','031','033')) --033 �Ƽ��ӹ���Ʒ���
	) 
	order by a.ywlx,djrq,djsj
end
if @functionname='Fun_ts_yk_tjbb_ylfltj_ck'
begin
	select rtrim(dbo.fun_yk_ywlx(a.ywlx)) ���� ,rtrim(s_ypjx) ����,s_yppm Ʒ��,s_ypgg ��� ,s_sccj ���� ,
	b.lsj ���ۼ�,cast(ypsl as float) ���� ,s_ypdw ��λ,cast(dbo.FUN_YK_DRT(a.ywlx,lsje)*(-1) as float) ���۽��,dbo.fun_getdeptname(wldw) ������λ,a.djh ���ݺ� 
	 from vi_yk_dj a,vi_yk_djmx b,#ypcd c where  dbo.Fun_GetDate(shrq)>=@dtp1 and  dbo.Fun_GetDate(shrq)<=@dtp2 and
	a.id=b.djid and b.cjid=c.cjid and a.ywlx in('003','004','014','022','017','018','020','030','032')  --032ԭ�����ĳ���
	and a.deptid in(select deptid from #deptid) and shbz=1
	order by a.ywlx,djrq,djsj
end

end


