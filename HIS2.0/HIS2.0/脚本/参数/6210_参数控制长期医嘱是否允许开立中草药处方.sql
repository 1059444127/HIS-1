---add by jchl 2014-07-10
if not exists(select 1 from jc_config where id=6210)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6210','0','�������Ƴ���ҽ���Ƿ��������в�ҩ���� 0=�� 1=��  ',6,getdate())