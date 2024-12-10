USE [EducationSystemDB]
GO
CREATE OR ALTER PROCEDURE GetStudentCourseGrades
    @StudentId INT,
    @SemesterCode NVARCHAR(50)
AS
BEGIN
    WITH ExerciseGrades AS (
        -- Lấy điểm các bài tập và đánh số thứ tự cho mỗi bài tập trong lớp
        SELECT 
            cl.Id AS ClassroomId,
            se.StudentId,
            se.Point AS ExercisePoint,
            e.Coefficient AS ExerciseCoef,
            ROW_NUMBER() OVER (PARTITION BY cl.Id ORDER BY e.EndTime) AS ExerciseNum
        FROM StudentExercise se
        JOIN Exercise e ON se.ExerciseId = e.Id
        JOIN Classroom cl ON e.ClassroomId = cl.Id
        WHERE se.StudentId = @StudentId
        AND cl.SemesterCode = @SemesterCode
    ),
    ExamGrades AS (
        -- Tính điểm kiểm tra dựa trên số câu đúng
        SELECT 
            e.ClassroomId,
            se.StudentId,
            e.Coefficient AS ExamCoef,
            SUM(CASE WHEN c.Answer = q.Answer THEN q.Point ELSE 0 END) AS ExamPoint
        FROM StudentExam se
        JOIN Exam e ON se.ExamId = e.Id
        JOIN Choice c ON se.ChoiceId = c.Id
        JOIN Question q ON c.QuestionId = q.Id
        WHERE se.StudentId = @StudentId
        GROUP BY e.ClassroomId, se.StudentId, e.Coefficient
    )
    SELECT 
        c.Name AS [Môn học],
        cl.Name AS [Lớp học],
        cl.SemesterCode AS [Học kỳ],
        MAX(CASE WHEN eg.ExerciseNum = 1 THEN eg.ExercisePoint END) AS [Điểm BT1],
        MAX(CASE WHEN eg.ExerciseNum = 1 THEN eg.ExerciseCoef END) AS [Hệ số BT1],
        MAX(CASE WHEN eg.ExerciseNum = 2 THEN eg.ExercisePoint END) AS [Điểm BT2],
        MAX(CASE WHEN eg.ExerciseNum = 2 THEN eg.ExerciseCoef END) AS [Hệ số BT2],
        exg.ExamPoint AS [Điểm kiểm tra],
        exg.ExamCoef AS [Hệ số kiểm tra],
        sc.Point AS [Điểm tổng kết]
    FROM StudentClassroom sc
    JOIN Classroom cl ON sc.ClassroomId = cl.Id
    JOIN Course c ON cl.CourseId = c.Id
    LEFT JOIN ExerciseGrades eg ON sc.ClassroomId = eg.ClassroomId AND sc.StudentId = eg.StudentId
    LEFT JOIN ExamGrades exg ON sc.ClassroomId = exg.ClassroomId AND sc.StudentId = exg.StudentId
    WHERE sc.StudentId = @StudentId
    AND cl.SemesterCode = @SemesterCode
    GROUP BY 
        c.Name, 
        cl.Name, 
        cl.SemesterCode,
        exg.ExamPoint,
        exg.ExamCoef,
        sc.Point
    ORDER BY c.Name
END