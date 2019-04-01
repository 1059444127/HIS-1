IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[sp_yf_TY_select_CFMX]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yf_TY_select_CFMX]
go
create PROCEDURE sp_yf_TY_select_CFMX --��ҩ���Ҵ�����ϸ  
(  
  @cfxh UNIQUEIDENTIFIER,  
  @fph bigint,  
  @fyid UNIQUEIDENTIFIER
)  
as  
begin  
  declare @ssql varchar(2000);  
  
		 SET @SSQL='select 0,a.psbz Ƥ��,a.YPpm ҩƷ����,a.ypgg ���,a.YPCJ ����,'+  
			'a.pfj ������,cast(a.lsj as float) ���ۼ�,cast(a.ypsl as float) ����,a.ypdw ��λ,(a.PFJE) �������,cast(a.LSJE as float) ���۽��,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH ����,0 ���۲��,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx where tyid=a.id),0)) else 0 end) tysl,a.syff �÷�,a.zt  ����
		  ,a.ypph ����,a.ypxq Ч��,a.yppch ���κ�,a.jhj ����,a.jhje �������  ,a.kcid,hjb.byscf
		   from Yf_FYMX a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '  
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()    
			  set @ssql=@ssql +' and (a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		--set @ssql=@ssql +' and fyid='''+cast(@fyid as varchar(50))+'''';  
		 
		set @ssql=@ssql+' union all select 0,a.psbz Ƥ��,a.YPmc ҩƷ����,a.ypgg ���,a.YPCJ ����,'+  
			'a.pfj ������,cast(a.lsj as float) ���ۼ�,cast(a.ypsl as float) ����,a.ypdw ��λ,(a.PFJE) �������,cast(a.LSJE as float) ���۽��,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH ����,0 ���۲��,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx_h where tyid=a.id),0))
			else 0 end) tysl,a.syff �÷�,a.zt  ���� 
			,a.ypph ����,a.ypxq Ч��,a.yppch ���κ�,a.jhj ����,a.jhje �������,a.kcid,hjb.byscf
		   from Yf_FYMX_h a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '   
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()    
			  set @ssql=@ssql +' and (a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		 set @ssql=@ssql+' order by id';
		 exec(@ssql)  
		  
		if @@rowcount=0  
		begin  
		   SET @SSQL=@ssql+'  select 0 ���,a.psbz Ƥ��,a.YPpm ҩƷ����,a.ypgg ���,a.YPCJ ����,'+  
			'a.pfj ������,a.lsj ���ۼ�,a.ypsl ����,a.ypdw ��λ,a.(PFJE) �������,a.(LSJE) ���۽��,'+  
			'a.cfxh,a.cjid ypid,a.Ydwbl,a.YPHH ����,0 ���۲��,a.cfts,a.id,a.FYID,a.tyid,a.deptid,a.CFMXID,  
		  (case when ypsl>0 then (ypsl+isnull((select sum(ypsl) from yf_fymx where tyid=a.id),0)) else 0 end) tysl,a.syff �÷�,a.zt  ���� 
		  ,a.ypph ����,a.ypxq Ч��,a.yppch ���κ�,a.jhj ����,a.jhje �������  ,a.kcid,a.hjb.byscf
		  from Yf_FYMX_h a left join YF_FY fy on a.fyid = fy.id 
		   left join MZ_CFB cfb on cfb.cfid = fy.CFXH
		   left join MZ_HJB hjb on hjb.HJID = cfb.HJID  where 1>0 '   
		   if @fph>0  
			set @ssql=@ssql+' and a.fph='+cast(@fph as varchar(50)) + '';  
		   if @cfxh<>dbo.FUN_GETEMPTYGUID()    
			set @ssql=@ssql+' and a.cfxh='''+cast(@cfxh as varchar(50))+''''  
			if @fyid<>dbo.FUN_GETEMPTYGUID()   
			  set @ssql=@ssql +' and a.fyid='''+cast(@fyid as varchar(50))+''' or a.fyid=dbo.FUN_GETEMPTYGUID())';  
		--set @ssql=@ssql +' and fyid='''+cast(@fyid as varchar(50))+'''';  
		  set @ssql=@ssql+' order by id';  
		end  
end 