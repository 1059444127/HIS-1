IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yk_ymjc' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yk_ymjc
GO
CREATE PROCEDURE sp_yk_ymjc 
(
	@year INTEGER ,
	@month integer,
	@deptid integer,
	@ksrq varchar(30),
	@jsrq varchar(30),
	@DJSJ VARCHAR(30),
	@DJY INTEGER,
	@ERR_CODE INTEGER output,
    @ERR_TEXT VARCHAR(100) output
)
as

p1:begin

 declare @yjid UNIQUEIDENTIFIER 
 set @yjid=dbo.FUN_GETEMPTYGUID()
 set @Err_Code=-1
 set @Err_Text=''

declare @sdjh varchar(10)   


declare @bpcgl int =0; --�ⷿ�Ƿ�������ι���  
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--��ʱ�趨Ϊ999

if EXISTS(select * from yp_kjqj where deptid=@deptid)
begin
	declare @nday int
	set @nday=DATEDIFF(DAY, cast(@ksrq as datetime), getdate()) 
	if @nday<=15 
	begin
	  set @err_text='�ϴ��½�����Ϊ'+@ksrq+',�����ܹ���Ƶ���Ľ����½����'
	  return;
	end 
end

 declare @New_yjid UNIQUEIDENTIFIER 
 set @New_yjid=dbo.FUN_GETGUID(newid(),getdate())

if ( @bpcgl=0 or @bpcgl is null )  --���������ι���
	begin 
	--���������¼
	insert into yp_kjqj(id,kjnf,kjyf,ksrq,jsrq,djsj,djy,deptid) values(@New_yjid,@year,@month,@ksrq,@jsrq,@djsj,@djy,@deptid)
	set @yjid=@New_yjid
	if @@rowcount=0
	begin
	   SET @ERR_TEXT='�½��¼û�в���ɹ�,����'
	   return
	end
	
	if @yjid is null or @yjid=dbo.FUN_GETEMPTYGUID()
	begin
	   SET @ERR_TEXT='�½�IDΪ�㣬�½�ʧ��'
	   return
	end

--���ڻ����ݺ��·�
	declare @sqyear int;
	declare @sqmonth int;
	set @sqyear=@year;
	set @sqmonth=@month-1;
	if @month=1 
	begin
		set @sqyear=@sqyear-1;
		set @sqmonth=12;
	end 

	--���±����½��¼
	update YK_dj set yjid=@yjid where  deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and 
	( (shbz=1 and ywlx not in('001','002') and shrq<=@jsrq ) or 
		(ywlx in('002','001') and djrq+convert(nvarchar,djsj,108)<=@jsrq )
	)    ;

	update YF_fy set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from YK_dj where yjid=@yjid); 

	update YF_tld set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from YK_dj where yjid=@yjid); ;



	--���ڽ����
	create table #qc(cjid int,sqsl decimal(15,3),sqpfje decimal(15,3),sqlsje decimal(15,3),sqjhje decimal(15,3))
	insert into #qc(cjid,sqsl,sqpfje,sqlsje,sqjhje) 
	select a.cjid,(jcsl*dwbl/ydwbl) jcsl,jcpfje,jclsje,jcjhje
	from YK_YMJC  a (nolock),YK_kcmx b  where a.cjid=b.cjid and  a.deptid=b.deptid and 
	nf=@sqyear and yf=@sqmonth and a.deptid=@deptid;

	--���ڷ�����
	create table #bq(cjid int,bqsl decimal(15,3),bqpfje decimal(15,3),bqlsje decimal(15,3),bqjhje decimal(15,3))
	INSERT INTO #bq(CJID,bqsl,bqpfje,bqlsje,bqjhje)
	SELECT c.cjid,
	sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
    sum(dbo.fun_YK_drt(a.ywlx,pfje)),
	round(sum(dbo.fun_YK_drt(a.ywlx,lsje)),2),
    sum(dbo.fun_YK_drt(a.ywlx,jhje))
	FROM YK_DJ A (nolock),YK_DJMX B (nolock),YK_kcmx c (nolock)
	WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and  yjid=@yjid and A.DEPTID=@DEPTID 
	group by c.cjid	

	insert into #qc (cjid,sqsl,sqpfje,sqlsje,sqjhje)
	select cjid,0,0,0,0 from  #bq where cjid not in(select cjid from #qc)


	--��������
	create table #jc(cjid int,jcsl decimal(15,3),jcpfje decimal(15,3),jclsje decimal(15,3),jcjhje decimal(15,3))
	insert into #jc (cjid,jcsl,jcpfje,jclsje,jcjhje)
	select a.cjid,(sqsl+coalesce(bqsl,0)),round(sqpfje+coalesce(bqpfje,0),3),
	round(sqlsje+coalesce(bqlsje,0),3),round(sqjhje+coalesce(bqjhje,0),3)
	from #qc a left join #bq b on a.cjid=b.cjid  

	--�������
	insert into YK_YMJC(id,nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid)
	select dbo.FUN_GETGUID(newid(),getdate()),@year,@month,a.cjid,dbo.fun_yp_ypdw(b.zxdw) ypdw,b.dwbl,round(b.pfj/b.dwbl,4) pfj,round(b.lsj/b.dwbl,4) lsj,
	jcsl,jcpfje,jclsje,
	jcjhje,
	@djsj,@deptid,@yjid
	from #jc a,vi_YK_kcmx b where a.cjid=b.cjid and deptid=@deptid;

	--����ڼ䵥����ˮ�ŵ�����    
	select top 1 @sdjh=rtrim(case when right(sdjh,2)='12' then left(sdjh,4)+1 else left(sdjh,4) end)+
	(case when right(sdjh,2)='12' then '01' else left('00',2-len(rtrim(right(sdjh,2)+1)))+rtrim(right(sdjh,2)+1) end) from yp_djh where deptid=@deptid

	if @sdjh=null or @sdjh=''
		begin
			set @err_text='���ݱ������ʱ��������'
			 return;
		end    
	update yp_djh set ndjh=0,sdjh=@sdjh where deptid=@deptid
	
	set @err_code=0
	set @err_text='�½�ɹ�'
	end
	
else  --�������ι���  ��ʵ�ǰ�ÿһ��kcid����һ����Ʒ������
	begin
		insert into yp_kjqj(id,kjnf,kjyf,ksrq,jsrq,djsj,djy,deptid) 
		values(@New_yjid,@year,@month,@ksrq,@jsrq,@djsj,@djy,@deptid)
	set @yjid=@New_yjid
	if @@rowcount=0
	begin
	   SET @ERR_TEXT='�½��¼û�в���ɹ�,����'
	   return
	end
	
	if @yjid is null or @yjid=dbo.FUN_GETEMPTYGUID()
	begin
	   SET @ERR_TEXT='�½�IDΪ�㣬�½�ʧ��'
	   return
	end

--���ڻ����ݺ��·�
	declare @sqyear_pc int;
	declare @sqmonth_pc int;
	set @sqyear_pc=@year;
	set @sqmonth_pc=@month-1;
	if @month=1 
	begin
		set @sqyear_pc=@sqyear-1;
		set @sqmonth_pc=12;
	end 

	--���µ����½�id
	
	--����ҩ�ⵥ��ͷ��
	update YK_dj set yjid=@yjid where  deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null) and 
	( (shbz=1 and ywlx not in('001','002') and shrq<=@jsrq ) or 
		(ywlx in('002','001') and djrq+convert(nvarchar,djsj,108)<=@jsrq )
	)  
	--����ҩ�ⷢҩ��
	update YF_fy set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from YK_dj where yjid=@yjid)
    
    --���µ���ͷ��
	update YF_tld set yjid=@yjid where deptid=@deptid and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)
	and djid in(select id from YK_dj where yjid=@yjid)

	--���ڽ����pc
	create table #qc_pc(cjid int,sqsl decimal(15,3),sqpfje decimal(15,3),sqlsje decimal(15,3),sqjhje decimal(15,3)
	,kcid uniqueidentifier) --kcid 
	insert into #qc_pc(cjid,sqsl,sqpfje,sqlsje,sqjhje,kcid ) 
	select a.cjid,(jcsl*dwbl/ydwbl) jcsl,jcpfje,jclsje,jcjhje,b.ID 
	from YK_YMJC  a (nolock), 
	YK_KCPH b  where a.cjid=b.cjid  
		and a.kcid=b.id  
	 and  a.deptid=b.deptid and  
	nf=@sqyear_pc and yf=@sqmonth_pc and a.deptid=@deptid ;

	
	--���ڷ�����pc
	create table #bq_pc(cjid int,bqsl decimal(15,3),bqpfje decimal(15,3),bqlsje decimal(15,3),bqjhje decimal(15,3)
	,kcid uniqueidentifier) --kcid
	INSERT INTO #bq_pc(CJID,bqsl,bqpfje,bqlsje,bqjhje,kcid)
	SELECT c.cjid,
	sum(case when a.ywlx='005' then 0 else dbo.fun_YK_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,
    sum(dbo.fun_YK_drt(a.ywlx,pfje)),
	round(sum(dbo.fun_YK_drt(a.ywlx,lsje)),2),
    sum(dbo.fun_YK_drt(a.ywlx,jhje))
    ,c.ID 
	FROM YK_DJ A (nolock),YK_DJMX B (nolock),YK_KCPH c (nolock)
	WHERE a.id=b.djid AND b.cjid=c.cjid
	and b.kcid=c.id 
	  and B.deptid=c.deptid and  yjid=@yjid and A.DEPTID=@DEPTID 
	group by c.cjid,c.id
	
	
	insert into #qc_pc (cjid,sqsl,sqpfje,sqlsje,sqjhje,kcid)
	select cjid,0,0,0,0,kcid from  #bq_pc where kcid not in(select kcid from #qc_pc)

	--��������pc
	create table #jc_pc(cjid int,jcsl decimal(15,3),jcpfje decimal(15,2),jclsje decimal(15,2),jcjhje decimal(15,2)
	,kcid uniqueidentifier) --kcid
	insert into #jc_pc (cjid,jcsl,jcpfje,jclsje,jcjhje,kcid)
	select a.cjid,(sqsl+coalesce(bqsl,0)),round(sqpfje+coalesce(bqpfje,0),2),
	round(sqlsje+coalesce(bqlsje,0),2),round(sqjhje+coalesce(bqjhje,0),2),
	a.kcid 
	from #qc_pc a left join #bq_pc b on a.cjid=b.cjid 
	 and a.kcid=b.kcid  

	 
	--�������pc
	insert into YK_YMJC(id,nf,yf,cjid,ypdw,ydwbl,pfj,lsj,jcsl,jcpfje,jclsje,jcjhje,djsj,deptid,yjid,jhj,kcid)
	select dbo.FUN_GETGUID(newid(),getdate()),@year,@month,a.cjid,dbo.fun_yp_ypdw(b.zxdw) ypdw,b.dwbl,round(b.pfj/b.dwbl,4) pfj,round(b.lsj/b.dwbl,4) lsj,
	jcsl,jcpfje,jclsje,
	jcjhje,
	@djsj,@deptid,@yjid
	,jhj,a.kcid  
	from #jc_pc a,vi_yk_kcph b where a.cjid=b.cjid 
	 and a.kcid =b.kcid  ---pc
	 and deptid=@deptid;

	--����ڼ䵥����ˮ�ŵ�����    
	select top 1 @sdjh=rtrim(case when right(sdjh,2)='12' then left(sdjh,4)+1 else left(sdjh,4) end)+
	(case when right(sdjh,2)='12' then '01' else left('00',2-len(rtrim(right(sdjh,2)+1)))+rtrim(right(sdjh,2)+1) end) from yp_djh where deptid=@deptid

	if @sdjh=null or @sdjh=''
		begin
			set @err_text='���ݱ������ʱ��������'
			 return;
		end    
	update yp_djh set ndjh=0,sdjh=@sdjh where deptid=@deptid
	
	set @err_code=0
	set @err_text='�½�ɹ�'
	end	

end

