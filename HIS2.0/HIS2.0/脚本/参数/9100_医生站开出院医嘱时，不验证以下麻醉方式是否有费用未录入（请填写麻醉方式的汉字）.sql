---add by tany 2015-04-27
if not exists(select 1 from jc_config where id=9100)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('9100','','ҽ��վ����Ժҽ��ʱ������֤��������ʽ�Ƿ��з���δ¼�루����д����ʽ�ĺ��֣�',9,getdate())