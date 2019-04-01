
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_CKHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_CKHZ
GO
CREATE PROCEDURE SP_YF_TJ_CKHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @qfy int
 )
as 

--����ǰ��·�ͳ���ȵõ��½�ID
declare @yjid UNIQUEIDENTIFIER
if @year>0
begin
  set @yjid=(select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid );
  if @yjid is null  
    set @yjid=dbo.FUN_GETEMPTYGUID()
end


if @year=0
begin
	  select '0' ���,rtrim(dbo.fun_yf_ywlx(a.YWLX)) ���ⷽʽ,
	(case a.ywlx when '003'  then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'����'
	            when '014' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'������ҩ'
				--when '019' then dbo.fun_yp_ghdw(wldw)+'�������'
				when '017' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'���ﴦ����ҩ'
				when '018' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'���ﴦ����¼'
				when '020' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'סԺ������ҩ'
				when '021' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'סԺ������¼'
				when '022' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'����ҩ��ҩ'
				when '023' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+rtrim(dbo.fun_yf_ywlx(a.YWLX))
				when '025' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'������������'
				when '026' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'����Ƽ���' else '' end
	) ������λ ,
	sum(jhje) �������,sum(pfje) �������,sum(lsje) ���۽��,
	(sum(lsje)-sum(jhje)) ������,(sum(lsje)-sum(pfje)) ������,count(distinct a.id) �������� 
	from vi_yF_dj a,vi_yf_djmx b 
	  where a.id=b.djid and shrq>=@rq1 and shrq<=@rq2 and shbz=1 
	and ((a.ywlx in('003','014','017','018','020','021','022','023','025','026') and @qfy=0) or (a.ywlx in('017','018','020','021') and @qfy=1) )and ((a.deptid=@deptid and @deptid>0) or @deptid=0)
	  group by a.deptid,a.YWLX,WLDW order by a.deptid,a.ywlx,wldw
end
else
begin
    select '0' ���,rtrim(dbo.fun_yf_ywlx(a.YWLX)) ���ⷽʽ,
			(case a.ywlx when '003'  then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'����'
            when '014' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'������ҩ'
			--when '019' then dbo.fun_yp_ghdw(wldw)+'�������'
			when '017' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'���ﴦ����ҩ'
			when '018' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'���ﴦ����¼'
			when '020' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'סԺ������ҩ'
			when '021' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'סԺ������¼'
			when '022' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+'����ҩ��ҩ'
			when '023' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+dbo.fun_getdeptname(wldw)+rtrim(dbo.fun_yf_ywlx(a.YWLX))
			when '025' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'������������'
			when '026' then (case when @deptid<>0 then '' else  dbo.fun_getdeptname(a.deptid) end)+'  '+'����Ƽ���' else '' end
			) ������λ ,
		sum(jhje) �������,sum(pfje) �������,sum(lsje) ���۽��,
  	 (sum(lsje)-sum(jhje)) ������,(sum(lsje)-sum(pfje)) ������,count(distinct a.id) �������� 
	from vi_yF_dj a,vi_yf_djmx b 
   	where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and shbz=1 and 
	((a.ywlx in('003','014','017','018','020','021','022','023','025','026')  and @qfy=0) or (a.ywlx in('017','018','020','021') and @qfy=1) )
	and ((a.deptid=@deptid and @deptid>0) or @deptid=0)
   	group by a.deptid,a.YWLX,WLDW order by a.deptid,a.ywlx,wldw
end 
--exec SP_YF_TJ_cKHZ 35,'2009-04-01 00:00:00','2011-04-29 23:59:59',0,0,0,0




