if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_sflb' and type = 'U')
	DROP table jc_gf_sflb
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_sflb]( 
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	name [varchar](50) NULL,		--�շ����	
	sflb varchar(8) NULL,			--�շ�������
	wbm varchar(50) NULL,			--�����
	pym varchar(50) NULL,			--ƴ����
	szm varchar(50) NULL,			--������
	Opr_man [varchar](50) NULL,		--������
	Opr_time [datetime] NULL,		--����ʱ��
	memo [varchar](50) NULL,		--��ע
	del_bit	int						--ɾ����־
) 

GO