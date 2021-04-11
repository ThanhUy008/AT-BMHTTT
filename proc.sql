
/*
This is to create a view
*/
CREATE OR REPLACE PROCEDURE beginSession
IS
BEGIN
EXECUTE IMMEDIATE('TRUNCATE TABLE justGrantSys');

EXECUTE IMMEDIATE('TRUNCATE TABLE justGrantTab');
COMMIT;
END beginSession;

/*alter session set container = XEPDB1;*/
/
/*
Reset quyen
*/
CREATE OR REPLACE PROCEDURE  revokeUserSysPriv (username in NVARCHAR2,sys_priv in NVARCHAR2)
IS
str   VARCHAR2 (1000);
BEGIN
str := 'REVOKE ' ||  sys_priv || ' FROM ' || username ;
        	EXECUTE IMMEDIATE ( str );
            COMMIT;
    
END;
/

/*
revoke data table
*/
CREATE OR REPLACE PROCEDURE  revokeUserTablePriv (username in NVARCHAR2,type_priv in NVARCHAR2, tab_name in NVARCHAR2)
IS
str   VARCHAR2 (1000);
BEGIN
str := 'REVOKE ' || type_priv|| ' ON ' || tab_name || ' FROM ' || username ;
        	EXECUTE IMMEDIATE ( str );
            COMMIT;
    
END;
/

-- grant sys priv to user
CREATE OR REPLACE PROCEDURE grant_sys_user(
	priv IN NVARCHAR2,
	user_name IN NVARCHAR2) 
IS
var1 NVARCHAR2(1000);

BEGIN
    EXECUTE IMMEDIATE('grant ' || priv || ' to ' || user_name);
    EXECUTE IMMEDIATE('INSERT INTO justGrantSys VALUES(''' || user_name || ''',User,''' || priv || ''');');
    DBMS_OUTPUT.put_line('INSERT INTO justGrantSys VALUES(''' || user_name || ''',''User'',''' || priv || ''');');
    COMMIT;
END grant_sys_user;
/
exec grant_sys_user('CREATE ANY TABLE','C##USER')
INSERT INTO justGrantSys VALUES('C##USER','User','CREATE ANY TABLE');
-- grant data priv column to user
CREATE OR REPLACE PROCEDURE grant_data_user_2(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	user_name IN NVARCHAR2,
    columnList IN VARCHAR2,
    withGrantOption IN NVARCHAR2)
IS
    str varchar2(4000);
    str2 varchar2(4000);
BEGIN
    str:= 'CREATE OR REPLACE VIEW' || table_name ||'_' || user_name || 'AS SELECT ' || columnList ||' FROM ' || table_name;
    EXECUTE IMMEDIATE (str);
    str2:= 'GRANT '|| data_priv || ' ON ' || table_name ||'_' || user_name || ' TO ' || user_name || ' ' || withGrantOption;
    EXECUTE IMMEDIATE(str2);
  
    EXECUTE IMMEDIATE('INSERT INTO justGrantTab VALUES(''' || user_name || ''',''User'',''' || data_priv || ''',''' || table_name || ''',''' || columnList || ''');');
  
    COMMIT;
END grant_data_user_2;
/
-- grant data priv to user
CREATE OR REPLACE PROCEDURE grant_data_user(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	user_name IN NVARCHAR2,
    withGrantOption IN NVARCHAR2
    ) 
IS
    str varchar2(50);
BEGIN
    EXECUTE IMMEDIATE('grant ' || data_priv || ' on '|| table_name || ' to ' || user_name ||' ' || withGrantOption);
     EXECUTE IMMEDIATE('INSERT INTO justGrantTab VALUES(''' || user_name || ''',''User'',''' || data_priv || ''',''' || table_name || ''');');
  
    COMMIT;
END grant_data_user;
/

--grant sys priv ro role
CREATE OR REPLACE PROCEDURE grant_sys_role(
	priv IN NVARCHAR2,
	role_name IN NVARCHAR2) 
IS
BEGIN
    EXECUTE IMMEDIATE('grant ' || priv || ' to ' || role_name);
      EXECUTE IMMEDIATE('INSERT INTO justGrantSys VALUES(''' || role_name || ''',''Role'',''' || priv || ''');');
  
    COMMIT;
END grant_sys_role;
/
-- grant data priv to role
CREATE OR REPLACE PROCEDURE grant_data_role(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	role_name IN NVARCHAR2,
    withGrantOption IN NVARCHAR2)
IS
BEGIN
    EXECUTE IMMEDIATE('grant ' || data_priv || ' on '|| table_name || ' to ' || role_name || ' ' || withGrantOption);
     EXECUTE IMMEDIATE('INSERT INTO justGrantTab VALUES(''' || role_name || ''',''User'',''' || data_priv || ''',''' || table_name || ''')');
  
    COMMIT;
END grant_data_role;
/

CREATE OR REPLACE PROCEDURE grant_data_role2(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	role_name IN NVARCHAR2,
    columnList IN NVARCHAR2,
    withGrantOption IN NVARCHAR2)
IS
BEGIN
    EXECUTE IMMEDIATE('CREATE OR REPLACE VIEW' || table_name ||'_' || role_name || 'AS SELECT ' || columnList ||' FROM ' || table_name);
    
    EXECUTE IMMEDIATE('GRANT '|| data_priv || ' ON ' || table_name ||'_' || role_name || ' TO ' || role_name || ' ' || withGrantOption);
    
    EXECUTE IMMEDIATE('INSERT INTO justGrantTab VALUES(''' || role_name || ''',''User'',''' || data_priv || ''',''' || table_name || ''', ''' || columnList || ''')');
  
    COMMIT;
END grant_data_role2;
/
/*
Revoke all
*/

create or replace NONEDITIONABLE PROCEDURE revokeUser_role(
	pi_username_role IN NVARCHAR2,
	pi_privilege IN NVARCHAR2) 
IS
	
	user_name_role NVARCHAR2(20)  	:= pi_username_role;
	prige NVARCHAR2(20) 		:= pi_privilege;
   	str   VARCHAR2 (1000);
BEGIN
        str := 'revoke ' || prige || ' from ' || user_name_role ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end revokeUser_role;
/

--create role
create or replace NONEDITIONABLE PROCEDURE createRole(
	pi_rolename IN NVARCHAR2) 
IS
	
	role_name NVARCHAR2(20)  	:= pi_rolename;
   	str   VARCHAR2 (1000);
BEGIN

        str:='alter session set "_ORACLE_SCRIPT"=true';
        EXECUTE IMMEDIATE (str);
        str := 'CREATE ROLE ' || role_name ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end createRole;
/
--drop role
create or replace NONEDITIONABLE PROCEDURE DropRole(
	pi_rolename IN NVARCHAR2) 
IS
	
	role_name NVARCHAR2(20)  	:= pi_rolename;
   	str   VARCHAR2 (1000);
BEGIN
        str := 'DROP Role ' || role_name  ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end DropRole;
/

--show all user
create or replace procedure showAllUser (c1 out sys_refcursor)
is
begin
    open c1 for select USERNAME ,
USER_ID ,
ACCOUNT_STATUS ,
LOCK_DATE ,
EXPIRY_DATE ,
DEFAULT_TABLESPACE ,
TEMPORARY_TABLESPACE ,
LOCAL_TEMP_TABLESPACE ,
CREATED ,
PROFILE ,
INITIAL_RSRC_CONSUMER_GROUP ,
EXTERNAL_NAME ,
PASSWORD_VERSIONS ,
EDITIONS_ENABLED ,
AUTHENTICATION_TYPE ,
PROXY_ONLY_CONNECT ,
COMMON ,
LAST_LOGIN ,
ORACLE_MAINTAINED ,
INHERITED ,
DEFAULT_COLLATION ,
IMPLICIT ,
ALL_SHARD  from dba_users;
end;
/

--show user privillage system
create or replace procedure showUserPrivSys (username in VARCHAR2, c1 out sys_refcursor)
is
begin
    open c1 for select * from dba_sys_privs where GRANTEE = username;
end;
/
--show user privillage table
create or replace procedure showUserPrivTab (username in VARCHAR2, c1 out sys_refcursor)
is
begin
    open c1 for select table_name, privilege, grantable from dba_tab_privs where GRANTEE = username;
end;
/
--show role privillage system 
create or replace procedure showRolePrivSys (rolename in varchar2, c1 out sys_refcursor)
is
begin
    open c1 for select * from role_sys_privs where ROLE = rolename;
end;
/
--show role privillage table 
create or replace procedure showRolePrivTab (rolename in varchar2, c1 out sys_refcursor)
is
begin
    open c1 for select * from role_tab_privs where ROLE = rolename;
end;
/
--create user
create or replace NONEDITIONABLE PROCEDURE createUser(
	pi_username IN NVARCHAR2,
	pi_password IN NVARCHAR2) 
IS
	
	user_name NVARCHAR2(20)  	:= pi_username;
	pwd NVARCHAR2(20) 		:= pi_password;
   	str   VARCHAR2 (1000);
BEGIN
        str:='alter session set "_ORACLE_SCRIPT"=true';
        EXECUTE IMMEDIATE (str);
        str := 'CREATE USER ' || user_name || ' IDENTIFIED BY ' || pwd ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end createUser;


/
--drop user
create or replace NONEDITIONABLE PROCEDURE DropUser(
	pi_username IN NVARCHAR2) 
IS
	
	user_name NVARCHAR2(20)  	:= pi_username;
   	str   VARCHAR2 (1000);
BEGIN
        str := 'DROP USER ' || user_name  ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end DropUser;
/
--edit user
create or replace NONEDITIONABLE PROCEDURE EditUser(
	pi_username IN NVARCHAR2,
    new_password IN NVARCHAR2) 
IS
	
	user_name NVARCHAR2(20)  	:= pi_username;
    new_pwd NVARCHAR2(20) 		:= new_password;
   	str   VARCHAR2 (1000);
BEGIN
        str :='ALTER USER '||user_name||' IDENTIFIED BY '|| new_pwd||' 
                DEFAULT TABLESPACE "USERS"
                TEMPORARY TABLESPACE "TEMP"
                ACCOUNT UNLOCK ';
        	EXECUTE IMMEDIATE ( str );
            commit;
end EditUser;
/


create or replace procedure showAllJustGrantSys (c1 out sys_refcursor)
is
begin
    open c1 for select *  from justGrantSys;
end;
/

create or replace procedure showAllJustGrantTab (c1 out sys_refcursor)
is
begin
    open c1 for select *  from justGrantTab;
end;
/




