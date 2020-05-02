USE [ScheduleMaker]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classrooms](
	[classroom_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [text] NULL,
 CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED 
(
	[classroom_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassroomsSubjects]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassroomsSubjects](
	[classroom_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
 CONSTRAINT [PK_DisciplineClassroom] PRIMARY KEY CLUSTERED 
(
	[classroom_id] ASC,
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CreatorsOfSyllabi]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreatorsOfSyllabi](
	[syllabus_id] [int] IDENTITY(1,1) NOT NULL,
	[creators] [text] NULL,
 CONSTRAINT [PK_CreatorsOfSyllabi] PRIMARY KEY CLUSTERED 
(
	[syllabus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[syllabus_id] [int] NOT NULL,
	[quarter] [int] NOT NULL,
	[day_of_week] [int] NOT NULL,
	[number_of_lesson] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[classroom_id] [int] NOT NULL,
	[teacher_id] [nvarchar](200) NOT NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[syllabus_id] ASC,
	[quarter] ASC,
	[day_of_week] ASC,
	[number_of_lesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[teacher_id] [nvarchar](200) NOT NULL,
	[discipline_id] [int] NOT NULL,
 CONSTRAINT [PK_TeacherDiscipline] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC,
	[discipline_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudyLoad]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudyLoad](
	[subject_id] [int] NOT NULL,
	[syllabus_id] [int] NOT NULL,
	[quarter] [int] NOT NULL,
	[lessons_count] [int] NOT NULL,
 CONSTRAINT [PK_SyllabusDiscipline] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC,
	[syllabus_id] ASC,
	[quarter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[subject_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[difficulty] [int] NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Syllabi]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Syllabi](
	[syllabus_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[year] [int] NOT NULL,
	[date_of_creation] [date] NULL,
 CONSTRAINT [PK_Syllabus] PRIMARY KEY CLUSTERED 
(
	[syllabus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 01.05.2020 18:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [nvarchar](200) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[second_name] [nvarchar](50) NOT NULL,
	[middle_name] [nvarchar](50) NULL,
	[is_part_time] [bit] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClassroomsSubjects]  WITH CHECK ADD  CONSTRAINT [FK_DisciplineClassroom_Classroom] FOREIGN KEY([classroom_id])
REFERENCES [dbo].[Classrooms] ([classroom_id])
GO
ALTER TABLE [dbo].[ClassroomsSubjects] CHECK CONSTRAINT [FK_DisciplineClassroom_Classroom]
GO
ALTER TABLE [dbo].[ClassroomsSubjects]  WITH CHECK ADD  CONSTRAINT [FK_DisciplineClassroom_Discipline] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[ClassroomsSubjects] CHECK CONSTRAINT [FK_DisciplineClassroom_Discipline]
GO
ALTER TABLE [dbo].[CreatorsOfSyllabi]  WITH CHECK ADD  CONSTRAINT [FK_Creators_Syllabus] FOREIGN KEY([syllabus_id])
REFERENCES [dbo].[Syllabi] ([syllabus_id])
GO
ALTER TABLE [dbo].[CreatorsOfSyllabi] CHECK CONSTRAINT [FK_Creators_Syllabus]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lesson_Class]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Classroom] FOREIGN KEY([classroom_id])
REFERENCES [dbo].[Classrooms] ([classroom_id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lesson_Classroom]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Discipline] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lesson_Discipline]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_Lesson_Teacher]
GO
ALTER TABLE [dbo].[Specialization]  WITH CHECK ADD  CONSTRAINT [FK_TeacherDiscipline_Discipline] FOREIGN KEY([discipline_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[Specialization] CHECK CONSTRAINT [FK_TeacherDiscipline_Discipline]
GO
ALTER TABLE [dbo].[Specialization]  WITH CHECK ADD  CONSTRAINT [FK_TeacherDiscipline_Teacher] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[Specialization] CHECK CONSTRAINT [FK_TeacherDiscipline_Teacher]
GO
ALTER TABLE [dbo].[StudyLoad]  WITH CHECK ADD  CONSTRAINT [FK_SyllabusDiscipline_Discipline] FOREIGN KEY([subject_id])
REFERENCES [dbo].[Subjects] ([subject_id])
GO
ALTER TABLE [dbo].[StudyLoad] CHECK CONSTRAINT [FK_SyllabusDiscipline_Discipline]
GO
ALTER TABLE [dbo].[StudyLoad]  WITH CHECK ADD  CONSTRAINT [FK_SyllabusDiscipline_Syllabus] FOREIGN KEY([syllabus_id])
REFERENCES [dbo].[Syllabi] ([syllabus_id])
GO
ALTER TABLE [dbo].[StudyLoad] CHECK CONSTRAINT [FK_SyllabusDiscipline_Syllabus]
GO
