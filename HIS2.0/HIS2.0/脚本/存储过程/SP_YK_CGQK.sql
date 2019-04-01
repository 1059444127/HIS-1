
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_CGQK' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_CGQK
GO
-- exec SP_YK_CGQK '2010-03-08 00:00:00','2012-03-08 23:59:59',33
--������ȥĳҩ���� ĳ����Ĺ������-������-��ҩƷ��ʾ
--���˱��ڹ�������>0������--�Ƿ���Ҫ���뿼��
--ҩƷ�������Ҽ������ۣ�ʹ�õ����һ�ε�
CREATE PROCEDURE SP_YK_CGQK
 (@rq1 datetime, 
  @rq2 datetime, 
  @deptid int
 ) 
as
BEGIN
 declare @zy varchar(200);
 declare @count INT 
 declare @sqyear int;
 declare @sqmonth int;

 DECLARE @stmt varchar(6000); --����SQL�ı�

 --������ʱ��
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
	  sqsl decimal(15,3),
	  sqje decimal(15,2),
	  bqsl decimal(15,3),
	  bqje decimal(15,2),
	  jcsl decimal(15,3),
	  jcje decimal(15,2),
      ypdw varchar(20),
	  ydwbl int,
	  cjid int,
	  bqsl_gj decimal(15,3), --���ڹ�������

   ) 


declare @yjid UNIQUEIDENTIFIER --�����½�ID
declare @yjdjsj datetime --�����½�Ǽ�ʱ��

select @count=count(*) from yp_kjqj where deptid=@deptid and jsrq<=@rq1 
if coalesce(@count,0)<1 
begin
  set @yjid=null
  set @yjdjsj='2001-01-01 00:00:00'
end
else
begin
	select top 1 @yjid=id,@yjdjsj=jsrq from  (
	select top 2 * from yp_kjqj where deptid=@deptid and jsrq<=@rq1  order by jsrq desc
	) a order by djsj desc
	IF @YJID IS NULL 
		set @yjid=null
end




--����������
create TABLE #ymjc (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,ydwbl int,sqsl DECIMAL(15,3),
sqje decimal(15,3),bqsl decimal(15,3),bqje decimal(15,3),jhj decimal(15,4), bqsl_gj decimal(15,3)) 

INSERT INTO #ymjc(CJID,sqsl,sqje,bqsl_gj,jhj)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YK_drt(a.ywlx,lsje)),0,B.JHJ
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
--( shbz=1 and shrq>@yjdjsj and shrq<@rq1--ԭ�������������񲻶ԣ�������a.djsj ����
((shbz=1 and a.ywlx not in('001','002') and shrq>@yjdjsj and shrq<@rq1 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@yjdjsj) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq1) 
and  convert(nvarchar,a.djsj,108)>convert(nvarchar,@yjdjsj,108) and
 convert(nvarchar,a.djsj,108)<convert(nvarchar,@rq1,108)  )
)
group by c.cjid,B.JHJ


insert into #ymjc(cjid,ydwbl,sqsl,sqje,bqsl_gj)
select b.cjid,ydwbl,round(jcsl*b.dwbl/ydwbl,3),jclsje,0 from YK_ymjc a (nolock),YK_kcmx b (nolock) 
where a.cjid=b.cjid and  b.deptid=@deptid and yjid=@yjid 


--������
INSERT INTO #ymjc(CJID,bqsl,bqje,bqsl_gj,jhj)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
sum(dbo.fun_YK_drt(a.ywlx,lsje)),
sum(case when a.ywlx in ('001','002') then  dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) else 0 end),
B.JHJ
FROM VI_YK_DJ A (nolock),VI_YK_DJMX B (nolock),YK_kcmx c (nolock)
WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID  and 
--( shbz=1 and shrq>=@rq1 and shrq<=@rq2 --ԭ�������������񲻶ԣ�������a.djsj ����
((shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
( a.ywlx in('002','001') and dbo.Fun_GetDate(a.djrq)>=dbo.Fun_GetDate(@rq1) and dbo.Fun_GetDate(a.djrq)<=dbo.Fun_GetDate(@rq2) 
and  convert(nvarchar,a.djsj,108)>=convert(nvarchar,@rq1,108) and convert(nvarchar,a.djsj,108)<=convert(nvarchar,@rq2,108)  )
)  
group by c.cjid,B.YWLX,B.JHJ

insert into #temp(cjid,sqsl,sqje,bqsl,bqje,jcsl,jcje,ypdw,bqsl_gj)
select a.cjid,sum(sqsl),sum(sqje),sum(bqsl),sum(bqje),0,0,dbo.fun_yp_ypdw(zxdw),SUM(bqsl_gj) from #ymjc a,
YK_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid group by a.cjid,b.zxdw


set @stmt='
select '''' ���,b.s_ypspm ��Ʒ��,b.s_yppm Ʒ��,b.s_ypgg ���, bzsl ��װ����,a.ypdw ��λ
,b.s_ypjx ҩƷ����,dbo.fun_getUsageName(syff) ��ҩ;��,sqsl ��������,bqsl_gj ���ڹ���
,(select top 1 jhj from #ymjc where cjid=a.cjid order by bqsl_gj desc ) ������
,b.s_sccj ��������
,(select top 1 dbo.fun_yp_ghdw(t1.wldw) from YK_DJ t1,YK_DJMX t2 where t1.ID=t2.DJID and t2.cjid=a.cjid  and t1.deptid='+ cast(@deptid AS varchar) +' order by t1.shrq desc ) ҩƷ������λ
,(coalesce(sqsl,0)+coalesce(bqsl,0)) �������
 from #temp a ,VI_YP_YPCD b
 where a.cjid=b.cjid and bqsl_gj>0 '


set @stmt=@stmt+
' union all 
select ''�ϼ�'',null ��Ʒ��,null Ʒ��,null ���,null ��װ����,null ��λ,
null ҩƷ����,null ��ҩ;��,sum(sqsl)��������,sum(bqsl_gj) ���ڹ���,null ������ ,null ��������,null ҩƷ������λ,(sum(sqsl)+sum(bqsl))  �����
 from #temp a where bqsl_gj>0  '


print @stmt
exec(@stmt)
drop table #ymjc
drop table #temp
end




