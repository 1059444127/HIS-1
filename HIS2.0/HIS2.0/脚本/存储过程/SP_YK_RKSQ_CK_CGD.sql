IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_YK_RKSQ_CK_CGD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_YK_RKSQ_CK_CGD]
GO
CREATE PROCEDURE [dbo].[SP_YK_RKSQ_CK_CGD]
(
	@DJID UNIQUEIDENTIFIER ,
	@DEPTID INTEGER,
	@functionname varchar(50)
) 
as
/*
�ɹ���ⵥת���ⵥ
*/
 begin

declare @bpcgl int =0 --�Ƿ�������ι���
select @bpcgl = zt from yk_config where deptid =@deptid and bh =999--��ʱ�趨Ϊ999

if EXISTS(select * from jc_config where id=8002 and config='0')
	SELECT 0 ���,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���,s_sccj ����,
	a.yppch ���κ�,a.kcid ,
	a.ypph ����,YPXQ Ч��,HWMC ��λ,
	cast(round((b.pfj/ydwbl),3) as decimal(15,3)) ������,
	cast(round((b.lsj/ydwbl),4) as decimal(15,4)) ���ۼ�,b.KCL �ܿ��,0 ������,ypsl ����,
	dbo.fun_yp_ypdw(a.nypdw) ��λ,cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) �������,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2)) ���۽��,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2))-cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) ������,
	( case @bpcgl when 0 then '0' else A.JHJ end ) ����,(case @bpcgl when 0 then '0.00' else  a.JHJ*A.YPSL end) �������,case A.zbzt when 1 then '��' else '��' end as �б�״̬,
	b.shh ����,a.cjid,a.ydwbl dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
	FROM yk_djmx A inner join vi_yk_kcmx B on A.CJID=B.CJID and b.deptid=@deptid
   left join yp_hwsz C on   B.GGID=C.GGID AND B.DEPTID=C.DEPTID
   where a.djid=@djid order by a.pxxh
else
	SELECT 0 ���,B.yppm Ʒ��,b.ypspm ��Ʒ��,b.ypgg ���,s_sccj ����,
	a.yppch ���κ� ,a.kcid ,
	a.ypph ����,YPXQ Ч��,HWMC ��λ,
	cast(round((b.pfj/ydwbl),3) as decimal(15,3)) ������,
	cast(round((b.lsj/ydwbl),4) as decimal(15,4)) ���ۼ�,b.kcl �ܿ��,0 ������,ypsl ����,
	dbo.fun_yp_ypdw(a.nypdw) ��λ,cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) �������,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2)) ���۽��,
	cast(round((b.lsj*ypsl/ydwbl),2) as decimal(15,2))-cast(round((b.pfj*ypsl/ydwbl),2) as decimal(15,2)) ������,
	jhj ����,cast(round((a.jhj*ypsl/ydwbl),2) as decimal(15,2)) �������,
	b.shh ����,a.cjid,a.ydwbl dwbl,0 kwid,dbo.FUN_GETEMPTYGUID() id 
	FROM yk_djmx A inner join vi_yk_kcmx B on A.CJID=B.CJID and b.deptid=@deptid
   left join yp_hwsz C on   B.GGID=C.GGID AND B.DEPTID=C.DEPTID
   where a.djid=@djid order by a.pxxh
end



GO


