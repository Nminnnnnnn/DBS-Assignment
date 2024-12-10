USE [EducationSystemDB]
GO
CREATE OR ALTER FUNCTION CalculateStudentClassroomFinalGrade
(
    @StudentId INT,
    @ClassroomId INT
)
RETURNS FLOAT
AS
BEGIN
    DECLARE @FinalGrade FLOAT = 0
    DECLARE @ExamGrade FLOAT = 0
    DECLARE @ExerciseGrade FLOAT = 0
    DECLARE @TotalCoefficient INT = 0

    -- Tính điểm thi (tổng điểm của các câu trả lời đúng có trọng số)
    SELECT 
        @ExamGrade = SUM(CASE WHEN c.Answer = q.Answer THEN q.Point ELSE 0 END * e.Coefficient),
        @TotalCoefficient = @TotalCoefficient + SUM(e.Coefficient)
    FROM StudentExam se
    JOIN Exam e ON se.ExamId = e.Id
    JOIN Choice c ON se.ChoiceId = c.Id
    JOIN Question q ON c.QuestionId = q.Id
    WHERE se.StudentId = @StudentId 
    AND e.ClassroomId = @ClassroomId

    -- Tính điểm bài tập (tổng điểm bài tập có trọng số)
    SELECT 
        @ExerciseGrade = SUM(se.Point * e.Coefficient),
        @TotalCoefficient = @TotalCoefficient + SUM(e.Coefficient)
    FROM StudentExercise se
    JOIN Exercise e ON se.ExerciseId = e.Id
    WHERE se.StudentId = @StudentId 
    AND e.ClassroomId = @ClassroomId
    AND se.Point IS NOT NULL

    -- Calculate final grade
    SET @FinalGrade = (@ExamGrade + @ExerciseGrade) / NULLIF(@TotalCoefficient, 0)

    RETURN @FinalGrade
END
GO