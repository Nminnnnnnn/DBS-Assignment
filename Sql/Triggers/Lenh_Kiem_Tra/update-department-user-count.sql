USE [EducationSystemDB]
GO
DECLARE @ErrorMessage NVARCHAR(MAX);

EXEC InsertStudentAndUser
    @Email = 'student4@gmail.com',
    @Password = N'123',
    @FullName = N'Student 5',
    @IdentityNumber = N'023984821392',
    @BirthDate = N'2000-01-01',
    @Gender = N'Nam',
    @Department = N'Kinh tế',
    @Status = N'Active',
    @AdmissionDate = N'2003-06-15',
    @LearningStatus = N'Active',
    @ErrorMessage = @ErrorMessage OUTPUT;

PRINT @ErrorMessage;
GO
SELECT * FROM [EducationSystemDB].[dbo].[DepartmentStats]