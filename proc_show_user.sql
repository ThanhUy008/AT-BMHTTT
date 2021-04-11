--show all user
create or replace procedure showAllUser (c1 out sys_refcursor)
is
begin
    open c1 for select * from dba_users;
end;
--show user privillage system
create or replace procedure showUserPrivSys (username in VARCHAR2, c1 out sys_refcursor)
is
begin
    open c1 for select * from dba_sys_privs where GRANTEE = username;
end;
--show user privillage table
create or replace procedure showUserPrivTab (username in VARCHAR2, c1 out sys_refcursor)
is
begin
    open c1 for select table_name, privilege, grantable from dba_tab_privs where GRANTEE = username;
end;

--show role privillage system 
create or replace procedure showRolePrivSys (rolename in varchar2, c1 out sys_refcursor)
is
begin
    open c1 for select * from role_sys_privs where ROLE = rolename;
end;

--show role privillage table 
create or replace procedure showRolePrivTab (rolename in varchar2, c1 out sys_refcursor)
is
begin
    open c1 for select * from role_tab_privs where ROLE = rolename;
end;

