IF  EXISTS (SELECT name FROM   sysobjects 
	   WHERE  name = N'Vi_Zy_Byjypxx' 
	   AND 	  type = 'V')
  drop view Vi_Zy_Byjypxx
go 
create view Vi_Zy_Byjypxx  as
select cjid as ҩƷ����,yppm as ҩƷͨ����,ypgg as ��Ʒ���,ypspm as ҩƷ��Ʒ��,
(case when (ypgg is not null and ypgg<>'' ) then SUBSTRING(ypgg,1,CHARINDEX('*',ypgg)-1) else ypgg end ) as �ɷֺ���,
s_ypjx as ҩƷ����,dbo.fun_yp_ghdw(bzdw) as ҩƷ��λ,s_sccj as ҩƷ������,
PYM ƴ����,
WBM  �����
from vi_yp_ypcd where s_ypjx in('���Ҽ�','Ƭ��');
