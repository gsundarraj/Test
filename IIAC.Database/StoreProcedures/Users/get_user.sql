CREATE PROCEDURE [dbo].[get_user]
	@id int 
	
AS
BEGIN
   SELECT Id,UserName,FirstName,LastName,Gender,Dob,Qualification,Experience,Email,Mobile,[Address],Reference,DeviceId,IPAddress,IsVerified,ActivatedDate
   FROM Users
   WHERE  Id = @id AND RecordStatus=0; 


END
