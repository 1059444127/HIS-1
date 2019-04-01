IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_MBIMPORT' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_MBIMPORT
GO
CREATE PROCEDURE sp_yf_MBIMPORT
(
  @mbid int,
  @deptid int,
  @bpcgl bit, --�Ƿ�������ι���
  @pcfs varchar(10) --�̴淽ʽ  0-����ϸ��� 1-�����ο�� 
)
as

 --������SQL����
declare @kslx varchar(10)
set @kslx=(select kslx from yp_yjks where deptid=@deptid)
if @kslx is null or rtrim(@kslx)=''  
 return
--8030��һ��ҩƷ�ڶ���̵�ģ���д���ʱ,Aģ�屣���¼�����ݺ�,Bģ��������ȡ���� 1�� 0��
if EXISTS(select * from jc_config where id=8030 and config='0')
	begin
		if ( @bpcgl=0 or (@pcfs='1' and @bpcgl='1')) --���������ι��� ���߽������ι����������ο��
			begin
				select a.id ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,
 			  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) ������,
			  0.00 �������,
			  coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) ����,
			  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) ���ۼ�,
			  coalesce(c.ypph,'������') ����,
			  coalesce(dbo.fun_yp_kwmc(kwid,c.DEPTID),'') ��λ,
			  coalesce(c.kcl,0) ��������,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) ������,coalesce(c.kcl,0) �̴�����,
			  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) ��λ,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) �̴���,
			  0.00 ӯ������,0.00 ӯ�����,shh ����,b.cjid,
			  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
			  coalesce(coalesce(c.dwbl,1),1) dwbl,
			  coalesce(c.kwid,0) kwid,
			  dbo.FUN_GETEMPTYGUID() id,a.bz ���� 
			  ,YPXQ Ч��,YPPCH ���κ�    
			  from yp_pdmbmx a inner join yp_ypcjd b 
			  on a.cjid=b.cjid and mbid=@mbid left join 
			 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
			  on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
			 --on a.cjid=d.cjid
			  where  a.mbid=@mbid and c.kcid not in(
				select kcid from yf_pdcs a,yf_pdcsmx b where a.id=b.djid and  a.bdelete=0 and shbz=0
				   )   order by a.id,b.cjid,c.ypph
			end
		else --����ϸ���
			begin
				select a.id ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,
 			  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) ������,
			  0.00 �������,
			  0 ����,
			  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) ���ۼ�,
			  null ����,
			  '' ��λ,
			  coalesce(c.kcl,0) ��������,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) ������,coalesce(c.kcl,0) �̴�����,
			  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) ��λ,
			  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) �̴���,
			  0.00 ӯ������,0.00 ӯ�����,shh ����,b.cjid,
			  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
			  coalesce(coalesce(c.dwbl,1),1) dwbl,
			  0 kwid,
			  dbo.FUN_GETEMPTYGUID() id,a.bz ���� from yp_pdmbmx a inner join yp_ypcjd b 
			  on a.cjid=b.cjid and mbid=@mbid left join 
			 (select * from YF_PDTEMP_KCMX where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
			  on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
			 --on a.cjid=d.cjid
			  where  a.mbid=@mbid and c.kcid not in(
				select kcid from yf_pdcs a,YF_PDCSMX_KCMX b where a.id=b.djid and  a.bdelete=0 and shbz=0
				   )   order by a.id,b.cjid
			end
	end
else
	begin
		if ( @bpcgl=0 or (@pcfs='1' and @bpcgl='1')) --���������ι��� ���߽������ι����������ο��
				begin
					 select a.id ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,
 					  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) ������,
					  0.00 �������,
					  coalesce(cast(round(c.jhj/coalesce(c.dwbl,1),4) as decimal(15,4)),0) ����,
					  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) ���ۼ�,
					  coalesce(c.ypph,'������') ����,
					  coalesce(dbo.fun_yp_kwmc(kwid,c.DEPTID),'') ��λ,
					  coalesce(c.kcl,0) ��������,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) ������,coalesce(c.kcl,0) �̴�����,
					  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) ��λ,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) �̴���,
					  0.00 ӯ������,0.00 ӯ�����,shh ����,b.cjid,
					  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
					  coalesce(coalesce(c.dwbl,1),1) dwbl,
					  coalesce(c.kwid,0) kwid,
					  dbo.FUN_GETEMPTYGUID() id,a.bz ����
					  ,YPXQ,YPPCH   from yp_pdmbmx a inner join yp_ypcjd b 
					 on a.cjid=b.cjid and mbid=@mbid left join 
					 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
					on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
					--on a.cjid=d.cjid
					 where  a.mbid=@mbid  order by a.id,b.cjid,c.ypph
				 end 
		 else
				begin
					 select a.id ���,s_yppm Ʒ��,s_ypspm ��Ʒ��,s_ypgg ���,s_sccj ����,
 					  coalesce(cast(round(pfj/coalesce(c.dwbl,1),4) as decimal(15,4)),pfj) ������,
					  0.00 �������,
					  0 ����,
					  coalesce(cast(round(lsj/coalesce(c.dwbl,1),4) as decimal(15,4)),lsj) ���ۼ�,
					  null ����,
					  '' ��λ,
					  coalesce(c.kcl,0) ��������,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) ������,coalesce(c.kcl,0) �̴�����,
					  coalesce(dbo.fun_yp_ypdw(c.ZXDW),s_ypdw) ��λ,
					  coalesce(round(c.kcl*lsj/coalesce(c.dwbl,1),2),0) �̴���,
					  0.00 ӯ������,0.00 ӯ�����,shh ����,b.cjid,
					  isnull(c.kcid,dbo.FUN_GETEMPTYGUID())  as kcid,
					  coalesce(coalesce(c.dwbl,1),1) dwbl,
					  0 kwid,
					  dbo.FUN_GETEMPTYGUID() id,a.bz ����
					  ,YPXQ,YPPCH   from yp_pdmbmx a inner join yp_ypcjd b 
					 on a.cjid=b.cjid and mbid=@mbid left join 
					 (select * from yf_pdtemp where deptid=@deptid and shbz=0 and  (bdelete=0 or (bdelete=1 and kcl<>0) ) ) c 
					on a.deptid=c.deptid and a.cjid=c.cjid    --left join (select * from yp_ypcl where deptid=@deptid) d
					--on a.cjid=d.cjid
					 where  a.mbid=@mbid  order by a.id,b.cjid,c.ypph
				end
	 end





