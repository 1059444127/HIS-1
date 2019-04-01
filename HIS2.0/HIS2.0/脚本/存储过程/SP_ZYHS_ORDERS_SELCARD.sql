IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ZYHS_ORDERS_SELCARD]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ZYHS_ORDERS_SELCARD]
GO
CREATE PROCEDURE [dbo].[SP_ZYHS_ORDERS_SELCARD]  
(  
 @JGBM BIGINT,
 @DEPT_ID INT --Add By Tany 2015-05-12 ��ҽ��Ȩ�޿�����Ҫ
)   
AS  
------------------------------------------------------------------------  
-- SQL �洢����  
------------------------------------------------------------------------  
BEGIN
	--Modify By Tany �人����ҽԺ��ҽ��Ȩ�޿��� 2015-05-12  
	if(SELECT LTRIM(RTRIM(CONFIG)) FROM JC_CONFIG WHERE ID=6203)=0
	begin
		SELECT AA.ƴ���� ,AA.ҽ������ AS ����,'' �Ը���, AA.��λ,AA.����,1 AS ����,  
		  CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10)) AS ҽ�����,HOICODE AS ��׼��,AA.BZ AS ��ע,   
		  ORDER_TYPE AS TYPE,ISCOMPLEX,DEFAULT_DEPT AS EXEC_DEPT,DBO.FUN_ZY_SEEKDEPTNAME(DEFAULT_DEPT) ִ�п���,  
		  Ĭ���÷�,itemid,D_CODE  
		 FROM   
		 (  
		  SELECT  A.ORDER_NAME AS ҽ������,ORDER_UNIT AS ��λ,RETAIL_PRICE AS ����,A.PY_CODE AS ƴ����,  
		   DEFAULT_USAGE Ĭ���÷�,CASE WHEN D.EXEC_DEPT>0 THEN D.EXEC_DEPT ELSE DEFAULT_DEPT END DEFAULT_DEPT,A.BZ,A.ORDER_ID,A.ORDER_TYPE,A.HOICODE,  
		   0 ISCOMPLEX,ZXDD_ID,C.ITEM_ID itemid,a.D_CODE as D_CODE   
		  FROM JC_HOITEMDICTION A  
		   LEFT JOIN --Modify By Tany 2010-01-25 ������ִ�п��ң�����ȡ�����������ִ�п���  
		   (SELECT ORDER_ID,EXEC_DEPT   
			FROM JC_HOI_DEPT B INNER JOIN JC_DEPT_PROPERTY C ON B.EXEC_DEPT=C.DEPT_ID  
			WHERE C.JGBM=@JGBM) D  
		   ON A.ORDER_ID=D.ORDER_ID,  
		   JC_HOI_HDI B,JC_HSITEMDICTION C   
		  WHERE A.ORDER_ID=B.HOITEM_ID AND C.ITEM_ID=B.HDITEM_ID   
		   AND A.DELETE_BIT=0 AND B.TC_FLAG<>1   
		   AND A.ORDER_TYPE IN (8, 9) AND C.JGBM=@JGBM  
		   AND C.DELETE_BIT=0  
		  UNION ALL   
		  SELECT  A.ORDER_NAME AS ҽ������,ORDER_UNIT AS ��λ,PRICE AS ����,A.PY_CODE AS ƴ����,  
		   DEFAULT_USAGE Ĭ���÷�,CASE WHEN D.EXEC_DEPT>0 THEN D.EXEC_DEPT ELSE DEFAULT_DEPT END DEFAULT_DEPT,A.BZ,A.ORDER_ID,A.ORDER_TYPE,A.HOICODE,  
		   0 ISCOMPLEX,EXECDEPTID ZXDD_ID,C.itemid,a.D_CODE as D_CODE   
		  FROM JC_HOITEMDICTION A  
		   LEFT JOIN --Modify By Tany 2010-01-25 ������ִ�п��ң�����ȡ�����������ִ�п���  
		   (SELECT ORDER_ID,EXEC_DEPT   
			FROM JC_HOI_DEPT B INNER JOIN JC_DEPT_PROPERTY C ON B.EXEC_DEPT=C.DEPT_ID  
			WHERE C.JGBM=@JGBM) D  
		   ON A.ORDER_ID=D.ORDER_ID,  
		   JC_HOI_HDI B,VI_JC_ITEMS C   
		  WHERE A.ORDER_ID=B.HOITEM_ID AND C.ITEMID=B.HDITEM_ID   
		   AND A.DELETE_BIT=0 AND B.TC_FLAG=1   
		   AND B.TCID=C.TCID AND A.ORDER_TYPE IN (8, 9) AND C.JGBM=@JGBM  
		--   AND C.DELETE_BIT=0  
		 ) AS AA  
	end
	else
	begin
		 SELECT AA.ƴ���� ,AA.ҽ������ AS ����,'' �Ը���, AA.��λ,AA.����,1 AS ����,  
		  CAST(CAST(ORDER_ID AS INT) AS CHARACTER(10)) AS ҽ�����,HOICODE AS ��׼��,AA.BZ AS ��ע,   
		  ORDER_TYPE AS TYPE,ISCOMPLEX,DEFAULT_DEPT AS EXEC_DEPT,DBO.FUN_ZY_SEEKDEPTNAME(DEFAULT_DEPT) ִ�п���,  
		  Ĭ���÷�,itemid,D_CODE  
		 FROM   
		 (  
		  SELECT  A.ORDER_NAME AS ҽ������,ORDER_UNIT AS ��λ,RETAIL_PRICE AS ����,A.PY_CODE AS ƴ����,  
		   DEFAULT_USAGE Ĭ���÷�,CASE WHEN D.EXEC_DEPT>0 THEN D.EXEC_DEPT ELSE DEFAULT_DEPT END DEFAULT_DEPT,A.BZ,A.ORDER_ID,A.ORDER_TYPE,A.HOICODE,  
		   0 ISCOMPLEX,ZXDD_ID,C.ITEM_ID itemid,a.D_CODE as D_CODE   
		  FROM JC_HOITEMDICTION A  
		   LEFT JOIN --Modify By Tany 2010-01-25 ������ִ�п��ң�����ȡ�����������ִ�п���  
		   (SELECT ORDER_ID,EXEC_DEPT   
			FROM JC_HOI_DEPT B INNER JOIN JC_DEPT_PROPERTY C ON B.EXEC_DEPT=C.DEPT_ID  
			WHERE C.JGBM=@JGBM) D  
		   ON A.ORDER_ID=D.ORDER_ID,  
		   JC_HOI_HDI B,JC_HSITEMDICTION C   
		  WHERE A.ORDER_ID=B.HOITEM_ID AND C.ITEM_ID=B.HDITEM_ID   
		   AND A.DELETE_BIT=0 AND B.TC_FLAG<>1   
		   AND A.ORDER_TYPE IN (8, 9) AND C.JGBM=@JGBM  
		   AND C.DELETE_BIT=0  
		  UNION ALL   
		  SELECT  A.ORDER_NAME AS ҽ������,ORDER_UNIT AS ��λ,PRICE AS ����,A.PY_CODE AS ƴ����,  
		   DEFAULT_USAGE Ĭ���÷�,CASE WHEN D.EXEC_DEPT>0 THEN D.EXEC_DEPT ELSE DEFAULT_DEPT END DEFAULT_DEPT,A.BZ,A.ORDER_ID,A.ORDER_TYPE,A.HOICODE,  
		   0 ISCOMPLEX,EXECDEPTID ZXDD_ID,C.itemid,a.D_CODE as D_CODE   
		  FROM JC_HOITEMDICTION A  
		   LEFT JOIN --Modify By Tany 2010-01-25 ������ִ�п��ң�����ȡ�����������ִ�п���  
		   (SELECT ORDER_ID,EXEC_DEPT   
			FROM JC_HOI_DEPT B INNER JOIN JC_DEPT_PROPERTY C ON B.EXEC_DEPT=C.DEPT_ID  
			WHERE C.JGBM=@JGBM) D  
		   ON A.ORDER_ID=D.ORDER_ID,  
		   JC_HOI_HDI B,VI_JC_ITEMS C   
		  WHERE A.ORDER_ID=B.HOITEM_ID AND C.ITEMID=B.HDITEM_ID   
		   AND A.DELETE_BIT=0 AND B.TC_FLAG=1   
		   AND B.TCID=C.TCID AND A.ORDER_TYPE IN (8, 9) AND C.JGBM=@JGBM  
		--   AND C.DELETE_BIT=0  
		 ) AS AA  
		 --Modify By Tany �人����ҽԺ��ҽ��Ȩ�޿��� 2015-05-12
		where 
		(exists (select 1 from jc_yzqx_ks t1 
						inner join jc_yzqx t2 on t1.qxid=t2.id and t2.jlzt=0 
						inner join jc_yzqxmx t3 on t1.qxid=t3.qxid and t3.order_type in ('4','5','6','7','8','9')
						where t1.deptid=@DEPT_ID and t3.order_id=AA.ORDER_ID)
		--Modify By Tany 2015-07-02 û��ƥ��Ĳ���ʾ
		--or not exists((select 1 from JC_YZQXMX t3 where AA.ORDER_ID=t3.ORDER_ID))
		or ORDER_TYPE=7
		) 
	end
END  
  
  
  
GO


