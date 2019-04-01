IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_tj_rkmxtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_tj_rkmxtj
GO
CREATE PROCEDURE sp_yp_tj_rkmxtj 
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
exec sp_yp_tj_rkmxtj @deptid=94,@yk=1,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text

declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_rkmxtj @deptid=142,@yk=0,@jhjetj=0,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
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

if @yk=1
	begin
	     if @jhjetj=0
			begin
				select a.CJID ����,dbo.fun_yp_ghdw(wldw) ��Ӧ��,shdh Ʊ�ݺ�,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
				cast(SUM(dbo.FUN_YK_DRT(A.YWLX,YPSL)) as float) ����,                                           --FUN_YK_DRTҵ������ת������
			    a.LSJ*YDWBL ����,sum(dbo.fun_yk_drt(a.ywlx,lsje)) ���  
				from YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
				inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='��������' 
				group by a.CJID,d.SHH,wldw,shdh,S_YPPM,S_YPGG,S_YPDW,a.LSJ*YDWBL order by  WLDW,shdh,a.CJID	
			end
		 else 
			begin
				select a.CJID ����,dbo.fun_yp_ghdw(wldw) ��Ӧ��,shdh Ʊ�ݺ�,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
				cast(SUM(dbo.FUN_YK_DRT(A.YWLX,YPSL)) as float) ����,                                           --FUN_YK_DRTҵ������ת������
				a.JHJ*YDWBL ����,sum(dbo.fun_yk_drt(a.ywlx,JHJE)) ���  
				from YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
				inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='��������'  
				group by a.CJID,d.SHH,wldw,shdh,S_YPPM,S_YPGG,S_YPDW,a.JHJ*YDWBL order by  WLDW,shdh,a.CJID
			end
	end
else
	begin
		 if @jhjetj=0
			begin
				select a.CJID ����,dbo.fun_getdeptname(wldw) ������λ,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
				cast(SUM(dbo.FUN_Yf_DRT(A.YWLX,YPSL)) as float) ����,                                           --FUN_YK_DRTҵ������ת������
			    a.LSJ*YDWBL ����,sum(dbo.fun_yf_drt(a.ywlx,lsje)) ���  
				from YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
				inner join yp_ypcjd D on a.CJID=d.CJID where tjlx='��������' 
				group by a.CJID,d.SHH,wldw,shdh,S_YPPM,S_YPGG,S_YPDW,a.LSJ*YDWBL order by  WLDW,shdh,a.CJID	
			end
		 else 
			begin
				select a.CJID ����,dbo.fun_getdeptname(wldw) ������λ,S_YPPM Ʒ��,S_YPGG ���,S_YPDW ��λ,
				cast(SUM(dbo.FUN_Yf_DRT(A.YWLX,YPSL)) as float) ����,                                           --FUN_YK_DRTҵ������ת������
				a.JHJ*YDWBL ����,sum(dbo.fun_yf_drt(a.ywlx,JHJE)) ���  
				from YP_TJ_YMJCMX a  inner join #tempyjjl b on a.yjid=b.yjid inner join #ywlx c on a.YWLX=c.ywlx  
				inner join yp_ypcjd D on a.CJID=d.CJID where  tjlx='��������'
				group by a.CJID,d.SHH,wldw,shdh,S_YPPM,S_YPGG,S_YPDW,a.JHJ*YDWBL order by  WLDW,shdh,a.CJID
			end
	end

set @ERR_CODE=0
set @ERR_TEXT='����ɹ�'  

end 