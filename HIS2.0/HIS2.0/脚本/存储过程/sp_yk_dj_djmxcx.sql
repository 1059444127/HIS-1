--exec sp_yk_dj_djmxcx @ywlx=N'001',@dtpdjsj1=N'2014-05-06',@dtpdjsj2=N'2014-05-06',@dtprq1=N'',@dtprq2=N'',@dtpshrq1=N'',@dtpshrq2=N'',@djh=0,@wldw=0,@shdh=N'',@fph=N'',@djbz=N'',@cjid=0,@tjwh=N'',@deptid=214,@sdjh=N'',@deptid_ck=214,@ywy=0

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yk_dj_djmxcx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yk_dj_djmxcx
GO
CREATE PROCEDURE sp_yk_dj_djmxcx
(
 	@ywlx char(3),
	@dtpdjsj1 varchar(30),
	@dtpdjsj2 varchar(30),
	@dtprq1 varchar(30),
	@dtprq2 varchar(30),
	@dtpshrq1 varchar(30),
	@dtpshrq2 varchar(30),
	@djh bigint,
	@wldw int ,
	@shdh varchar(50),
	@fph varchar(50),
	@djbz varchar(200),
	@cjid int,
	@tjwh varchar(50),
	@deptid int  ,
	@sdjh varchar(50),
	@deptid_ck int,
    @ywy int
)
as

p1:begin

 declare @ssfun varchar(200);
 declare @ssql varchar(8000);


--һ��ҵ����ʱ��
 create TABLE #DJMX
   (
 		  ID UNIQUEIDENTIFIER  ,
		  DJH BIGINT default -1 not null,
		  DEPTID INTEGER default -1 not null,
		  YWLX CHAR(3) not null,
		  WLDW INTEGER default -1 not null,
		  JSR INTEGER DEFAULT 0,
		  RQ  varchar(30),
		  DJRQ varchar(40),
		  SHRQ varchar(30),
		  FPH VARCHAR(30),
		  FPRQ CHAR(10),
		  BZ VARCHAR(100),
   		  SHDH VARCHAR(50) ,
		  DJID UNIQUEIDENTIFIER  ,
		  CJID INTEGER default -1 not null,
		  YPPH VARCHAR(30) not null,
		  ypxq varchar(30),
		  YPKL DECIMAL(15,3) default 0 not null,
		  YPSL DECIMAL(15,3) default 0 not null,
		  YPDW VARCHAR(10) not null,
		  JHJ DECIMAL(15,4) default 0 not null,
		  PFJ DECIMAL(15,4) default 0 not null,
		  LSJ DECIMAL(15,4) default 0 not null,
		  JHJE DECIMAL(15,2) default 0 not null,
		  PFJE DECIMAL(15,3) default 0 not null,
		  LSJE DECIMAL(15,3) default 0 not null,
		  SDJH VARCHAR(50),
		  FKBL DECIMAL(15,4) default 1 not null, --�������
		  yppch varchar(100) ,
		  kcid uniqueidentifier ,
		  zbzt smallint
	) 

create table #deptid(deptid int)
--��Ҫͳ�ƵĿ���
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


if @ywlx='008' 
begin
	 set @ssql='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,c.s_yppm Ʒ��,c.s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,
	 yppch ���κ�, b.kcid ,
	 YPpH ����,b.lsj ���ۼ�,b.ypdw ��λ, '+
	 'zcs �ʴ���,zclsje �ʴ���,pcs �̴���,pclsje �̴���,(zcs-pcs) ӯ����,(pclsje-zclsje) ӯ�����,'+
	 'a.djh ���ݺ�,rq ��������,djrq �������,a.id,b.cjid '+ 
	 ' from yf_pd a,yf_pdmx b,yp_ypcjd c '+
	 'where a.id=b.djid and b.cjid=c.cjid'+
	 ' and a.deptid in(select deptid from #deptid) ';
	 if  rtrim(@dtpshrq1)<>'' or rtrim(@dtprq1)<>'' or RTRIM(@dtpdjsj1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +' 00:00:01'' and  djrq<='''+@dtpdjsj2+' 23:59:59'''  ;

	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';

	 exec(@ssql)
	 return;
end

if @ywlx='005' 
begin
	 set @ssql='select 0 ���,dbo.fun_getdeptname(a.deptid) �ֿ�����,c.s_yppm Ʒ��,c.s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,tjsl ����,b.ypdw ��λ, '+
	 'ypfj ԭ������,xpfj ��������,ylsj ԭ���ۼ�,xlsj �����ۼ�,(xlsj-ylsj) ��λ���,tlsje ���۽��, '+
	 'a.djh ���ݺ�,djrq �Ǽ�����,zxrq ִ������,tjwh �����ĺ�,dbo.fun_getempname(a.djy) ����Ա,a.id,b.cjid  '+ 
	 ' from yf_tj a,yf_tjmx b,yp_ypcjd c '+
	 ' where a.id=b.djid and b.cjid=c.cjid'+
	 ' and a.deptid in(select deptid from #deptid) and a.wcbj=1  ';

	 if  RTRIM(@dtpdjsj1)<>'' or RTRIM(@dtprq1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +' 00:00:01'' and  djrq<='''+@dtpdjsj2+' 23:59:59'''  ;

	 if  rtrim(@dtpshrq1)<>'' 
	    set @ssql=@ssql+' and wcbj=1 and zxrq>='''+ @dtpshrq1 +' 00:00:01'' and  zxrq<='''+@dtpshrq2+' 23:59:59'''  ;
	 
	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @tjwh<>'' 
	    set @ssql=@ssql+' and a.tjwh like ''%'+@tjwh+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';

	 set @ssql=@ssql+' order by b.djh,b.id';
	 
	exec(@ssql)
	 return;
end 


--��ǰҵ����������ۺ��̵�ҵ��
	 set @ssql=' insert into #djmx(id,djh,deptid,ywlx,wldw,jsr,rq,djrq,shrq,fph,
	 fprq,bz,djid,cjid,ypph,ypxq,ypkl,ypsl,ypdw,jhj,pfj,lsj,jhje,pfje,lsje,shdh,sdjh,fkbl,yppch,kcid,zbzt ) '+
	 'select a.id,a.djh,a.deptid,a.ywlx,wldw,jsr,rq,djrq,shrq,fph,fprq,a.bz,djid,cjid,ypph,ypxq,
	 ypkl,ypsl,ypdw,jhj,pfj,lsj,jhje,pfje,lsje,b.shdh,sdjh,b.fkbl,b.yppch,b.kcid,b.zbzt   '+ 
	 ' from vi_yk_dj a,vi_yk_djmx b where a.id=b.djid and a.deptid in(select deptid from #deptid) ';

	 if (@ywlx='001' or @ywlx='002' ) and @ywy>0
        set @ssql=@ssql+' and a.jsr='+cast(@ywy as varchar(30))

	 if  @ywlx<>'000' 
	    set @ssql=@ssql+' and a.ywlx='''+@ywlx+'''';

	 if  RTRIM(@dtpdjsj1)<>'' 
	    set @ssql=@ssql+' and djrq>='''+ @dtpdjsj1 +''' and  djrq<='''+@dtpdjsj2+''''  ;

	 if  rtrim(@dtprq1)<>'' 
	    set @ssql=@ssql+' and rq>='''+ @dtprq1 +''' and  rq<='''+@dtprq2+''''  ;

	 if  rtrim(@dtpshrq1)<>'' 
	    set @ssql=@ssql+' and shrq>='''+ @dtpshrq1 +' 00:00:01'' and  shrq<='''+@dtpshrq2+' 23:59:59'''  ;

	 if @djh>0 
	    set @ssql=@ssql+' and a.djh='+cast(@djh as char(10))+'';

	 if @wldw>0 
	    set @ssql=@ssql+' and a.wldw='+cast(@wldw as char(10))+'';

	 if  @shdh<>'' 
	    set @ssql=@ssql+' and b.shdh='''+@shdh+'''';

	 if  @fph<>'' 
	    set @ssql=@ssql+' and a.fph like ''%'+@fph+'%''';

	 if  @djbz<>'' 
	    set @ssql=@ssql+' and a.bz like ''%'+@djbz+'%''';

	 if  @cjid>0 
	    set @ssql=@ssql+' and b.cjid='+cast(@cjid as char(10))+'';
	 if @sdjh<>'' 
	    set @ssql=@ssql+' and sdjh='''+rtrim(@sdjh) +''''
	 print @ssql
	 exec(@ssql)

	 if @ywlx='001' or @ywlx='002' or @ywlx='016' 
	 	 set @ssfun='dbo.fun_yp_ghdw(wldw) ������λ';
	 else
	    set @ssfun='dbo.fun_getdeptname(wldw) ������λ';
 
	 set @ssql='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,rtrim(dbo.fun_yk_ywlx(ywlx)) ҵ������,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,'+
	 's_sccj ����,yppch ���κ�,a.kcid, ypph ����,rtrim(ypxq) Ч��,a.ypkl ����,a.jhj ����,a.lsj ���ۼ�,cast(ypsl as float) ����,a.ypdw ��λ,jhje �������,lsje ���۽��,'+
	 ' (lsje-jhje) ������,djh ���ݺ�,sdjh �µ��ݺ�,cast(rq as datetime)  ��������,shdh �ͻ�����,'+@ssfun+',DBO.fun_yp_ywy(jsr) ҵ��Ա,fph ��Ʊ��,'+
	 'fprq ��Ʊ����,dbo.Fun_GetDate(djrq) �Ǽ�����,shrq  �������,txm ������,a.pfj ������,pfje �������,a.id,b.cjid, cast(a.fkbl*100 as decimal(15,2)) �������, 
	 cast(a.jhje*a.fkbl as decimal(15,3)) ������,(case when a.zbzt=0 then ''��'' else ''��'' end) as �б�״̬ from #djmx a,yp_ypcjd b where a.cjid=b.cjid order by id';
	exec(@ssql)
	 
end 

