---add by tany 2015-05-11
if not exists(select 1 from jc_config where id=9101)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('9101','0','����Ʒ���ҽ��ʱ���Ƿ�ֻ������ҽʦ������ܷ��� 0=�� 1=��',9,getdate())