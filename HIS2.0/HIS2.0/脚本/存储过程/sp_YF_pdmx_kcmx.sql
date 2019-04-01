IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_pdmx_kcmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_pdmx_kcmx
GO
CREATE PROCEDURE sp_YF_pdmx_kcmx
(
	@ID UNIQUEIDENTIFIER,
	@DJID UNIQUEIDENTIFIER ,
	@CJID INTEGER,
	@KCID UNIQUEIDENTIFIER ,
	@PCS DECIMAL(15,3) ,
	@ZCS DECIMAL(15,3) ,
	@YPDW VARCHAR(10) ,
	@YDWBL INTEGER,
	@PFJ DECIMAL(15,4) ,
	@LSJ DECIMAL(15,4) ,
	@PCPFJE DECIMAL(15,2) ,
	@ZCPFJE DECIMAL(15,2) ,
	@PCLSJE DECIMAL(15,2) ,
	@ZCLSJE DECIMAL(15,2),
	@ERR_CODE INTEGER OUTPUT,
    @ERR_TEXT VARCHAR(250) OUTPUT,
	@pxxh int
) 
AS
 begin

 set @Err_Code=-1;
 set @Err_Text='';
 
if @djid is null or @djid=dbo.FUN_GETEMPTYGUID() 
begin
   	    set @err_text='����IDΪ��������ȷ��';
	    return;
end
 
if @cjid=0 
begin
   	    set @err_text='����,����IDΪ��������ȷ��';
	    return;
end
 
 -- if @kcid=0 then
 --  	    set err_text='����,���IDΪ��������ȷ��';
	--    return;
 --end if ;
 
if @ydwbl=0 
begin
   	    set @err_text='����,ԭ��λ����Ϊ��������ȷ��';
	    return;
end
 
IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
begin
    insert into YF_pdmx_kcmx(id,djid,cjid,kcid,pcs,zcs,ypdw,ydwbl,pfj,lsj,pcpfje,zcpfje,pclsje,zclsje,pxxh)
    values(dbo.FUN_GETGUID(newid(),getdate()),@djid,@cjid,@kcid,@pcs,@zcs,@ypdw,@ydwbl,@pfj,@lsj,@pcpfje,@zcpfje,@pclsje,@zclsje,@pxxh);
    if @@rowcount=0
      begin
	    set @err_text='���뵥����ϸû�гɹ���Ӱ�쵽���ݿ�0��';
	    return;
      end
	SET @ERR_TEXT='����ɹ�';
end

 
IF @id<>dbo.FUN_GETEMPTYGUID() 
begin
	SET @ERR_TEXT='��¼�����ݿ����Ѵ治���ٴ��޸ģ���͹���Ա��ϵ';
	return;
end
 
 SET @ERR_CODE=0;
   
end;