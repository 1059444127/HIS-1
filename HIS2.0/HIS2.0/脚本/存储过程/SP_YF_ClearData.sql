
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'SP_YF_ClearData' 
	   AND 	  type = 'P')
    DROP PROCEDURE SP_YF_ClearData
GO
CREATE PROCEDURE [dbo].[SP_YF_ClearData]  
 (  
   @deptid integer  
 )   
as  
BEGIN  
   declare @kslx2 varchar(20);  
   delete from yF_cgmx where djid in(select id from yf_cg where deptid=@deptid);  
   delete from yF_cg where deptid=@deptid;  
   
   delete from YF_djmx where deptid=@deptid;   
   delete from YF_dj where deptid=@deptid;  
    
   delete from YF_djmx_h where deptid=@deptid;  
   delete from YF_dj_h where deptid=@deptid;  
  
  
   delete from YF_kcmx where deptid=@deptid;  
   delete from YF_kcph where deptid=@deptid;  
  
   delete from yf_pdtemp where deptid=@deptid  
  
   delete from YF_pdmx where djid in(select id from yf_pd where deptid=@deptid);  
   delete from YF_pd where deptid=@deptid;  
  
   delete from YF_pdcsmx where deptid=@deptid;  
   delete from YF_pdcs where deptid=@deptid;          
  
   delete from YF_rksqmx where deptid=@deptid;  
   delete from YF_rksq where deptid=@deptid;  
  
   delete from YF_tjmx where deptid=@deptid;  
   delete from YF_tj where deptid=@deptid;  
  
   delete from yp_djh where deptid=@deptid;  
   insert into yp_djh(ywlx,djh,deptid) select ywlx,0,@deptid from yf_ywlx;  
   insert into yp_djh(ywlx,djh,deptid)values('100',0,@deptid);  
   update  yP_djh set djh=0,sdjh='',ndjh=0  where deptid=@deptid;  
  
     
   delete from YF_ymjc where deptid=@deptid;  
   delete from yp_kjqj where deptid=@deptid;  
   delete from yk_config where deptid=@deptid;  
   
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('100','�ɹ�����Ƿ񱣴漴���ӿ��',0,'1 ������ʹ�� 0 ��ʹ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('101','ǿ�ƿ��ƿ��',0,'0 ���� 1 ��ʼ',@deptid);  
--   insert into yk_config(bh,mc,zt,bz,deptid)values('102','��������',0,'0 ���� 1 ����',@deptid);  
--   insert into yk_config(bh,mc,zt,bz,deptid)values('103','��λ����',0,'0 ���� 1 ����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('104','ϵͳ����',1,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('105','����ϵͳ',0,'0 �� 1 ��',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('106','��ҩģʽ',1,'0 �� 1 ��',@deptid);  
  -- insert into yk_config(bh,mc,zt,bz,deptid)values('107','��ҩģʽ��ǿ����ҩ',1,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('108','ҵ�񵥾ݽ��ܷ��Ƿ�����ֹ�������',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('109','�Ƿ������û�п���¼��ҩƷ�����̴�',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('110','�Ƿ������û�п���¼��ҩƷ���е���',0,'0 �� 1 ��',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('112','����������ʾ��Ʒ��',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('113','��ӡ����ʱ������ʾ��Ʒ��',0,'0 ��ӡƷ�� 1 ��ӡ��Ʒ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('114','ͳ�쵥��ҩ����ҩ�Ƿ�ֿ�',0,'0 ���ֿ� 1 �ֿ�',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('115','���﷢ҩ����ҩʱĬ�ϴ�ӡСƱ',0,'0 ������ 1 ����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('116','������ҩʱ��ӡ�嵥',0,'0 ���� 1 ��ӡ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('117','������ҩʱ��ӡ����',0,'0 ���� 1 ��ӡ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('118','������ҩʱ��ӡע�䵥',0,'0 ���� 1 ��ӡ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('119','���﷢ҩʱ��ӡ�嵥',0,'0 ���� 1 ��ӡ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('120','���﷢ҩʱ��ӡ����',0,'0 ���� 1 ��ӡ',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('121','���﷢ҩʱ��ӡע�䵥',0,'0 ���� 1 ��ӡ',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('122','���﷢ҩʱĬ�ϴ�ӡ����',0,'0 ���� 1 ��ӡ',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('123','��ͳ�쵥���˷ֿ�ʱ(����114=1ʱ),��ҩ��ϸĬ�ϲ�ѡ��',0,'1 ��ѡ�� 0 ѡ��',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('124','���﷢ҩʱ�س�,��ҩ��ť�Ƿ�������ý���',1,'1 ��ѡ�� 0 ѡ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('151','���﷢ҩ����ܴ�ӡ����',0,'1 ��ѡ�� 0 ѡ��',@deptid);  
  
   insert into yk_config(bh,mc,zt,bz,deptid)values('153','�����Ƿ�ʹ�÷ְ���',0,'0�� 1��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('999','�Ƿ��������ι���',0,'0-������,1-����',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('998','�̴淽ʽ',0,'0-�����ο���̴�,1-���ܿ���̴�',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('997','�Ƿ����ÿ췢�ӿ�',0,'0-������,1-����',@deptid);
   set @kslx2=(select rtrim(kslx2) from yp_yjks where deptid=@deptid );  
   if (@kslx2 is null)   
      set @kslx2='';  
  
   if rtrim(@kslx2)='����ҩ��'   
   begin  
   insert into yk_config(bh,mc,zt,bz,deptid)values('106','��ҩģʽ',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('107','��ҩģʽ��ǿ����ҩ',0,'0 �� 1 ��',@deptid);  
   insert into yk_config(bh,mc,zt,bz,deptid)values('152','�����շѷ��䷢ҩ����ʱ�Ƿ���֤��ҩ���ڵ�ʹ��״̬',0,'0 ����֤ 1 ��֤����״̬',@deptid);  
   end   
  
        
  
   delete from yf_fy where deptid=@deptid;  
   delete from yf_fy_h where deptid=@deptid;  
   delete from yf_fymx where deptid=@deptid;  
   delete from yf_fymx_h where deptid=@deptid;  
   delete from yf_fymx_ph where deptid=@deptid;  
   delete from yf_fymx_ph_h where deptid=@deptid;  
     
   delete from yf_tldmx where groupid in(select groupid from  yf_tld where deptid=@deptid);  
   delete from yf_tldmx_h where groupid in(select groupid from  yf_tld_h where deptid=@deptid);  
   delete from yf_tld where deptid=@deptid;  
   delete from yf_tld_h where deptid=@deptid;  
   
   delete from yf_zyfymx where deptid=@deptid  
     
   delete from YF_PD where DEPTID=@deptid  
   delete from YF_PDCS where DEPTID=@deptid   
   delete from YF_PDCSMX_KCMX where DEPTID=@deptid;--�̵�¼����ϸ�������ϸ��  
   delete from YF_PDMX_KCMX where DJID in ( select id from yf_pd where deptid=@deptid) --�̵������ϸ�������ϸ��  
   delete from YF_PDTEMP_KCMX where DEPTID=@deptid;--�̵��ʴ棨�����ϸ��  
   delete from YF_DJ_H where DEPTID =@deptid --ҩ��������ʱ��  
   delete from YF_DJMX_H where DEPTID=@deptid--ҩ��������ϸ��ʱ��  
   delete from YF_DJ_H where DEPTID=@deptid --ҩ�ⵥ����ʱ��  
   delete from YF_DJMX_H where DEPTID=@deptid --ҩ�ⵥ����ϸ��ʱ��  
   delete from yf_tldmx_fee   where zxks=@deptid   
     
  
  
   update yp_yjks set qybz=1,qysj=getdate() where deptid=@deptid;  
  
end ;