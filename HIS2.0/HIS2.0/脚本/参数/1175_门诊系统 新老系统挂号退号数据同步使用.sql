---add by pengyang 2015-10-9 ����ϵͳ ����ϵͳ�Һ��˺�����ͬ��ʹ��
if not exists(select 1 from jc_config where id=1175)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('1175','0','����ϵͳ ����ϵͳ�Һ��˺�����ͬ��ʹ�ã�0���Կ⣬1��ʽ��',6,getdate())