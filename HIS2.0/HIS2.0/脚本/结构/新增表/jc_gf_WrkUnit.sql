if exists(SELECT 1 FROM dbo.sysobjects where name ='jc_gf_WrkUnit' and type = 'U')
	DROP table jc_gf_WrkUnit
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[jc_gf_WrkUnit](
	id   INT  IDENTITY(1, 1)  PRIMARY KEY,
	name [varchar](50) NULL,
	pym  [varchar](50) NULL,
	wbm  [varchar](50) NULL,
	Wrk_Unit  smallint default 0,		--��λ����    
	fzr		[varchar](50) NULL,			--������
	bank		[varchar](50) NULL,		--��������
	pay_id		[varchar](50) NULL,		--�����˻�
	tel_no	[varchar](50) NULL,			--��ϵ�绰
	wrk_addr [varchar](50) NULL,		--��ַ
	del_bit		char(1) default '0',	--�ر��շ�
	cfsl_xz		int,					--������������
	cfslM_xz	int,					--ÿ�´�����������
	je_xz		decimal(15,4),			--�������
	jcje_xz		decimal(15,4),			--���������
	zlje_xz		decimal(15,4),			--���ƽ������
	memo  [varchar](50) NULL,			
	opr_date  datetime NULL,			
	opr_man  [varchar](50) NULL,			
	Mod_date  datetime NULL,			
	Mod_man  [varchar](50) NULL
) 

GO