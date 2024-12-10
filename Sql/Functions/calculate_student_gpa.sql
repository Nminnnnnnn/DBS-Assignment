USE [EducationSystemDB]
GO
CREATE OR ALTER FUNCTION CalculateStudentGPA
(
    @StudentId INT
)
RETURNS TABLE
AS
RETURN
(
    WITH ClassroomGrades AS (
        -- Tính điểm cuối kỳ cho từng lớp học
        SELECT DISTINCT
            cl.CourseId,
            c.Name AS CourseName,
            c.NumberOfCredits,
            cl.Id AS ClassroomId,
            cl.SemesterCode,
            dbo.CalculateStudentClassroomFinalGrade(@StudentId, cl.Id) AS FinalGrade
        FROM StudentExercise se
        JOIN Exercise e ON se.ExerciseId = e.Id
        JOIN Classroom cl ON e.ClassroomId = cl.Id
        JOIN Course c ON cl.CourseId = c.Id
        WHERE se.StudentId = @StudentId
        
        UNION
        
        SELECT DISTINCT
            cl.CourseId,
            c.Name AS CourseName,
            c.NumberOfCredits,
            cl.Id AS ClassroomId,
            cl.SemesterCode,
            dbo.CalculateStudentClassroomFinalGrade(@StudentId, cl.Id) AS FinalGrade
        FROM StudentExam se
        JOIN Exam e ON se.ExamId = e.Id
        JOIN Classroom cl ON e.ClassroomId = cl.Id
        JOIN Course c ON cl.CourseId = c.Id
        WHERE se.StudentId = @StudentId
    ),
    BestGrades AS (
        -- Nhận điểm cao nhất cho mỗi khóa học, cho nỗ lực nào là tốt nhất
        SELECT 
            CourseId,
            CourseName,
            NumberOfCredits,
            MAX(FinalGrade) AS BestGrade,
            -- Chi tiết bổ sung về nỗ lực tốt nhất
            STRING_AGG(
                CONCAT(
                    N'Học kì: ', SemesterCode, 
                    N', Điểm số: ', CAST(FinalGrade AS DECIMAL(4,2))
                ),
                ' | '
            ) WITHIN GROUP (ORDER BY FinalGrade DESC) AS AllAttempts
        FROM ClassroomGrades
        GROUP BY CourseId, CourseName, NumberOfCredits
    )
    SELECT 
        SUM(NumberOfCredits) AS TotalCredits,
        CAST(SUM(NumberOfCredits * BestGrade) / NULLIF(SUM(NumberOfCredits), 0) AS DECIMAL(4,2)) AS GPA,
        STRING_AGG(
            CONCAT(
                CourseName, 
                ' (', NumberOfCredits, N' tín chỉ)', 
                N': Điểm cao nhất = ', CAST(BestGrade AS DECIMAL(4,2)),
                CHAR(13),
                N'Toàn bộ: ', AllAttempts
            ), 
            CHAR(13) + CHAR(13)
        ) AS CourseDetails
    FROM BestGrades
    WHERE BestGrade >= 0  -- chỉ lấy điểm nếu lớn hơn 0
)
GO