
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_XHQK' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_XHQK
GO
-- exec SP_YF_XHQK '2011-07-24 00:00:00','2011-07-24 23:59:59',35
--������ȥĳҩ���� ĳ������������-��ҩƷ��ʾ
--ԭ����ʱ���������񲻶�
--�������סԺ��cjid,���ۼ�

CREATE PROCEDURE SP_YF_XHQK
 (@rq1 datetime, 
  @rq2 datetime, 
  @deptid int
 ) 
as
BEGIN

 DECLARE @stmt varchar(6000); --����SQL�ı�

 --������ʱ��
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
	  bqsl decimal(15,3),
	  bqje decimal(15,2),
      ypdw varchar(20),
	  ydwbl int,
	  cjid int,
	  lsj decimal(15,4), --����
	  lx varchar(20) --���� �����סԺ

   ) 

create TABLE #bqxh (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,
bqsl decimal(15,3),bqje decimal(15,3),lsj decimal(15,4),lx varchar(20)) 




--������
INSERT INTO #bqxh(CJID,bqsl,bqje,lsj,lx)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) * -1 ,
sum(dbo.fun_YF_drt(a.ywlx,lsje)) * -1 ,b.LSJ,
(case when a.ywlx in ('017','018') then '����'  when a.ywlx in ('020','021') then 'סԺ' else '' end) lx

FROM VI_YF_DJ A (nolock),VI_YF_DJMX B (nolock),YF_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
a.YWLX in ('017','018','020','021') and --017,018 ���020,021סԺ
--( shbz=1 and shrq>=@rq1 and shrq<=@rq2 --ԭ�������������񲻶ԣ�������a.djsj ����
((shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@rq1) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq2) 
and  convert(nvarchar,a.djsj,108)>=convert(nvarchar,@rq1,108) and convert(nvarchar,a.djsj,108)<=convert(nvarchar,@rq2,108)  )
) 
group by c.cjid,b.lsj,a.YWLX 


insert into #temp(cjid,bqsl,bqje,ypdw,lsj,lx)
select a.cjid,sum(bqsl)  ,sum(bqje) ,dbo.fun_yp_ypdw(zxdw),a.lsj,a.lx from #bqxh a,
YF_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid group by a.cjid,b.zxdw,a.lx,a.lsj



set @stmt=' select * from (  
select '''' ���,a.lx �����סԺ,a.cjid ҩƷ����,b.s_ypspm ��Ʒ��,b.s_yppm Ʒ��,b.s_sccj ��������  
,b.s_ypgg ���, bzsl ��װ����,a.ypdw ��λ,bqsl ʹ������,a.lsj ����,bqje ���  
  
 from #temp a ,VI_YP_YPCD b  
 where a.cjid=b.cjid'  
  
  
set @stmt=@stmt+  
' union all   
select ''�ϼ�'',null �����סԺ,null ҩƷ����,null ��Ʒ��,null Ʒ��,null ��������,  
null ���,null ��װ����,null ��λ,sum(bqsl) ʹ������,null ����,sum(bqje) ���  
 from #temp a ) aa order by ���,�����סԺ'  
  


print @stmt
exec(@stmt)
drop table #bqxh
drop table #temp
end




