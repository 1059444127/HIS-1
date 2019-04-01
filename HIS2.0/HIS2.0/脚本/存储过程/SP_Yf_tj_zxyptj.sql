IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_Yf_tj_zxyptj' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_Yf_tj_zxyptj
GO
CREATE PROCEDURE SP_Yf_tj_zxyptj
 (@type int, --0 ��ʾ���� 1��ʾסԺ 2 ȫ��
  @type1 int ,--0 ���� 1 ���
  @dtp1 varchar(30),
  @dtp2 varchar(30),
  @num1 decimal(15,2),
  @num2 decimal(15,2),
  @yplx int
 )  
as
BEGIN
declare @count INT 
declare @ss varchar(5000)
 --������ʱ��
   create TABLE #TEMP
   (
   	  cjid int,
	  ypsl decimal(15,2),
	  lsje decimal(15,2)
   ) 
    create TABLE #TEMP1
   (
   	  cjid int,
	  ypsl decimal(15,2),
	  lsje decimal(15,2)
   ) 
  
  p2:begin
	if @type=0 or @type=2
	begin
		 set @ss='insert into #temp(cjid,ypsl,lsje)select cjid,sum(ypsl/ydwbl) ypsl,sum(lsje) from vi_yf_fy a(nolock),vi_yf_fymx b(nolock) '+
		 'where a.id=b.fyid and fyrq>='''+@dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59''  '
		 set @ss=@ss+' group by cjid'
		 exec(@ss)
	end
     
	if @type=1  or @type=2
	begin
		 set @ss='insert into #temp(cjid,ypsl,lsje)select cjid,sum(ypsl/ydwbl) ypsl,sum(lsje) from '+
				 ' vi_yf_tld a(nolock),vi_yf_tldmx b  where a.groupid=b.groupid and fyrq>='''+@dtp1+' 00:00:00'' and fyrq<='''+@dtp2+' 23:59:59''  '
		 set @ss=@ss+' group by cjid '
		 exec(@ss)
	end
	
--סԺ���������
insert into #temp1(cjid,ypsl,lsje) 
select cjid,sum(ypsl) ypsl,sum(lsje)  from #temp group by cjid 
--�����⹺
create table #rk(cjid int,rksl decimal(15,2),rkje decimal(15,2))
insert into #rk(cjid,rksl,rkje)
select cjid,sum(dbo.FUN_YK_DRT(a.ywlx,ypsl)),sum(dbo.FUN_YK_DRT(a.ywlx,lsje)) 
from vi_yk_dj a,vi_yk_djmx b where 
 djrq>=@dtp1 and djrq<=@dtp2 and  a.id=b.djid and a.ywlx in('001','002') group by cjid
insert into #rk(cjid,rksl,rkje)
select cjid,sum(dbo.FUN_YK_DRT(a.ywlx,ypsl)),sum(dbo.FUN_YK_DRT(a.ywlx,lsje)) 
from vi_yf_dj a,vi_yf_djmx b where 
 djrq>=@dtp1 and djrq<=@dtp2 and  a.id=b.djid and a.ywlx in('001','002') group by cjid

--����ȫԺ���
 create table #kc (cjid int,rkje decimal(15,2),kcl decimal(15,2),ypsl decimal(15,2) not null default 0,lsje decimal(15,2) not null default 0,rksl decimal(15,2))
insert into #kc(cjid,kcl)
select cjid,sum(ypsl) from (
select a.cjid,sum(kcl/dwbl) ypsl from yf_kcmx a where kcl<>0  group by a.cjid
union all 
select a.cjid,sum(kcl/dwbl) ypsl from yk_kcmx a where kcl<>0 group by a.cjid
) a group by cjid

update a set a.ypsl=b.ypsl,a.lsje=b.lsje from  #kc a,#temp1 b where a.cjid=b.cjid
update a set a.rksl=b.rksl,a.rkje=b.rkje from  #kc a,(select cjid,sum(rksl) rksl,sum(rkje) rkje from #rk group by cjid) b where a.cjid=b.cjid  

if @type1=0    
	select '' ���,s_yppm Ʒ��,s_ypgg ���,s_sccj ����,lsj ���ۼ�,s_ypdw ��λ,rksl �ɹ�����,rkje �ɹ����,ypsl ��������,lsje ���۽��,kcl �������,kcl*lsj �����
	 from yp_ypcjd a 
	inner join #kc b on a.cjid=b.cjid where ( (n_yplx=@yplx and @yplx>0) or ( @yplx=0 ))  and ypsl>=@num1 and ypsl<=@num2 
else 
	select '' ���,s_yppm Ʒ��,s_ypgg ���,s_sccj ����,lsj ���ۼ�,s_ypdw ��λ,rksl �ɹ�����,rkje �ɹ����,ypsl ��������,lsje ���۽��,cast(kcl  as float) �������,cast(kcl*lsj as float) �����
	 from yp_ypcjd a 
	inner join #kc b on a.cjid=b.cjid	 where ( (n_yplx=@yplx and @yplx>0) or ( @yplx=0 )) and lsje>=@num1 and lsje<=@num2
	 
  end 
 END;
 
 --exec SP_Yf_tj_zxyptj 2,0,'2001-1-01','2010-01-01',0,100000

