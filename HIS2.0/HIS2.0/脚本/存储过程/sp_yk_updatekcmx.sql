IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yk_updatekcmx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yk_updatekcmx]
GO
CREATE PROCEDURE [dbo].[sp_yk_updatekcmx]
(
	@djid UNIQUEIDENTIFIER,
	@Err_Code INTEGER output,
    @Err_Text VARCHAR(200)output,
	@jgbm bigint
)

as

 begin
 declare @phgl int		   --��������
 declare @Sypph varchar(20)--ҩƷ����
 declare @ncount int --����
 declare @dwbl int--���㵥λ����
 declare @zxdw int --���㵥λ
 declare @kczxdw int--��浥λ
 declare @kcdwbl int--��浥λ����
 declare @deptid int
 declare @cjid int
 declare @ypph varchar(30)
 declare @ypsl decimal(15,3)
 declare @ydwbl int
 declare @kwid int
 declare @ypxq varchar(20)
 declare @ggid int
 declare @jhj decimal(15,4)
 declare @ypkl decimal(15,4)
 declare @wldw int
 declare @ypdw int
 declare @jjgl varchar(10) --���ٽ��ۺͽ������
 declare @ywlx varchar(10)
 
 
 declare @djh  bigint       --���ݺ�  
 declare @yppch varchar(100) --���κ�
 declare @kcid  uniqueidentifier 
 declare @rjdh bigint --��ⵥ��   
 DECLARE @YPMC VARCHAR(100)
 declare @djmxid uniqueidentifier 
 
 declare @kcl_temp decimal(15,3)
 
 

 set @Err_Code=-1
 set @Err_Text=''
 

set @deptid=( select top 1 DEPTID  from YK_DJ where ID=@djid)
declare @bpcgl int =0;   --���κŹ���
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--��ʱ�趨Ϊ999
if @bpcgl is null
	set @bpcgl=0 
	
declare @bqzkc int =0 --ǿ�ƿ��ƿ��
select @bqzkc=ZT from YK_CONFIG where DEPTID=@deptid and BH=101
if @bqzkc is null 
	set @bqzkc=0 
 
 if @deptid=0 
   begin
    set @Err_Text='����IDΪ��������ȷ��'
    return
   end
 
  if @djid is null or @djid=dbo.FUN_GETEMPTYGUID()
   begin
    set @Err_Text='��������,djIDΪ��'
    return
   end 

set @jjgl=(select config from jc_config where id=8002)  --������������κŹ����˲�������Ч,�������ι�����ض����ٽ���
--set @phgl=(select  zt from yk_config where bh='102' and deptid=@deptid)

update YK_DJ set sumpfje=coalesce((select SUM(pfje) from YK_DJMX where DJID=@djid),0) where YK_DJ.ID=@djid 
update YK_DJ set SUMJHJE=coalesce((select SUM(jhje) from YK_DJMX where DJID=@djid),0) where YK_DJ.ID=@djid 
update YK_DJ set SUMLSJE=coalesce((select SUM(lsje) from YK_DJMX where DJID=@djid),0) where YK_DJ.ID=@djid 

--����������ϸ������kcmx��kcph(//jchl:ypsl��ydwbl)
declare t1 cursor local for 
	select a.cjid,a.ypph,dbo.fun_yk_drt(c.ywlx,ypsl) ypsl,a.ydwbl,a.deptid,a.kwid,a.ypxq,b.ggid,round(a.jhj*ydwbl,4) jhj,a.ypkl,c.wldw,b.ypdw ,c.ywlx,A.YPPM,
		 a.yppch,a.kcid,c.djh,a.id djmxid 
	from YK_djmx a,vi_yp_ypcd b,YK_dj c  
	where a.cjid=b.cjid and c.id=a.djid  and a.djid=@djid  FOR read only
open  t1
fetch next from t1 into @cjid,@ypph,@ypsl,@ydwbl,@deptid,@kwid,@ypxq,@ggid,@jhj,@ypkl,@wldw,@ypdw,@ywlx,@YPMC,@yppch,@kcid,@djh,@djmxid
while @@FETCH_STATUS=0  
begin
    if (@bpcgl=0 or @bpcgl is null) --���������κŹ��� 
	begin 
	  if @phgl is null
	  set @phgl=(select  zt from yk_config where bh='102' and deptid=@deptid)
	  
  	  --���ҿ���Ƿ���ڸ�ҩƷ
	  SET @KCZXDW=0
	  SET @KCDWBL=0
	  SET @DWBL=0
	  SET @ZXDW=0
	  set @ncount=0
  	  select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw from YK_kcmx where cjid=@cjid and deptid=@deptid

	  --����ҩƷ�Ĳ���ϵ��
	  select @dwbl=dwbl,@zxdw=zxdw  from yp_ypcl where cjid=@cjid and deptid=@deptid
	  if @dwbl=0 or @dwbl is null 
            begin
		 set @dwbl=1
		 set @zxdw=@ypdw	
	    end
	   
	  --���������ϵ���Ͳ�����е�ϵ����һ��
	  if (@dwbl<>@kcdwbl or @zxdw<> @kczxdw) and @ncount>0 
               begin
	     	  set @Err_Text='��������,������ϵ���Ͳ�����е�ϵ����һ��,���¿��û�гɹ�' +cast(@dwbl as char(10))+'  '+cast(@kcdwbl as char(10))
		  return
	       end 
	  if @ywlx='001' and @jhj>0 and  exists(select 1 from jc_config where id=8029 and config='1')
	  begin
			update yp_ypcjd set mrjj=@jhj where cjid=@cjid
	  end

	  if @ncount=0 or @ncount is null
		begin
  	  	   	   insert into YK_kcmx(id,jgbm,ggid,cjid,kcl,zxdw,dwbl,djsj,bdelete,deptid,scjj,sckl,ghdw)values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@ypsl*@dwbl/@ydwbl,@zxdw,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,@jhj,@ypkl,@wldw)
        end
	  else
	        begin
    	  	   update YK_kcmx set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),scjj=(case when @jhj>0 then @jhj else scjj end),
		  		 sckl=(case when @ypkl>0 then @ypkl else sckl end),ghdw=(case when @wldw>0 and @ywlx in('001','002') then @wldw else ghdw end ),
				bdelete=(case when @ywlx in('004') then bdelete else 0 end) where ggid=@ggid and cjid=@cjid and deptid=@deptid
				if @@rowcount=0
				begin
					 set @ERR_TEXT='���¿��ʱ��������6��Ӱ�쵽���ݿ�0��';
					 return;
				end  
	        end
 

	   SET @Sypph=@ypph
	   if rtrim(@sypph)='' 
             --  begin
   	         set @Sypph='������'
             --  end
             
	 --��������ٽ��ۺͽ������ڴ˽����۸���Ϊ��
	 if @jjgl='0' or @jjgl is null 
	    set @jhj=0
	    
	 --ǿ�ƿ��ƿ��
	 if EXISTS(select cjid from YK_kcph where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj and deptid=@deptid  and (kcl+((@ypsl*dwbl)/@Ydwbl)) <0  and @ypsl<0  )
	 and exists(select * from yk_config where deptid=@deptid and bh=101 and zt=1)
	 begin
			set @Err_Text='ϵͳ��������Ϊ����,���޸�['+@YPMC+'] ����:'+isnull(@ypph,'')+' ����:'+cast(@ypsl as varchar(50))
			return
	 end
	 
 	 set @ncount=0
 	 set @ncount=(select cjid from YK_kcph where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj and deptid=@deptid )
 	 IF @ncount=0 or @ncount is null 
	     begin 
		   if @phgl=0 --or @phgl is null 
             begin
		         set @Sypph='������'
		   		 set @ncount=(select CJID from YK_kcph where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid and jhj=@jhj  and deptid=@deptid)
				 if coalesce(@ncount,0)>0 
				  begin
				        update YK_kcph set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),
						bdelete=(case when @ywlx in('004') then bdelete else 0 end)
   		   				where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid  and jhj=@jhj and deptid=@deptid
						if @@rowcount=0
						begin
							 set @ERR_TEXT='���½�����ʱ��������Ӱ�쵽���ݿ�0��';
							 return;
						end 
 				  end
				  else
		    	   	    insert into YK_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid)
        	   		   	 values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@kwid,@Sypph,@ypxq,@jhj,@ypsl*@dwbl/@ydwbl,@ZXDW,@dwbl,convert(nvarchar,getdate(),120),0,@deptid)
		     end
		   else
		     begin
		    	   insert into YK_kcph(id,jgbm,ggid,cjid,kwid,ypph,ypxq,jhj,kcl,zxdw,dwbl,djsj,bdelete,deptid)
		   		   values(dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@kwid,@Sypph,@ypxq,@jhj,@ypsl*@dwbl/@ydwbl,@ZXDW,@dwbl,convert(nvarchar,getdate(),120),0,@deptid)
             end
	
	    end
 	 ELSE
	     begin --���ܹ���������� ֻҪ�ҵ��˸����ž�ֱ�Ӹ���
 	   	   update YK_kcph set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),
			bdelete=(case when @ywlx in('004') then bdelete else 0 end)
   		   where ggid=@ggid and cjid=@cjid and rtrim(ypph)=rtrim(@Sypph) and kwid=@kwid  and jhj=@jhj and deptid=@deptid
			if @@rowcount=0
			begin
				 set @ERR_TEXT='���½�����ʱ��������Ӱ�쵽���ݿ�0��';
				 return;
			end  
	     end 
	end 
    else   --�������κŹ���
		begin
		
		----����kcmx�Ƿ���ڸ�ҩƷ
		set @kczxdw=0;
		set @kcdwbl=0;
		set @zxdw=0;
		set @dwbl=0;
		set @ncount=0;
		select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw from YK_kcmx where cjid=@cjid and deptid=@deptid
		
	   if(LTRIM(RTRIM(@yppch))='' or @yppch is null)
	   begin
			set @Err_Text='��������,����Ϊ��,���޸�['+@YPMC+'] ����:'+isnull(@ypph,'')+' ����:'+cast(@ypsl as varchar(50))
			return 
	   end
		
		----����ҩƷ�Ĳ���ϵ��
	     select @dwbl=dwbl,@zxdw=zxdw  from yp_ypcl where cjid=@cjid and deptid=@deptid
         if @dwbl=0 or @dwbl is null 
         begin
			 set @dwbl=1
			 set @zxdw=@ypdw	
		 end
		 
		----���������ϵ���Ͳ�����е�ϵ����һ��
		  if (@dwbl<>@kcdwbl or @zxdw<> @kczxdw) and @ncount>0 
			 begin
     			set @Err_Text='��������,������ϵ���Ͳ�����е�ϵ����һ��,���¿��û�гɹ�' +cast(@dwbl as char(10))+'  '+cast(@kcdwbl as char(10))
				return
			 end 
		--�����ֵ����
	   if @ywlx='001' and @jhj>0 and  exists(select 1 from jc_config where id=8029 and config='1')
		  begin
				update yp_ypcjd set mrjj=@jhj where cjid=@cjid
		  end
		 
		----�������¿����ϸ
      if @ncount=0 or @ncount is null
			begin
  	  	   	   insert into YK_kcmx(id,jgbm,ggid,cjid,kcl,zxdw,dwbl,djsj,bdelete,deptid,scjj,sckl,ghdw)values
  	  	   	   (dbo.FUN_GETGUID(newid(),getdate()),@jgbm,@ggid,@cjid,@ypsl*@dwbl/@ydwbl,@zxdw,@dwbl,convert(nvarchar,getdate(),120),0,@deptid,@jhj,@ypkl,@wldw)
  	  	   	   if @@ROWCOUNT=0
  	  	   	   begin
  	  	   			 set @ERR_TEXT='����ҩ����ϸ��淢������Ӱ�쵽���ݿ�0��';
					 return
  	  	   	   end
			end
	  else
			begin
    	  	   update YK_kcmx set kcl=kcl+((@ypsl*dwbl)/@Ydwbl),scjj=(case when @jhj>0 then @jhj else scjj end),
		  		 sckl=(case when @ypkl>0 then @ypkl else sckl end),ghdw=(case when @wldw>0 and @ywlx in('001','002') then @wldw else ghdw end ),
				bdelete=(case when @ywlx in('004') then bdelete else 0 end) where ggid=@ggid and cjid=@cjid and deptid=@deptid
				if @@rowcount=0
				begin
					 set @ERR_TEXT='������ϸ���ʱ��������Ӱ�쵽���ݿ�0��';
					 return;
				end  
	        end
	        
	declare @kcid_temp uniqueidentifier 
	set @kcid_temp=dbo.FUN_GETGUID(NEWID(),getdate())
 
    --��������kcph
    if(@ywlx in ('001','009','016','033'))  --�ɹ���⡢�ڳ���⡢������� �Ƽ��ӹ���Ʒ���
		begin
			if rtrim(@ypph)=''  set @ypph='������' 
			
			--if not exists(select 1 from YK_KCPH where yppch=@yppch and CJID=@cjid and ID=@kcid)
				begin
					insert into YK_KCPH (ID,JGBM,GGID,CJID,KWID,
										YPPH,YPXQ,JHJ,KCL,ZXDW,
										DWBL,DJSJ,BDELETE,DEPTID,yppch,
										rkdh,rkdjmxid,maxsl,YJHJ) values
					(@kcid_temp,@jgbm,@ggid,@cjid,@kwid,
					@ypph,@ypxq,@jhj,(@ypsl*@dwbl)/@ydwbl,@zxdw,
					@dwbl,CONVERT(nvarchar,GETDATE(),120),0,@deptid,@yppch,
					@djh,@djmxid,(@ypsl*@dwbl)/@ydwbl
					,@jhj);
					if @@rowcount=0
						begin
							 set @ERR_TEXT='�������ο��ʱ��������Ӱ�쵽���ݿ�0��';
							 return;
						end  
					--����djmx�е�kcid
					update yk_djmx set kcid=@kcid_temp where id=@djmxid
					if @@rowcount=0
						begin
							 set @ERR_TEXT='�������ϸkcidʱ��������Ӱ�쵽���ݿ�0��';
							 return;
						end
				end
			--else
			--	begin
			--		update YK_KCPH set KCL=KCL+(@ypsl*@dwbl)/@ydwbl,maxsl=maxsl+(@ypsl*@dwbl)/@ydwbl  
			--		where CJID=@cjid and yppch=@yppch and ID=@kcid
			--		if @@ROWCOUNT=0
			--			begin
			--				set @Err_Text='���¿��ʱ��������10'
			--				return 
			--			end
			--	end
		end
    else
		begin
			--����kcph�����Ƿ���ڸø�����
			set @ncount=0 
			select @ncount=cjid,@kcdwbl=dwbl,@kczxdw=zxdw,@kcid_temp=ID,@kcl_temp=KCL from yk_kcph where cjid=@cjid and deptid=@deptid and yppch =@yppch
			if @ncount=0 or @ncount is null
				begin  --��������������kcph
				
						if(@bqzkc=1 and @ypsl<0) --���ƿ��
						begin
							set @Err_Text=
							--CAST(@cjid as varchar(10))+' '+
							--cast(@kcid as varchar(40))+' '+ 
							--@yppch+''+
							'�ⷿ���������ο��Ϊ����,���޸�['+@YPMC+'] ����:'+isnull(@ypph,'')+' ����:'+cast(@ypsl as varchar(50))
							return 
						end
				
						if rtrim(@ypph)=''  set @ypph='������'  
						
						--��ȡԭ������
						declare @yjhj decimal(15,4) --ԭ������
						if @ywlx in ('004','031') --004ҩ���˿� 031ͬ���ⷿ����
						begin
							if @ywlx='004'
								select @yjhj=YJHJ from YF_KCPH where yppch=@yppch and CJID=@cjid
							else
								select @yjhj=YJHJ from YK_KCPH where yppch=@yppch and CJID=@cjid 
						end
						
						
							insert into YK_KCPH (ID,JGBM,GGID,CJID,KWID,
								YPPH,YPXQ,JHJ,KCL,ZXDW,
								DWBL,DJSJ,BDELETE,DEPTID,yppch,
								rkdh,YJHJ) values
								(@kcid_temp,@jgbm,@ggid,@cjid,@kwid,
								@ypph,@ypxq,@jhj,(@ypsl*@dwbl)/@ydwbl,@zxdw,
								@dwbl,CONVERT(nvarchar,GETDATE(),120),0,@deptid,@yppch,
								@djh,@yjhj);
						if @@rowcount=0
							begin
								set @ERR_TEXT='�������ο��ʱ��������Ӱ�쵽���ݿ�0��';
								return;
							end  
					    	--����djmx�е�kcid
						update yk_djmx set kcid=@kcid_temp where id=@djmxid
						if @@rowcount=0
							begin
								 set @ERR_TEXT='�������ϸkcidʱ��������Ӱ�쵽���ݿ�0��';
								 return;
							end
				end
		    else		
				begin	--������������kcph
				
				     if (@bqzkc=1 and ((@kcl_temp+((@ypsl*@kcdwbl)/@Ydwbl)) <0)) --ǿ�ƿ��ƿ��
						begin
							set @Err_Text='1�ⷿ��������Ϊ����,���޸�['+@YPMC+'] ����:'+isnull(@ypph,'')+' ����:'+cast(@ypsl as varchar(50))
							return 
						end
				
					if(@ywlx in ('002'))
						begin--���Ϊ�˻�������Ҫ����maxsl
							update YK_KCPH set KCL=KCL+((@ypsl*DWBL)/@ydwbl),
									maxsl=maxsl+((@ypsl*DWBL)/@ydwbl),
									BDELETE =(case when @ywlx in ('004') then BDELETE else 0 end )
									where GGID=@ggid and CJID =@cjid --and RTRIM(YPPH)=RTRIM(@ypph)
									 and KWID=@kwid and DEPTID=@deptid  --and JHJ=@jhj
									and yppch=@yppch 
									if @@rowcount=0
										begin
											set @ERR_TEXT='�������ο��ʱ��������002��Ӱ�쵽���ݿ�0��';
											return
										end  
						end
					else
						begin
							update YK_KCPH set KCL=KCL+((@ypsl*DWBL)/@ydwbl),
									BDELETE =(case when @ywlx in ('004') then BDELETE else 0 end )
									where  GGID=@ggid and CJID =@cjid --and RTRIM(YPPH)=RTRIM(@ypph)
									 and DEPTID=@deptid  and KWID=@kwid  and yppch=@yppch --and JHJ=@jhj ����ᵼ�½������
									if @@rowcount=0
										begin
											set @ERR_TEXT='�������ο��ʱ��������Ӱ�쵽���ݿ�0��';
											return
										end 
							 if ((@ywlx='004' or @ywlx='031') and @kcid=dbo.FUN_GETEMPTYGUID())  --ҩ���˿� ���� ͬ���ⷿ���� Ҫ����djmx�е�kcid 
							 begin
							 	update yk_djmx set kcid=@kcid_temp where id=@djmxid
								if @@rowcount=0
									begin
										 set @ERR_TEXT=CAST(@djmxid as varchar(100))+'�������ϸkcidʱ��������004,031��Ӱ�쵽���ݿ�0��'+cast(@kcid_temp as varchar(50));
										 return;
									end
							end
						end
				end
		end
    end	   
	
	fetch next from t1 into @cjid,@ypph,@ypsl,@ydwbl,@deptid,@kwid,@ypxq,@ggid,@jhj,@ypkl,@wldw,@ypdw,@ywlx,@YPMC,@yppch,@kcid,@djh,@djmxid
end

CLOSE t1
DEALLOCATE t1

--Add By Tany 2015-12-30 ���µ�����ϸ��Ŀ������Ϣ
update a set a.kcl=ISNULL(b.KCL,0),a.zxdw=ISNULL(b.ZXDW,0),a.dwbl=ISNULL(b.DWBL,0) 
from yk_djmx a inner join YK_KCMX b on a.CJID=b.CJID and a.DEPTID=b.DEPTID
where a.DJID=@djid

 SET @Err_Code=0
 SET @Err_Text='����ɹ�'
end
GO


