---add by jchl 2014-07-10
if not exists(select 1 from ZY_ORDERPRTCFG where id=200)
	insert into ZY_ORDERPRTCFG(ID,NAME,X,Y,ISPRINT,LB,MEMO,JGBM)
	values(200,'ȡ������',0,0,1,2,'��ʱ',1001)