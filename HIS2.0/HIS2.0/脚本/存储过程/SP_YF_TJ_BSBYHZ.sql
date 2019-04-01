IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_TJ_BSBYHZ' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_TJ_BSBYHZ
GO
CREATE PROCEDURE SP_YF_TJ_BSBYHZ
 ( 
   @deptid int,
   @RQ1 datetime, 
   @RQ2 datetime,
   @yplx int,
   @year int,
   @month int,
   @YWLX char(3)
 )
as 
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
  select  '0' ���,yppm Ʒ��,ypspm ��Ʒ��,ypgg ���,sccj ����,b.jhj ����,b.pfj ������,b.lsj ���ۼ�,ypsl ����, ypdw ��λ,jhje �������,pfje �������,
   lsje ���۽��,ypph ����,ypxq Ч��,shh ����,a.djh ���ݺ�,rq �Ǽ����� , 
  a.bz ��ע from vi_yf_dj a,vi_yf_djmx b
  where a.id=b.djid and a.shrq>=@rq1 and a.shrq<=@rq2  and a.deptid=@deptid and a.ywlx=@ywlx
end
else
begin
  select  '0' ���,yppm Ʒ��,ypspm ��Ʒ��,ypgg ���,sccj ����,b.jhj ����,b.pfj ������,b.lsj ���ۼ�,ypsl ����, ypdw ��λ,jhje �������,pfje �������,
   lsje ���۽��,ypph ����,ypxq Ч��,shh ����,a.djh ���ݺ�,rq �Ǽ����� , 
  a.bz ��ע from vi_yf_dj a,vi_yf_djmx b
  where a.id=b.djid and isnull(yjid,dbo.FUN_GETEMPTYGUID())=@yjid  and a.deptid=@deptid and a.ywlx=@ywlx 
end 



