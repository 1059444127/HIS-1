--Add By Daniel 2015-01-31
if not exists(select 1 from JC_CONFIG where ID=10022)
INSERT INTO JC_CONFIG(ID,CONFIG,NOTE,MODULE_ID,CJSJ)
VALUES(10022,'1','�������ȷ�Ͻ����Ƿ�ֻ��ʾĬ��ִ�п���Ϊ��ǰ���ҵ�ҽ����Ŀ,0=��,1=��,Ĭ��Ϊ1',10,GETDATE())
