
if exists (select * from sysobjects 
           where name = N'SP_YF_tj_xspmtj'
           and type = 'P')
   drop proc SP_YF_tj_xspmtj
go

create  PROCEDURE [dbo].[SP_YF_tj_xspmtj]
 ( @type int, --1�����ͳ��  0������ͳ��
   @yplx INTEGER,--ҩƷ����
   @dtp1 varchar(30),--����1
   @dtp2 varchar(30),--����2
   @MC int,--��ʾ����
   @deptid int,--ҩ������
   @ypsx int,--ҩƷ����
   @ypylfl varchar(10),--ҩ�����
   @ifZFPH varchar(10)--�����¶Ա���������ͳ�� 0 ��ͳ�� 1ͳ��   
 )  
as
BEGIN
 declare @count int
 DECLARE @stmt varchar(1000); --����SQL�ı�
 declare @ssql varchar(1000)--ȫ�ֱ���


 --������ʱ��
  create TABLE #temp
   (
      ID INTEGER not null IDENTITY (1,1),
   	  cjid int,
	  sl decimal(15,3),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
    create TABLE #temp1
   (
      ID INTEGER not null identity(1,1),
   	  cjid int,
	  sl decimal(15,3),
	  pfje decimal(15,2),
	  lsje decimal(15,2)
   ) 
   
   
begin  --and a.shrq>='''+ @dtp1+''' and a.shrq<='''+@dtp2+'''
     
	--��ͼ
	 set @ssql='select c.cjid,sum(ypsl/ydwbl),sum(pfje),sum(lsje) from VI_YF_dj a,VI_YF_djmx b ,vi_yp_ypcd c '+	 
	           'where a.id=b.djid and b.cjid=c.cjid   and '+
			   'a.ywlx in(''017'',''018'',''020'',''021'',''025'',''026'')  and a.shbz=1 '
	 set @stmt='insert into #temp(cjid,sl,pfje,lsje)'
	 begin
	    if @yplx<>0 
		 set @ssql=@ssql+' and yplx='+cast(@yplx as char(10))+'';
	    if @deptid<>0 
		 set @ssql=@ssql+' and a.deptid='+cast(@deptid as char(10))+'';
	    if @ypylfl<>''
		 set @ssql=@ssql+' and YLFL='+cast(@ypylfl as CHAR(10))+''; 
	    if @ypsx=0 
		 set @ssql=@ssql+' and gzyp=1 '
		if @ypsx=1
		 set @ssql=@ssql+' and  mzyp=1 '
		if @ypsx=2
		 set @ssql=@ssql+' and  djyp=1 '
		if @ypsx=3
		 set @ssql=@ssql+' and  psyp=1 '
		if @ypsx=4
		 set @ssql=@ssql+' and  jsyp=1 '
		if @ypsx=5
		 set @ssql=@ssql+' and  wyyp=1 '
		if @ypsx=6
		 set @ssql=@ssql+' and  cfyp=1 '
		if @ypsx=7
		 set @ssql=@ssql+' and  rsyp=1 '
		if @ypsx=8
		 set @ssql=@ssql+' and  gjjbyw=1 '
		if @ypsx=9
		 set @ssql=@ssql+' and  kssdjid>0 and ddd>0'
	end
	set @stmt+=@ssql+' and a.shrq>='''+ @dtp1+''' and a.shrq<='''+@dtp2+''' group by c.cjid ';
 	exec(@stmt)
	declare @topValue varchar(200)
	set @topvalue= '' 
	if (@mc>0) set @topvalue =' top '+cast(@mc as char(10)) 
	 set @stmt='insert into #temp1(cjid,sl,pfje,lsje) select '+@topvalue +' cjid,sum(sl),sum(pfje),sum(lsje)'+
	  ' from #temp group by cjid ';
	 if @type=0 
		   set @stmt=@stmt+' order by sum(sl) desc '
	 if @type=1 
		   set @stmt=@stmt+' order by sum(lsje) desc ';
	 exec(@stmt)	 	 
	if(@ifZFPH=0)
	  begin
		 set @stmt='select a.id ����,b.s_ypspm Ʒ��,s_ypgg ���,s_sccj ����,
		 pfj ������,lsj ���ۼ�,sl ����,s_ypdw ��λ,pfje �������,
		 lsje ���۽��,shh ���� from #temp1 a,VI_YP_YPCD b where a.cjid=b.cjid order by a.id';
		 exec(@stmt)
	 end
	
	 if(@ifZFPH=1)
		 begin
			--�����������
			create table #tempZFPH---��ѯ���ڵ�ҩƷ���
			(
			  ID INTEGER not null IDENTITY (1,1),
   			  cjid int,
			  sl decimal(15,3),
			  pfje decimal(15,2),
			  lsje decimal(15,2)
			)		
			create TABLE #tempZFPH_JG --�Ա����
			(
			  ID INTEGER not null identity(1,1),
   			  cjid int,
			  sl decimal(15,3),
			  pfje decimal(15,2),
			  lsje decimal(15,2),
			  sl_sq decimal(15,3), --��������
			  pfje_sq decimal(15,2),--�����������
			  lsje_sq decimal(15,2), --�������۽��
			  
			  zfsl decimal(15,2),
			  zfje decimal(15,2)
			)
		   
			set @stmt='insert into #tempZFPH(cjid,sl,pfje,lsje) ' 
			set @stmt+=@ssql+'and a.shrq between DATEADD(month,-1,'''+@dtp1+''') and DATEADD(month,-1,'''+@dtp2+''') group by c.cjid ';
 			exec(@stmt) 
 			set @stmt='insert into #tempZFPH_JG(cjid,sl,pfje,lsje,sl_sq,pfje_sq,lsje_sq,zfsl,zfje)';
 			set @stmt+='select '+ @topValue +' a.cjid,sum(a.sl),sum(a.pfje),sum(a.lsje),sum(b.sl),sum(b.pfje),sum(b.lsje),
 			SUM(a.sl-b.sl) zfsl,SUM(a.lsje-b.lsje)zfje from #temp a left join #tempZFPH b on a.cjid=b.cjid 
 			group by a.cjid '
 			if @type=0 
				set @stmt=@stmt+' order by zfsl desc'		 
			if @type=1 
				set @stmt=@stmt+' order by zfje desc ';	
			exec (@stmt)
			select a.id ����,b.s_ypspm Ʒ��,s_ypgg ���,s_sccj ����,
			pfj ������,lsj ���ۼ�,s_ypdw ��λ,sl ��������,pfje �������,
			lsje ���۽��,sl_sq ��������,pfje_Sq �����������,lsje_sq �������۽��,			
			shh ����,a.zfsl ��������,a.zfje ������� 
			from #tempZFPH_JG a inner join VI_YP_YPCD b	 on a.cjid=b.cjid order by a.id		
		end
  end 
 END;
 
 
