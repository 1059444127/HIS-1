if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_sflbmx' and type = 'U')
	DROP table jc_gf_sflbmx
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_sflbmx]( 
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	sflb varchar(8) NULL,			--�շ�������
	xmly   INT,						--��Ŀ��Դ
	xmid INT,						--��Ŀid
	Opr_man [varchar](50) NULL,		--������
	Opr_time [datetime] NULL,		--����ʱ��
	del_bit	int						--ɾ����־
) 

GO