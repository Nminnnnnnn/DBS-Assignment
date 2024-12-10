USE [EducationSystemDB]
GO
DECLARE @ErrorMessage NVARCHAR(MAX);

EXEC InsertStudentAndUser
    @Email = 'example@student.com',
    @Password = 'password123',
    @FullName = 'Nguyen Van A',
    @IdentityNumber = '123456789',
    @BirthDate = '2000-01-01',
    @Gender = 'Nam',
    @Department = 'Công nghệ thông tin',
    @Status = 'Active',
    @AdmissionDate = '2024-11-25',
    @LearningStatus = 'Active',
    @ErrorMessage = @ErrorMessage OUTPUT;

PRINT @ErrorMessage;
SELECT TOP (200) Id, Email, Password, FullName, IdentityNumber, BirthDate, Gender, Department, Status
FROM [User]
