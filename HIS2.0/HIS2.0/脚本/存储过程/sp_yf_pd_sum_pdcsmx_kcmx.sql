 --exec sp_yf_pd_sum_pdcsmx_kcmx @deptid=214
 IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_pd_sum_pdcsmx_kcmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_pd_sum_pdcsmx_kcmx
GO
CREATE PROCEDURE sp_yf_pd_sum_pdcsmx_kcmx
(
 	@deptid int
)
as

create table #temp(cjid int,kcid UNIQUEIDENTIFIER, pcsl decimal(15,3), pxxh int)

--�����̴���,������������
insert into #temp(cjid,kcid,pcsl,pxxh)
select 
x.cjid,
x.kcid,
cast(sum(pcsl*coalesce(x.ydwbl,1)/ydwbl) as float) pcsl,
(select top 1 a.djh+pxxh from yf_pdcs a,YF_PDCSMX_KCMX b where a.id=b.djid and 
shbz=0 and bdelete=0 and b.kcid=x.kcid order by djrq,pxxh )  as pxxh
FROM YF_PDCSMX_KCMX x inner join yf_pdcs y on x.djid=y.id
left join yf_pdtemp z on x.kcid=z.kcid AND z.shbz=0 and z.deptid=@deptid 
where x.deptid=@deptid and y.shbz=0 and y.bdelete=0 
 group by x.cjid,x.kcid 


--�����
select CAST(0 AS CHAR(12)) ���,B.s_yppm Ʒ��,b.s_ypspm ��Ʒ��,b.s_ypgg ���,s_sccj ����,
cast(round(b.pfj/coalesce(c.dwbl,1),4) as decimal(15,4)) ������,
cast(round(b.pfj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) �������,
 cast(round(b.lsj/coalesce(c.dwbl,1),4) as decimal(15,4)) ���ۼ�,
 '' ����,'' ��λ,
 cast(coalesce(c.kcl,0) as float) ��������,
 cast(round(b.lsj*coalesce(c.kcl,0)/coalesce(c.dwbl,1),2) as decimal(15,2)) ������,
 pcsl �̴�����, 
 coalesce(dbo.fun_yp_ypdw(coalesce(zxdw,0)),b.s_ypdw) ��λ, 
 cast(round(b.lsj*cast(a.pcsl as decimal(15,3))/coalesce(c.dwbl,1),2) as decimal(15,2)) �̴���,
 (a.pcsl-coalesce(c.kcl,0)) ӯ������,
cast(round(b.lsj*(a.pcsl-coalesce(c.kcl,0))/coalesce(c.dwbl,1),2) as decimal(15,2)) ӯ�����,
0 ����,
0 �������,
b.shh ����, a.cjid,a.kcid,coalesce(c.dwbl,1) dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
 from 
 #temp A inner join YP_YPCJD B on a.cjid=b.cjid 
left join  yf_pdtemp_kcmx  C on a.kcid=c.kcid  and c.deptid=@deptid  and c.shbz=0 --and c.bdelete=0
left join yp_hwsz d on b.ggid=d.ggid and d.deptid=@deptid order by pxxh



