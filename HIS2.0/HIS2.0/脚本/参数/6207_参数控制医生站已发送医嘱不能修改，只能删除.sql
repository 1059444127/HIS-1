---add by jchl 2014-07-23
if not exists(select 1 from jc_config where id=6207)
	insert into jc_config(id,config,note,module_id,cjsj) 
	values('6207','0','��������ҽ��վ�ѷ��ͣ�״̬Ϊ1��ҽ�������޸ģ�ֻ��ɾ�� 0=�� 1=��  ',6,getdate())