--create role
create or replace NONEDITIONABLE PROCEDURE createRole(
	pi_rolename IN NVARCHAR2,
	pi_password IN NVARCHAR2) 
IS
	
	role_name NVARCHAR2(20)  	:= pi_rolename;
	pwd NVARCHAR2(20) 		:= pi_password;
   	str   VARCHAR2 (1000);
BEGIN

        str:='alter session set "_ORACLE_SCRIPT"=true';
        EXECUTE IMMEDIATE (str);
        str := 'CREATE ROLE ' || role_name || ' IDENTIFIED BY ' || pwd ;
        	EXECUTE IMMEDIATE ( str );
            commit;
end createRole;
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

