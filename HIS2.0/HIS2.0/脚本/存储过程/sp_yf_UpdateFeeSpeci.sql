IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_yf_UpdateFeeSpeci' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_yf_UpdateFeeSpeci
GO
CREATE PROCEDURE sp_yf_UpdateFeeSpeci  
(  
 @groupid UNIQUEIDENTIFIER,--��ҩ���κ�  
 @fy_date datetime,--��ҩ����   
 @fy_user int,--��ҩ��  
 @py_user int,--��ҩ��  
 @charge_bit smallint,--�Ƿѱ��  
 @charge_date datetime,--�Ƿ�����  
 @charge_user int,--�Ƿ�Ա  
 @execid decimal(21,6),--ʱ���  
 @ERR_CODE INTEGER  output,  
 @ERR_TEXT VARCHAR(100) output  
)    
as  
  
declare @ss varchar(8000)  
declare @ltbz int  
  
 set @ERR_CODE=-1  
 set @ERR_TEXT='����û�гɹ�������û�и��µ��У�������ˢ�����ݺ�����';  

if @groupid is null or @groupid=dbo.FUN_GETEMPTYGUID()
begin
  set @groupid=null
end 
  
begin  
if @charge_bit=0   
  begin  
    update  a  set group_id=@groupid,fy_bit=1, fy_date=@fy_date,fy_user=@fy_user,py_user=@py_user,charge_bit=1,charge_date=@charge_date,charge_user=@charge_user  
    from zy_fee_speci  a,yf_zyfymx b where a.id=b.zy_id and b.execid=@execid and fy_bit=0  and a.DELETE_BIT=0
  
    if @@rowcount=0  
    begin  
     update  a  set group_id=@groupid,fy_bit=1, fy_date=@fy_date,fy_user=@fy_user,py_user=@py_user,charge_bit=1,charge_date=@charge_date,charge_user=@charge_user  
     from zy_fee_speci_h  a,yf_zyfymx b where a.id=b.zy_id and b.execid=@execid and fy_bit=0  and a.DELETE_BIT=0 
            if @@rowcount=0 return  
    end  
  end  
  
else   
 begin  
    update  a  set group_id=@groupid,fy_bit=1, fy_date=@fy_date,fy_user=@fy_user,py_user=@py_user  
     from zy_fee_speci  a,yf_zyfymx b where a.id=b.zy_id and b.execid=@execid and fy_bit=0   and a.DELETE_BIT=0
    if @@rowcount=0  
    begin  
     update  a  set group_id=@groupid,fy_bit=1, fy_date=@fy_date,fy_user=@fy_user,py_user=@py_user   
     from zy_fee_speci_h  a,yf_zyfymx b where a.id=b.zy_id and b.execid=@execid and fy_bit=0   and a.DELETE_BIT=0
     if @@rowcount=0 return  
    end  
 end  
  
   set @ERR_CODE=0;  
   set @ERR_TEXT='���³ɹ�';  
  
  
END  
  
