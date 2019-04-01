IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_RKSQMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_RKSQMX
GO
CREATE PROCEDURE sp_YF_RKSQMX
(
	@ID UNIQUEIDENTIFIER ,
    @DJID UNIQUEIDENTIFIER,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@CJID INTEGER ,
	@YPDW VARCHAR(10) ,
	@YDWBL INTEGER ,
	@YPSL DECIMAL(15,3),
	@PFJ DECIMAL(15,4),
	@LSJ DECIMAL(15,4),
	@PFJE DECIMAL(15,3),
	@LSJE DECIMAL(15,3), 
	@ERR_CODE INTEGER output,
        @ERR_TEXT VARCHAR(250) output
) 
AS
 begin

 
 set @Err_Code=-1;
 set @Err_Text='';
 
 if @djh=0 
BEGIN
   	    set @err_text='���ݺ�Ϊ��������ȷ��';
	    return;
END
 
 if @cjid=0 
BEGIN
   	    set @err_text='����,����IDΪ��������ȷ��';
	    return;
END
 
 IF @id=dbo.FUN_GETEMPTYGUID() or @id is null 
BEGIN
    insert into YF_RKSQmx(id,DJID,DJH,DEPTID,CJID,YPDW,YDWBL,YPSL,PFJ,LSJ,PFJE,LSJE)
    values(dbo.FUN_GETGUID(newid(),getdate()),@DJID,@DJH,@DEPTID,@CJID,@YPDW,@YDWBL,@YPSL,@PFJ,@LSJ,@PFJE,@LSJE);
    if @@ROWCOUNT=0 
    BEGIN
	    set @err_text='���뵥����ϸû�гɹ���Ӱ�쵽���ݿ�0��';
	    return;
    end 
	SET @ERR_TEXT='����ɹ�';
 END 

 
 IF @id<>dbo.FUN_GETEMPTYGUID()
BEGIN
    update YF_RKSQmx set CJID=@CJID,YPDW=@YPDW,YDWBL=@YDWBL,YPSL=@YPSL,PFJ=@PFJ,LSJ=@LSJ,PFJE=@PFJE,LSJE=@LSJE
	 where deptid=@deptid and djh=@djh and id=@id;
    if @@ROWCOUNT=0 
    BEGIN
	    set @err_text='���µ�����ϸû�гɹ���Ӱ�쵽���ݿ�0��';
	    return;
    end 
	SET @ERR_TEXT='�޸ĳɹ�';
 END 
 
 SET @ERR_CODE=0;
   
end;


