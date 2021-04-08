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
