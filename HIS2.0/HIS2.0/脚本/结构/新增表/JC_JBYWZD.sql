--Add By Tany 2015-05-25 ����ҩ���ֵ�
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[JC_JBYWZD]') AND type in (N'U'))
CREATE TABLE [dbo].[JC_JBYWZD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[pym] [varchar](50) NULL,
	[wbm] [varchar](50) NULL,
 CONSTRAINT [PK_JC_JBYWZD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

/*
insert into JC_JBYWZD(name,pym,wbm) values('���һ���ҩ��',dbo.GETPYWB('���һ���ҩ��',0),dbo.GETPYWB('���һ���ҩ��',1))
insert into JC_JBYWZD(name,pym,wbm) values('ʡ������ҩ��',dbo.GETPYWB('ʡ������ҩ��',0),dbo.GETPYWB('ʡ������ҩ��',1))
*/