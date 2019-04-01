IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_CG' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_Yf_CG
GO
CREATE PROCEDURE sp_YF_CG
(
	@ID UNIQUEIDENTIFIER ,
	@JHCGRQ varchar(30),
	@DJSJ varchar(30),
	@DJY INTEGER ,
	@BZ VARCHAR(100),
	@DEPTID INTEGER ,
	@DJH BIGINT ,
	@djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER output ,
    @ERR_TEXT VARCHAR(100) output,
	@jgbm bigint,
    @pxfs int
) 
as
 begin

 
 set @Err_Code=-1;
 set @Err_Text='';
 
if @djh=0 
begin
   	    set @err_text='���ݺ�Ϊ��������ȷ��';
	    return;
end
 
 
IF @id=dbo.FUN_GETEMPTYGUID() 
begin
	set @djid=dbo.FUN_GETGUID(newid(),getdate())
    insert into yf_cg(id,jgbm,jhcgrq,djsj,djy,bz,deptid,djh,pxfs)
    values(@djid,@jgbm,@jhcgrq,@djsj,@djy,@bz,@deptid,@djh,@pxfs);
    if @@rowcount=0 
    begin
	    set @err_text='���뵥��ͷû�гɹ���Ӱ�쵽���ݿ�0��';
	    return;
    end
	 SET @ERR_TEXT='����ɹ�';
 END 

 
IF @id<>dbo.FUN_GETEMPTYGUID()
begin
    update yf_cg set  jhcgrq=@jhcgrq,bz=@bz,pxfs=@pxfs
    where deptid=@deptid and djh=@djh and id=@id and shbz=0;
    if @@rowcount=0 
    begin
	    set @err_text='���µ���ͷû�гɹ���Ӱ�쵽���ݿ�0��';
	    return;
    end
    set @djid=@id
    SET @ERR_TEXT='�޸ĳɹ�';
end

  SET @ERR_CODE=0;
end;


