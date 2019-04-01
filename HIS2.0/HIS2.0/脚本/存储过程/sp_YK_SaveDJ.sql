IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_SaveDJ' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_SaveDJ
GO

CREATE PROCEDURE sp_YK_SaveDJ
(
 	@id UNIQUEIDENTIFIER,
	@DJH BIGINT ,
	@DEPTID INTEGER ,
	@YWLX CHAR(3),
	@WLDW INTEGER ,
	@JSR INTEGER ,
	@RQ varchar(30) ,
	@DJY INTEGER,
	@DJRQ varchar(30),
	@DJSJ varchar(30),
	@FPH VARCHAR(30),
	@FPRQ varchar(10),
	@BZ VARCHAR(100) ,
   	@SHDH VARCHAR(50) ,
	@yydm int,
	@sqdh bigint,
	@jhje decimal(15,2),
	@pfje decimal(15,2),
	@lsje decimal(15,2),
	@sdjh varchar(20),
	@djid UNIQUEIDENTIFIER output,
	@ERR_CODE INTEGER  output,
    @ERR_TEXT VARCHAR(100)  output,
	@jgbm bigint
)
--sp_yk_saveDJ����ҩ��ҵ�񵥾�ͷ��
--@id   ����ͷID   0 ��ʾ�µ���  ����0��ʾ�޸ĵ���
--@DJH  ���ݺ�
--@ywlx ҵ������
--@wldw ������λ
--@jsr  ������
--@rq   ����
--@djy  �Ǽ�Ա
--@djrq �Ǽ�����
--@djsj �Ǽ�ʱ��
--@fph  ��Ʊ��
--@fprq ��Ʊ����
--@bz   ��ע
--@shdh �ͻ�����
--@jhje �������
--@pfje �������
--@lsje ���۽��
--@djid ���ص�ǰ�����������ĵ���ͷID ������޸ĵ��ݴ�DJIDҲҪ��ֵ
--@err_code 0 ��ʾ�ɹ�
--@err_text ��ʾ��Ϣ�ı�
--*********************************2006-11-19 ����֪
as
 begin

 SET @djid=dbo.FUN_GETEMPTYGUID()
 set @err_code=-1
 set @err_text=''
 
 if @djh=0 
   begin
   	set @err_text='���ݺ�Ϊ��������ȷ��'
	return
   end
 
 if rtrim(@ywlx)='' 
   begin
   	set @err_text='ҵ������Ϊ��������ȷ��'
	return
   end 
 
  if @wldw=0 
   begin
   	set @err_text='������λΪ��������ȷ��'
	return
   end

 IF @id=dbo.FUN_GETEMPTYGUID() OR @ID IS NULL 
  begin
		SET @DJID=dbo.FUN_GETGUID(newid(),getdate())
        insert into yk_dj(ID,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,fph,fprq,bz,shdh,yydm,sqdh,sumjhje,sumpfje,sumlsje,sdjh)
        values(@DJID,@jgbm,@djh,@deptid,@ywlx,@wldw,@jsr,@rq,@djy,@djrq,@djsj,@fph,@fprq,@bz,@shdh,@yydm,@sqdh,@jhje,@pfje,@lsje,@sdjh)
	
        if @@rowcount=0
	  begin
	    set @err_text='���뵥��ͷû�гɹ���Ӱ�쵽���ݿ�0��'
		SET @DJID=dbo.FUN_GETEMPTYGUID()
	    return
 	  end

	--set @djid=@@IDENTITY
        IF @djid=dbo.FUN_GETEMPTYGUID() OR @djid IS NULL
	  begin
	    SET @err_text='@djidΪ��,������'
	    return
	  end
	
        SET @err_text='����ɹ�'
        set @err_code=0
   end 

 
 IF @id<> dbo.FUN_GETEMPTYGUID() 
  begin
        update yk_dj set wldw=@wldw,jsr=@jsr,rq=@rq,fph=@fph,fprq=@fprq,bz=@bz,shdh=@shdh,yydm=@yydm,sumjhje=@jhje,sumpfje=@pfje,sumlsje=@lsje
        where deptid=@deptid and djh=@djh and id=@id and shbz=0 --isnull(yjid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
        if @@rowcount=0
	begin
	     update yk_dj_h set wldw=@wldw,jsr=@jsr,rq=@rq,fph=@fph,fprq=@fprq,bz=@bz,shdh=@shdh,yydm=@yydm,sumjhje=@jhje,sumpfje=@pfje,sumlsje=@lsje
		    where deptid=@deptid and djh=@djh and id=@id and shbz=0 --isnull(yjid,dbo.FUN_GETEMPTYGUID())=dbo.FUN_GETEMPTYGUID()
	     if @@rowcount=0
	     begin
	      	  set @err_text='���µ���ͷû�гɹ���Ӱ�쵽���ݿ�0��'
	   	  return
             end 
        end 

	set @djid=@id
	SET @err_text='����ɹ�'
	SET @err_code=0
 end


end



