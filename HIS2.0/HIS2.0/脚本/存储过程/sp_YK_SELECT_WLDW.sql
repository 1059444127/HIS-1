
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'sp_YK_SELECT_WLDW' 
	   AND 	  type = 'P')
    DROP PROCEDURE sp_YK_SELECT_WLDW
GO
CREATE PROCEDURE sp_YK_SELECT_WLDW
(
	@functionname varchar(30),
	@deptid int,
	@ss varchar(8000) output 
)
as
p1:begin
 declare @ssql varchar(8000)


  --�ڳ���ⵥ
 if @functionname='Fun_ts_yk_ypptrk_qc'  or @functionname='Fun_ts_yk_ypptrk_qc_cx' 
begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from jc_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+')';
 end 
 
 --ҩ���˿ⵥ
  if @functionname='Fun_ts_yk_ypptrk_tk' or @functionname='Fun_ts_yk_ypptrk_tk_cx' 
begin
 	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from jc_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''02'') ';
end
 
 
 --ҩƷ���ⵥ ҩ����ⵥ��ѯ
 if @functionname='Fun_ts_yk_ypck' or @functionname='Fun_ts_yk_tjbb_yktkd' 
or @functionname='Fun_ts_yk_ypck_cx' or @functionname='Fun_ts_yk_tjbb_yktkd_cx' 
begin
  	set @ssql='select  DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from jc_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''02'')';
end
 
  --������ҩ
 if @functionname='Fun_ts_yk_ypck_qtly'  or @functionname='Fun_ts_yk_ypck_wyylyd' or
@functionname='Fun_ts_yk_ypck_qtly_cx'  or @functionname='Fun_ts_yk_ypck_wyylyd_cx'
begin
  	set @ssql='select  DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from jc_dept_property  '+
		     ' WHERE DELETED=0 and dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and code=''04'')';
end
 
--ͬ���ⷿ���������
if @functionname='Fun_ts_yk_ypck_dck'  or @functionname='Fun_ts_yk_ypck_dck_cx' 
 or @functionname='Fun_ts_yk_ypck_drk'  or @functionname='Fun_ts_yk_ypck_drk_cx' 
begin
  	set @ssql='select DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from JC_dept_property '+
			 ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+' and  code=''01'' )';
end

  --����
 if @functionname='' 
begin
  	set @ssql='select  DEPT_ID,0 ROWNO,NAME, PY_CODE, WB_CODE from jc_dept_property  '+
		     ' WHERE dept_id in(select dyksid from yp_lyks where deptid='+cast(@deptid as char(10))+')';
end


 
 set @ss=rtrim(@ssql)
 return
 
 end 
 

