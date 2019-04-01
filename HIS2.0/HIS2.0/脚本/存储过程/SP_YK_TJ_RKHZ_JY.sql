--exec SP_YK_TJ_RKHZ_JY 206 ,'2014-02-12 00:00:00', '2014-02-13 23:59:59',0,0,0,206
if exists (select * from sysobjects 
           where name = N'SP_YK_TJ_RKHZ_JY'
           and type = 'P')
   drop proc SP_YK_TJ_RKHZ_JY
go
create  PROCEDURE [dbo].[SP_YK_TJ_RKHZ_JY]
 ( 
   @deptid int,--ҩ������
   @RQ1 datetime, --ͳ������1
   @RQ2 datetime,
   @yplx int,--ҩƷ����
   @year int,--ͳ�����
   @month int,--ͳ���·�
   @deptid_ck int--ͳ�Ʋֿ�
 )
as 

create table #tempYjid(yjid UNIQUEIDENTIFIER)
create table #deptid(deptid int)

--��Ҫͳ�ƵĿ���
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID
--��Ҫͳ�ƵĻ����
if @year>0
begin
    insert into #tempYjid(yjid) 
	select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid in(select deptid from #deptid)
	if @@rowcount=0
      insert into #tempYjid(yjid)values(dbo.FUN_GETEMPTYGUID()) 
end

declare @bywy int--������ͳ������ҵ��Ա 0������ 1���� 
set @bywy=(select top 1 zt from yk_config where bh=114 and deptid in(select deptid from #deptid))
if @bywy is null set @bywy=0

if @year=0  and @bywy=0-- ������ͳ�� ������ҵ��Ա
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) ���, yppm Ʒ��,YPGG ���, SCCJ ����,
cast(PFJ as varchar) ������,cast(LSJ as varchar)���ۼ�,SUM(YPSL) ����,SUM(PFJE) �������,SUM(LSJE) ���۽��,dbo.fun_yp_ghdw(WLDW) �ͻ���λ,
SHH ���� from
(
	select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and(
			(a.shbz=1 and a.ywlx in('016','009','031','033') and shrq>=@rq1 and shrq<=@rq2 )
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 )
        )  and a.deptid in(select deptid from #deptid)
      union all -----ҩƷ�˻�
    select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH from vi_yk_dj a  inner join
    VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and(             
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)  
) aa 
group by  CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW
order by YPPM
end

if @year>0 and @bywy=0 --���·�ͳ�� ������ҵ��Ա
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) ���, yppm Ʒ��,YPGG ���, SCCJ ����,
cast(PFJ as varchar) ������,cast(LSJ as varchar)���ۼ�,SUM(YPSL) ����,SUM(PFJE) �������,SUM(LSJE) ���۽��,dbo.fun_yp_ghdw(WLDW) �ͻ���λ,
SHH ���� from
(
	select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where  c.gjjbyw=1  and a.deptid in(select deptid from #deptid) and 
   		isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)   		 
   		and ((shbz=1 and a.YWLX in('016','009','031','033')) or ( a.ywlx in('001')))
   		union all 
		select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where
   		 c.gjjbyw=1  and
   		 a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002'))
   		 or (shbz=0 and a.ywlx in('002'))) 
  ) aa 
group by CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW
order by YPPM
end


----------------------------------------------����ҵ��Ա
if @year=0  and @bywy=1-- ������ͳ�� ����ҵ��Ա
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) ���, yppm Ʒ��,YPGG ���, SCCJ ����,
cast(PFJ as varchar) ������,cast(LSJ as varchar)���ۼ�,SUM(YPSL) ����,SUM(PFJE) �������,
SUM(LSJE) ���۽��, 
(case when jsr>0 then dbo.fun_yp_ghdw(WLDW)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(WLDW) end) �ͻ���λ ,
SHH ���� from
(
	select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH,a.JSR  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
    where c.gjjbyw=1 and (
			(a.shbz=1 and a.ywlx in('016','009','031','033') and shrq>=@rq1 and shrq<=@rq2 ) 
			or (a.ywlx in('001') and djrq>=@rq1 and djrq<=@rq2 )
        )and a.deptid in(select deptid from #deptid)
      union all -----ҩƷ�˻�
    select b.CJID,b.YPPM yppm,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,a.WLDW,b.SHH from vi_yk_dj a  inner join
    VI_YK_DJMX b on a.ID=b.DJID inner join VI_YP_YPCD c on b.CJID=c.cjid
    where  c.gjjbyw=1 and(
			( a.ywlx in('002') and djrq>=@rq1 and djrq<=@rq2 )
        ) and a.deptid in(select deptid from #deptid)  
) aa 
group by  CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW,JSR
order by YPPM
end


if @year>0 and @bywy=1
begin
select cast(ROW_NUMBER() over(order by cjid) as varchar) ���, yppm Ʒ��,YPGG ���, SCCJ ����,
cast(PFJ as varchar) ������,cast(LSJ as varchar)���ۼ�,SUM(YPSL) ����,SUM(PFJE) �������,
SUM(LSJE) ���۽��,
(case when jsr>0 then dbo.fun_yp_ghdw(WLDW)+' ['+isnull(dbo.fun_yp_ywy(jsr),'')+']' else dbo.fun_yp_ghdw(WLDW) end) �ͻ���λ ,
SHH ���� from
(
	select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW,a.JSR  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where c.gjjbyw=1  and  a.deptid in(select deptid from #deptid) and 
   		isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  
   		and ((shbz=1 and a.YWLX in('016','009','031','033')) or ( a.ywlx in('001'))) 
   		union all 
		select b.cjid,b.YPPM,b.ypgg,b.SCCJ,b.PFJ, b.LSJ,b.YPSL ,b.YPDW,b.PFJE,b.LSJE,b.SHH,a.WLDW  from vi_yk_dj  a  inner join
	VI_YK_DJMX b on a.ID=b.DJID
	inner join VI_YP_YPCD c on b.CJID=c.cjid
   		where c.gjjbyw=1 and a.deptid in(select deptid from #deptid) and isnull(yjid,dbo.FUN_GETEMPTYGUID())in(select yjid from #tempYjid)  and ((shbz=1 and a.ywlx in('002'))
   		 or (shbz=0 and a.ywlx in('002'))) 
  ) aa 
group by CJID,YPPM,YPGG,SCCJ,PFJ,LSJ,SHH,WLDW,JSR
order by YPPM

end 







