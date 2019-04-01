

/*******************************************************************************************/
/*����ϵͳ���й����У���Ÿ�����ϵͳ֮�䷢�͵���Ϣ                                         */
/*******************************************************************************************/

if exists( select 1 from dbo.sysobjects where name = N'Pub_Message_Record' )
	drop table Pub_Message_Record

go

create table Pub_Message_Record(
	MsgId           uniqueidentifier     not null,
	Summary         varchar(1000)        not null,                        --��ϢժҪ��������ʾ�ļ�Ҫ��Ϣ,��Ϣ���Ͷ���д
	SendTime        datetime			 not null default getdate(),      --��Ϣ����ʱ��
	SendStaff       int                  not null                  ,      --��Ϣ������ID
	SendByIP        varchar(20)          not null                  ,      --��Ϣ����ʱ�Ļ���IP
	FontColor       varchar(20)          not null                  ,      --����                            ��*��
	ShowType        smallint             not null default 0      ,      --��Ϣ��ʾ��ʽ 0:���� 1:��������   ��*�����ݵ�������Ϣ��Ϊ�Ƿ�ǿ�ƶ�ȡ�ģ����ڵ���Ϊǿ�ƶ�ȡ
	ShowTime        int                  not null default 0       ,      --��ʾʱ��                        ��*��ֻ�����ݵ�������Ϣ��Ч
	ReciveSystem    int                  not null default 0       ,      --�ܽ�����Ϣ��ϵͳģ��             ��*��
	ReciveStaff     int                  not null default 0       ,      --�ܽ�����Ϣ�Ĳ���Ա                ��*��
	ReciveDept      int                  not null default 0       ,      --�ܽ�����Ϣ�Ŀ���                  ��*��
	ReciveWard      varchar(10)         not null default ''      ,      --�ܽ��տ��ҵĲ���                  ��*��
	DealStatus      smallint             not null default 0      ,      --����״̬ ��0��δ����1�������Ϊ�Ѷ���2����������)
	FirstReader     int                  not null default 0       ,      --��һ���Ķ�����ID
	ReadTime        DateTime             null                      ,      --�Ķ�ʱ��
	ReadByIP        varchar(20)          not null default ''     ,      --�Ķ���Ϣʱ�Ļ���IP
	DllName         varchar(100)         null                      ,      --��ʾ��Ϣ����ʱ��Ҫ���õ�DLLģ��,�����������ʾ������Ҫ��д
	FuncationName   varchar(100)         null                      ,      --���ú�����
	FormText        varchar(100)         null                      ,      --���������
	FuncationTag    varchar(100)         null                      ,      --��������ֵ
	InvokMethod     varchar(100)         null                      ,      --������غ�Ļص�������
	Parameter       varchar(1000)        null default ''           ,      --���ݸ�Ŀ�괰��Ĳ���(������Ա�Զ���)
	constraint PK_PUB_MESSAGE_RECORD primary key  (MsgId) 
)

go