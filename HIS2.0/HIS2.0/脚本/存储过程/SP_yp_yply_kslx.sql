
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_yp_yply_kslx' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_yp_yply_kslx
GO
create proc SP_yp_yply_kslx
@rq1 varchar(30),
@rq2 varchar(30),
@yfdm  varchar(10),
@ksdm varchar(10),
@lyfs  varchar(10)
as
set @rq1+=' 00:00:00'
set @rq2+=' 23:59:59'
create table #tmp1(yjksdm int,ksdm int,jhje decimal(18,2),
				pfje decimal(18,2),lsje decimal(18,2),mzzy int,lyfs varchar(10),djzs int)


--סԺ������ҩ�����﷢ҩ�� yf_fy DJID ���ݺ�
insert into #tmp1(yjksdm,ksdm,jhje,pfje,lsje,mzzy,lyfs,djzs)
select 
 	 a.DEPTID ҩ�����ұ���,a.ksdm as ���ұ���,
 	 sum(b.JHJE) �������,
sum(b.pfje) as �������,SUM(b.LSJE)���۽�� ,(case when a.YWLX in ('020') then 1 else 0 end ) mzzy,
'cf' tlfs --������ҩ
,COUNT(distinct DJID)djzs--DJID
        from vi_yf_fy a , vi_yf_fymx b ,yp_ypcjd c
        where  a.id=b.fyid  and b.cjid = c.cjid
         and a.YWLX in ('017','020') --20   סԺ 1
and a.fyrq  between @rq1 and @rq2 and SCBZ=0
group by a.ksdm,a.YWLX,a.DEPTID
order by KSDM

--סԺͳ��Ͱ�ҩ
insert into #tmp1(yjksdm,ksdm,jhje,pfje,lsje,mzzy,lyfs,djzs)
select 
a.DEPTID ҩ�����ұ���,
a.dept_ly as ���ұ���,
sum(b.JHJE) �������
,sum(b.pfje) as ������� ,SUM(b.LSJE)���۽�� ,1 mzzy, (select top 1 LYFLCODE from ZY_APPLY_DRUG where GROUP_ID=a.GROUPID )tlfs,
COUNT(distinct a.DJH)
from VI_yf_tld a, vi_yf_tldmx b ,yp_ypcjd c 
where  a.groupid=b.groupid   and b.cjid = c.cjid 
and a.fyrq between @rq1 and @rq2-->= '2013-1-1 00:00:00' and a.fyrq < '2013-1-31 23:59:59'
 group by a.dept_ly,a.GROUPID,a.DEPTID  --,c.n_yplx
 order by a.DEPT_LY --01��ҩ    99 ͳ��
 
 
 ----������ҩ��018���ﴦ����¼���⣻021סԺ������¼����  --022����ҩ��ҩ�� 
 insert into #tmp1(yjksdm,ksdm,jhje,pfje,lsje,mzzy,lyfs,djzs)
select
a.wldw as ҩ�����ұ���,
a.wldw as ���ұ���,
sum(b.JHJE) �������
,sum(b.pfje) as �������,SUM(b.LSJE)���۽�� ,(case when a.YWLX in ('021') then 1 else 0 end ) mzzy --,'022'
,'qt' tlfs,COUNT(distinct a.DJH) djzs
from vi_YF_dj a,vi_YF_djmx b ,vi_yp_ypcd c 
where a.id=b.djid and b.cjid=c.cjid   
and  a.ywlx in('018','021')--,'022'
and a.SHRQ between @rq1 and @rq2
and a.shbz=1
group by a.wldw,a.YWLX

select '0' ���, dbo.fun_getDeptname(ksdm) ��ҩ����,
sum(jhje) �������,sum(pfje) �������,sum(lsje) ���۽��,SUM(lsje)-SUM(pfje) ������,
sum(lsje)-SUM(jhje) ������,SUM(djzs) �������� from #tmp1 where (@yfdm=0 or (@yfdm<>0 and yjksdm=@yfdm))
and (@ksdm='' or (@ksdm<>'' and ksdm=@ksdm)) 
 and (@lyfs=0 or (@lyfs=1 and lyfs not in ('01','cf','qt')) or(@lyfs=2 and lyfs='01') or (@lyfs=3 and lyfs='cf') or (@lyfs=4 and lyfs='qt'))
group by ksdm
order by(select SORT_ID from JC_DEPT_PROPERTY where DEPT_ID=ksdm)

drop table #tmp1

--select distinct (select top 1 LYFLCODE from ZY_APPLY_DRUG where GROUP_ID=YF_TLD.GROUPID ) from YF_TLD 
--select * from YP_DJH
--select * from ZY_YPTL

--select distinct ywlx from VI_yf_tld

--select * from YF_YWLX

--select * from vi_yf_fy


--select deptid,ksmc from YP_YJKS where KSLX='ҩ��'
--select * from JC_DEPT_TYPE where CODE in ('002','003','004','005','006')
--select * from JC_DEPT_PROPERTY
--select * from JC_DEPT_TYPE_RELATION
--select a.DEPT_ID,a.NAME from JC_DEPT_PROPERTY a,JC_DEPT_TYPE_RELATION b--,JC_DEPT_TYPE c   --and b.TYPE_CODE=c.CODE
--where a.DEPT_ID=b.DEPT_ID
--and b.TYPE_CODE in ('002','003','004','005','006')

