USE [master]
GO
/****** Object:  Database [ScheduleMaker]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[ClassesTeachers]    Script Date: 27.06.2020 17:01:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassesTeachers](
	[class_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL,
 CONSTRAINT [PK_Load] PRIMARY KEY CLUSTERED 
(
	[class_id] ASC,
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classrooms]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[ClassroomsSubjects]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Lessons]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Specialization]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[StudyLoad]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Subjects]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Syllabi]    Script Date: 27.06.2020 17:01:53 ******/
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 27.06.2020 17:01:53 ******/
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
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (29, N'9а', 2)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (30, N'9б', 2)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (31, N'9в', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (32, N'9г', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (33, N'9д', 2)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (34, N'9е', NULL)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (35, N'9в', 2)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (36, N'9з', 2)
INSERT [dbo].[Classes] ([class_id], [name], [syllabus_id]) VALUES (37, N'9и', 2)
SET IDENTITY_INSERT [dbo].[Classes] OFF
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 7)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 15)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 45)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 46)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 47)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 48)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 49)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 50)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 51)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (29, 53)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 7)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 15)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 45)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 46)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 47)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 48)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 49)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 50)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 51)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (30, 53)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 15)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 44)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 45)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 46)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 47)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 48)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 49)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 50)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 51)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (33, 55)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 35)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 45)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 46)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 47)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 48)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 49)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 50)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 51)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 52)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (35, 54)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 44)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 55)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 56)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 57)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 58)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 59)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 60)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 61)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 62)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (36, 63)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 44)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 55)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 56)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 57)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 58)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 59)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 60)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 61)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 62)
INSERT [dbo].[ClassesTeachers] ([class_id], [teacher_id]) VALUES (37, 63)
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
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 9, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 11, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 4, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 8, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 2, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 0, 19, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 11, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 7, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 19, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 9, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 12, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 6, 5, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 2, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 12, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 8, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 11, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 5, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 12, 18, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 18, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 6, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 23, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 3, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 2, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 18, 7, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 5, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 8, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 19, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 2, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 9, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 24, 23, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 30, 19, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 0, 36, 18, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 4, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 19, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 2, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 9, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 8, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 1, 23, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 19, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 3, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 6, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 5, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 8, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 7, 9, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 2, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 3, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 12, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 7, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 9, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 13, 18, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 3, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 19, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 12, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 8, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 11, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 19, 9, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 25, 9, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 25, 2, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 25, 18, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 25, 7, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 25, 4, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 31, 18, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 1, 37, 18, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 19, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 4, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 11, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 7, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 2, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 2, 3, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 23, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 4, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 18, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 2, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 3, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 8, 8, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 12, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 9, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 2, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 19, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 23, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 14, 7, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 2, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 5, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 18, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 6, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 7, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 20, 3, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 26, 18, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 26, 8, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 26, 2, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 32, 18, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 2, 38, 19, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 8, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 9, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 2, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 19, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 11, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 3, 6, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 8, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 23, NULL, NULL, 30)
GO
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 9, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 2, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 19, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 9, 12, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 2, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 23, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 7, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 19, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 3, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 15, 11, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 12, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 18, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 11, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 4, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 23, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 21, 2, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 27, 4, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 27, 2, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 27, 19, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 27, 9, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 33, 18, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 3, 39, 18, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 18, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 2, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 7, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 3, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 4, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 4, 12, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 18, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 7, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 23, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 9, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 4, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 10, 2, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 6, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 9, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 3, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 12, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 18, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 16, 2, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 23, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 18, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 5, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 12, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 2, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 22, 4, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 28, 3, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 28, 9, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 28, 2, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 28, 18, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 34, 18, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 4, 40, 18, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 9, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 12, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 8, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 23, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 19, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 5, 11, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 7, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 11, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 9, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 4, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 6, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 11, 19, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 19, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 2, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 3, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 11, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 12, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 17, 8, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 11, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 2, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 4, NULL, NULL, 33)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 23, NULL, NULL, 35)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 9, NULL, NULL, 36)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 23, 18, NULL, NULL, 37)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 29, 7, NULL, NULL, 29)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 29, 18, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 35, 18, NULL, NULL, 30)
INSERT [dbo].[Lessons] ([syllabus_id], [quarter], [day_of_week], [number_of_lesson], [subject_id], [classroom_id], [teacher_id], [class_id]) VALUES (NULL, 1, 5, 41, 19, NULL, NULL, 30)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (7, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (7, 9)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (15, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (15, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (35, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (35, 9)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (44, 2)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (44, 9)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (45, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (46, 4)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (47, 5)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (48, 6)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (49, 11)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (50, 12)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (51, 23)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (52, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (52, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (53, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (53, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (54, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (54, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (55, 18)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (55, 19)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (56, 7)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (56, 8)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (57, 3)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (58, 4)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (59, 5)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (60, 23)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (61, 6)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (62, 12)
INSERT [dbo].[Specialization] ([teacher_id], [subject_id]) VALUES (63, 11)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (2, 2, 1, 4)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (3, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (4, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (5, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (6, 2, 1, 1)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (7, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (8, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (9, 2, 1, 3)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (11, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (12, 2, 1, 2)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (18, 2, 1, 4)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (19, 2, 1, 3)
INSERT [dbo].[StudyLoad] ([subject_id], [syllabus_id], [quarter], [lessons_count]) VALUES (23, 2, 1, 2)
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

INSERT [dbo].[Syllabi] ([syllabus_id], [description], [year], [date_of_creation], [creators]) VALUES (2, N'Стандартный план', N'2020', CAST(N'2020-06-13' AS Date), N'Мария А.П.                                 ')
SET IDENTITY_INSERT [dbo].[Syllabi] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (7, N'рус1', N'рус1', N'рус1', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (15, N'история1', N'история1', N'история1', 0)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (35, N'рус2', N'рус2', N'рус2', 1)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (44, N'рус3', N'рус3', N'рус3', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (45, N'ин.яз', N'ин.яз', N'ин.яз', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (46, N'труд', N'труд', N'труд', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (47, N'физ-ра', N'физ-ра', N'физ-ра', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (48, N'изо', N'изо', N'изо', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (49, N'географ', N'географ', N'географ', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (50, N'биолог', N'биолог', N'биолог', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (51, N'музыка', N'музыка', N'музыка', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (52, N'история2', N'история2', N'история2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (53, N'алгебра1', N'алгебра1', N'алгебра1', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (54, N'алгебра2', N'алгебра2', N'алгебра2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (55, N'алгебра3', N'алгебра3', N'алгебра3', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (56, N'история3', N'история3', N'история3', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (57, N'ин.яз2', N'ин.яз2', N'ин.яз2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (58, N'труд2', N'труд2', N'труд2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (59, N'физ-ра2', N'физ-ра2', N'физ-ра2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (60, N'музыка2', N'музыка2', N'музыка2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (61, N'изо2', N'изо2', N'изо2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (62, N'биолог2', N'биолог2', N'биолог2', NULL)
INSERT [dbo].[Teachers] ([teacher_id], [first_name], [second_name], [middle_name], [is_part_time]) VALUES (63, N'географ2', N'географ2', N'географ2', NULL)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Syllabi] FOREIGN KEY([syllabus_id])
REFERENCES [dbo].[Syllabi] ([syllabus_id])
GO
ALTER TABLE [dbo].[Classes] CHECK CONSTRAINT [FK_Classes_Syllabi]
GO
ALTER TABLE [dbo].[ClassesTeachers]  WITH CHECK ADD  CONSTRAINT [FK_Load_Classes] FOREIGN KEY([class_id])
REFERENCES [dbo].[Classes] ([class_id])
GO
ALTER TABLE [dbo].[ClassesTeachers] CHECK CONSTRAINT [FK_Load_Classes]
GO
ALTER TABLE [dbo].[ClassesTeachers]  WITH CHECK ADD  CONSTRAINT [FK_Load_Teachers] FOREIGN KEY([teacher_id])
REFERENCES [dbo].[Teachers] ([teacher_id])
GO
ALTER TABLE [dbo].[ClassesTeachers] CHECK CONSTRAINT [FK_Load_Teachers]
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
