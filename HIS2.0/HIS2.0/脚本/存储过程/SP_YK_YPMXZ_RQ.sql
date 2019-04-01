--exec SP_YK_YPMXZ @year=2014,@month=4,@cjid=418,@deptid=217,@cfmx=0,@deptid_ck=217
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YK_YPMXZ_RQ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YK_YPMXZ_RQ
GO

CREATE PROCEDURE SP_YK_YPMXZ_RQ
 (@rq1 datetime, 
  @rq2 datetime, 
  @cjid int,
  @deptid int,
  @cfmx smallint,
  @deptid_ck int
 ) 
as



BEGIN
 declare @zy varchar(200)
 declare @count INT 
 declare @sqyear int
 declare @sqmonth int

 DECLARE @ss varchar(5000) --����SQL�ı�

SET @RQ1=@RQ1+' 00:00:00'
SET @RQ2=@RQ2+' 23:59:59'

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
	  ypph varchar(50),--����
	  ypxq varchar(30),--Ч��
	  jhj decimal(15,3),--����
	  ypkl  decimal(10,4),
	  shdh varchar(50),
  	  djrq varchar(30),--��������
	  djid UNIQUEIDENTIFIER,
	  ydwbl int,
	  cjid int,
	  yppch varchar(100),
	  kcid uniqueidentifier
	  
   ) 
   
  create table #DJMX
   (
   	  DJID UNIQUEIDENTIFIER,
   	  CJID INT,
	  zy varchar(100),
	  wldw int,
	  shrq datetime,
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
	  ydwbl int ,
	  yppch varchar(100),
	  kcid uniqueidentifier 
   ) 

--��Ҫͳ�ƵĿ���
create table #deptid(deptid int)
if (@deptid_ck>0)
  insert #deptid(deptid)values(@deptid_ck)
else 
  insert #deptid(deptid) select deptid from yp_yjks_gx where p_deptid=@deptid UNION SELECT @DEPTID


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
declare   @yppch varchar(100)
declare   @kcid  uniqueidentifier 

if @cjid=0  return

declare @yjid UNIQUEIDENTIFIER --�����½�ID
declare @yjdjsj datetime --�����½�Ǽ�ʱ��

--�����������ͽ��
create TABLE #ymjc (ID int IDENTITY (1, 1) NOT NULL ,CJID INT,sysl DECIMAL(15,3),ydwbl int,syje decimal(15,3),bqsl decimal(15,3),bqje decimal(15,3)) 


--���ս����
INSERT INTO #ymjc(CJID,bqsl,bqje)
SELECT c.cjid,
sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,ypsl/b.ydwbl) end) ,
sum(dbo.fun_YK_drt(a.ywlx,lsje))
FROM VI_YK_DJ A,VI_YK_DJMX B,yp_ypcjd c 
WHERE a.id=b.djid AND b.cjid=c.cjid  and a.deptid in(select deptid from #deptid)  and 
( (shbz=1 and a.ywlx not in('001','002') and shrq<@rq1 ) or 
(a.ywlx in('002','001') and a.djrq<@rq1  )
) and b.cjid=@cjid
group by c.cjid


insert into #TEMP(cjid,rq,zy,ypdw,ydwbl,lsj,jcsl,jcje) select a.cjid,'1900-01-01','���ս��',s_ypdw,1,0,bqsl,bqje from  yp_ypcjd a left join #ymjc  b on a.cjid=b.cjid where a.cjid=@cjid

   
--ͳ�������ڵķ�����ϸ
insert into #djmx(DJID,cjid,wldw,zy,lsj,shrq,ywlx,ypsl,ypdw,lsje,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,yppch,kcid ) 
	   select A.ID,b.cjid,wldw,dbo.FUN_YK_YWLX(a.YWLX),lsj,
	   	  cast(case when a.ywlx in('001','002') then (cast(djrq as char(10))+' '+convert(nvarchar,djsj,108)) else (cast(shrq as char(10))+' '+convert(nvarchar,shrq,108)) end as datetime),
		  a.ywlx,ypsl,ypdw,lsje,a.djh,ypph,ypxq,jhj,ypkl,b.shdh,a.rq,ydwbl,b.yppch,b.kcid 
	   from VI_YK_DJ a,VI_YK_DJMX b where 
	       a.id=b.djid   and a.deptid in(select deptid from #deptid)  and 
	( (shbz=1 and a.ywlx not in('001','002') and shrq>=@rq1 and shrq<=@rq2 ) or 
	(a.ywlx in('002','001') and djrq>=@rq1 and djrq<=@rq2  )
	)  and b.cjid=@cjid

	
declare t1 cursor local for  select djid,rtrim(zy),wldw,shrq,ywlx,ypsl,ypdw,lsje,lsj,djh,ypph,ypxq,jhj,ypkl,shdh,djrq,ydwbl,yppch,kcid  from #DJmx order by shrq
open t1
fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@yppch,@kcid 
while @@FETCH_STATUS=0
begin
	   set @zy=''
	   --�跽
	   --�ɹ���⡢
	   if @ywlx in('001') 
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )
		end

	   --�˿�
	   if @ywlx in('002') 
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+') ' +'[����:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@zy,@ypdw,@lsj,@ypsl*(-1),@lsje*(-1),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )
		end

	   
	   --�ڳ�¼��
	   if @ywlx in('009') 
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'�ڳ�¼�� '+'[����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   --��ӯ
	   if @ywlx in('005') and @lsje>0  
	      insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'��ӯ' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   --����
	   if @ywlx in('007') and @lsje>0  
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   if @ywlx in('008') and @lsje>0  --��ӯ
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'��ӯ' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid  )

	   
	   if @ywlx in('012') and @lsje>0  --����
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'�������' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@lsje,'','',@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid  )

	   
	   if @ywlx in('016')  --�������
		begin
	   	  set @zy=@t1_zy +'('+coalesce(dbo.fun_yp_ghdw(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )
                end
	   
	   --����
	   --���ⵥ
	   if @ywlx in('003','014','022') 
		begin
        	      set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@zy,@ypdw,@lsj,@ypsl,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid  )
		end

	   --ҩ���˿ⵥ
	   if @ywlx in('004') 
		begin
     	          set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']'
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@zy,@ypdw,@lsj,(@ypsl)*(-1),(@lsje)*(-1),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl ,@yppch,@kcid )
		end

	      
	   if @ywlx in('005') and @lsje<0  --����
	      insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'����' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid  )
	  
	
	   if @ywlx in('006')  --����
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	      
	   if @ywlx in('007') and @lsje<0  --����
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@ypsl) ,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   if @ywlx in('008') and @lsje<0  --�̿�
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'�̿�' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@ypsl) ,abs(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   
	   if @ywlx in('012') and @lsje<0  --����
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,'�������' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,abs(@lsje),'','',@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   
	   if @ywlx in('017')  --��������
	   	   insert into #TEMP(cjid,rq,zy,lsj,ypdw,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@lsj,@ypdw,@ypsl ,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid)
	   
	   if @ywlx in('018')  --���˴�����¼
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )

	   
	   if @ywlx in('020')  --������¼
       begin
	   	  insert into #TEMP(cjid,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,ydwbl,yppch,kcid )values(@cjid,@shrq,@t1_zy +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@ydwbl,@yppch,@kcid )
	   end

	   if @ywlx in('030')  --ͬ������
           begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
	   end
	   if @ywlx in('031')  --ͬ������
       begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
	   end
	   
	       if @YWLX in ('032') --�Ƽ��ӹ�ԭ�����ĳ���
	   begin
			set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')'+' [����:'+RTRIM(CAST(@djh as CHAR(20)))+']'
			insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,dfsl,dfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid ) values
			(@CJID,@ydwbl,@shrq,@zy,@ypdw,@lsj,@YPSL,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@DJID,@yppch,@kcid )
	   end
	   
	   if @YWLX in ('033') --�Ƽ��ӹ���Ʒ���
	   begin
			set @zy=@t1_zy+'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')'+' [����:'+RTRIM(CAST(@djh as CHAR(20)))+']'
			insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid ) values
			(@CJID,@ydwbl,@shrq,@zy,@ypdw,@lsj,@YPSL,@lsje,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@DJID,@yppch,@kcid )
	   end
	   
	   if @YWLX in ('034') --���ε���
	    begin
	   	  insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,ypph,ypxq,jhj,ypkl,shdh,djrq,djid,yppch,kcid )values(@cjid,@ydwbl,@shrq,@t1_zy +'('+coalesce(dbo.fun_getdeptname(@wldw),'')+')' +' [����:'+rtrim(CAST(@DJH AS CHAR(20)))+']',@ypdw,@lsj,(@ypsl) ,(@lsje),@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@djid,@yppch,@kcid )
	   end
	   

fetch next from t1 into @djid,@t1_zy,@wldw,@shrq,@ywlx,@ypsl,@ypdw,@lsje,@lsj,@djh,@ypph,@ypxq,@jhj,@ypkl,@shdh,@djrq,@ydwbl,@yppch,@kcid 
	   
end
CLOSE t1
DEALLOCATE t1
  
  --���ڽ��
declare @t2_jcsl decimal(15,2)
declare @t2_jcje decimal(15,2)
declare @t2_jfsl decimal(15,2)
declare @t2_jfje decimal(15,2)
declare @t2_dfsl decimal(15,2)
declare @t2_dfje decimal(15,2)
declare @t2_ydwbl int
declare @t2_id int
declare @t2_xzxdw varchar(20)
declare @t2_xdwbl int

declare @ymjcsl decimal(15,2)
declare @ymjcje decimal(15,2)
declare @ymjcdwbl int
set @ymjcsl=0
set @ymjcje=0
set @ymjcdwbl=1


declare @sumsl decimal(15,2)
declare @sumje decimal(15,2)


declare t2 cursor local for  select coalesce(jcsl,0),coalesce(jcje,0),coalesce(jfsl,0),coalesce(jfje,0),coalesce(dfsl,0),coalesce(dfje,0),ydwbl,a.id,s_ypdw,1 from #temp a ,yp_ypcjd b where a.cjid=b.cjid  order by a.id
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


insert into #TEMP(cjid,rq,zy,ypdw,lsj,jcsl,jcje)values(@cjid,getdate(),'���ս��',@t2_xzxdw,0,round(@ymjcsl*@t2_xdwbl/@t2_ydwbl,2) ,@ymjcje)

--����ϼ�
insert into #TEMP(cjid,ydwbl,rq,zy,ypdw,lsj,jfsl,jfje,dfsl,dfje) 
select @cjid,1,getdate(),'С��',s_ypdw,null,
sum(jfsl/ydwbl),cast(round(sum(jfje),2) as decimal(15,2)),
sum(dfsl/ydwbl),cast(round(sum(dfje),2) as decimal(15,2)) from #TEMP a,yp_ypcjd b
where a.cjid=b.cjid  group by s_ypdw


select id ���,rq ����,zy ժҪ,ypdw ��λ,cast(lsj as decimal(15,2)) ���ۼ�,cast(jfsl as float) �跽����,jfje �跽���,cast(dfsl as float) ��������,
dfje �������,cast(jcsl as float) �������,cast(jcje as float) �����,
yppch ���κ�,kcid,
ypph ����,ypxq Ч��,(case when jhj=0 then null else jhj end) ����,(case when ypkl=0 then null else ypkl end) ����,shdh �ͻ�����, dbo.Fun_GetDate( djrq) ��������,djid,cjid from #TEMP order by id

select id ���,rq ����,zy ժҪ,ypdw ��λ,cast(lsj as decimal(15,2)) ���ۼ�,cast(jfsl as float) �跽����,
jfje �跽���,cast(dfsl as float) ��������,dfje �������,cast(jcsl as float) �������,cast(jcje as float) �����,
yppch ���κ�,kcid,
ypph ����,ypxq Ч��,
(case when jhj=0 then null else jhj end) ����,(case when ypkl=0 then null else ypkl end) ����,
shdh �ͻ�����,dbo.Fun_GetDate( djrq) ��������,djid,cjid from #TEMP where dfje is null or zy='С��' order by id

select id ���,rq ����,zy ժҪ,ypdw ��λ,cast(lsj as decimal(15,2)) ���ۼ�,cast(jfsl as float) �跽����,
jfje �跽���,cast(dfsl as float) ��������,dfje �������,cast(jcsl as float) �������,cast(jcje as float) �����,
yppch ���κ�,kcid,
ypph ����,ypxq Ч��,
(case when jhj=0 then null else jhj end) ����,(case when ypkl=0 then null else ypkl end) ����,
shdh �ͻ�����,dbo.Fun_GetDate( djrq) ��������,djid,cjid from #TEMP where jfje is null or zy='С��' order by id

end
 

 --exec SP_YK_YPMXZ_RQ '2006-1-31','2007-08-10',24,1148,0
--select * from yk_kcmx where deptid=1148 and cjid=36

