IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_PDHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_PDHZ
GO
CREATE PROCEDURE SP_YF_TJ_PDHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int
 )
as 

declare @bpcgl int =0 --�Ƿ�������ι���
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--��ʱ�趨Ϊ999

declare @pdfs varchar(10) ='1'  --�������ι���ʱ�̵㷽ʽ 0-����ϸ 1-������
select @pdfs=CONFIG from JC_CONFIG where ID=8052 


--exec SP_YK_TJ_PDHZ 95,'','',0,2007,4
--����ǰ��·�ͳ���ȵõ��½�ID
declare @yjid UNIQUEIDENTIFIER
if @year>0
begin
  set @yjid=(select id from yp_kjqj where kjnf=@year and kjyf=@month and deptid=@deptid );
  if @yjid is null  
    set @yjid=dbo.FUN_GETEMPTYGUID()
end


if @year=0
begin
	if @bpcgl=0 --���������ι���
		begin
		  select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,ypph ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
		  pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,jhj ����,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) �������ӯ��,pclsje-zclsje ӯ�����,shh ����,a.djh ���ݺ�,rq �̵�����  
		  from yf_pd a,
		  yf_pdmx b,
		  yp_ypcjd c
		  where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
		end
	else        --�������ι���
		begin
			if @pdfs=1  --�����ο��
				begin
					   select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,ypph ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
						pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,jhj ����,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) �������ӯ��,pclsje-zclsje ӯ�����,shh ����,a.djh ���ݺ�,rq �̵�����  
						from yf_pd a,
						yf_pdmx b,
						yp_ypcjd c
						 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
				end
			else		--����ϸ���
				begin
						  select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,'' ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
						 pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,
						 CAST(0 as decimal(15,3)) ����,cast(0 as decimal(15,2)) �������ӯ��,
						 pclsje-zclsje ӯ�����,shh ����,a.djh ���ݺ�,rq �̵�����  
						 from yf_pd a,
						 yf_pdmx b,
						 yp_ypcjd c
						 where a.id=b.djid and b.cjid=c.cjid and a.djrq>=@rq1 and a.djrq<=@rq2  and a.deptid=@deptid and pcs-zcs<>0
				end
		end
end
else
begin
	if @bpcgl =0	--���������ι���
		begin
			  select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,ypph ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
			  pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,pclsje-zclsje ӯ�����,jhj ����,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) �������ӯ��,shh ����,a.djh  ���ݺ�,rq �̵�����  
			  from yf_pd a,
			  yf_pdmx b,
			  yp_ypcjd c
			  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
			  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
		end
	else			--�������ι���
		begin
			if @pdfs=0	--�����ο��
				begin
					 select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,ypph ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
					  pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,pclsje-zclsje ӯ�����,jhj ����,cast(round((pcs-zcs)*jhj,2) as decimal(15,2)) �������ӯ��,shh ����,a.djh  ���ݺ�,rq �̵�����  
					  from yf_pd a,
					  yf_pdmx b,
					  yp_ypcjd c
					  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
					  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
				end
			else	   --����ϸ���
				begin
					 select  '0' ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,'' ����,b.pfj ������,b.lsj ���ۼ�,zcs �ʴ�����,zclsje �ʴ���,
					  pcs �̴�����,ypdw ��λ,pclsje �̴���,pcs-zcs ӯ������,pclsje-zclsje ӯ�����,
					  CAST(0 as decimal(15,3)) ����,cast(0 as decimal(15,2)) �������ӯ��,
					  shh ����,a.djh  ���ݺ�,rq �̵�����
					    from yf_pd a,
					    YF_PDMX_KCMX b,
					    yp_ypcjd c
					  where a.id=b.djid and b.cjid=c.cjid and a.deptid=@deptid and pcs-zcs<>0 and djh 
					  in(select djh from vi_yf_dj where isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid and ywlx='008')
				end
		end
end 

