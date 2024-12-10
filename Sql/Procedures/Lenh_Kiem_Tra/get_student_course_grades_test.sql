USE [EducationSystemDB]
GO
-- In bảng điểm của sinh viên trong học kỳ
EXEC GetStudentCourseGrades 
    @StudentId = 2, 
    @SemesterCode = 'Spring_HK1'