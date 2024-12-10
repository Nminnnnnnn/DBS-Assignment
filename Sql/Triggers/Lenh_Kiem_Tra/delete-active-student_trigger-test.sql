USE [EducationSystemDB]
GO
-- Insert overlapping timetable record
BEGIN TRY 
	INSERT INTO Timetable (StudentId, ScheduleId)
	VALUES (2, 3); -- Student 1 with Schedule 2 (overlaps with Schedule 1)
END TRY 
BEGIN CATCH 
END CATCH 
GO
SELECT TOP (200) StudentId, ScheduleId
FROM Timetable