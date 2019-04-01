
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_HS_ORDER_EXEJMFY' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_HS_ORDER_EXEJMFY
GO
--�����������ĵ������� �ƷѺͳ���
CREATE PROCEDURE SP_HS_ORDER_EXEJMFY
  @V_INPATIENTID uniqueidentifier, --����ID (visitid)
  @V_BABYID BIGINT, -- 0
  @V_ORDERID uniqueidentifier, --ҽ��ID yzxh
  @V_EXECDEPT_ID BIGINT, --ҩ��ID execdept_id (yfid)
  @V_HOITEM_ID BIGINT, ---ҽ����ĿID(�շ���ĿID XM)------------------
  @V_EXEUSER BIGINT, --
  @V_NUM decimal(18, 4), ---���� shl  INTEGER
  @V_CZ_FLAG INTEGER, --
  @V_CZ_FEEID uniqueidentifier, --BIGINT  �������ķ���ID
  @V_BARCODE VARCHAR(50), --������
  @V_NEW_FEEID uniqueidentifier output, --����ID
  @ERR_CODE INTEGER output, 
  @ERR_TEXT VARCHAR(100)output
as
	  
    declare @v_HSITEM_ID bigint;--�շ���ĿID
	DECLARE @SQLCODE INT 
	declare @V_STATITEM_CODE varchar(12)--����Ŀ���� 
	declare @V_TCID smallint--�ײ�ID
	declare @V_TC_FLAG smallint--�Ƿ��ײ�
	declare @V_PRICE decimal(18,4)--����
	declare @V_ITEM_NAME VARCHAR(100)--��Ŀ����
	declare @V_SUBCODE VARCHAR(20)--��Ŀ����
	declare @v_unit VARCHAR(50)	--��λ
	declare @v_cost_price decimal(18,4)--���ۼ�
	declare @v_retail_Price decimal(18,4)--ʵ�����ۼ�
	declare @v_sdValue decimal(18,2)--Ӧ�����
	declare @v_acValue decimal(18,2)--ʵ�ʽ��
	declare @v_presc_no decimal(21,6)--������
	declare @v_newfeeid uniqueidentifier --�����ĵ�ǰ����ID
		--set @v_newfeeid=dbo.FUN_GETEMPTYGUID()
	declare @V_CZFLAG_SAVE int;--Ҫ������ñ�ĳ�����־
	declare @v_CZ_ID_SAVE uniqueidentifier;--Ҫ������ñ�ı�����ID
	declare @v_yczcs int--�ѳ�������
	declare @v_kczcs int--�ɳ�������
	declare @v_barcodecount int ---��ǰ����ķ��ü�¼��
	declare @v_barFeeID uniqueidentifier --�Ѵ��ڵ�������FeeID
	declare @v_odocid bigint--����ҽ��
    declare @v_odeptid bigint--��������
    declare @v_wdeptid bigint--����
	declare @v_dept_br bigint--���˿���

 	set @v_HSITEM_ID=0;--�շ���ĿID
	set @v_presc_no=0
	set @V_STATITEM_CODE=''--����Ŀ
	set @V_TCID=0--�ײ�ID
	set @V_TC_FLAG=0--�Ƿ��ײ�
	set @V_PRICE=0
	set @V_ITEM_NAME=''
	set @V_SUBCODE=''
	set @v_unit=''
	set @v_cost_price=0
	set @v_retail_Price=0
	set @v_sdValue=0
	set @v_acValue=0
	set @v_kczcs=0
	set @v_yczcs=0
	set @v_barFeeID=dbo.FUN_GETEMPTYGUID()
	set @v_barcodecount=0
		
set @err_code=-1
---�ѳ�����Ժ�Ĳ��˲����ٴ����ã���His�ѽ��㣬��ҽ���ѽ���
if not exists(select * from zy_inpatient where inpatient_id=@v_InpatientID and flag not in (2,5,6) and is_ybjs=0) 
begin 
 set @Err_Code=1
 set @err_text='�ò����ѳ������Ժ��ҽ���ѽ��㣬���ܽ��з������Ӻͳ�������'
 return
end

-----�����ж�------
if @v_cz_flag>0  AND @V_NUM>=0
BEGIN
	set @err_text='����������Ӧ��ΪС����';
	return;
END
 
if @v_cz_FeeID<>dbo.FUN_GETEMPTYGUID() --�����ĳ�����Σ�����������
begin 	 
	 if not exists(select * from zy_fee_speci where inpatient_id=@v_InpatientID and id=@v_cz_FeeID and delete_bit=0) 
	 begin 
	    set @err_text='������ԭ����ID������';
		return;
	 end 
	 
	 
	 set @v_yczcs=(select sum(num) from zy_fee_speci where inpatient_id=@v_InpatientID and cz_id=@v_cz_FeeID and delete_bit=0);--�ѳ�������
	 set @v_kczcs=(select sum(num) from zy_fee_speci where inpatient_id=@v_InpatientID and id=@v_cz_FeeID and delete_bit=0);--�ɳ�������	
	 					 				 
	 --�ѳ�������+��������>�ɳ����������򲻿ɳ���
	 if (@v_yczcs+@v_num)*-1>@v_kczcs 
	 begin
	    set @err_text='�ѳ��������Ѵﵽ�ɳ�������';
		return;
	 end  
	 
  	 set @V_CZFLAG_SAVE=2;
	 set @v_CZ_ID_SAVE=@v_cz_FeeID;
end 
else
begin
	set @V_CZFLAG_SAVE=0;
	set @v_CZ_ID_SAVE=null
end

		  
		  
--��ȡ��Ŀ��������Ϣ		  
SELECT  top 1 
@v_HSITEM_ID=hditem_id, @V_STATITEM_CODE=h.bigitemcode,@V_ITEM_NAME=H.ITEMNAME,@V_SUBCODE=H.ITEMCODE,
@V_TCID=r.tcid,@V_TC_FLAG=r.tc_flag,@v_unit=unit,@v_cost_price=h.price,@v_retail_Price=h.price,
@v_sdValue=h.price*@v_num,@v_acValue=round(h.price*@v_num,2) 
FROM JC_HOI_HDI r inner join VI_JC_ITEMS h
on h.itemid=r.hditem_id and h.tcid=r.tcid and r.hoitem_id =@V_HOITEM_ID  and JGBM=1001

--�²���ķ��õ�ID ����zy_fee_speci
set @V_NEW_FEEID=dbo.FUN_GETGUID(newid(),getdate())
	
--��ѯ�������Ƿ��Ѽǹ���					   
select top 1 @v_barcodecount=1,@v_barFeeID=a.ID from zy_fee_speci a inner join
zy_fy_jmpz b on a.ID=b.fyid 
WHERE b.txm=@v_barcode and @v_cz_flag=0 

--����Ǽ�������zy_fy_jmpz��û�м�¼ �����ǼǸ�������
if ((@v_barcodecount=0 or @v_barcodecount is null ) and @V_CZ_FLAG=0)  or @V_CZ_FLAG=2
begin
	--��ȡԭҽ�������Ϣ
	select @v_odocid=order_doc,@v_odeptid=dept_id,@v_dept_br=dept_br,
	@v_wdeptid=(select dept_id from jc_ward where ward_id=zy_orderrecord.ward_id) 
	FROM zy_orderrecord where inpatient_id=@v_InpatientID and order_id=@v_orderid	 
	
	INSERT INTO ZY_Fee_speci
				(   ID,
					Inpatient_ID,baby_id,
					Order_id,orderexec_id,prescription_id,
					presc_no,presc_date,
					book_date,book_user,
					STATITEM_CODE,--hditem_id
					XMID,Item_Name,subcode,unit,unitrate,--HSItem_ID
					cost_price,retail_Price,
					num,dosage,
					sdValue,agio,acValue,
					charge_bit,charge_date,charge_user,
					DELETE_BIT,DISCHARGE_BIT,
					CZ_FLAG,CZ_ID,
					doc_id,dept_id,dept_br,execdept_id,type,dept_ly,XMLY,JGBM--C1
				)		
  			values(
  				@V_NEW_FEEID, 
  				@v_InpatientID,@v_BabyID,
  				@v_orderid,dbo.FUN_GETEMPTYGUID(),dbo.FUN_GETEMPTYGUID(),
  				@v_presc_no,GETDATE(),--(current timestamp)
				GETDATE(),@V_EXEUSER,
  				@V_STATITEM_CODE,--@v_HOITEM_ID,
  				@v_HSITEM_ID,@V_ITEM_NAME,@V_SUBCODE,@v_unit,1,
  				@v_cost_price,@v_retail_Price,
  				@v_num,1,
  				@v_sdValue,1,@v_acValue, 
  				1,GETDATE(),@v_exeUser,
  				0,0,
				@V_CZFLAG_SAVE,@v_CZ_ID_SAVE,
  				@v_odocid,@v_odeptid,@v_dept_br,@v_execdept_id,1,@v_wdeptid ,2,'1001' )--@v_barcode

	if @V_NEW_FEEID=dbo.FUN_GETEMPTYGUID() or @V_NEW_FEEID is null
	begin
	   set @err_text='û�з�����ȷ�ķ��ñ��ID';
	   return;
	end 
         			
	--����ʱ���뵽�����	
	if @V_CZ_FLAG=0	
		insert into zy_fy_jmpz(fyid,txm,RQ) values(@V_NEW_FEEID,@V_BARCODE,GETDATE())	
		
	--��ԭ��¼�ĳ���״̬Ϊ 1
	if @V_CZ_FLAG<>0
   	   update ZY_Fee_speci set CZ_FLAG=1 where inpatient_id=@v_InpatientID and id=@v_cz_FeeID;

END

ELSE
BEGIN
	--����������Ƿ���������������ؼ�¼,�򷵻������ķ���ID����������(����������ҵ��ʱ,���������Ѽ��ʵ����������ظ����ͼǷ�����)
	if @V_CZ_FLAG=0	AND @v_barcodecount>0
   	   set @v_new_FeeID=@v_barFeeID;
END
		
SET @ERR_TEXT='����ɹ�'
SET @ERR_CODE=0


