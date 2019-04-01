IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YF_tj_djqktj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YF_tj_djqktj]
GO
CREATE PROCEDURE [dbo].[SP_YF_tj_djqktj]
 (
   @TYPE INT,
   @ywlx char(3), 
   @yplx INTEGER,
   @ypzlx integer,
   @ghdw integer,
   @CJID INTEGER,
   @dtp1 varchar(30),
   @dtp2 varchar(30),
   @deptid int
 )  
 as
BEGIN 
 declare @ss varchar(500);
 declare @count int
 DECLARE @stmt varchar(5000); --����SQL�ı�


 --������ʱ��
   create TABLE #TEMP
   (
	ID BIGINT IDENTITY (1, 1) NOT NULL ,
	CJID INTEGER default -1 not null,
	YPKL DECIMAL(15,3) default 0 not null,
	YPSL DECIMAL(15,3) default 0 not null,
	ypdw varchar(10),
	YDWBL INTEGER,
	JHJE DECIMAL(15,3) default 0 not null,
	PFJE DECIMAL(15,3) default 0 not null,
	LSJE DECIMAL(15,3) default 0 not null,
	wldw varchar(100),
	yydm int,
	djh bigint,
	djrq datetime,
	djy int,
	bz varchar(100),
	pxxh int
   ) 
  
begin

 --��һ����ȡҵ�����ݵ���ʱ��
  if @ywlx not in('017','020')
  begin
     set @stmt='insert into #temp(cjid,ypkl,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,yydm,djh,djrq,djy,pxxh) '+
	  'select C.cjid,ypkl,ypsl,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,wldw,yydm,a.djh,
	  (case when a.ywlx in(''001'',''002'') then cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime) else a.shrq end),
	   a.djy,b.pxxh from vi_YF_dj a,vi_YF_djmx b,yp_ypcjd c '+ 
	  'where a.id=b.djid and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))

	 if @ywlx<>'001' and @ywlx<>'002' 
	   set @stmt=@stmt+' and shbz=1 and ' +' a.shrq>='''+@dtp1+''' and a.shrq<='''+@dtp2+'''';
     else 
       set @stmt=@stmt+' and ' +'cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime)>='''+@dtp1+''' and cast(dbo.Fun_GetDate(djrq)+'' ''+CONVERT(varchar,a.djsj,108) as datetime)<='''+@dtp2+'''';
     
     
  	 if @ghdw>0 
	   set @stmt=@stmt+' and wldw='+cast(@ghdw as char(10)) +'';

	 
	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

	 
  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
	  
--��ҩҵ��
  if @ywlx  in('017','020')
  begin
     set @stmt='insert into #temp(cjid,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,djrq,djy,bz,pxxh) '+
	  'select C.cjid,ypsl*b.cfts,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,null,
	  a.fyrq,
	   a.fyr,
	  (case when a.ywlx=''017'' then ''���﷢Ʊ��:''+cast(a.fph as varchar(50)) else ''סԺ��:''+patientno end),pxxh
	   from VI_YF_FY a,VI_YF_FYMX b,yp_ypcjd c '+ 
	  'where a.id=b.FYID and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))
	   set @stmt=@stmt+' and ' +' a.fyrq>='''+@dtp1+''' and a.fyrq<='''+@dtp2+'''';

	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
  

 
 --��ҩҵ��
 if @ywlx  in('020')
  begin
     set @stmt='insert into #temp(cjid,ypsl,ypdw,ydwbl,jhje,pfje,lsje,wldw,djrq,djy,bz) '+
	  'select C.cjid,ypsl,b.ypdw,ydwbl,'+
	  'b.jhje,pfje,'+
	  'lsje,null,
	  a.fyrq,
	   a.fyr,
	  ''ͳ�췢ҩ����:''+cast(djh as varchar(50)) 
	    from VI_YF_TLD a,VI_YF_TLDMX b,yp_ypcjd c '+ 
	  'where a.GROUPID=b.GROUPID and b.cjid=c.cjid and a.ywlx='''+@ywlx+''' and a.deptid='+cast(@deptid as char(10))
	   set @stmt=@stmt+' and ' +' a.fyrq>='''+@dtp1+''' and a.fyrq<='''+@dtp2+'''';

	 if @cjid>0 
	   set @stmt=@stmt+' and C.cjid='+cast(@cjid as char(10)) +'';

  	 if @yplx<>0 
	 begin
		   set @stmt=@stmt+' and n_yplx='+cast(@yplx as char(10)) +'';
	 end ;

	 if @ypzlx<>0 
	     begin
		   set @stmt=@stmt+' and n_ypzlx='+cast(@ypzlx as char(10))+'';
		 end;

	 print @stmt
  	 exec(@stmt)
  end
  
 end
 
 
	  
--�ڶ�������ʱ����ͳ�Ʊ���
begin

  if @ywlx='001' OR @YWLX='002' 
begin
     if @type=0  
	   BEGIN
	     set @stmt='select ''0'' ���,dbo.fun_yp_ghdw(wldw) ������λ,sum(jhje) �������,sum(pfje) �������,'+
		 'sum(lsje) ���۽��,(sum(lsje)-sum(jhje)) ������,(sum(lsje)-sum(pfje)) ������ '+ 
		 'from #temp a  group by a.wldw';
	   END; 
	 else
  	     set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(jhje) �������,sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(jhje)) ������,'+
			  '(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a ,vi_yp_ypcd b '+
	          'where  a.cjid=b.cjid  group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw'; 
end
  
  --ҩƷ����
  if @ywlx='003' 
begin
     if @type=0 
	 	set @stmt='select ''0'' ���,dbo.fun_getdeptname(wldw) ��ҩ��λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID '+
		'from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,'+
			  '(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

  
  --ҩ���˿�
  if @ywlx='004' 
begin
     if @type=0 
	 	set @stmt='select ''0'' ���,dbo.fun_getdeptname(wldw) ������λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID '+
		'from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,'+
			  '(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --����
  if @ywlx='005' 
begin
     --0 
     if @type=0  
	 	set @stmt='select ''0'' ���,''���۽��'' ��Ŀ ,coalesce(sum(pfje),0) �������,'+
		'coalesce(sum(lsje),0) ���۽�� '+
		'from #temp a ';
     else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ��������,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --����
 if @ywlx='006' 
begin
         if @type=0  
	 	set @stmt='select ''0'' ���,coalesce(dbo.fun_yp_bsyy(yydm),''δдԭ��'') ����ԭ�� ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ '+
		'from #temp a group by yydm';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --����
  if @ywlx='007' 
begin
     --0 ����ԭ���ѯ 
    	 if @type=0  
	 	set @stmt='select ''0'' ���,coalesce(dbo.fun_yp_yyyy(yydm),''δдԭ��'') ����ԭ�� ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ '+
		'from #temp a  group by yydm';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  --ҩƷ�̵�
  if @ywlx='008' 
begin
   	 if @type=0  
	 	set @stmt='select ''0'' ���,''ӯ�����'' ��Ŀ ,coalesce(sum(pfje),0) �������,coalesce(sum(lsje),0) ���۽�� from #temp a';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ӯ������,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
      --�ڳ�¼��
  if @ywlx='009' 
begin
      if @type=0 
	 	set @stmt='select ''0'' ���,''�ڳ����'' ��Ŀ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a group by wldw';
      else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
  if @ywlx='012' 
begin
        if @type=0 
	 	set @stmt='select ''0'' ���,''�������'' ��Ŀ ,coalesce(sum(jhje),0) �������,coalesce(sum(pfje),0) �������,'+
		'coalesce(sum(lsje),0) ���۽�� from #temp a where lsje<>0 or pfje<>0 ';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(jhje) �������,sum(pfje) �������,sum(lsje) ���۽��,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid and (lsje<>0 or pfje<>0) group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
    --������ҩ��
  if @ywlx='014' 
begin
     	if @type=0 
	 	set @stmt='select ''0'' ���,dbo.fun_getdeptname(wldw) ��ҩ��λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --ҩƷ���뵥
  if @ywlx='015' or @ywlx='016' 
begin
     	if @type=0  
	 	set @stmt='select ''0'' ���,dbo.fun_getdeptname(wldw) ������λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  --���ﴦ������
if @ywlx='017' or @ywlx='020' 
begin
     	if @type=0 
	 	set @stmt='select ''0'' ���,''��������'' ��Ŀ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,
	 			dbo.fun_yp_sccj(sccj) ���� ,cast(round(kcl/dwbl,2) as float) ���п��, 
	 			cast(round(sum(ypsl/ydwbl),3) as float) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a inner join vi_yp_ypcd b '+
	          'on a.cjid=b.cjid inner join yf_kcmx c on b.cjid=c.cjid where c.deptid='+cast(@deptid as varchar(50))+' group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw,kcl,dwbl';
end
  
    --������ʴ�����¼����
 if @ywlx='018' or @ywlx='021' 
begin
    	 if @type=0  
	 	set @stmt='select ''0'' ���,''������¼����'' ��Ŀ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a  group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

      --�������
  if @ywlx='019' 
begin
     if @type=0  
	 	set @stmt='select ''0'' ���, dbo.fun_yp_ghdw(wldw) ������λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
  
      --����ҩ��ҩ
  if @ywlx='022' 
begin
   	  if @type=0  
	 	set @stmt='select ''0'' ���, dbo.fun_getdeptname(wldw) ������λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID from #temp a group by wldw';
	  else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
   --Сҩ��ҩƷ(������Һ)���쵥����
  if @ywlx='023' or @ywlx='024' 
begin
     if @type=0  
	 	set @stmt='select ''0'' ���, dbo.fun_getdeptname(wldw) ������λ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,wldw as ������λID from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
    --������������
  if @ywlx='025'
begin
    	 if @type=0  
	 	set @stmt='select ''0'' ���,''������������'' ��Ŀ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end
  
      --����Ƽ���
  if @ywlx='026'
begin
   	  if @type=0  
	 	set @stmt='select ''0'' ���,''����Ƽ���'' ��Ŀ ,sum(pfje) �������,'+
		'sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������ from #temp a group by wldw';
	 else
	 	set @stmt='select ''0'' ���,ypspm Ʒ��,ypgg ���,dbo.fun_yp_sccj(sccj) ���� ,cast(round(sum(ypsl/ydwbl),3) as decimal(18,3)) ����,dbo.fun_yp_ypdw(b.ypdw) ��λ,'+
		      'sum(pfje) �������,sum(lsje) ���۽��,(sum(lsje)-sum(pfje)) ������,b.cjid  from #temp a,vi_yp_ypcd b '+
	          'where a.cjid=b.cjid group by b.cjid,b.ypspm,b.ypgg,b.sccj,b.ypdw';
end

 exec(@stmt)
 
select '0' ��� ,SHH ����,S_YPPM Ʒ��,S_YPSPM ��Ʒ��,S_YPGG ���,b.s_sccj ����,a.YPSL ����,a.ypdw ��λ,
a.pfje �������,a.LSJE ���۽��,a.djh ���ݺ�,a.djrq ����,
(case when @ywlx IN('001','002','019') then dbo.fun_yp_ghdw(wldw) else  dbo.fun_getDeptname(a.wldw)  end) ������λ,a.BZ ��ע
from #TEMP a,YP_YPCJD b where a.CJID=b.CJID
union all
select '�ϼ�' ��� ,'' ����,'�ϼ�' Ʒ��,'' ��Ʒ��,'' ���,'' ����,null ����,'' ��λ,
sum(a.pfje) �������,sum(a.LSJE) ���۽��,null ���ݺ�,GETDATE() ����,
null  ������λ,null ��ע
from #TEMP a 
 order by ����,��ע
  

end 

 END;
GO


