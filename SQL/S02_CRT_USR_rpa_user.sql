CREATE LOGIN rpa_user   
    WITH PASSWORD = 'Alura@2023';  
GO  

CREATE USER rpa_user 
    FOR LOGIN rpa_user
	WITH DEFAULT_SCHEMA = alura_rpa
GO  


EXEC sp_addrolemember N'db_owner', N'rpa_user'
GO


