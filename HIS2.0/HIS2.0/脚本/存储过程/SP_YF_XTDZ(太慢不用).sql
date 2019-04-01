--ncq 2014-03-15 ҩ������ ������ι���
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_XTDZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_XTDZ
GO
  
create PROCEDURE SP_YF_XTDZ  
 (@JSRQ datetime,  
  @deptid integer  
 )    
as  

--  exec SP_YF_XTDZ '2014-05-20',215  --ҩ������
  
BEGIN  
declare @jcsl decimal(15,3);  
declare @jcjhje decimal(15,3); --��������� 
declare @jcpfje decimal(15,3);  
declare @jclsje decimal(15,3);  
declare @bqsl decimal(15,3);   
declare @bqjhje decimal(15,3); --���ڽ������
declare @bqpfje decimal(15,3);  
declare @bqlsje decimal(15,3);  
  
declare @yjid UNIQUEIDENTIFIER   
declare @count INT   
declare @year int;  
declare @month int;  
  
declare @t1_zxdw int  
declare @t1_dwbl int  
declare @t1_cjid int  
declare @t1_shh varchar(20)  
declare @t1_yppm varchar(100)  
declare @t1_ypspm varchar(100)  
declare @t1_ypgg varchar(50)  
declare @t1_sccj varchar(100)  
declare @t1_kcl DECIMAL(15,3)  
declare @t1_kcpfje DECIMAL(15,3)  
declare @t1_kclsje DECIMAL(15,3)  

declare @t1_jhj decimal(15,3) 
declare @t1_ypph varchar(30)
declare @t1_ypxq char(10)
declare @t1_yppch varchar(100)
declare @t1_kcid uniqueidentifier 
  
 --��ʼ�����ڻ���ꡢ�¡�YJID ����  
SELECT top 1 @yjid=id,@year=kjnf,@month=kjyf FROM YP_KJQJ WHERE DEPTID=@DEPTID   order by djsj desc --AND JSRQ=@JSRQ  
if @yjid is null   
begin  
   set @yjid=null;  
   set @year=0;  
   set @month=0;  
end  
   
 --������ϸ  
 create TABLE #DJMX  
   (  
      ID int IDENTITY (1, 1) NOT NULL ,  
	  CJID INT,  
	  YPSL DECIMAL(15,3),  
	  jhje decimal(15,3),  --�������
	  PFJE decimal(15,3),  
	  LSJE decimal(15,3),
      yppch varchar(100), --���κ�
	  ypph varchar(30),   --����
	  ypxq char(10) ,     --Ч��
	  kcid uniqueidentifier --
   )   
  
--��������  
 create TABLE #SQMX  
   (  
      ID int IDENTITY (1, 1) NOT NULL ,  
      CJID INT,  
      YPSL DECIMAL(15,3),  
      PFJE decimal(15,3),  
      LSJE decimal(15,3),  
      yppch varchar(100), --���κ�
      ypph varchar(30),   --����
      ypxq char(10),      --Ч��
      kcid uniqueidentifier 
   )   
  
  --�����  
 create TABLE #temp  
   (  
   cjid INT,  
   SHH VARCHAR(20),  
   yppm varchar(100),  
   ypspm varchar(100),  
   ypgg varchar(50),  
   sccj varchar(100),  
   ypdw varchar(10),  
   jcsl DECIMAL(15,3),  
   jcjhje decimal(15,3), --���������
   jcpfje DECIMAL(15,3),  
   jclsje DECIMAL(15,3),  
   bqsl DECIMAL(15,3),  
   bqjhje decimal(15,3), --���ڽ������
   bqpfje DECIMAL(15,3),  
   bqlsje DECIMAL(15,3),  
   kcsl DECIMAL(15,3),  
   kcjhje decimal(15,3), --���������
   kcpfje DECIMAL(15,3),  
   kclsje DECIMAL(15,3),  
   dwbl int  ,
   
   yppch varchar(100),
   ypph varchar(30), 
   kcid  uniqueidentifier 
   )  

--�����жϸÿⷿ�Ƿ�������ι���  
declare @bpcgl int =0;
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--��ʱ�趨Ϊ999
if(@bpcgl=0 or @bpcgl is null)  --���������ι���
	begin  
		--���ܱ��ڵ��ݵķ��������ͽ��  
		INSERT INTO #DJMX(CJID,YPSL,PFJE,LSJE)  
		SELECT c.cjid,  
		sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,  
		sum(dbo.fun_YF_drt(a.ywlx,pfje)),  
		sum(dbo.fun_YF_drt(a.ywlx,lsje))  
		FROM YF_DJ A,YF_DJMX B,YF_kcmx c   
		WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID   
		and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)   
		and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))   
		group by c.cjid;  
		   
		--���ܵ�ǰ��������ͽ��  
		insert into #temp(cjid,shh,yppm,ypspm,ypgg,sccj,ypdw,jcsl,jcpfje,jclsje,bqsl,bqpfje,bqlsje,kcsl,kcpfje,kclsje,dwbl)  
		select a.cjid,shh,yppm,ypspm,ypgg,s_sccj,dbo.fun_yp_ypdw(zxdw),0,0,0,0,0,0,kcl,  
		cast(round(pfj*kcl/a.dwbl,3) as decimal(15,3)),cast(round(lsj*kcl/a.dwbl,3) as decimal(15,3)),dwbl  
		 from YF_kcmx a,vi_yp_ypcd b   
		where a.cjid=b.cjid and a.deptid=@deptid;  
		  
		update a set a.bqsl=b.ypsl,bqpfje=b.pfje,bqlsje=b.lsje   
		from #temp a,#djmx b where a.cjid=b.cjid  
		  
		--��������  
		INSERT INTO #SQMX(CJID,YPSL,PFJE,LSJE)  
		select a.CJID,(a.jcsl*dwbl)/ydwbl,round(a.jcpfje,3),a.jclsje   
		from YF_YMJC A ,#TEMP B WHERE A.CJID=B.CJID AND A.deptid=@deptid and nf=@year and yf=@month;  
		  
		update a set a.JCsl=b.ypsl,jcpfje=b.pfje,jclsje=b.lsje   
		from #temp a,#SQMX b where a.cjid=b.cjid  
		 
		  select cjid,shh ����,yppm Ʒ��,ypspm ��Ʒ��,ypgg ���,sccj ����,ypdw ��λ,
		 jcsl ��������, 0 ���ڽ������,jcpfje �����������,jclsje �������۽��,  
		 bqsl ��������,
		 0 �����������, --
		 bqpfje �����������,bqlsje �������۽��,   kcsl �������,
		 0 ���������, --
		  kcpfje ����������,kclsje ������۽��,(jcsl+bqsl-kcsl) ������ֵ,  
		  0 ��������ֵ,--
		 (jcpfje+bqpfje-kcpfje) ��������ֵ,(jclsje+bqlsje-kclsje) ���۽���ֵ,dwbl, 
		 null ���κ�,
		 null ����,
		 null kcid 
		  from #temp where (jcsl+bqsl-kcsl)<>0  or ABS(jclsje+bqlsje-kclsje)>=0.01   or abs(jcpfje+bqpfje-kcpfje)>0.01 
		    or (jcjhje+bqjhje-kcjhje) >=0.01 
		  
		  
		 --select cjid,shh ����,yppm Ʒ��,ypspm ��Ʒ��,ypgg ���,sccj ����,ypdw ��λ,jcsl ��������,jcpfje �����������,jclsje �������۽��,  
		 --bqsl ��������,bqpfje �����������,bqlsje �������۽��,  
		 --kcsl �������,kcpfje ����������,kclsje ������۽��,(jcsl+bqsl-kcsl) ������ֵ,  
		 --(jcpfje+bqpfje-kcpfje) ��������ֵ,(jclsje+bqlsje-kclsje) ���۽���ֵ,dwbl   
		 -- from #temp where (jcsl+bqsl-kcsl)<>0  or ABS(jclsje+bqlsje-kclsje)>=0.01   or abs(jcpfje+bqpfje-kcpfje)>0.01 
		--where (jcsl+bqsl-kcsl)<>0 or (jcpfje+bqpfje-kcpfje)<>0 or (jclsje+bqlsje-kclsje)<>0  
end 
else
	begin
		--���ܱ��ڵ��ݵķ��������ͽ��  
		INSERT INTO #DJMX(CJID,YPSL,jhje,PFJE,LSJE,yppch,ypph,kcid )  
		SELECT c.cjid,  
		sum(case when a.ywlx='005' then 0 else dbo.fun_YF_drt(a.ywlx,(ypsl*c.dwbl)/b.ydwbl) end) ,  
		SUM(dbo.FUN_YF_DRT(a.ywlx,jhje)),
		sum(dbo.fun_YF_drt(a.ywlx,pfje)),  
		sum(dbo.fun_YF_drt(a.ywlx,lsje))  
		,b.yppch,b.YPPH,b.kcid    
		FROM YF_DJ A,YF_DJMX B,YF_KCPH c   
		WHERE a.id=b.djid AND b.cjid=c.cjid  and B.deptid=c.deptid and A.DEPTID=@DEPTID   
		and (yjid=dbo.FUN_GETEMPTYGUID() or yjid is null)   
		and (shbz=1 or (shbz=0 and (a.ywlx='001' or a.ywlx='002')))  
		and b.kcid=c.ID   
		group by c.cjid,b.kcid,b.yppch,b.YPPH;    
		   
		--���ܵ�ǰ��������ͽ��   --ֻȡ��������0�����ſ�� 
		insert into #temp(cjid,shh,yppm,ypspm,ypgg,sccj,ypdw,jcsl,
			jcjhje, --��������� 
			jcpfje,jclsje,
			bqsl,
			bqjhje, --���ڽ������ 
			bqpfje,bqlsje,
			kcsl,
			kcjhje, --��������� 
			kcpfje,kclsje,dwbl
			,yppch,ypph,kcid 
		)  
		select a.cjid,shh,yppm,ypspm,ypgg,s_sccj,dbo.fun_yp_ypdw(zxdw),0,0,0,0,0,0,0,0,kcl, 
	    CAST(round(a.jhj*kcl/a.dwbl,3) as decimal(15,3)), --�������
		cast(round(pfj*kcl/a.dwbl,3) as decimal(15,3)),cast(round(lsj*kcl/a.dwbl,3) as decimal(15,3)),dwbl  
		,a.yppch,a.YPPH,a.id   
		 from YF_KCPH a,vi_yp_ypcd b   
		where a.cjid=b.cjid and a.deptid=@deptid 
		 and a.KCL<>0 ;  
		  
		update a set a.bqsl=b.ypsl,bqpfje=b.pfje,bqlsje=b.lsje   
		from #temp a,#djmx b where a.cjid=b.cjid  and a.kcid=b.kcid 
		  
		--��������  
		INSERT INTO #SQMX(CJID,YPSL,PFJE,LSJE,yppch,ypph,ypxq,kcid)  
			select a.CJID,(a.jcsl*dwbl)/ydwbl,round(a.jcpfje,3),a.jclsje  
			,A.yppch,A.ypph,A.ypxq,A.kcid   
		from YF_YMJC A ,#TEMP B WHERE A.CJID=B.CJID AND A.deptid=@deptid and nf=@year and yf=@month;  
		
		update a set a.JCsl=b.ypsl,jcpfje=b.pfje,jclsje=b.lsje   
		from #temp a,#SQMX b where a.cjid=b.cjid and a.kcid=b.kcid 
		  
		 select cjid,shh ����,yppm Ʒ��,ypspm ��Ʒ��,ypgg ���,sccj ����,ypdw ��λ,
		 jcsl ��������, jcjhje ���ڽ������,jcpfje �����������,jclsje �������۽��,  
		 bqsl ��������,
		 bqjhje �����������, --
		 bqpfje �����������,bqlsje �������۽��,   kcsl �������,
		 kcjhje ���������, --
		  kcpfje ����������,kclsje ������۽��,(jcsl+bqsl-kcsl) ������ֵ,  
		 (jcjhje+bqjhje-kcjhje) ��������ֵ,--
		 (jcpfje+bqpfje-kcpfje) ��������ֵ,(jclsje+bqlsje-kclsje) ���۽���ֵ,dwbl 
		 ,
		 yppch ���κ�,ypph ����,kcid --   
		  from #temp where (jcsl+bqsl-kcsl)<>0  or ABS(jclsje+bqlsje-kclsje)>=0.01   or abs(jcpfje+bqpfje-kcpfje)>0.01 
		    or (jcjhje+bqjhje-kcjhje) >=0.01 
		--where (jcsl+bqsl-kcsl)<>0 or (jcpfje+bqpfje-kcpfje)<>0 or (jclsje+bqlsje-kclsje)<>0  
		
	
		
		--exec SP_YF_XTDZ '2014-05-06',214  --
	end
  
  
end  
   
   
   
   