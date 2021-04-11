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
