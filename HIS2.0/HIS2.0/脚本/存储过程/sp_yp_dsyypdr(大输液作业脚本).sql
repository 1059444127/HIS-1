IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yp_dsyypdr' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yp_dsyypdr
GO
create proc sp_yp_dsyypdr
(
  @rq1 datetime,
  @rq2 datetime
)
as
 

declare @startdate datetime
declare @enddate datetime
--��ʼ����
set @startdate=CONVERT(varchar(10),@rq1,120)
--��������
set @enddate=CONVERT(varchar(10),@rq2,120)

----declare @rq1 datetime
----declare @rq2 datetime
----set @rq1='2014-07-01'
----set @rq2='2014-07-31'
----exec sp_yp_dsyypdr @rq1,@rq2




--ɾ�������е�����
delete from yp_tj_dsyyp where fyrq>=@startdate and fyrq<=@enddate

---------סԺ����Һ-------------------------------
insert into yp_tj_dsyyp(cjid,shh,spmc,gg,dw,sl,lsj,lsje,fyrq,wldw,zylx,bz,ydwbl,JHJ,JHJE)
select a.XMID ,shh ,ltrim(rtrim(YPPM)) ,LTRIM(RTRIM(YPGG)) ,s_ypdw,SUM(NUM) ,a.dj,
SUM(lsje) as lsje,
CONVERT(varchar(10),fyrq,120) as fyrq,a.EXECDEPT_ID as wldw,'1' as zylx,'סԺ����Һ' as bz,1 as ydwbl   ,
(select top 1 JHJ from YF_KCPH where cjid=a.XMID order by DJSJ desc) jhj,
(select top 1 JHJ*SUM(A.NUM) from YF_KCPH where cjid=a.XMID order by DJSJ desc) jhje
from (
SELECT CONVERT(varchar(10),FY_DATE,120) fyrq,A.XMID,A.EXECDEPT_ID,SUM(NUM*dosage/UNITRATE) num,COST_PRICE/UNITRATE as dj,SUM(sdvalue) lsje
from ZY_FEE_SPECI a inner join 
VI_YP_YPCD b on a.XMID=b.cjid and a.SUBCODE=b.shh  and TLFL='03' and (a.FY_BIT=5 and a.DELETE_BIT=0 and a.XMLY=1)
where CONVERT(varchar(10),FY_DATE,120)>=@startdate and  CONVERT(varchar(10),FY_DATE,120)<=@enddate
GROUP BY CONVERT(varchar(10),FY_DATE,120),A.XMID,A.EXECDEPT_ID,COST_PRICE/UNITRATE
) a inner join VI_YP_YPCD b on a.xmid=b.cjid
  group by fyrq,XMID,EXECDEPT_ID,shh,YPPM,YPGG,s_ypdw,DJ  


-------------------����ҩ��---------------------
insert into yp_tj_dsyyp(cjid,shh,spmc,gg,dw,sl,lsj,lsje,fyrq,wldw,zylx,bz,ydwbl,jhj,jhje)
select XMID,shh,YPPM,YPGG,s_ypdw,sum(ypsl),DJ,sum(je),fyrq,wldw,0 as zylx,'�������Һ',1 as ydwbl,
(select top 1 JHJ from YF_KCPH where cjid=a.XMID order by DJSJ desc) jhj,
(select top 1 JHJ*SUM(ypsl) from YF_KCPH where cjid=a.XMID order by DJSJ desc) jhje
 from (
select  CONVERT(varchar(10),a.FYRQ,120) fyrq,XMID,
(case when dbo.fun_getDeptname(a.ksdm) like '%��%' and dbo.fun_getDeptname(a.ksdm) not like '%���%'  and XMID<>6902 then  103 
when dbo.fun_getDeptname(a.ksdm) not like '%��%' and dbo.fun_getDeptname(a.ksdm) not like '%���%'  and XMID<>6902  then 175 
else a.KSDM end) as wldw,SUM((SL*JS)/ydwbl) ypsl,DJ,SUM(JE) je
from MZ_CFB a inner join MZ_CFB_MX b on a.CFID=b.CFID    
inner join vi_yp_ypcd c on b.XMID=c.cjid and c.TLFL='03'
where 
CONVERT(varchar(10),a.FYRQ,120)>=@startdate  and CONVERT(varchar(10),a.FYRQ,120)<=@enddate and  a.BFYBZ=1 and
( b.YFMC in('iv drip','H','iv','im','Ƥ��ע��','iv pump','��������') or b.XMID=6902 )
and  dbo.fun_getDeptname(a.ksdm) not like '%���%' and dbo.fun_getDeptname(a.ksdm) not like '%��Ժ%' 
group by CONVERT(varchar(10),a.FYRQ,120),XMID,ksdm,DJ
) a inner join VI_YP_YPCD b on a.XMID=b.cjid group by fyrq,XMID,wldw,shh,YPPM,YPGG,s_ypdw,DJ order by wldw


--select cjid,shh,spmc,gg,dw,sl,lsj,lsje,fyrq,wldw,zylx,bz,ydwbl from(
--select b.XMID as cjid,e.shh as shh,ltrim(rtrim(b.SPM)) as spmc,LTRIM(RTRIM(e.YPGG)) as gg,b.DW as dw,SUM(SL) as sl,b.DJ as lsj,SUM(b.SL*b.DJ) as lsje,
--CONVERT(varchar(10),a.FYRQ,120) as fyrq,ZXKS as wldw,0 as zylx,'�������Һ'  as bz ,b.YDWBL as YDWBL 
-- from MZ_CFB a inner join MZ_CFB_MX b on a.CFID=b.CFID and ZXKS not in (378,207) and a.BFYBZ=1  and CONVERT(varchar(10),a.FYRQ,120)>=@startdate and CONVERT(varchar(10),a.FYRQ,120)<=@enddate
--inner join vi_yp_ypcd e on b.XMID=e.cjid and e.TLFL='03'
--where  b.YFMC in('iv drip','H','iv','im','Ƥ��ע��','iv pump') or b.XMID=6902 
--group by CONVERT(varchar(10),a.FYRQ,120),XMID,e.shh,dw,ZXKS,DJ,ltrim(rtrim(SPM)),LTRIM(RTRIM(e.YPGG)),b.YDWBL
--union all
--select b.XMID as cjid,e.shh as shh,ltrim(rtrim(b.SPM)) as spmc,LTRIM(RTRIM(e.YPGG)) as gg,b.DW as dw,SUM(SL) as sl,b.DJ as lsj,SUM(b.SL*b.DJ) as lsje,
--CONVERT(varchar(10),a.FYRQ,120) as fyrq,ZXKS as wldw,0 as zylx,'С����Һ��'  as bz,b.YDWBL as YDWBL 
-- from MZ_CFB a inner join MZ_CFB_MX b on a.CFID=b.CFID and ZXKS=176 and a.BFYBZ=1 
--inner join vi_yp_ypcd e on b.XMID=e.cjid and e.TLFL='03' 
--where CONVERT(varchar(10),a.FYRQ,120)>=@startdate and CONVERT(varchar(10),a.FYRQ,120)<=@enddate 
--group by CONVERT(varchar(10),a.FYRQ,120),XMID,e.shh,dw,ZXKS,DJ,ltrim(rtrim(SPM)),LTRIM(RTRIM(e.YPGG)),b.YDWBL 
--union all
--select b.XMID as cjid,e.shh as shh,ltrim(rtrim(b.SPM)) as spmc,LTRIM(RTRIM(e.YPGG)) as gg,b.DW as dw,SUM(SL) as sl,b.DJ as lsj,SUM(b.SL*b.DJ) as lsje,
--CONVERT(varchar(10),a.FYRQ,120) as fyrq,ZXKS as wldw,0 as zylx,
--case when ZXKS=207 then dbo.fun_getDeptname(207) when ZXKS=378 then dbo.fun_getDeptname(378) else  '��Ժ�������Һ' end as bz,b.YDWBL as YDWBL 
-- from MZ_CFB a inner join MZ_CFB_MX b on a.CFID=b.CFID and ZXKS<>176 and a.BFYBZ=1  and CONVERT(varchar(10),a.FYRQ,120)>=@startdate and CONVERT(varchar(10),a.FYRQ,120)<=@enddate
--inner join vi_yp_ypcd e on b.XMID=e.cjid and e.TLFL='03'
--where  b.YFMC not in('iv drip','H','iv','im','Ƥ��ע��','iv pump') or b.XMID<>6902 
--group by CONVERT(varchar(10),a.FYRQ,120),XMID,e.shh,dw,ZXKS,DJ,ltrim(rtrim(SPM)),LTRIM(RTRIM(e.YPGG)),b.YDWBL
--) a


--truncate table yp_tj_dsyyp

/*
select  *from 
declare @err_code int
declare @err_text varchar(300)
exec sp_yp_tj_dsyhz @deptid=566,@year=2014,@month=7,@err_code=@err_code output,@err_text=@err_text output
select @err_code,@err_text 
select * from yp_tj_dsyyp 
select ����,Ʒ��,���,��λ,���ۼ�,sum(��ҩ��) as ��ҩ��,sum(��ҩ��) as ��ҩ��,sum(���۽��) as ���۽��,������λ,��λ���� from 
(
select b.CJID as ����,LTRIM(RTRIM(b.yppm)) as Ʒ��,b.YPGG as ���,YPDW as ��λ,b.LSJ as ���ۼ�,0 as ��ҩ��,sum(YPSL) as ��ҩ��,sum(LSJE) as ���۽��, dbo.fun_getdeptname(a.wldw) as ������λ,YDWBL as ��λ���� 
from  yf_dj  a inner join yf_djmx b on a.ID=b.DJID 
and a.DEPTID=566 and a.YWLX in('014') and SHBZ=1 and 
DATEPART(yy,SHRQ)=2014 and DATEPART(mm,SHRQ)=7
group by CJID,b.yppm,YPGG,YPDW,a.WLDW,YDWBL,LSJ order by WLDW
union all
select cjid as ����,LTRIM(RTRIM(spmc)) as Ʒ��,gg as ���,dw as ��λ,lsj as ���ۼ�,sum(sl) as ��ҩ��,0 as ��ҩ��,sum(lsje) as ���۽��, dbo.fun_getdeptname(wldw) as ������λ,YDWBL as ��λ���� 
from yp_tj_dsyyp  where DATEPART(yy,fyrq)=2014 and DATEPART(mm,fyrq)=7 and (zylx=1 or bz='�������Һ')
group by cjid,spmc,gg,dw,lsj,wldw,ydwbl order by wldw
) a
group by ����,Ʒ��,���,��λ,���ۼ�,������λ,��λ����

*/
--select  *from yf_djmx
--select * from VI_YP_YPCD where cjid='6962'
--select  *from JC_DEPT_PROPERTY where NAME like '%��Һ%'
--select * from yp_tj_dsyyp where cjid=6504 and sl=2 and lsj='5.4600'

--select * from ZY_FEE_SPECI where FY_BIT=5 and DELETE_BIT=0 and XMLY=1 and CONVERT(varchar(10),a.FYRQ,120)='2014-07-24 00:00:00.000' and xmid=6504
--truncate table yp_tj_dsyyp



