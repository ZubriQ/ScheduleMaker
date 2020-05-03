USE [ScheduleMaker]
GO
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (1, N'Математика', 11)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (2, N'Русский язык', 11)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (3, N'Иностранный язык', 10)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (4, N'Труд', 4)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (5, N'Физкультура', 5)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (6, N'ИЗО', 2)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (7, N'История', 8)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (8, N'Обществознание', 8)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (9, N'Литература', 6)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (10, N'ОБЖ', 3)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (11, N'География', 6)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (12, N'Биология', 10)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (13, N'Информатика', 7)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (14, N'Физика', 9)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (15, N'Химия', 9)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (16, N'Философия', 9)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (17, N'Черчение', 9)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (18, N'Алгебра', 11)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (19, N'Геометрия', 11)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (20, N'Чтение', 5)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (21, N'Чистописание', 5)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (22, N'Окружающий мир', 6)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (23, N'Музыка', 1)
INSERT [dbo].[Subjects] ([subject_id], [name], [difficulty]) VALUES (25, N'Родной язык', 7)
SET IDENTITY_INSERT [dbo].[Subjects] OFF
SET IDENTITY_INSERT [dbo].[Syllabi] ON 

INSERT [dbo].[Syllabi] ([syllabus_id], [description], [year], [date_of_creation], [creators]) VALUES (2, N'Стандартный план', N'2020', CAST(N'2020-05-03' AS Date), N'Директор школы                                    ')
INSERT [dbo].[Syllabi] ([syllabus_id], [description], [year], [date_of_creation], [creators]) VALUES (5, N'11 Классы', N'2019', CAST(N'2020-05-03' AS Date), N'Мария')
SET IDENTITY_INSERT [dbo].[Syllabi] OFF
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (1, 2, 1, 8)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (2, 2, 1, 6)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (2, 5, 1, 7)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (3, 2, 1, 3)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (3, 5, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (4, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (5, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (5, 5, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (6, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (6, 5, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (7, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (7, 5, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (8, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (8, 5, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (9, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (9, 5, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (10, 5, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (11, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (11, 5, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (12, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (12, 5, 1, 3)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (13, 5, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (14, 5, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (18, 5, 1, 5)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (19, 5, 1, 4)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (23, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (23, 5, 1, 1)
SET IDENTITY_INSERT [dbo].[Classrooms] ON 

INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (1, N'101', N'Стадион Физкультуры')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (2, N'102', N'Бассейн Физкультуры')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (3, N'103', N'Информатика')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (4, N'104', N'Информатика')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (5, N'105', N'Труд и ОБЖ')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (6, N'106', N'Труд и ОБЖ')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (7, N'107', N'Алгебра, Геометрия, Черчение')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (8, N'108', N'Алгебра, Геометрия, Черчение')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (9, N'109', N'Алгебра, Геометрия, Черчение')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (10, N'110', N'Алгебра, Геометрия, Черчение')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (11, N'201', N'Биология')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (12, N'202', N'Биология')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (13, N'203', N'Химия')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (14, N'204', N'Химия')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (15, N'205', N'География')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (16, N'206', N'География')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (17, N'207', N'Физика')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (18, N'208', N'Физика')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (19, N'209', N'Музыка')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (20, N'210', N'Музыка')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (21, N'301', N'История, Обществознание')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (22, N'302', N'История, Обществознание')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (23, N'303', N'Русский язык')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (24, N'304', N'Русский язык')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (25, N'305', N'Иностранный язык')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (26, N'306', N'Иностранный язык')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (27, N'307', N'ИЗО')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (28, N'308', N'ИЗО')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (29, N'309', N'Литература')
INSERT [dbo].[Classrooms] ([classroom_id], [name], [description]) VALUES (30, N'310', N'Литература')
SET IDENTITY_INSERT [dbo].[Classrooms] OFF
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (1, 5)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (2, 5)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (3, 13)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (4, 13)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (5, 4)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (5, 10)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (6, 4)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (6, 10)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (7, 17)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (7, 18)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (7, 19)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (8, 17)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (8, 18)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (8, 19)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (9, 17)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (9, 18)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (9, 19)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (10, 17)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (10, 18)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (10, 19)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (11, 12)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (12, 12)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (13, 15)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (14, 15)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (15, 11)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (16, 11)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (17, 14)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (18, 14)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (19, 23)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (20, 23)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (21, 7)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (21, 8)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (22, 7)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (22, 8)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (23, 2)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (24, 2)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (25, 3)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (26, 3)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (27, 6)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (28, 6)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (29, 9)
INSERT [dbo].[ClassroomsSubjects] ([classroom_id], [subject_id]) VALUES (30, 9)
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (1, N'Харитон', N'Егоров', N'Эдуардович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (3, N'Зиновий', N'Алексеев', N'Петрович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (4, N'Макар', N'Андрухович', N'Виталиевич', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (5, N'Йонас', N'Большаков', N'Максимович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (6, N'Остап', N'Сердюк', N'Петрович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (7, N'Чарльз', N'Шуфрич', N'Дмитриевич', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (8, N'Тарас', N'Галкин', N'Артёмович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (10, N'Чеслав', N'Журавлёв', N'Леонидович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (12, N'Таисия', N'Козлова', N'Брониславовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (13, N'Дарья', N'Родионова', N'Викторовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (14, N'Лилия', N'Григорьева', N'Платоновна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (15, N'Елизавета', N'Чухрай', N'Ярославовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (16, N'Ядвига', N'Карпова', N'Платоновна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (17, N'Ульяна', N'Рымар', N'Брониславовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (18, N'Жозефина', N'Зварыч', N'Станиславовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (19, N'Чеслава', N'Пилипейко', N'Леонидовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (20, N'Жасмин', N'Самсонова', N'Евгеньевна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (21, N'Ждан', N'Трофимов', N'Сергеевич', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (22, N'Максим', N'Максим', N'Григорьевич', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (23, N'Жерар', N'Гущин', N'Борисович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (24, N'Цезарь', N'Недбайло', N'Дмитриевич', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (25, N'Эрик', N'Капустин', N'Максимович', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (26, N'Шанетта', N'Романова', N'Ивановна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (27, N'Цезария', N'Петрик', N'Григорьевна', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (29, N'Валерия', N'Исакова', N'Васильевна', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (30, N'Ульяна', N'Сусаренко', N'Платоновна', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (32, N'Олег', N'Дорофеев', N'Вадимович', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (33, N'Гарри', N'Кудрявцев', N'Сергеевич', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (35, N'Марк', N'Чухрай', N'Юхимович', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (36, N'Валентина', N'Городецка', N'Платоновна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (37, N'Нелли', N'Пархоменко', N'Романовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (38, N'Зинаида', N'Князева', N'Даниловна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (39, N'Ксения', N'Сысоева', N'Вадимовна', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (40, N'123', N'123', N'123123', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (41, N'Ofofo', N'Said', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (1, 5)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (3, 5)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (4, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (4, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (5, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (5, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (6, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (6, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (7, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (7, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (7, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (8, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (8, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (8, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (10, 23)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (12, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (13, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (14, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (14, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (15, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (15, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (16, 14)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (17, 14)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (18, 12)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (18, 22)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (19, 12)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (19, 22)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (20, 4)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (20, 10)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (21, 4)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (21, 10)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (22, 1)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (22, 13)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (22, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (22, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (23, 11)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (24, 11)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (25, 16)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (26, 6)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (27, 1)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (29, 23)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (30, 17)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (30, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (30, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (32, 17)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (32, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (32, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (33, 17)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (33, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (33, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (35, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (35, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (35, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (36, 23)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (37, 1)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (37, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (37, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (37, 22)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (37, 25)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (38, 1)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (38, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (38, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (38, 22)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (38, 25)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (39, 1)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (39, 20)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (39, 21)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (39, 22)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (39, 25)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 5)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 9)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 10)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 11)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (40, 12)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (41, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (41, 9)
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (1, N'1а', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (2, N'1б', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (3, N'1в', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (4, N'5а', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (5, N'55b', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (6, N'5в', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (7, N'5г', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (8, N'5д', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (9, N'10а', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (10, N'10б', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (11, N'10в', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (13, N'11д', 5)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (14, N'11е', 5)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (15, N'11ж', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (17, N'2а', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (18, N'2б', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (19, N'2в', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (20, N'2г', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (21, N'2д', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (22, N'5б', NULL)
SET IDENTITY_INSERT [dbo].[Classes] OFF
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 1)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 3)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 4)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 7)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 8)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 10)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 12)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 14)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 15)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 16)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 18)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 19)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 21)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 22)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 25)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 26)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 27)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 29)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 30)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 32)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 33)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 35)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 36)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 37)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 38)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 39)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 40)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (13, 41)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 4)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 18)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 22)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 24)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 32)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 38)
INSERT [dbo].[Load] ([class_id], [teacher_id]) VALUES (14, 39)
