if exists (select 1 from dbo.sysobjects where name = 'SP_YF_SELECT_ZYCF_MESSAGE_TLFS' and type ='P')
	drop procedure SP_YF_SELECT_ZYCF_MESSAGE_TLFS
GO	

CREATE PROCEDURE SP_YF_SELECT_ZYCF_MESSAGE_TLFS 
 ( @dept_ly int,  
   @zxks int,
   @tlfs int   --3��Ժ��ҩ 5����  
 )   
as  
	DECLARE @TS INT  
	SET @TS=(SELECT CONFIG FROM JC_CONFIG WHERE ID=8034)  
	IF @TS IS NULL OR RTRIM(@TS)='' 
		SET @TS=0  

	declare @rq datetime  
	set @rq=GETDATE()-@TS  
	declare @bz varchar(100)  
	if @TS>0  
	begin  
		set @bz='��'+CAST(month(@rq) as varchar(10))+'��'+CAST(day(@rq) as varchar(10))+'����'  
		select DEPT_LY,@bz+CAST(count(*) as varchar(30))+'������ҩ��¼' as bz 
		from zy_fee_speci(NOLOCK)   
		where PRESC_DATE>=GETDATE()-@TS and xmly=1 and fy_bit=0 and TLFS = @tlfs 
			and DELETE_BIT=0 and EXECDEPT_ID=@zxks  
		group by DEPT_LY  
	end  
	else  
		select 0 dept_ly ,'' bz   
  
  


