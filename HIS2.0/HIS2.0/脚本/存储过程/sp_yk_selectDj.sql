IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_yk_selectDj]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_yk_selectDj]
GO
CREATE PROCEDURE [dbo].[sp_yk_selectDj]
(
 	@ywlx char(3),
	@wldw int ,
	@dtp1 varchar(30),
	@dtp2 varchar(30),
	@djh bigint,
	@fph varchar(50),
	@shdh varchar(50),
	@shbz int,
	@deptid int,
	@functionname varchar(30),
	@P_deptid int
)
as



 declare @ss varchar(8000);


 --ҩƷ�����˻�
 if @functionname='Fun_ts_yk_cgrk' or @functionname='Fun_ts_yk_cgrk_th' 
  or @functionname='Fun_ts_yk_cgrk_yf' or @functionname='Fun_ts_yk_cgrk_th_yf'
  or @functionname='Fun_ts_yk_cgrk_cx' or @functionname='Fun_ts_yk_cgrk_th_cx' 
  or @functionname='Fun_ts_yk_cgrk_yf_cx' or @functionname='Fun_ts_yk_cgrk_th_yf_cx'
 set @ss='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.FUN_YP_GHDW(wldw) ������λ,dbo.FUN_YP_YWY(jsr) ҵ��Ա,
        shdh �ͻ�����,sumjhje �������,sumpfje �������,sumlsje ���۽��,fph ��Ʊ��,fprq ��Ʊ����, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,'+
	'dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHy) ���Ա,bz ��ע,id 
	 
	,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) ������
	from VI_YK_DJ a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))


--ҩ��ɹ���⣨�����⣩ 
if @functionname='Fun_ts_yk_cgrk_h' or @functionname='Fun_ts_yk_cgrk_th_h' 
begin 
	if @shbz =0
	 set @ss='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.FUN_YP_GHDW(wldw) ������λ,dbo.FUN_YP_YWY(jsr) ҵ��Ա,
        shdh �ͻ�����,sumjhje �������,sumpfje �������,sumlsje ���۽��,fph ��Ʊ��,fprq ��Ʊ����, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,'+
		'dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHy) ���Ա,bz ��ע,id 
		,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) ������
		from yk_dj_temp a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))
	else
		 set @ss='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.FUN_YP_GHDW(wldw) ������λ,dbo.FUN_YP_YWY(jsr) ҵ��Ա,
        shdh �ͻ�����,sumjhje �������,sumpfje �������,sumlsje ���۽��,fph ��Ʊ��,fprq ��Ʊ����, cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,'+
		'dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHy) ���Ա,bz ��ע,id 
		,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yk_djmx where djid= a.id ) ������
		from VI_YK_DJ a where ywlx='+@ywlx+'  and shbz='+cast(@shbz as char(10))
end 

 --ҩ���˿���ڳ�¼����������
 if   @functionname='Fun_ts_yk_ypptrk_qc'  or  @functionname='Fun_ts_yk_ypptrk_qc_cx' 
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,'''' ҩ������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id from VI_YK_DJ a
		where  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 if @functionname='Fun_ts_yk_ypptrk_tk' or  @functionname='Fun_ts_yk_ypptrk_tk_cx' 
or @functionname='Fun_ts_yk_ypptrk_drk' or @functionname='Fun_ts_yk_ypptrk_drk_cx'
         set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.Fun_getdeptname(wldw) ҩ������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id from VI_YK_DJ a
		where shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 if   @functionname='Fun_ts_yk_ypptrk_qtrk'   or @functionname='Fun_ts_yk_ypptrk_qtrk_cx' 
        set @ss='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.fun_yp_ghdw(wldw) ҩ������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id from VI_YK_DJ  a
		where shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''  ';

 
-- if @ywlx='003'  then
--        set @ss=' select 0 ���,djh ���ݺ� ,,,dbo.Fun_getdeptname(wldw) Ŀ�Ŀ���,djRQ ��������,dbo.Fun_getempname(djy) ������,
--		shrq as ���ʱ��,dbo.Fun_getempname(SHr) ���Ա,ckdh ��˵��ݺ�,bz ��ע,id from yk_rksq
--		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
-- end if ;	
 
 --ҩƷ���쵥
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=0  
 begin
        set @ss=' select 0 ���,dbo.fun_getdeptname(wldw) �ֿ�����,djh ���쵥��,dbo.Fun_getdeptname(deptid) �������,djRQ ����ʱ��,dbo.Fun_getempname(djy) ������,
		bz ��ע,id,djh ���ݺ�,deptid from yF_rksq a
		where  shbz='+cast(@shbz as char(10)) + ' ';
	if @wldw<>0 
		set @ss=@ss+' and deptid='+cast(@wldw as char(10))
	if @deptid>0
		set @ss=@ss+' and wldw='+cast(@deptid as char(10))
	else 
	   set @ss=@ss+' and wldw in( select deptid from yp_yjks_gx where (p_deptid='+cast(@p_deptid as varchar(20))+' or deptid='+cast(@p_deptid as varchar(20))+' ) ) '

	 exec(@ss)
	 print @ss
	return
 end
 --ҩƷ���ⵥ
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=1 
        set @ss=' select 0 ���,dbo.fun_getdeptname(a.deptid) �ֿ�����,(case when a.bprint=1 then ''��'' else '''' end) ��ӡ,a.djh ���ݺ�,a.RQ ��������,dbo.Fun_getdeptname(a.wldw) ��ҩ����,a.sumjhje �������,a.sumpfje �������,a.sumlsje ���۽��,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(a.djy) �Ǽ�Ա,a.shrq as ���ʱ��,dbo.Fun_getempname(a.SHy) ���Ա,a.bz ��ע,a.id,a.sqdh ���쵥��,
		(case when b.shbz=1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''���''  else ''δ���'' end)  ����״̬ from VI_YK_DJ a 
		left join vi_yf_dj b  on a.id=b.ydjid
		where    a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+''' ';
--������òɹ���ⵥ
 if (@functionname='Fun_ts_yk_ypck') and @shbz=2  
        set @ss=' select 0 ���,dbo.fun_getdeptname(a.deptid) �ֿ�����,(case when a.bprint=1 then ''��'' else '''' end) ��ӡ,a.djh ���ݺ�,a.RQ ��������,dbo.fun_yp_ghdw(a.wldw) ������λ,dbo.fun_yp_ywy(jsr) ҵ��Ա,a.sumjhje �������,a.sumpfje �������,a.sumlsje ���۽��,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(a.djy) �Ǽ�Ա,a.shrq as ���ʱ��,dbo.Fun_getempname(a.SHy) ���Ա,a.bz ��ע,deptid,id from VI_YK_DJ a 
		where a.ywlx=''001'' ';
		
 --ҩƷ���ⵥ��ʱ���� Add By Tany 2015-12-23
 if (@functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_ypck_cx') and @shbz=3
        set @ss=' select 0 ���,dbo.fun_getdeptname(a.deptid) �ֿ�����,(case when a.bprint=1 then ''��'' else '''' end) ��ӡ,a.djh ���ݺ�,a.RQ ��������,dbo.Fun_getdeptname(a.wldw) ��ҩ����,a.sumjhje �������,a.sumpfje �������,a.sumlsje ���۽��,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(a.djy) �Ǽ�Ա,a.shrq as ���ʱ��,dbo.Fun_getempname(a.SHy) ���Ա,a.bz ��ע,a.id,a.sqdh ���쵥��,
		''δ���'' ����״̬ from yk_dj_temp a 
		where    a.shbz=0 and a.ywlx='''+ @ywlx+''' ';
 
  --ҩƷ������ҩ��
 if (@functionname='Fun_ts_yk_ypck_qtly' or @functionname='Fun_ts_yk_ypck_wyylyd' 
		or @functionname='Fun_ts_yk_ypck_qtly_cx' or @functionname='Fun_ts_yk_ypck_wyylyd_cx' ) and @shbz=1 
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.Fun_getdeptname(wldw) ��ҩ����,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id,sqdh ���쵥�� from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

--ͬ��������
if @functionname='Fun_ts_yk_ypck_dck'  or @functionname='Fun_ts_yk_ypck_dck_cx' 
        set @ss=' select 0 ���,dbo.fun_getdeptname(a.deptid) �ֿ�����,(case when a.bprint=1 then ''��'' else '''' end) ��ӡ,a.djh ���ݺ�,a.RQ ��������,dbo.Fun_getdeptname(a.wldw) ��ҩ����,a.sumjhje �������,a.sumpfje �������,a.sumlsje ���۽��,
		cast((cast(a.djrq AS char(10))+'' ''+convert(nvarchar,a.djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(a.djy) �Ǽ�Ա,a.shrq as ���ʱ��,dbo.Fun_getempname(a.SHy) ���Ա,a.bz ��ע,a.id,a.sqdh ���쵥��,
		(case when b.shbz=1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''���''  else ''δ���'' end)  ����״̬ from VI_YK_DJ a 
		left join vi_yk_dj b  on a.id=b.ydjid
		where    a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+''' ';

 
   --������˴�������
 if @functionname='Fun_ts_yk_ypck_jzcfck'  or @functionname='Fun_ts_yk_ypck_jzcfck_cx'  
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.Fun_getdeptname(wldw) ��ҩ����,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id,sqdh ���쵥�� from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 --��ҩ������¼
  if @functionname='Fun_ts_yk_ypck_cfbl' or @functionname='Fun_ts_yk_ypck_cfbl_cx' 
        set @ss='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.Fun_getdeptname(wldw) ��ҩ����,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,bz ��ע,id,sqdh ���쵥�� from VI_YK_DJ  a
		where    shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 
 --ҩƷ���۵�
  if @functionname='Fun_ts_yp_tj' or @functionname='Fun_ts_yp_tj_cx' 
  begin
        set @ss=' select 0 ���,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,ZXRQ ִ������,TJWH �����ĺ�,
		DJRQ as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,bz ��ע,id from yf_Tj  a
		where   WCBJ='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';
		if @shdh<>'' 
		  set @ss=@ss+' and tjwh like ''%'+rtrim(cast(@shdh as char(30)))+'%''';
		
  end

 
 --ҩƷ����
 if @functionname='Fun_ts_yk_ypbs'  or @functionname='Fun_ts_yk_ypbs_cx' 
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,dbo.fun_yp_bsyy(yydm) ԭ��,bz ��ע,id from VI_YK_DJ a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 	
 --ҩƷ����
 if @functionname='Fun_ts_yk_ypby' or @functionname='Fun_ts_yk_ypby_cx' 
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ�,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,dbo.fun_yp_yyyy(yydm) ԭ��,bz ��ע,id from VI_YK_DJ  a
		where   shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+''' ';

 
 --�̵�¼��
 if @functionname='Fun_ts_yp_pdlr' or @functionname='Fun_ts_yp_pdlr_yf'
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,djh ���ݺ�,DJRQ as �Ǽ�ʱ��,dbo.Fun_getempname(djy) �Ǽ�Ա,
		shrq as ���ʱ��,dbo.Fun_getempname(SHy) ���Ա,shdjh ��˵��ݺ�,bz ��ע,id from yf_pdcs a
		where  shbz='+cast(@shbz as char(10)) + '  and bdelete=0 ';

 --�̵㵥
  if @functionname='Fun_ts_yp_pd' or @functionname='Fun_ts_yp_pd_yf' or
	 @functionname='Fun_ts_yp_pd_cx' or @functionname='Fun_ts_yp_pd_yf_cx'
        set @ss=' select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,djh ���ݺ�,DJRQ as ���ʱ��,dbo.Fun_getempname(DJY) ���Ա,id from yf_pd a where bdelete=0 ';


 if @deptid>0
   set @ss=@ss+' and a.deptid='+cast(@deptid as char(10)) 
 else
   set @ss=@ss+' and a.deptid in( select deptid from yp_yjks_gx where (p_deptid='+cast(@p_deptid as varchar(20))+' or deptid='+cast(@p_deptid as varchar(20))+' ) ) '

 if @wldw<>0  set @ss=@ss+' and a.wldw='+cast(@wldw as char(10))+' '   
 if rtrim(@dtp1)<>''  
     begin
		if @ywlx<>'005'
			set @ss=@ss+' and a.djrq>='''+@dtp1+' 00:00:00'' and a.djrq<='''+@dtp2+' 23:59:59'''
		else
			begin
				if @shbz=0
					set @ss=@ss+' and a.djrq>='''+@dtp1+' 00:00:00'' and a.djrq<='''+@dtp2+' 23:59:59'''
				else
					set @ss=@ss+' and a.zxrq>='''+@dtp1+' 00:00:00'' and a.zxrq<='''+@dtp2+' 23:59:59'''
			end
	 end
 if @djh<>0  set @ss=@ss+' and a.djh='+cast(@djh as char(20))+' '   
if rtrim(@fph)<>''  set @ss=@ss+' and a.fph='''+@fph+''' '   
 if rtrim(@shdh)<>''   and  @functionname<>'Fun_ts_yp_tj'  set @ss=@ss+' and shdh='''+@shdh+''' '   
-- if @shbz=1 
--   begin 
--	set @ss=@ss+' and shbz=1 '
--   end
-- else
--   begin
--        set @ss=@ss+' and shbz=0'
--   end
 --if @deptid<>0 and @functionname<>'Fun_ts_yk_ypck' and @shbz<>0   set @ss=@ss+' and deptid='+cast(@deptid as char(20))+' '        
 --  print @ss
 set @ss=@ss+' order by ���ݺ�'
exec( @ss)





GO


