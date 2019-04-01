
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_selectDj' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_selectDj
GO
CREATE PROCEDURE sp_yf_selectDj
(
 	@ywlx char(3),
	@wldw int ,
	@dtp1 varchar(30),
	@dtp2 varchar(30),
	@djh bigint,
	@fph varchar(50),
	@shdh varchar(50),
	@shbz smallint,
	@deptid int,
	@functionname varchar(30),
	@P_deptid int
)
as
begin
 declare @ssql varchar(1000);

 --������SQL����

 --ҩƷ�����˻�
 if @functionname='Fun_ts_yk_cgrk' or @functionname='Fun_ts_yk_cgrk_th'  or @functionname='Fun_ts_yk_cgrk_yf' or @functionname='Fun_ts_yk_cgrk_th_yf'
 set @ssql='select 0 ���,dbo.fun_getdeptname(deptid) �ֿ�����,(case when bprint=1 then ''��'' else '''' end) ��ӡ,djh ���ݺ� ,RQ ��������,dbo.FUN_YP_GHDW(wldw) ������λ,dbo.FUN_YP_YWY(jsr) ҵ��Ա,
        shdh �ͻ�����,sumjhje �������,sumpfje �������,sumlsje ���۽��,
        fph ��Ʊ��,fprq ��Ʊ����,cast((cast(djrq AS char(10))+'' ''+convert(nvarchar,djsj,108)) as datetime) as �Ǽ�ʱ��,'+
	'dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHy) ���Ա,bz ��ע,id  
	
	        ,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yf_djmx where djid= a.id ) ������ 
	        
	from VI_YF_DJ a where ywlx='+@ywlx+' and deptid='+cast(@deptid as char(10))+'  and shbz='+cast(@shbz as char(10))


 --ҩƷ�����˻�
----- if @functionname='Fun_ts_yf_yprk' or @functionname='Fun_ts_yf_yprk_th'  
-----        set @ssql=' select 0  ���,djh ���ݺ� ,RQ ��������,dbo.fun_yp_ghdw(wldw) ������λ,FUN_YP_YWY(jsr) ҵ��Ա,
------        shdh �ͻ�����,fph ��Ʊ��,fprq ��Ʊ����,(cast(djrq AS char(11)) + cast(djsj AS char(8))) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHY) ���Ա,bz ��ע,id,ywlx from vi_yf_dj 
-----		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 --ҩƷ�ɹ��������
  if @functionname='Fun_ts_yf_yprk_sh'   
        set @ssql=' select 0  ���,(case when ywlx=''001'' then ''���'' else ''�˻�'' end) ��������, djh ���ݺ� ,RQ ��������,dbo.fun_yp_ghdw(wldw) ������λ,FUN_YP_YWY(jsr) ҵ��Ա,
        shdh �ͻ�����,fph ��Ʊ��,fprq ��Ʊ����,(cast(djrq AS char(11)) + cast(djsj AS char(8))) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,
        shrq as ���ʱ��,dbo.fun_getempname(SHY) ���Ա,bz ��ע,id,ywlx 
        ,( select cast(sum(jhje*fkbl) as decimal(15,3)) from yf_djmx where djid= a.id ) ������ 
        from vi_yf_dj a
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx in(''001'',''002'')';

 
  --ҩ����ⵥ���ڳ�¼�롢���뵥��Сҩ��������
 if @functionname='Fun_ts_yf_ypptrk_sh' or @functionname='Fun_ts_yf_ypptrk_drd'  or @functionname='Fun_ts_yf_ypptrk_xygrk' or @functionname='Fun_ts_yf_ypptrk_qc'  or @functionname='Fun_ts_yf_ypptrk_xygqcrk' 
        set @ssql=' select 0  ���,djh ���ݺ� ,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,dbo.fun_getdeptname(wldw) ������λ,
		(djrq+djsj) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHY) ���Ա,bz ��ע,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
 --�������
 if  @functionname='Fun_ts_yf_ypptrk_qtrk' 
        set @ssql=' select 0  ���,djh ���ݺ� ,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,dbo.fun_yp_ghdw(wldw) ������λ,
		(djrq+djsj) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,shrq as ���ʱ��,dbo.fun_getempname(SHY) ���Ա,bz ��ע,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';


 
 if @functionname='Fun_ts_yf_ypqlrk' or @functionname='Fun_ts_yf_ypqlrk_xyg'  
        set @ssql=' select 0  ���,djh ���ݺ� ,dbo.fun_getdeptname(wldw) Ŀ�Ŀ���,djRQ ��������,dbo.fun_getempname(djy) ������,
		shrq as ���ʱ��,dbo.fun_getempname(SHR) ���Ա,ckdh ��˵��ݺ�,bz ��ע,id from YF_rksq
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 
 
 --ҩƷ������ ��ҩƷ�˿ⵥ\���˴������⡢��ҩ������¼
 if (@functionname='Fun_ts_yf_ypck' or @functionname='Fun_ts_yf_ypck_tk' or @functionname='Fun_ts_yf_ypck_qtly' or  @functionname='Fun_ts_yf_ypck_cfbl' or @functionname='Fun_ts_yf_ypck_xygck' or @functionname='Fun_ts_yf_ypck_wyylyd') and @shbz=1 
        set @ssql=' select 0  ���,djh ���ݺ� ,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,dbo.fun_getdeptname(wldw) ��������,
		(djrq+djsj) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,a.shrq as ���ʱ��,dbo.fun_getempname(a.SHY) ���Ա,bz ��ע,id,'''' ���쵥�� ,
		(case b.shbz when  1 then dbo.fun_getempname(b.shy)+ (dbo.Fun_GetDate(b.shrq)+'' ''+convert(nvarchar,b.shrq,108)) +''���''  when 0 then ''δ���'' else '''' end)  ����״̬
		from vi_yf_dj a
		left join (select shbz,shy,shrq,ydjid from vi_yf_dj union all select shbz,shy,shrq,ydjid from vi_yk_dj) b 
		on a.id=b.ydjid
		where  deptid='+cast(@deptid as char(10)) +' and  a.shbz='+cast(@shbz as char(10)) + ' and a.ywlx='''+ @ywlx+'''';


 
 --ҩƷ�����е�δ����Сҩ�����뵥
 if @functionname='Fun_ts_yf_ypck_xygck' and @shbz=0 
 begin
        set @ssql=' select 0  ���,djh ���쵥�� ,dbo.fun_getdeptname(deptid) �������,djRQ ����ʱ��,dbo.fun_getempname(djy) ������,
		bz ��ע,A.id,djh ���ݺ�,deptid from yF_rksq A  
		where WLDW='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx=''027'' ';
	if @wldw<>0 
	 set @ssql=@ssql+' and deptid='+cast(@wldw as char(10))
	 exec(@ssql)
	 return
 end
 
 --ҩƷ���۵�
  if @functionname='Fun_ts_yf_yptj' 
  begin
        set @ssql=' select 0  ���,djh ���ݺ� ,ZXRQ ִ������,TJWH �����ĺ�,
		djrq as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,bz ��ע,id from YF_Tj 
		where deptid='+cast(@deptid as char(10)) +' and  WCBJ='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';
		if @shdh<>'' 
		  set @ssql=@ssql+' and tjwh like ''%'+rtrim(cast(@shdh as char(30)))+'%''';
  end
 
 --ҩƷ����
 if @functionname='Fun_ts_yf_ypbs' 
        set @ssql=' select 0  ���,djh ���ݺ� ,RQ ��������,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		(djrq+djsj) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,dbo.fun_yp_bsyy(yydm) ԭ��,bz ��ע,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 	
 --ҩƷ����
 if @functionname='Fun_ts_yf_ypby' 
        set @ssql=' select 0  ���,djh ���ݺ�,sumjhje �������,sumpfje �������,sumlsje ���۽��,
		(djrq+djsj) as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,dbo.fun_yp_yyyy(yydm) ԭ��,bz ��ע,id from vi_yf_dj 
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and ywlx='''+ @ywlx+'''';

 
 --�̵�¼��
 if @functionname='Fun_ts_yf_pdlr' 
        set @ssql=' select 0  ���,djh ���ݺ�,DJRQ as �Ǽ�ʱ��,dbo.fun_getempname(djy) �Ǽ�Ա,
		shrq as ���ʱ��,dbo.fun_getempname(SHY) ���Ա,shdjh ��˵��ݺ�,bz ��ע,id from YF_pdcs
		where deptid='+cast(@deptid as char(10)) +' and  shbz='+cast(@shbz as char(10)) + ' and bdelete=0';

 
 --�̵㵥
  if @functionname='Fun_ts_yf_pdsh' 
        set @ssql=' select 0  ���,djh ���ݺ�,DJRQ as ���ʱ��,dbo.fun_getempname(DJY) ���Ա,id from YF_pd where deptid='+cast(@deptid as char(10)) +'';

 if @functionname='Fun_ts_yf_xygpd' 
        set @ssql=' select 0  ���,djh ���ݺ�,DJRQ as ¼������,dbo.fun_getempname(DJY) ¼��Ա,shdjh ��˵��ݺ�,shrq �������,dbo.fun_getempname(SHY) ���Ա,id from YF_pdcs where deptid='+cast(@deptid as char(10)) + ' and  shbz='+cast(@shbz as char(10)) + '';

 
 if @wldw>0 
     set @ssql=@ssql+' and wldw='+cast(@wldw as char(10)) ;

 
 if @dtp1<>'' 
     set @ssql=@ssql+' and djrq>='''+ @dtp1 +' 00:00:00'' and  djrq<='''+@dtp2+' 23:59:59'''  ;

 
  if @djh<>0 
     set @ssql=@ssql+' and djh='+ cast(@djh as char(50)) ;

 
  if @fph<>'' 
     set @ssql=@ssql+' and fph='''+ cast(@fph as varchar(50))+'''' ;

 
 if rtrim(@shdh)<>''   and  @functionname<>'Fun_ts_yp_tj' 
     set @ssql=@ssql+' and shdh='''+@shdh+''' '   

 
     set @ssql=@ssql+' order by djh'
 exec(@ssql)
 
 end 