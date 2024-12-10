USE [EducationSystemDB]
GO
DECLARE @ErrorMessage NVARCHAR(MAX);

EXEC DeleteStudentAndUser
    @UserId = 9,
    @ErrorMessage = @ErrorMessage OUTPUT;

PRINT @ErrorMessage;

SELECT TOP (200) Id, Email, Password, FullName, IdentityNumber, BirthDate, Gender, Department, Status
FROM [User]
