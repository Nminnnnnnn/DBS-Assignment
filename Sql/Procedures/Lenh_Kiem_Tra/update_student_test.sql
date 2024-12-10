USE [EducationSystemDB]
GO
DECLARE @ErrorMessage NVARCHAR(MAX);

EXEC UpdateStudentAndUser
    @UserId = 9,
    @Email = 'example123@email.com',
    @Password = 'securepassword',
    @FullName = 'Nguyen Van A',
    @IdentityNumber = '123456789',
    @BirthDate = '2000-01-01',
    @Gender = 'Nam',
    @Department = 'IT',
    @Status = 'Active',
    @AdmissionDate = '2024-09-01',
    @LearningStatus = 'Active',
    @ErrorMessage = @ErrorMessage OUTPUT;

PRINT @ErrorMessage;
SELECT TOP (200) Id, Email, Password, FullName, IdentityNumber, BirthDate, Gender, Department, Status
FROM [User]