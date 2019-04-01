IF EXISTS ( SELECT  name
            FROM    sysobjects
            WHERE   name = N'SP_YJ_SELECT_FEE'
                    AND TYPE IN (N'P', N'PC')) 
DROP PROCEDURE SP_YJ_SELECT_FEE
GO

CREATE  PROCEDURE [dbo].[SP_YJ_SELECT_FEE]    
 (    
   @ORDERID UNIQUEIDENTIFIER,  
   @ORDEREXECID UNIQUEIDENTIFIER,  
   @TYPE INT, -- 0 ҽ��ȷ����ҳ���ѯʱ,1ҽ��ȷ����ҳ���ѯʱ֮�޸�  2��ȷ��ҽ��ҳ���ѯʱ 3 ��ȷ��ҽ���޸�ʱ  
   @yjqrid UNIQUEIDENTIFIER --ҽ��ȷ��ID  
 )     
    
AS    
    
  
BEGIN    
if @type=0  
 SELECT '' ���,ITEM_NAME,rtrim(UNIT) unit,COST_PRICE,cast(NUM as float) num ,ACVALUE,CHARGE_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) CHARGEUSER  
  FROM ZY_FEE_SPECI (nolock)  
 WHERE ORDER_ID=@ORDERID and ORDEREXEC_ID=@ORDEREXECID AND charge_bit=0 and delete_bit=0 and type=1  
if @type=2  
 SELECT '' ���,ITEM_NAME,rtrim(UNIT) unit,COST_PRICE,cast(NUM as float) num ,ACVALUE,CHARGE_DATE,DBO.FUN_GETEMPNAME(CHARGE_USER) CHARGEUSER,bz  
  FROM ZY_FEE_SPECI aa (nolock)  
  inner join yj_zysq_qrmx bb  
 on aa.id=bb.ZYID WHERE yjqrid=@yjqrid   
if @type=1  
 SELECT aa.subcode AS code,aa.ITEM_NAME as name,AA.cost_PRICE as price,AA.UNIT as item_unit,AA.NUM,AA.ACVALUE as je,  
 CAST(charge_bit AS SMALLINT) as jz,statitem_code,xmid,cast(id as varchar(100)) as id,'' as cz_id,'' DELETE_BIT ,cz_id as y_cz_id,YBJS_BIT  
 FROM    
 ZY_FEE_SPECI aa (nolock)  
  WHERE ORDER_ID=@ORDERID and ORDEREXEC_ID=@ORDEREXECID and charge_bit=0  and delete_bit=0 and aa.type=1  
if @type=3   
 SELECT aa.subcode AS code,aa.ITEM_NAME as name,AA.cost_PRICE as price,AA.UNIT as item_unit,AA.NUM,AA.ACVALUE as je,  
 CAST(charge_bit AS SMALLINT) as jz,statitem_code,xmid,cast(id as varchar(100)) as id,'' as cz_id,'' DELETE_BIT ,cz_id as  y_cz_id,YBJS_BIT  
 FROM    
 ZY_FEE_SPECI aa (nolock) inner join yj_zysq_qrmx bb  
 on aa.id=bb.ZYID WHERE yjqrid=@yjqrid   
   
 END    
 