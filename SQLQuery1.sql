SELECT Id, Name FROM AspNetRoles WHERE Name = 'Admin';

SELECT Id, Email FROM AspNetUsers WHERE Email = 'admin@example.com';


--4fd7ca32-e661-4aff-8332-48e784b70d2e
INSERT INTO AspNetUserRoles (UserId, RoleId)
VALUES ('[8bd12046-cdd4-45fe-ac4e-49936f4b0c36]', '[4fd7ca32-e661-4aff-8332-48e784b70d2e]');

select * from AspNetUsers
select * from AspNetRoles

select * from BlogPosts