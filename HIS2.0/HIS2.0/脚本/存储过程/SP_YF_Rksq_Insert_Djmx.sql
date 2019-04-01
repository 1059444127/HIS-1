IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YF_Rksq_Insert_Djmx' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YF_Rksq_Insert_Djmx
GO
create PROCEDURE sp_YF_Rksq_Insert_Djmx    
(    
  @djh bigint,--ҩ�����ⵥ��    
 @DEPTID INTEGER,--ҩ��ID    
 @sqdh bigint,--�����������뵥�ݺ�    
 @sqks int,--�������    
 @ywlx char(3),    
 @DJID UNIQUEIDENTIFIER output,    
 @Err_Code INTEGER output,    
    @Err_Text VARCHAR(100) output,    
    @tojgbm bigint, --Ŀ��ҽԺ    
    @ydjid UNIQUEIDENTIFIER --ԭ����ID    
)    
    
as    
 begin    
 declare @ncount int     
 declare @kslx varchar(10);    
 declare @newywlx char(3);    
    
     
 set @Err_Code=-1;    
 set @Err_Text='';    
 --set @djid=-1;    
     
 if @djh=0     
begin    
        set @Err_Text='���ݺ�Ϊ��������ȷ��';    
     return;    
end    
     
 if @deptid=0     
begin    
        set @Err_Text='����IDΪ��������ȷ��';    
     return;    
end    
    
-- if @sqdh=0 then    
--        set @Err_Text='���뵥��Ϊ��������ȷ��';    
--     return;    
-- end if ;    
     
 if rtrim(@ywlx)=''     
begin    
        set @Err_Text='ҵ������Ϊ��������ȷ��';    
     return;    
end    
declare @ssdjh varchar(20)    
declare @t1_djh bigint    
declare @t1_deptid int    
declare @t1_ywlx char(3)    
declare @t1_wldw int    
declare @t1_jsr int    
declare @t1_rq varchar(30)    
declare @t1_djy int    
declare @t1_djrq varchar(30)    
declare @t1_djsj varchar(30)    
declare @t1_bz varchar(100)    
declare @t1_sqdh bigint    
declare @t1_sumjhje decimal(15,3)    
declare @t1_sumpfje decimal(15,3)    
declare @t1_sumlsje decimal(15,3)    
     
 set @kslx=(select rtrim(kslx) from yp_yjks where deptid=@sqks and qybz=1);    
 if (@kslx is null)     
    set @kslx='';    
    
     
 if RTRIM(@kslx)='ҩ��' AND (@YWLX='003' or @ywlx='023')  --��ҩƷ����\Сҩ�����    
begin    
   set @Err_Text='�����ͷ';    
   if @ywlx='003'     
      set @newywlx='015';    
    
   if @ywlx='023'     
      set @newywlx='024';    
    
 declare t1 cursor local for     
  select @DJH djh,@SQKS deptid,@newywlx ywlx,@deptid wldw,jsr,rq,djy,djrq,djsj,bz,@sqdh sqdh,sumjhje,sumpfje,sumlsje from yf_dj     
           where deptid=@deptid and djh=@djh and ywlx=@ywlx    
 open  t1    
 fetch next from t1 into @t1_djh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje    
 while @@FETCH_STATUS=0    
 begin    
   
  update yp_djh set djh=djh+1 where ywlx=@t1_ywlx and deptid=@t1_deptid  
  set @djh=(select djh from yp_djh  where ywlx=@t1_ywlx and deptid=@t1_deptid)  
   
  set @DJID=dbo.FUN_GETGUID(newid(),getdate())    
  insert into yF_dj(id,jgbm,djh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,bz,sqdh,sumjhje,sumpfje,sumlsje,YDJID)    
  values(@djid,@tojgbm,@djh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje,@YDJID);    
    
       
   IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL     
   begin    
      SET @Err_Text='DJIDΪ��,������';    
      return;    
   END    
       
       
   set @Err_Text='�������ϸ';    
   insert into YF_djmx(id,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,BZ,PXXH,    
   yppch,kcid )    
   select dbo.FUN_GETGUID(newid(),getdate()),@djid,CJID,0 KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,@DJH,@SQKS,@newywlx,BZ ,PXXH,    
   yppch,dbo.FUN_GETEMPTYGUID()      
   from YF_djmx where djid=@ydjid --deptid=@deptid and djh=@djh and ywlx=@ywlx;    
   if @@ROWCOUNT=0    
   BEGIN    
      set @Err_Text='�����ͷû�гɹ���Ӱ�쵽���ݿ�0��';    
      return;    
   end     
      
  fetch next from t1 into @t1_djh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje    
 end    
     
     
 CLOSE t1    
 DEALLOCATE t1    
 end     
    
if RTRIM(@kslx)='ҩ��' and @ywlx='004'  --��ҩ���˿ⵥ    
begin    
            
 set @Err_Text='�����ͷ';    
 declare t2 cursor local for     
   select @DJH djh,@SQKS deptid,'004' ywlx,@deptid wldw,jsr,rq,djy,djrq,djsj,bz,@sqdh sqdh,sumjhje,sumpfje,sumlsje from yf_dj     
          where deptid=@deptid and djh=@djh and ywlx=@ywlx    
 open  t2    
 fetch next from t2 into @t1_djh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje    
 while @@FETCH_STATUS=0    
 begin    
    
  UPDATE YP_DJH SET nDJH=nDJH+1 WHERE DEPTID=@t1_deptid AND YWLX=@t1_ywlx;    
  SET @ssDJH=(SELECT sdjh+'--'+rtrim(nDJH) FROM yp_djh where DEPTID=@t1_deptid AND YWLX='004');    

  update yp_djh set djh=djh+1 where ywlx=@t1_ywlx and deptid=@t1_deptid  
  set @djh=(select djh from yp_djh  where ywlx=@t1_ywlx and deptid=@t1_deptid)  
  
   set @DJID=dbo.FUN_GETGUID(newid(),getdate())    
   insert into yk_dj(id,jgbm,djh,sdjh,deptid,ywlx,wldw,jsr,rq,djy,djrq,djsj,bz,sqdh,sumjhje,sumpfje,sumlsje,ydjid)    
   values(@djid,@tojgbm,@djh,@ssdjh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje,@ydjid);    
    
        
    IF @DJID=dbo.FUN_GETEMPTYGUID() OR @DJID IS NULL     
    begin    
      SET @Err_Text='DJIDΪ��,������';    
      return;    
    END     
        
        
    set @Err_Text='�������ϸ';    
    insert into Yk_djmx(id,djid,CJID,KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,DJH,DEPTID,ywlx,BZ,PXXH,    
    yppch,kcid )    
    select dbo.FUN_GETGUID(newid(),getdate()),@djid,CJID,0 KWID,shh,yppm,ypspm,ypgg,sccj,YPPH,YPXQ,YPKL,SQSL,YPSL,YPDW,NYPDW,YDWBL,JHJ,PFJ,LSJ,JHJE,PFJE,LSJE,@DJH,@SQKS,'004',BZ,PXXH,    
    yppch,dbo.FUN_GETEMPTYGUID()        
    from YF_djmx where  djid=@ydjid --deptid=@deptid and djh=@djh and ywlx=@ywlx;    
    if @@rowcount=0     
    begin    
       set @Err_Text='�����ͷû�гɹ���Ӱ�쵽���ݿ�0��';    
       return;    
    end     
       
  fetch next from t2 into @t1_djh,@t1_deptid,@t1_ywlx,@t1_wldw,@t1_jsr,@t1_rq,@t1_djy,@t1_djrq,@t1_djsj,@t1_bz,@t1_sqdh,@t1_sumjhje,@t1_sumpfje,@t1_sumlsje    
 end    
 CLOSE t2    
 DEALLOCATE t2    
 end     
     
     
 SET @Err_Code=0;    
 SET @Err_Text='����ɹ�';    
end;    
    