IF  not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[yk_cwtz_temp]') AND type in (N'U'))
CREATE TABLE [dbo].[yk_cwtz_temp](
	[id] [uniqueidentifier] NOT NULL,--id
	[djh] [bigint] NULL, --ԭ���ݺ�
	[djid] [uniqueidentifier] NULL,--ԭ����ID
	[djmxid] [uniqueidentifier] NULL,--ԭ������ϸID
	[wldw] [int] NULL, --������λ
	[deptid] [int] NULL,--����
	[RQ] [datetime] NULL,--����
	[tzjg] [decimal](18, 3) NULL,--�����۸�
	[tzsl] [decimal](18, 3) NULL,--��������
	[tzje] [decimal](18, 3) NULL,--�������
	[kcid] [uniqueidentifier] NULL,--kcid
	[yppch] [varchar](100) NULL, --���κ�
	[cjid] [int] NULL,--����ID
	[SHH] [varchar](20) NULL, --����
	[SHDH] [varchar](50) NULL,--�ͻ�����
	[YPDW] [varchar](10) NULL,--ҩƷ��λ
	[FPH] [varchar](30) NULL, --ԭ��Ʊ
	[FPRQ] [char](10) NULL, --�ַ�Ʊ����
	[djy] [int] NULL,  --�Ǽ�Ա
	[djrq] [datetime] NULL,--�Ǽ�����
	[shr] [int] NULL, --�����
	[shrq] [datetime] NULL,--�������
	[cjr] [int] NULL,--���񴴽���
	[cjrq] [datetime] NULL,--��������
	[ywlx] [char](3) NULL,--ҵ������
	[ypph] [varchar](30) NULL,--ҩƷ����
	[jgbm] [bigint] NULL,--��������
	[xdjh] [bigint] NULL,--�ֵ��ݺ�
	[xfph] [varchar](30) null,--�ַ�Ʊ��
	[xdjid] [uniqueidentifier] NULL,�ֵ���ID
 CONSTRAINT [PK_yk_cwtz_temp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


