CREATE PROCEDURE SP_YK_ClearData  
 (  
    @deptid integer  
 )   
as  
BEGIN  
   delete from yf_cgmx where djid in(select id from yf_cg where deptid=@deptid);  
   delete from yf_cg where deptid=@deptid;  
  
   delete from yk_djmx where deptid=@deptid;  
   delete from yk_djmx_h where deptid=@deptid;  
  
   delete from yk_dj where deptid=@deptid;  
   delete from yk_dj_h where deptid=@deptid;  
  
   delete from yk_kcmx where deptid=@deptid;  
   delete from yk_kcph where deptid=@deptid;  
  
   delete from yf_pdmx where djid in(select id from yf_pd where deptid=@deptid);  
   delete from yf_pd where deptid=@deptid;  
  
   delete from yf_pdcsmx where deptid=@deptid;  
   delete from yf_pdcs where deptid=@deptid;  
  
   delete from yf_rksqmx where deptid=@deptid;  
   delete from yf_rksq where deptid=@deptid;  
  
   delete from yf_tjmx where deptid=@deptid;  
   delete from yf_tj where deptid=@deptid;  
  
   delete from yF_fymx_ph where deptid=@deptid;  
   delete from yF_fymx_ph_h where deptid=@deptid;  
     
   delete from yF_fymx where deptid=@deptid;  
   delete from yF_fy where deptid=@deptid;  
  
   delete from yF_fymx_h where deptid=@deptid;  
   delete from yF_fy_h where deptid=@deptid;  
  
   delete from yp_djh where deptid=@deptid;  
   insert into yp_djh(ywlx,djh,deptid) select ywlx,0,@deptid from yk_ywlx;  
   update  yP_djh set djh=0  where deptid=@deptid;  
     
   --delete from yp_gllx where deptid=@deptid;  
     
   delete from yK_ymjc where deptid=@deptid;  
   delete from yp_kjqj where deptid=@deptid;  
     
   --add by ncq 2014-05-23   
   delete from YF_PD where DEPTID=@deptid  
   delete from YF_PDCS where DEPTID=@deptid    
   delete from Yf_PDCSMX_KCMX where DEPTID=@deptid;--�̵�¼����ϸ�������ϸ��  
   delete from Yf_PDMX_KCMX where DJID in ( select id from yf_pd where deptid=@deptid) --�̵������ϸ�������ϸ��  
   delete from Yf_PDTEMP_KCMX where DEPTID=@deptid;--�̵��ʴ棨�����ϸ��  
   delete from YK_DJ_H where DEPTID =@deptid --ҩ��������ʱ��  
   delete from YK_DJMX_H where DEPTID=@deptid--ҩ��������ϸ��ʱ��  
   delete from YK_DJ_H where DEPTID=@deptid --ҩ�ⵥ����ʱ��  
   delete from YK_DJMX_H where DEPTID=@deptid --ҩ�ⵥ����ϸ��ʱ��  
     
   delete YP_KCSXX where DEPTID=@deptid   
    
     
     
     
     
   delete from yk_config where deptid=@deptid;  
   --insert into yk_config(bh,mc,zt,bz,deptid)values('100','�ɹ�����Ƿ񱣴漴���ӿ��',0,'1 ������ʹ�� 0 ��ʹ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('101','ǿ�ƿ��ƿ��',0,'0 ���� 1 ��ʼ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('102','��������',1,'0 ���� 1 ����',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('103','��λ����',0,'0 ���� 1 ����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('104','ϵͳ����',1,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('105','����ϵͳ',0,'0 �� 1 ��',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('106','��ҩģʽ',1,'0 �� 1 ��',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('107','��ҩģʽ��ǿ����ҩ',1,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('108','ҵ�񵥾ݽ��ܷ��Ƿ�����ֹ�������',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('109','�Ƿ������û�п���¼��ҩƷ�����̴�',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('110','�Ƿ������û�п���¼��ҩƷ���е���',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('111','ֱ��¼��������',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('112','����������ʾ��Ʒ��',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('113','��ӡ����ʱ������ʾ��Ʒ��',0,'0 ��ӡƷ�� 1 ��ӡ��Ʒ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('114','������ͳ������ҵ��Ա',0,'0 ������ 1 ����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('125','�ɹ���ⵥ��ʾ�����ۺ��������',0,'0 ����ʾ 1 ��ʾ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('125','�ɹ���ⵥ��ʾ�����ۺ��������',0,'0 ����ʾ 1 ��ʾ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('999','�Ƿ��������ι���',0,'0-������,1-����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('998','�̴淽ʽ',0,'0-�����ο���̴�,1-���ܿ���̴�',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('997','�Ƿ����ÿ췢�ӿ�',0,'0-������,1-����',@deptid);
   update yp_yjks set qybz=1,qysj=getdate() where deptid=@deptid;  
  
end ;  
  
  
  