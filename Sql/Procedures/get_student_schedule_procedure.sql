USE [EducationSystemDB]
GO
CREATE OR ALTER PROCEDURE GetStudentSchedule
    @StudentId INT,
    @SemesterCode NVARCHAR(50) = NULL,
    @Date DATE = NULL,
    @LessonNum INT = NULL,
    @CourseName NVARCHAR(50) = NULL,
    @ClassroomName NVARCHAR(50) = NULL
AS
BEGIN
    SELECT 
        s.StartTime AS "StartTime",
        s.EndTime AS "EndTime",
        s.LessonNum AS "LessonNum",
        s.RoomName AS "RoomName",
        c.Name AS "SubjectName",
        cl.Name AS "ClassName",
        cl.SemesterCode AS "SemesterCode",
        t.FullName AS "TeacherName",
        te.Degree AS "TeacherDegree"
    FROM Timetable tt
    JOIN Schedule s ON tt.ScheduleId = s.Id
    JOIN Classroom cl ON s.ClassroomId = cl.Id
    JOIN Course c ON cl.CourseId = c.Id
    JOIN Teacher te ON cl.TeacherId = te.UserId
    JOIN [User] t ON te.UserId = t.Id
	WHERE tt.StudentId = @StudentId
      AND (
           (@SemesterCode IS NULL OR cl.SemesterCode = @SemesterCode)
           AND (@Date IS NULL OR CAST(s.StartTime AS DATE) = @Date)
           AND (@LessonNum IS NULL OR s.LessonNum = @LessonNum)
           AND (@CourseName IS NULL OR c.Name LIKE '%' + @CourseName + '%')
           AND (@ClassroomName IS NULL OR cl.Name LIKE '%' + @ClassroomName + '%')
      )
    ORDER BY s.StartTime, s.LessonNum;
END