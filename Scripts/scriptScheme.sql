USE [master]
GO
/****** Object:  Database [ScheduleMaker]    Script Date: 28.05.2020 22:14:41 ******/
CREATE DATABASE [ScheduleMaker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ScheduleMaker', FILENAME = N'E:\Programs\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ScheduleMaker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ScheduleMaker_log', FILENAME = N'E:\Programs\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ScheduleMaker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ScheduleMaker] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ScheduleMaker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ScheduleMaker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ScheduleMaker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ScheduleMaker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ScheduleMaker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ScheduleMaker] SET ARITHABORT OFF 
GO
ALTER DATABASE [ScheduleMaker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ScheduleMaker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ScheduleMaker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ScheduleMaker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ScheduleMaker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ScheduleMaker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ScheduleMaker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ScheduleMaker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ScheduleMaker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ScheduleMaker] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ScheduleMaker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ScheduleMaker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ScheduleMaker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ScheduleMaker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ScheduleMaker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ScheduleMaker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ScheduleMaker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ScheduleMaker] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ScheduleMaker] SET  MULTI_USER 
GO
ALTER DATABASE [ScheduleMaker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ScheduleMaker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ScheduleMaker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ScheduleMaker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ScheduleMaker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ScheduleMaker] SET QUERY_STORE = OFF
GO
USE [ScheduleMaker]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[syllabus_id] [int] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 28.05.2020 22:14:41 ******/
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
/****** Object:  Table [dbo].[ClassroomsSubjects]    Script Date: 28.05.2020 22:14:41 ******/
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
/****** Object:  Table [dbo].[Lessons]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[syllabus_id] [int] NULL,
	[quarter] [int] NOT NULL,
	[day_of_week] [int] NOT NULL,
	[number_of_lesson] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[classroom_id] [int] NULL,
	[teacher_id] [int] NULL,
	[class_id] [int] NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[quarter] ASC,
	[day_of_week] ASC,
	[number_of_lesson] ASC,
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Load]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Load](
	[class_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
 CONSTRAINT [PK_Load] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC,
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[teacher_id] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
 CONSTRAINT [PK_TeacherDiscipline] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC,
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudyLoad]    Script Date: 28.05.2020 22:14:41 ******/
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
/****** Object:  Table [dbo].[Subjects]    Script Date: 28.05.2020 22:14:41 ******/
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
/****** Object:  Table [dbo].[Syllabi]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Syllabi](
	[syllabus_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NOT NULL,
	[year] [nvarchar](4) NOT NULL,
	[date_of_creation] [date] NULL,
	[creators] [nvarchar](50) NULL,
 CONSTRAINT [PK_Syllabus] PRIMARY KEY CLUSTERED 
(
	[syllabus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 28.05.2020 22:14:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
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
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Syllabi] FOREIGN KEY([syllabus_id])
REFERENCES [dbo].[Syllabi] ([syllabus_id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Syllabi]
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
ALTER TABLE [dbo].[Load]  WITH CHECK ADD  CONSTRAINT [FK_Load_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[Load] CHECK CONSTRAINT [FK_Load_Classes]
GO
ALTER TABLE [dbo].[Load]  WITH CHECK ADD  CONSTRAINT [FK_Load_Teachers] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[Load] CHECK CONSTRAINT [FK_Load_Teachers]
GO
ALTER TABLE [dbo].[Specialization]  WITH CHECK ADD  CONSTRAINT [FK_TeacherDiscipline_Discipline] FOREIGN KEY([subject_id])
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
USE [master]
GO
ALTER DATABASE [ScheduleMaker] SET  READ_WRITE 
GO
