USE [EducationSystemDB]
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Password], [FullName], [IdentityNumber], [BirthDate], [Gender], [Department], [Status]) VALUES (1, N'teacher@gmail.com', N'123', N'Teacher', N'039382759182', CAST(N'2000-04-04' AS Date), N'Nam', N'Công nghệ thông tin', N'Active')
INSERT [dbo].[User] ([Id], [Email], [Password], [FullName], [IdentityNumber], [BirthDate], [Gender], [Department], [Status]) VALUES (2, N'student@gmail.com', N'123', N'Student 1', N'039284712374', CAST(N'2003-03-15' AS Date), N'Nam', N'Công nghệ thông tin', N'Active')
INSERT [dbo].[User] ([Id], [Email], [Password], [FullName], [IdentityNumber], [BirthDate], [Gender], [Department], [Status]) VALUES (3, N'student1@gmail.com', N'123', N'Student 2', N'039231458237', CAST(N'2005-09-12' AS Date), N'Nam', N'Công nghệ thông tin', N'Active')
INSERT [dbo].[User] ([Id], [Email], [Password], [FullName], [IdentityNumber], [BirthDate], [Gender], [Department], [Status]) VALUES (4, N'student2@gmail.com', N'123', N'Student 3', N'093827421323', CAST(N'2002-12-01' AS Date), N'Nam', N'Kinh tế', N'Active')
INSERT [dbo].[User] ([Id], [Email], [Password], [FullName], [IdentityNumber], [BirthDate], [Gender], [Department], [Status]) VALUES (5, N'student3@gmail.com', N'123', N'Student 4', N'023984821392', CAST(N'2001-07-14' AS Date), N'Nam', N'Kinh tế', N'Active')
SET IDENTITY_INSERT [dbo].[User] OFF
GO

INSERT [dbo].[Student] ([UserId], [AdmissionDate], [LearningStatus]) VALUES (2, CAST(N'2021-05-12' AS Date), N'Active')
INSERT [dbo].[Student] ([UserId], [AdmissionDate], [LearningStatus]) VALUES (3, CAST(N'2021-08-12' AS Date), N'Active')
INSERT [dbo].[Student] ([UserId], [AdmissionDate], [LearningStatus]) VALUES (4, CAST(N'2021-08-12' AS Date), N'Active')
INSERT [dbo].[Student] ([UserId], [AdmissionDate], [LearningStatus]) VALUES (5, CAST(N'2021-05-12' AS Date), N'Active')
GO
INSERT [dbo].[Teacher] ([UserId], [StartDate], [Degree], [WorkType], [Achievement]) VALUES (1, CAST(N'2020-09-12' AS Date), N'Thạc Sĩ', N'Dạy học', N'123')
GO

SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [BeforeCourseId], [Name], [NumberOfCredits], [EndDate], [ForumId]) VALUES (1, NULL, N'PTO152', 15, CAST(N'2024-05-15' AS Date), NULL)
INSERT [dbo].[Course] ([Id], [BeforeCourseId], [Name], [NumberOfCredits], [EndDate], [ForumId]) VALUES (2, NULL, N'AOC147', 15, CAST(N'2024-05-15' AS Date), NULL)
INSERT [dbo].[Course] ([Id], [BeforeCourseId], [Name], [NumberOfCredits], [EndDate], [ForumId]) VALUES (3, NULL, N'PCF912', 15, CAST(N'2024-05-15' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO

SET IDENTITY_INSERT [dbo].[Classroom] ON 

INSERT [dbo].[Classroom] ([Id], [Name], [SemesterCode], [TeacherId], [CourseId]) VALUES (1, N'Winter_DCD153', N'Spring_HK1', 1, 1)
INSERT [dbo].[Classroom] ([Id], [Name], [SemesterCode], [TeacherId], [CourseId]) VALUES (2, N'Winter_OBC123', N'Spring_HK1', 1, 2)
INSERT [dbo].[Classroom] ([Id], [Name], [SemesterCode], [TeacherId], [CourseId]) VALUES (3, N'WInter_BDA_582', N'Spring_HK1', 1, 3)
INSERT [dbo].[Classroom] ([Id], [Name], [SemesterCode], [TeacherId], [CourseId]) VALUES (4, N'WInter_BDA_531', N'Spring_HK1', 1, 3)
SET IDENTITY_INSERT [dbo].[Classroom] OFF
GO

SET IDENTITY_INSERT [dbo].[Schedule] ON 

INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (1, N'Phòng 202', CAST(N'2024-03-05T15:00:00.000' AS DateTime), CAST(N'2024-03-05T17:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (3, N'Phòng 404', CAST(N'2024-03-05T17:30:00.000' AS DateTime), CAST(N'2024-03-05T19:30:00.000' AS DateTime), 2, 1)
INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (4, N'Phòng 321', CAST(N'2024-03-05T15:00:00.000' AS DateTime), CAST(N'2024-03-05T17:00:00.000' AS DateTime), 1, 3)
INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (5, N'Phòng 105', CAST(N'2024-03-05T17:30:00.000' AS DateTime), CAST(N'2024-03-05T19:30:00.000' AS DateTime), 2, 3)
INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (6, N'Phòng 024', CAST(N'2024-03-05T15:00:00.000' AS DateTime), CAST(N'2024-03-05T17:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Schedule] ([Id], [RoomName], [StartTime], [EndTime], [LessonNum], [ClassroomId]) VALUES (7, N'Phòng 147', CAST(N'2024-03-05T17:30:00.000' AS DateTime), CAST(N'2024-03-05T19:30:00.000' AS DateTime), 2, 2)
SET IDENTITY_INSERT [dbo].[Schedule] OFF
GO
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (2, 1)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (2, 3)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (2, 4)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (2, 5)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (2, 6)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (3, 1)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (3, 3)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (3, 6)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (3, 7)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (4, 4)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (4, 5)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (5, 4)
INSERT [dbo].[Timetable] ([StudentId], [ScheduleId]) VALUES (5, 5)
GO

SET IDENTITY_INSERT [dbo].[Chapter] ON
-- Thêm dữ liệu mẫu cho bảng Chapter
INSERT INTO [dbo].[Chapter] ([Id], [Name], [CourseId]) VALUES 
(1, N'Chương 1: Cơ bản', 1),
(2, N'Chương 2: Nâng cao', 1),
(3, N'Chương 1: Nhập môn', 2),
(4, N'Chương 2: Chuyên sâu', 2),
(5, N'Chương 1: Cơ sở', 3),
(6, N'Chương 2: Ứng dụng', 3);
SET IDENTITY_INSERT [dbo].[Chapter] OFF
GO
SET IDENTITY_INSERT [dbo].[Exam] ON
-- Thêm bài kiểm tra
INSERT INTO [dbo].[Exam] ([Id], [Title], [ExamDate], [ExamDuration], [MaxPoint], [Coefficient], [ExamMethod], [ClassroomId]) VALUES
(1, N'Kiểm tra giữa kỳ 1', '2024-04-15', '01:30:00', 10, 2, N'Online', 1),
(2, N'Kiểm tra cuối kỳ 1', '2024-05-30', '02:00:00', 10, 3, N'Offline', 1),
(3, N'Kiểm tra giữa kỳ 2', '2024-04-16', '01:30:00', 10, 2, N'Online', 2);
SET IDENTITY_INSERT [dbo].[Exam] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON
-- Thêm câu hỏi cho các chương
INSERT INTO [dbo].[Question] ([Id], [Contents], [Answer], [Point], [ExamId], [RelatedProgram], [Difficulty], [Type], [ChapterId]) VALUES
(1, N'Câu hỏi 1 Chương 1', N'B', 2, 1, N'Program 1', N'Dễ', N'Multiple Choice', 1),
(2, N'Câu hỏi 2 Chương 2', N'A', 4, 1, N'Program 1', N'Trung bình', N'Multiple Choice', 2),
(3, N'Câu hỏi 3 Chương 1', N'B', 2, 1, N'Program 1', N'Dễ', N'Multiple Choice', 1),
(4, N'Câu hỏi 4 Chương 1', N'B', 2, 1, N'Program 1', N'Dễ', N'Multiple Choice', 1),
(5, N'Câu hỏi 1 Chương 2', N'C', 6, 2, N'Program 2', N'Khó', N'Multiple Choice', 4),
(6, N'Câu hỏi 2 Chương 1', N'A', 4, 2, N'Program 2', N'Trung bình', N'Multiple Choice', 4),
(7, N'Câu hỏi 1 Chương 2', N'A', 4, 3, N'Program 2', N'Trung bình', N'Multiple Choice', 2),
(8, N'Câu hỏi 2 Chương 2', N'D', 4, 3, N'Program 2', N'Trung bình', N'Multiple Choice', 2),
(9, N'Câu hỏi 3 Chương 1', N'B', 2, 3, N'Program 2', N'Dễ', N'Multiple Choice', 1);
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Choice] ON
-- Thêm lựa chọn cho câu hỏi
INSERT INTO [dbo].[Choice] ([Id], [Contents], [Answer], [QuestionId]) VALUES
(1, N'Lựa chọn A', N'A', 1),
(2, N'Lựa chọn B', N'B', 1),
(3, N'Lựa chọn C', N'C', 1),
(4, N'Lựa chọn D', N'D', 1),
(5, N'Lựa chọn A', N'A', 2),
(6, N'Lựa chọn B', N'B', 2),
(7, N'Lựa chọn C', N'C', 2),
(8, N'Lựa chọn D', N'D', 2),
(9, N'Lựa chọn A', N'A', 3),
(10, N'Lựa chọn B', N'B', 3),
(11, N'Lựa chọn C', N'C', 3),
(12, N'Lựa chọn D', N'D', 3),
(13, N'Lựa chọn A', N'A', 4),
(14, N'Lựa chọn B', N'B', 4),
(15, N'Lựa chọn C', N'C', 4),
(16, N'Lựa chọn D', N'D', 4),
(17, N'Lựa chọn A', N'A', 5),
(18, N'Lựa chọn B', N'B', 5),
(19, N'Lựa chọn C', N'C', 5),
(20, N'Lựa chọn D', N'D', 5),
(21, N'Lựa chọn A', N'A', 6),
(22, N'Lựa chọn B', N'B', 6),
(23, N'Lựa chọn C', N'C', 6),
(24, N'Lựa chọn D', N'D', 6),
(25, N'Lựa chọn A', N'A', 7),
(26, N'Lựa chọn B', N'B', 7),
(27, N'Lựa chọn C', N'C', 7),
(28, N'Lựa chọn D', N'D', 7),
(29, N'Lựa chọn A', N'A', 8),
(30, N'Lựa chọn B', N'B', 8),
(31, N'Lựa chọn C', N'C', 8),
(32, N'Lựa chọn D', N'D', 8),
(33, N'Lựa chọn A', N'A', 9),
(34, N'Lựa chọn B', N'B', 9),
(35, N'Lựa chọn C', N'C', 9),
(36, N'Lựa chọn D', N'D', 9);
SET IDENTITY_INSERT [dbo].[Choice] OFF
GO

SET IDENTITY_INSERT [dbo].[Exercise] ON
-- Thêm bài tập
INSERT INTO [dbo].[Exercise] ([Id], [Name], [Description], [MaxPoint], [Coefficient], [EndTime], [ClassroomId]) VALUES
(1, N'Bài tập 1', N'Mô tả bài tập 1', 10, 1, '2024-03-20 23:59:59', 1),
(2, N'Bài tập 2', N'Mô tả bài tập 2', 10, 2, '2024-04-10 23:59:59', 1),
(3, N'Bài tập 3', N'Mô tả bài tập 3', 10, 1, '2024-03-25 23:59:59', 2);
SET IDENTITY_INSERT [dbo].[Exercise] OFF
GO

-- Thêm dữ liệu sinh viên làm bài tập
INSERT INTO [dbo].[StudentExercise] ([StudentId], [ExerciseId], [Point], [CreatedTime], [Contents]) VALUES
(2, 1, 8.5, '2024-03-19 10:00:00', N'Bài làm của sinh viên 1'),
(2, 2, 9.0, '2024-04-09 15:30:00', N'Bài làm của sinh viên 1'),
(2, 3, 9.0, '2024-04-09 15:30:00', N'Bài làm của sinh viên 1'),
(3, 1, 7.5, '2024-03-18 14:20:00', N'Bài làm của sinh viên 2'),
(3, 2, 8.0, '2024-04-08 16:45:00', N'Bài làm của sinh viên 2');
GO

-- Thêm dữ liệu sinh viên làm bài kiểm tra
INSERT INTO [dbo].[StudentExam] ([StudentId], [ExamId], [ChoiceId]) VALUES
(2, 1, 1),
(2, 1, 5),
(2, 2, 18),
(2, 2, 21),
(3, 1, 2),
(3, 2, 5),
(3, 2, 19),
(3, 2, 21),
(4, 3, 25),
(4, 3, 30),
(4, 3, 36);
GO
-- Thêm điểm tổng kết môn cho sinh viên
INSERT INTO [dbo].[StudentClassroom] ([StudentId], [ClassroomId], [Point]) VALUES
(2, 1, 8.5),
(2, 2, 7.5),
(3, 1, 8.0),
(3, 2, 7.0),
(4, 3, 8.2),
(5, 3, 7.8);
GO