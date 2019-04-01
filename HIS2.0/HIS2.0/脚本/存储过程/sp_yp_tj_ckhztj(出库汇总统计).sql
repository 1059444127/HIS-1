IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_tj_ckhztj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_tj_ckhztj
GO
CREATE PROCEDURE sp_yp_tj_ckhztj 
(
	@deptid int,
	@yk int,
	@jhjetj int,
	@year int,
	@month int,
    @ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(250) output
)
as


/*
declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_ckhztj @deptid=94,@yk=1,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text


declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_ckhztj @deptid=142,@yk=0,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

*/
begin

create table #ywlx(ywlx varchar(30),ywmc varchar(50),ywzt varchar(10),ywfx varchar(10),ywjc varchar(30),tjlx varchar(50),ywlxpxfs int,wldwhz int,wldwlx int)


--׼�����»����½��¼ID 
create table #tempyjjl(yjid uniqueidentifier,kjnf int ,kjyf int,deptid int,qc smallint ,qm smallint)
if @yk=1 
begin
	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)
	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 
	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0) where a.KSLX='ҩ��' and a.DEPTID =@deptid and QYBZ=1
	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yk_ywlx
end
else
begin
	insert into #tempyjjl(yjid,kjnf,kjyf,deptid)
	select b.ID,KJNF,KJYF,a.DEPTID from YP_YJKS a left join YP_KJQJ b 
	on a.DEPTID=b.DEPTID and KJNF=@year and ((KJYF=@month and @month>0) or @month=0)  where a.KSLX='ҩ��' and a.DEPTID =@deptid and QYBZ=1
	insert into #ywlx(ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx) select ywlx,ywmc,ywzt,ywfx,ywjc,tjlx,ywlxpxfs,wldwhz,wldwlx from yf_ywlx
end



--����ҩ����ҩ�� ҩ�⣨001 004��
if @yk=1
begin  
if @jhjetj=1 
        select   dbo.fun_yp_wldwmc(c.wldwlx,wldw) ������λ,sum(case when a.ywlx not in('004') then JHJE else 0 end) ������,
        sum(case when a.YWLX in('004') then jhje else 0 end) �˻����,
		sum(dbo.fun_yk_drt(a.ywlx,JHJE))*(-1) as ʵ�ʽ�� 
		from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
        inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='���ڼ���' 
        group by a.wldw,c.WLDWLX order by wldw
else
        select  dbo.fun_yp_wldwmc(c.wldwlx,wldw) ������λ,sum(case when a.ywlx not in('004') then LSJE else 0 end) ������,
        sum(case when a.YWLX in('004') then LSJE else 0 end) �˻����,
		sum(dbo.fun_yk_drt(a.ywlx,LSJE))*(-1) as ʵ�ʽ�� 
		from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
        inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='���ڼ���' 
        group by a.wldw,c.WLDWLX order by wldw 
end
     
if @yk=0
begin  
if @jhjetj=1 
        select wldw ������λ,sum(case when a.ywlx not in('0000') then JHJE else 0 end) ������,
        sum(case when a.YWLX in('004') then jhje else 0 end) �˻����,
		sum(dbo.fun_yf_drt(a.ywlx,JHJE))*(-1) as ʵ�ʽ�� 
		from (
		select isnull(dbo.fun_yp_wldwmc(c.wldwlx, wldw),dbo.fun_yf_ywlx(c.ywlx)) as wldw,SUM(jhje) jhje,c.ywlx 
		from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
        inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='���ڼ���' group by c.ywlx,c.wldwlx,a.WLDW 
        ) a 
        group by a.wldw  order by wldw
else
        select wldw ������λ,sum(case when a.ywlx not in('0000') then lsje else 0 end) ������,
        sum(case when a.YWLX in('004') then lsje else 0 end) �˻����,
		sum(dbo.fun_yf_drt(a.ywlx,lsje))*(-1) as ʵ�ʽ�� 
		from (
		select isnull(dbo.fun_yp_wldwmc(c.wldwlx, wldw),dbo.fun_yf_ywlx(c.ywlx)) as wldw,SUM(lsje) lsje,c.ywlx 
		from  YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
        inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='���ڼ���' group by c.ywlx,c.wldwlx,a.WLDW 
        ) a 
        group by a.wldw  order by wldw
end
	
	
set @ERR_CODE=0
set @ERR_TEXT='����ɹ�'  

end 

