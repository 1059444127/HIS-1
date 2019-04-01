IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_tj_xspmtj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_tj_xspmtj
GO
CREATE PROCEDURE SP_YK_tj_xspmtj
 (@type int, --0 ��ʾ���� 1��ʾ���
  @yplx INTEGER,--ҩƷ���� 
  @dtp1 varchar(30),
  @dtp2 varchar(30),
  @MC int, --����
  @deptid int,
  @deptid_ck int
 )  
as
BEGIN
 declare @count INT 
 declare @ss varchar(400)
 --������ʱ��
   create TABLE #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
   create TABLE #TEMP1
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  cjid int,
	  sl decimal(15,3),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 

  	create table #deptid(deptid int)
	--��Ҫͳ�ƵĿ���
	if (@deptid_ck>0)
	  insert #deptid(deptid)values(@deptid_ck)
	else 
	  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


  p2:begin
     
	--��ǰ��
	 set @ss='insert into #temp(cjid,sl,pfje,lsje)select c.cjid,sum(ypsl),sum(pfje),sum(lsje) from yk_dj a,yk_djmx b ,vi_yp_ypcd c '+
	          'where a.id=b.djid and b.cjid=c.cjid  and a.deptid in(select deptid from #deptid) and '+
			  ' a.ywlx in (''003'',''017'',''018'',''020'',''022'',''030'',''032'') and a.shrq>='''+ @dtp1+''' and a.shrq<='''+@dtp2+''' and a.shbz=1 ';
		 if @yplx<>0 
                 begin
		     set @ss=@ss+' and yplx='+cast(@yplx as char(10))+'';
                 end
		     set @ss=@ss+' group by c.cjid ';
	 exec(@ss)
	 
	 --���ݱ�
	 set @ss='insert into #temp(cjid,sl,pfje,lsje)select c.cjid,sum(ypsl),sum(pfje),sum(lsje) from yk_dj_H a,yk_djmx_H b ,vi_yp_ypcd c '+
	          'where a.id=b.djid and b.cjid=c.cjid  and a.deptid in(select deptid from #deptid) and '+
			  '  a.ywlx in (''003'',''017'',''018'',''020'',''022'',''030'',''032'')  and a.shrq>='''+ @dtp1+''' and a.shrq<='''+@dtp2+''' and a.shbz=1 ';
		 if @yplx<>0 
                 begin
		     set @ss=@ss+' and yplx='+cast(@yplx as char(10))+'';
                 end
		     set @ss=@ss+' group by c.cjid ';
		 
	  exec(@ss)
	 
	  set @ss='insert into #temp1(cjid,sl,pfje,lsje)select top '+cast(@mc as char(10))+' cjid,sum(sl),sum(pfje),sum(lsje)'+
	  ' from #temp group by cjid ';
	 if @type=0 
		   set @ss=@ss+' order by sum(sl) desc  ';

		 
	 if @type=1 
		   set @ss=@ss+' order by sum(lsje) desc  ';
	exec(@ss)
	  
	 select  a.id ����,s_ypspm Ʒ��,s_ypgg ���,s_sccj ����,
	 pfj ������,lsj ���ۼ�,sl ����,s_ypdw ��λ,pfje �������,
	  lsje ���۽��,shh ���� from #temp1 a,yp_ypcjd b where a.cjid=b.cjid order by a.id

  end 
 END;
 
 
 

