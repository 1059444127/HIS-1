
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_SELECT_TLMX' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_SELECT_TLMX
GO
CREATE PROCEDURE SP_YF_SELECT_TLMX   
 ( @apply_id UNIQUEIDENTIFIER, 
   @APPLY_date varchar(50),
   @dept_ly int,
   @FY_BIT SMALLINT,
   @DEPTID INT,
   @lyfscode varchar(10)
 ) 
as
BEGIN
  declare @stmt varchar(3000);

begin
declare @fk varchar(10)
declare @bmr varchar(10)
set @fk=(select top 1 zt from yk_config where bh=114 and deptid=@deptid)
set @bmr=(select top 1 zt from yk_config where bh=123 and deptid=@deptid)

--select 0 ���, cast( (case when (@fk='1' and @bmr='1') or bsel=0 then 0 else 1 end) as smallint) ѡ��, Modify BY Tany 2015-05-11 pivasĬ�Ϲ������еģ���д��
select 0 ���, cast( (case when (@fk='1' and @bmr='1') or (bsel=0 and @DEPTID not in (598)) then 0 else 1 end) as smallint) ѡ��,
coalesce(d.name,'����') ����,s_ypjx ����,  
yppm+isnull(ypspmbz,'') Ʒ��,ypspm ��Ʒ��,ypgg ���,s_sccj ����,cast(cost_price as float) ����,
cast(round(b.KCL,2) as float) �����,cast(a.num*a.dosage as float) ����,a.unit ��λ,'ȱҩ' ȱҩ,'ת��' ת��, 
cast(sdvalue as float) ���,isnull(shh,'') ����,B.cjid,dbo.FUN_ZY_GETBEDNO(bed_id)  ����, 
c.name  ����, c.inpatient_no  סԺ��,''  �Ա�,''  ����,a.dept_id,@apply_id as apply_id,@APPLY_date as apply_date,
charge_bit,@dept_ly as dept_ly,a.id zy_id,a.UNITRATE,
cast((a.num*a.dosage*B.DWBL/unitrate) as float) ypsl, --ҩƷ���� ��ҩ����浥λ��������
b.zxdw,b.dwbl,
cast(round(b.pfj/b.dwbl,4) as float) ������, CAST((b.pfj*a.num*a.dosage/unitrate) AS FLOAT) �������, --סԺ���ñ��� UNITRATE ��λ���� num ���� dosage ����
cast(CAST(f.NUM as float) as varchar(50))+isnull(f.UNIT,'') ����,order_usage �÷�,
frequency Ƶ��,'' ryrq, isnull(hwmc,'') ��λ��,@lyfscode lyflcode, 
cast( round(cost_price*unitrate/b.dwbl,4) as float) lsj,a.PRESC_DATE as ��������,
(case when MNGTYPE =0 then '����ҽ��' else '��ʱҽ��' end) ҽ������,


--�����Ǽӵ�
a.kcid,b.ypywm Ӣ����,a.cz_id,a.DOSAGE ����,--4
f.num ����,a.CHARGE_DATE �շ�����,a.CHARGE_USER �շ�Աid,c.ZY_DOC �ܴ�ҽ��id,f.HOITEM_ID ҽ�����,
a.PRESCRIPTION_ID ����id,f.ORDER_CONTEXT ҽ������,f.EXEC_DEPT ִ�п���id,f.DEPT_BR ���˿���id,f.DEPT_ID ��������id,
f.ORDER_DOC ����ҽ��id ,(select ID from yp_ypdw where DWMC=f.UNIT ) jlzxdw,dbo.fun_yp_ypdw(b.zxdw) ypdw ,c.INPATIENT_ID סԺid,a.BABY_ID Ӥ��id,
'' ���� ,0 ���־,f.unit ������λ   
from zy_fee_speci a(nolock) 
inner join vi_yf_kcmx b(nolock) on a.XMID=b.cjid AND A.XMLY=1 and deptid=@deptid 
and fy_bit=@FY_BIT and delete_bit=0 AND EXECDEPT_ID=@DEPTID
and apply_id=@apply_id
inner join VI_ZY_VINPATIENT c on a.inpatient_id=c.inpatient_id
left join yp_tlfl d on b.tlfl=d.code 
left join yp_hwsz e on b.ggid=e.ggid and e.deptid=@deptid
left join ZY_ORDERRECORD f on a.ORDER_ID=f.ORDER_ID
 order by  ylfl,s_ypjx,ypspm,cost_price;  
end 
 
END;


--select * from zy_orderrecord
