USE [EducationSystemDB]
GO
-- Truy vấn tất cả thời khóa biểu của sinh viên trong học kỳ
EXEC GetStudentSchedule 
    @StudentId = 2, 
    @SemesterCode = 'Spring_HK1'
-- Truy vấn có lọc theo các tiêu chí
EXEC GetStudentSchedule 
    @StudentId = 2,
    @LessonNum = 2