
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_TJ_GZYPTJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_TJ_GZYPTJ
GO
CREATE PROCEDURE SP_YK_TJ_GZYPTJ
 ( 
   @deptid int,
   @RQ1 varchar(30), 
   @RQ2 varchar(30),
   @yplx int,
   @type int,
   @deptid_ck int
 )
as 
 DECLARE @stmt varchar(1000); --����SQL�ı�

  create TABLE #temp
   (
      ID INTEGER not null IDENTITY (1,1),
	  cjid int,
      sk int,
	  kcl decimal(15,1),
   	  rksl decimal(15,1),
   	  cksl decimal(15,1)
   ) 
	create table #deptid(deptid int)
	--��Ҫͳ�ƵĿ���
	if (@deptid_ck>0)
	  insert #deptid(deptid)values(@deptid_ck)
	else 
	  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID

--032 ԭ�����ĳ���  033�Ƽ��ӹ���Ʒ���
begin
  set @stmt='insert into #temp(cjid,cksl,sk,rksl)
 			 select b.cjid,sum(case when b.ywlx in(''003'',''004'',''014'',''030'',''032'') then dbo.FUN_YK_DRT(b.ywlx,ypsl/ydwbl) else 0 end) cksl,0,
		 sum(case when b.ywlx in(''001'',''002'',''016'',''009'',''031'',''033'') then dbo.FUN_YK_DRT(b.ywlx,ypsl/ydwbl) else 0 end) rksl 
  		 from vi_yk_dj A(nolock),vi_yk_djmx b(nolock),vi_yp_ypcd c(nolock) 
  		where a.id=b.djid and  b.cjid=c.cjid and shrq>='''+@rq1+''' and shrq<='''+@rq2+''' and shbz=1 and 
 		 b.ywlx in(''003'',''004'',''014'',''001'',''002'',''016'',''009'',''030'',''031'',''032'',''033'')   '
    if @type=0 
     set @stmt=@stmt+' and gzyp=1 '
    if @type=1
     set @stmt=@stmt+' and  mzyp=1 '
    if @type=2
     set @stmt=@stmt+' and  djyp=1 '
    if @type=3
     set @stmt=@stmt+' and  psyp=1 '
    if @type=4
     set @stmt=@stmt+' and  jsyp=1 '
    if @type=5
     set @stmt=@stmt+' and  wyyp=1 '
    if @type=6
     set @stmt=@stmt+' and  cfyp=1 '
    if @type=7
     set @stmt=@stmt+' and  rsyp=1 '
    if @type=8
     set @stmt=@stmt+' and  gjjbyw=1 '
    if @type=9
     set @stmt=@stmt+' and  kssdjid>0 '
	if @type=10--ȫ��
	 set @stmt=@stmt+' and (gzyp=1 or mzyp=1 or djyp=1 or psyp=1 or jsyp=1 or wyyp=1 or cfyp=1 or rsyp=1 or gjjbyw=1 or kssdjid>0) '
	
   if @deptid>0
     set @stmt=@stmt+'and b.deptid in(select deptid from #deptid)'
   if @yplx>0
     set @stmt=@stmt+'and yplx='+cast(@yplx as char(10))
   set @stmt=@stmt+'  group by b.cjid  '
  print @stmt
  exec(@stmt)
  
  update a  set a.kcl=b.kcl from #temp a inner join 
  (select cjid,round(sum(kcl/dwbl),1) kcl from vi_yk_kcmx where deptid in(select deptid from #deptid) group by cjid) b
	on a.cjid=b.cjid

  select 0 ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,lsj ���ۼ�,s_ypdw ��λ,cast(rksl as float) �����,-(cast(cksl as float)) ������,
   cast(kcl as float) ����� from #temp a inner join yp_ypcjd b on a.cjid=b.cjid 
end


--exec SP_YK_TJ_GZYPTJ 98,'2007-01-01 00:00:00','2008-01-01 23:59:59',0
