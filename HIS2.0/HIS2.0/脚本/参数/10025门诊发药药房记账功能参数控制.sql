--���﷢ҩҩ�����˹��ܲ������� 0���� 1 ������ Ĭ��Ϊ0  add pengyang 2015-7-10
if not exists(select 1 from jc_config where id=10025) 
insert into jc_config(id,config,note,module_id,cjsj) 
values(10025,'207','���﷢ҩҩ�����˹��ܲ�������',10,GETDATE())


 select * from JC_CONFIG where ID = 10025