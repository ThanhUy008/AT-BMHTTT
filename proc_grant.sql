-- grant sys priv to user
CREATE OR REPLACE PROCEDURE grant_sys_user(
	priv IN NVARCHAR2,
	user_name IN NVARCHAR2) 
IS
BEGIN
    EXECUTE IMMEDIATE('grant ' || priv || ' to ' || user_name);
END grant_sys_user;

-- grant data priv to user
CREATE OR REPLACE PROCEDURE grant_data_user(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	user_name IN NVARCHAR2) 
IS
    str varchar2(50);
BEGIN
    EXECUTE IMMEDIATE('grant ' || data_priv || ' on '|| table_name || ' to ' || user_name);
END grant_data_user;

--grant sys priv ro role
CREATE OR REPLACE PROCEDURE grant_sys_role(
	priv IN NVARCHAR2,
	role_name IN NVARCHAR2) 
IS
BEGIN
    EXECUTE IMMEDIATE('grant ' || priv || ' to ' || role_name);
END grant_sys_role;

-- grant data priv to role
CREATE OR REPLACE PROCEDURE grant_data_role(
	data_priv IN NVARCHAR2,
    table_name IN NVARCHAR2,
	role_name IN NVARCHAR2)
IS
BEGIN
    EXECUTE IMMEDIATE('grant ' || data_priv || ' on '|| table_name || ' to ' || role_name);
END grant_data_role;









