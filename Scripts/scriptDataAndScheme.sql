USE [master]
GO
/****** Object:  Database [ScheduleMaker]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Classes]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Classrooms]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[ClassroomsSubjects]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[CreatorsOfSyllabi]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Lessons]    Script Date: 04.05.2020 0:10:46 ******/
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
	[teacher_id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Load]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Specialization]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[StudyLoad]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Subjects]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Syllabi]    Script Date: 04.05.2020 0:10:46 ******/
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 04.05.2020 0:10:46 ******/
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
