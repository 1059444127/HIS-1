IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_tj_qtmxtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_tj_qtmxtj
GO
CREATE PROCEDURE sp_yp_tj_qtmxtj 
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
exec sp_yp_tj_qtmxtj @deptid=137,@yk=1,@jhjetj=0,@year=2014,@month=6,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_qtmxtj @deptid=142,@yk=0,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
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

 if @jhjetj=0
		begin
			select a.CJID ����,ywjc as ҵ������,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
			(case when a.YWLX='005' then round(sum(a.LSJE)/sum(YPSL),4) else a.LSJ end) ����,
			case when ywjc = '��������' then  -cast(SUM(YPSL) as float) else cast(SUM(YPSL) as float) end ����, 
			case when ywjc = '��������' then  -sum(lsje) else sum(lsje) end ��� 
		 
			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx
			inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='��������'  and LSJE<>0     and a.YWLX<>'005'
			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.LSJ,a.YWLX,ywjc 
			union all 
			select  a.CJID ����,ywjc as ҵ������,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
			round(sum(a.LSJE)/sum(YPSL/YDWBL),4)  ����,cast(sum(YPSL/YDWBL) as float) ����, 
			sum(LSJE) ���
			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx
			inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='��������'    and LSJE<>0    and a.YWLX='005'
			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.YWLX,ywjc
			order by ywjc,a.CJID
       end
   else
		begin
			select  a.CJID ����,ywjc as ҵ������,S_YPPM Ʒ��,S_YPGG ���,YPDW ��λ,
			a.JHJ ����,
			case when ywjc = '��������' then  -cast(SUM(YPSL) as float) else cast(SUM(YPSL) as float) end ����, 
			case when ywjc = '��������' then  -sum(JHJE) else sum(JHJE) end ��� 			 
			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx
			inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='��������'    and JHJE<>0    and a.YWLX<>'005'
			group by a.CJID,d.SHH,S_YPPM,S_YPGG,YPDW,a.JHJ,a.YWLX,ywjc
			union all 
			select  a.CJID ����,ywjc as ҵ������,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
			round(sum(a.JHJE)/sum(YPSL/YDWBL),4)  ����,cast(sum(YPSL/YDWBL) as float) ����, 
			sum(JHJE) ���
			from YP_TJ_YMJCMX a inner join #tempyjjl b on a.YJID=b.yjid inner join #ywlx c on a.YWLX=c.ywlx
			inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='��������'    and JHJE<>0    and a.YWLX='005'
			group by a.CJID,d.SHH,S_YPPM,S_YPGG,S_YPDW,a.YWLX,ywjc
			order by ywjc,a.CJID
		end
		
set @ERR_CODE=0
set @ERR_TEXT='����ɹ�'  

end

