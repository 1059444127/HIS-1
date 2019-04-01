--exec SP_Yf_YPMXZ @year=2014,@month=5,@cjid=423,@deptid=215,@cfmx=0
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_YPMXZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_YPMXZ
GO

CREATE PROCEDURE SP_YF_YPMXZ
 ( @year int, 
   @month INTEGER,
   @CJID INTEGER,
   @deptid integer,
   @cfmx int
 ) 
as
BEGIN
 declare @zy varchar(200);
 declare @yjid UNIQUEIDENTIFIER 
 declare @count INT 
 declare @sqyear int;
 declare @sqmonth int;

 DECLARE @stmt varchar(2000); --����SQL�ı�


 --������ʱ��
   create table #TEMP
   (
      ID INTEGER IDENTITY (1, 1) NOT NULL ,
   	  rq datetime,
	  zy varchar(100),
	  ypdw varchar(10),
	  lsj decimal(15,4),
	  jfsl decimal(15,3),
	  jfje decimal(15,2),
	  dfsl decimal(15,3),
	  dfje decimal(15,2),
	  jcsl decimal(15,3),
	  jcje decimal(15,2),
	  ypph varchar(50),
	  ypxq varchar(30),
	  jhj decimal(15,3),
	  ypkl  decimal(10,4),
	  shdh varchar(50),
  	  djrq varchar(30),--��������
	  djid bigint,
	  ydwbl int,
	  cjid int,
	  ywlx varchar(10),
	  ywmc varchar(100),
	  yppch varchar(100),
	  kcid uniqueidentifier,
	  
	  --jhj decimal(15,3) --������
   ) 
   
  create table #DJMX
   (
   	  DJID UNIQUEIDENTIFIER,
   	  CJID INT,
	  zy varchar(100),
	  wldw int,
	  shrq varchar(30),
	  YWLX CHAR(3),
	  YPSL DECIMAL(15,3),
	  ypdw varchar(10),
	  lsje DECIMAL(15,3),
	  lsj decimal(10,4),
	  djh bigint,
	  ypph varchar(50),
	  ypxq varchar(30),
	  jhj decimal(15,3),
	  ypkl  decimal(10,4),
	  shdh varchar(50),
	  djrq varchar(30),
	  ydwbl int,
	  BZ VARCHAR(100),
	  yppch varchar(100),
	  kcid uniqueidentifier ,
	  
	  --jhj decimal(15,3)  --������
   ) 



declare   @DJID UNIQUEIDENTIFIER
declare   @t1_zy varchar(100)
declare   @wldw int
declare   @shrq varchar(30)
declare   @YWLX CHAR(3)
declare   @YPSL DECIMAL(15,3)
declare   @ypdw varchar(10)
declare   @lsje DECIMAL(15,3)
declare   @lsj decimal(10,4)
declare   @djh bigint
declare   @ypph varchar(50)
declare   @ypxq varchar(30)
declare   @jhj decimal(15,3)
declare   @ypkl  decimal(10,4)
declare   @shdh varchar(50)
declare   @djrq varchar(30)  
declare   @ydwbl int
declare   @BZ VARCHAR(100)
declare   @yppch varchar(100)
declare   @kcid uniqueidentifier 

     
if @cjid=0 
   return;


set @sqyear=@year;
set @sqmonth=@month-1;
if @month=1 
begin
  set @sqyear=@sqyear-1;
  set @sqmonth=12;
end 

set @yjid=(select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid );
--if @yjid is null  
--  set @yjid=dbo.FUN_GETEMPTYGUID()
if @yjid is null
  set @yjid=dbo.FUN_GETEMPTYGUID()
	--���ڽ��
set @count=(select count(*) from YF_YMJC (nolock) where cjid=@cjid and nf=@sqyear and yf=@sqmonth and deptid=@deptid);
if @count=0 
   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jcsl,jcje,YDWBL,cjid)values('000','���ڽ��','1900-01-01','���ڽ��',0,'',0,0,1,@cjid);
else
   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jcsl,jcje,YDWBL,cjid) 
   select '000','���ڽ��','1900-01-01','���ڽ��',lsj,ypdw,sum(jcsl),sum(jclsje),YDWBL,cjid 
   from YF_YMJC (nolock) where cjid=@cjid and nf=@sqyear and yf=@sqmonth and deptid=@deptid group by LSJ,YPDW,ydwbl,CJID;


   
insert into #djmx(DJID,cjid,wldw,zy,lsj,shrq,ywlx,ypsl,ypdw,lsje,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,YDWBL,BZ,yppch,kcid ) 
	  select A.ID,b.cjid,wldw,dbo.fun_yf_ywlx(a.YWLX),lsj,case when a.ywlx in('001','002') then (cast(djrq as char(10))+' '+convert(nvarchar,djsj,108)) else (cast(dbo.fun_getdate(shrq) as char(10))+' '+convert(nvarchar,shrq,108) ) end,
		a.ywlx,ypsl,ypdw,lsje,A.DJH,ypph,ypxq,jhj,ypkl,b.shdh,a.rq,YDWBL,A.BZ,b.yppch,b.kcid 
	  from vi_yf_dj a (nolock),vi_yf_djmx b (nolock) where 
		a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and a.deptid=@deptid and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002'))) and a.ywlx not in('017','020') and cjid=@cjid ;

declare t1 cursor local for  select djid,rtrim(zy),wldw,shrq,ywlx,ypsl,ypdw,lsje,lsj,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,bz ,yppch,kcid from #DJmx  order by shrq
open t1
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@bz,@yppch,@kcid 
while @@FETCH_STATUS=0
begin	
	   set @zy='';
	   --�跽
	   --�ɹ���⡢
	   if @ywlx in('001') 
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') '+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj )values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end 
	   --�˻�
	   if @ywlx in('002') 
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl*(-1),@lsje*(-1),@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end 
	   
	   --ҩ���˿ⵥ
	   if @ywlx in('004') 
	   begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,(@ypsl)*(-1),(@lsje)*(-1) ,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end
	   
	   --�ڳ�¼��
	   if @ywlx in('009') 
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'�ڳ�¼��'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   --��ӯ
	   if @ywlx in('005') and @lsje>0  
	      insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'��ӯ'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   --����
	   if @ywlx in('007') and @lsje>0  
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   if @ywlx in('008') and @lsje>0  --��ӯ
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'��ӯ'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid ,@yppch,@kcid,@jhj);

	   
	   if @ywlx in('012') and @lsje>0  --����
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'�������'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   
	   if @ywlx in('015')  --ҩƷ���뵥
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end

	   if @ywlx in('016')  --ҩƷ��ⵥ
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end

	   
   	   if @ywlx in('019','024')  --������� Сҩ�����
	   begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,jfsl,jfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end 
	   
	   --����
	   --ҩƷ������
	   if @ywlx in('003') 
	   begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end 

	      
	   if @ywlx in('005') and @lsje<0  --����
	      insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'����'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@jhj);

	
	   if @ywlx in('006')  --����
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,(@ypsl) ,(@lsje),@YDWBL,@cjid,@yppch,@kcid,@jhj);

	      
	   if @ywlx in('007') and @lsje<0  --����
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@ypsl) ,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   if @ywlx in('008') and @lsje<0  --�̿�
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'�̿�'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,abs(@ypsl) ,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   
	   if @ywlx in('012') and @lsje<0  --����
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,'�������'+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,abs(@lsje),@YDWBL,@cjid,@yppch,@kcid,@jhj);
  
	   
	  if @ywlx in('014','022','023')  --������ҩ
	  begin
	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']';
	   	  insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@zy,@lsj,@ypdw,@ypsl,@lsje ,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	 end
	   
	   if @ywlx in('017')  --��������
	  begin
	      if @cfmx=0 
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   end
	   if @ywlx in('018')  --������¼����
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   
	   if @ywlx in('020')  --סԺ��������
	   begin
	      if rtrim(@BZ)<>'���˴���ͳ�췢ҩ' and  @cfmx=0 
	   	    insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);
	   end 
	   if @ywlx in('021')  --סԺ������¼����
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   
	   if @ywlx in('025')  --������������
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   if @ywlx in('026')  --����Ƽ���
	   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,jhj)values(@ywlx,@t1_zy,@shrq,@t1_zy+'[����:'+rtrim(CAST(@DJH AS  CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@YDWBL,@cjid,@yppch,@kcid,@jhj);

	   
	   
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@bz,@yppch,@kcid
	   
end
CLOSE t1
DEALLOCATE t1
  
  --���ﴦ����ϸ
  	--if @cfmx=1 
		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj)
		select '017','���ﴦ������',b.fyrq,'��������'+'('+rtrim(b.hzxm)+' ��Ʊ:'+rtrim(cast(b.fph as char(15)))+')',c.lsj,c.ypdw,c.ypsl*c.cfts,c.lsje,c.Ydwbl,c.cjid ,c.yppch,c.kcid,c.ypph,c.ypxq ,@jhj
		from vi_YF_FY B (nolock),vi_yf_fymx c (nolock) 
		WHERE  b.id=c.fyid AND b.ywlx ='017'  and isnull(b.yjid,dbo.FUN_GETEMPTYGUID())=@yjid /*and scbz=1*/ and b.deptid=@deptid and c.cjid=@cjid
		--AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='017')       
	
  --סԺ������ϸ
  	--if @cfmx=1 
		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
		select '020','סԺ��������',b.fyrq,'��������'+'('+rtrim(b.hzxm)+' סԺ��:'+rtrim(cast(b.patientno as char(15)))+')',c.lsj,c.ypdw,c.ypsl*c.cfts,c.lsje,c.Ydwbl,c.cjid,c.yppch,c.kcid,c.ypph,c.ypxq ,@jhj
		from  vi_YF_FY B (nolock),vi_yf_fymx c (nolock)
		WHERE  b.id=c.fyid AND b.ywlx ='020'  and isnull(b.yjid,dbo.FUN_GETEMPTYGUID())=@yjid /*and scbz=1*/ and b.deptid=@deptid and c.cjid=@cjid
		--AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='020')    
     

  --סԺͳ�쵥
   		insert into #temp(ywlx,ywmc,rq,zy,lsj,ypdw,dfsl,dfje,YDWBL,cjid,yppch,kcid,ypph,ypxq,jhj )
		select '020','סԺ��������',b.fyrq,dbo.fun_getdeptname(dept_ly)+'ͳ�����('+'����:' +rtrim(cast(b.djh as char(15)))+')',c.lsj,c.ypdw,c.ypsl,c.lsje,c.YDWBL,c.cjid ,c.yppch,c.kcid,c.ypph,c.ypxq ,@jhj
		from YF_tld B (nolock),yf_tldmx c (nolock)
		WHERE  b.groupid=c.groupid and B.ywlx ='020' and isnull(b.yjid,dbo.FUN_GETEMPTYGUID())=@yjid /*and scbz=1*/ and b.deptid=@deptid and C.cjid=@cjid
		--AND DJID IN(SELECT DJID FROM #DJMX WHERE YWLX='020')    


	
  --���ڽ��
    set @count=0;
  	set @count=(select count(*) from YF_YMJC where cjid=@cjid and nf=@year and yf=@month and deptid=@deptid);
    if @count is null 
	   set @count=0;

	
   if @yjid=dbo.FUN_GETEMPTYGUID()
	   insert into #temp(ywlx,ywmc,rq,zy,lsj,jcsl,jcje,YDWBL,cjid) 
	   select '999','���ڽ��',getdate(),'���ڽ��',round(lsj/dwbl,4),kcl,cast(round(lsj*kcl/dwbl,2) as decimal(15,2)),A.DWBL,a.cjid from yf_kcmx a (nolock),vi_yp_ypcd b  (nolock)
	   where a.cjid=b.cjid and a.cjid=@cjid and deptid=@deptid;

	
    if @yjid<>dbo.FUN_GETEMPTYGUID() and @count>0 
   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,jcsl,jcje,YDWBL,cjid) 
	   select '999','���ڽ��',getdate(),'���ڽ��',lsj,sum(jcsl) ,sum(jclsje),YDWBL,cjid
	   from Yf_YMJC (nolock) where cjid=@cjid and nf=@year and yf=@month and deptid=@deptid group by LSJ,YDWBL,CJID;

	
	if @yjid<>dbo.FUN_GETEMPTYGUID() and @count=0 
   	   insert into #temp(ywlx,ywmc,rq,zy,lsj,jcsl,jcje,YDWBL) 
	   values('999','���ڽ��',getdate(),'���ڽ��',0,0,0,1);


declare @t2_jcsl decimal(15,2)
declare @t2_jcje decimal(15,2)
declare @t2_jfsl decimal(15,2)
declare @t2_jfje decimal(15,2)
declare @t2_dfsl decimal(15,2)
declare @t2_dfje decimal(15,2)
declare @t2_ydwbl int
declare @t2_id int
declare @t2_xzxdw int
declare @t2_xdwbl int

declare @ymjcsl decimal(15,2)
declare @ymjcje decimal(15,2)
declare @ymjcdwbl int
set @ymjcsl=0
set @ymjcje=0
set @ymjcdwbl=1


declare @sumsl decimal(15,2)
declare @sumje decimal(15,2)


declare t2 cursor local for  select coalesce(jcsl,0),coalesce(jcje,0),coalesce(jfsl,0),coalesce(jfje,0),coalesce(dfsl,0),coalesce(dfje,0),ydwbl,a.id,zxdw,dwbl from #temp a,yf_kcmx b where a.cjid=b.cjid and deptid=@deptid order by RQ
open t2
fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xzxdw,@t2_xdwbl
while @@FETCH_STATUS=0
begin
   
   if @t2_id>1 
	begin

		set @ymjcsl=@ymjcsl*@t2_ydwbl/@ymjcdwbl
		set @ymjcsl=round(@ymjcsl,2)+ round(@t2_jfsl,2) + round(@t2_dfsl*(-1),2)
	
		set @ymjcje=@ymjcje+@t2_jfje+@t2_dfje*(-1)
		update #temp set jcsl=@ymjcsl,jcje=@ymjcje where id=@t2_id
		set @ymjcdwbl=@t2_ydwbl
	end
    else
	begin
		set @ymjcsl=@t2_jcsl
		set @ymjcje=@t2_jcje
                set @ymjcdwbl=@t2_ydwbl
	end
    
fetch next from t2 into @t2_jcsl,@t2_jcje,@t2_jfsl,@t2_jfje,@t2_dfsl,@t2_dfje,@t2_ydwbl,@t2_id,@t2_xzxdw,@t2_xdwbl
end 


--����ϼ�
insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,dfsl,dfje) 
select @cjid,1,getdate(),'С��',dbo.fun_yp_ypdw(zxdw),null,
sum(jfsl*dwbl/ydwbl),cast(round(sum(jfje),2) as decimal(15,2)),
sum(dfsl*dwbl/ydwbl),cast(round(sum(dfje),2) as decimal(15,2)) from #TEMP a,yf_kcmx b
where a.cjid=b.cjid and b.deptid=@deptid  group by zxdw


  

	
select id ���,rq ����,zy ժҪ,ypdw ��λ,lsj ���ۼ�,cast(jfsl as float) �跽����,jfje �跽���,
cast(dfsl as float) ��������,dfje �������,cast(jcsl as float) �������,cast(jcje as float) �����,ypph ����,
ypxq Ч��,jhj ����,yppch ���κ�,ypkl ����,shdh �ͻ�����,djrq ��������,ywlx ҵ������,ywmc ҵ������ from #TEMP order by rq


select '0' ��� ,zy ҵ������,cast(round(sum(ypsl*dwbl/ydwbl),1) as float) ����,dbo.fun_yp_ypdw(zxdw) ��λ,
cast(sum(lsje) as float) ��� 
from 
(select ywlx,zy,cjid,ypsl,lsje,ydwbl,yppch,kcid,ypph,ypxq  from #djmx union all
 select ywlx,ywmc,cjid,dfsl ypsl,dfje lsje,ydwbl,yppch,kcid,ypph,ypxq from #temp where ywlx in('017','020')
union all  select ywlx,ywmc,cjid,jcsl ypsl,jcje lsje,ydwbl,yppch,kcid,ypph,ypxq from #temp where ywlx in('000','999')) a,
yf_kcmx b (nolock) where a.cjid=b.cjid and deptid=@deptid group by ywlx,zy,zxdw order by ywlx



 END;