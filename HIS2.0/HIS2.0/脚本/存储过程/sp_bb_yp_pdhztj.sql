create proc sp_bb_yp_pdhztj
 ( 

   @RQ1 datetime, 

   @RQ2 datetime

 )

as 
select dbo.fun_getDeptname(DEPTID) ����,sum(zcjhje) �ʴ�������,sum(zclsje) �ʴ����۽��,

sum(pcjhje) �̴�������,sum(pclsje) �̴����۽��,

sum(pcjhje-zcjhje) ����ӯ�����,
sum(pclsje-zclsje) ����ӯ�����

from yf_pd a,

yf_pdmx b

where a.id=b.djid and a.djrq>=@RQ1 and a.djrq<=@RQ2

group by DEPTID 

order by DEPTID