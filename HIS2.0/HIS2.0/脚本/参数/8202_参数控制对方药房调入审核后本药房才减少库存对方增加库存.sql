---add by py 2015-02-13
if not exists(select 1 from jc_config where id=8202)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('8202','0','ҩ���������Ƿ�ֱ�����ӶԷ���棬0 �� 1�ǣ�Ĭ��Ϊ0 ',8,getdate())
	
	
