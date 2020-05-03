using ScheduleMaker.OP;
using ScheduleMaker.OP.PSO;
using ScheduleMaker.OP.School;
using ScheduleMaker.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleMaker.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Список расписаний для каждого школьного класса.
        /// </summary>
        public List<ClassSchedule> ClassSchedulesList = new List<ClassSchedule>();

        // Тест
        List<Teacher> teachers1 = new List<Teacher>();

        public MainWindow()
        {
            InitializeComponent();
            // Инициализация начальных данных
            InitializeSchool();
        }

        #region Initializations
        private void InitializeSchool()
        {
            InitializeTypesOfLessons();
            InitializeTeachers();
            InitializeClassrooms();
            teachers1.Add(App.Teachers[0]);
            teachers1.Add(App.Teachers[1]);
        }

        /// <summary>
        /// Загрузка предметов.
        /// </summary>
        private void InitializeTypesOfLessons()
        {
            App.Subjects.Add(new Subject(0, "математика", 11));
            App.Subjects.Add(new Subject(1, "русский язык", 11));
            App.Subjects.Add(new Subject(2, "иностранный язык", 10));
            App.Subjects.Add(new Subject(3, "физика", 9));
            App.Subjects.Add(new Subject(4, "химия", 9));
            App.Subjects.Add(new Subject(5, "информатика", 9));
            App.Subjects.Add(new Subject(6, "история", 8));
            App.Subjects.Add(new Subject(7, "обществознание", 8));
            App.Subjects.Add(new Subject(8, "литература", 7));
            App.Subjects.Add(new Subject(9, "биология", 6));
            App.Subjects.Add(new Subject(10, "география", 6));
            App.Subjects.Add(new Subject(11, "экономика", 6));
            App.Subjects.Add(new Subject(12, "астрономия", 6));
            App.Subjects.Add(new Subject(13, "физкультура", 5));
            App.Subjects.Add(new Subject(14, "ОБЖ", 5));
            App.Subjects.Add(new Subject(15, "технология", 4));
            App.Subjects.Add(new Subject(16, "черчение", 3));
            App.Subjects.Add(new Subject(17, "ИЗО", 2));
            App.Subjects.Add(new Subject(18, "МХК", 2));
            App.Subjects.Add(new Subject(19, "музыка", 1));
        }

        /// <summary>
        /// Загрузка работающих учителей
        /// </summary>
        private void InitializeTeachers()
        {
            Subject[] subjects1 = new Subject[2];
            subjects1[0] = App.Subjects[0];
            subjects1[1] = App.Subjects[5];
            Subject[] subjects2 = new Subject[1];
            subjects2[0] = App.Subjects[1];
            App.Teachers.Add(new Teacher(0, subjects1));
            App.Teachers.Add(new Teacher(1, subjects2));
        }

        private void InitializeClassrooms()
        {
            Subject[] subjects1 = new Subject[2];
            subjects1[0] = App.Subjects[0];
            subjects1[1] = App.Subjects[5];
            Subject[] subjects2 = new Subject[1];
            subjects2[0] = App.Subjects[1];
            App.Classrooms.Add(new Classroom(0, "математика и информатика", subjects1));
            App.Classrooms.Add(new Classroom(1, "русский язык", subjects2));
        }
        #endregion

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            // Если расписание уже создано, то обнулить текущее
            if (SchedulesItemsControl.ItemsSource != null)
            {
                ClassSchedulesList.Clear();
                App.Syllabi = new List<Syllabus>();
                App.Teachers.Clear();
                Subject[] subject1 = new Subject[2];
                subject1[0] = App.Subjects[0];
                subject1[1] = App.Subjects[5];
                Subject[] subject2 = new Subject[2];
                subject2[0] = App.Subjects[1];
                App.Teachers.Add(new Teacher(0, subject1));
                App.Teachers.Add(new Teacher(1, subject2));
                SchedulesItemsControl.ItemsSource = null;
                App.Classes.Clear();
            }
            // Планы предметов в Учебных планах
            List<SubjectPlan> subjects1 = new List<SubjectPlan>();
            subjects1.Add(new SubjectPlan(App.Subjects[0], 5));
            subjects1.Add(new SubjectPlan(App.Subjects[1], 10));
            subjects1.Add(new SubjectPlan(App.Subjects[5], 6));
            List<SubjectPlan> subjects2 = new List<SubjectPlan>();
            subjects2.Add(new SubjectPlan(App.Subjects[0], 5));
            subjects2.Add(new SubjectPlan(App.Subjects[1], 10));
            subjects2.Add(new SubjectPlan(App.Subjects[5], 6));
            List<SubjectPlan> subjects3 = new List<SubjectPlan>();
            subjects3.Add(new SubjectPlan(App.Subjects[0], 5));
            subjects3.Add(new SubjectPlan(App.Subjects[1], 10));
            subjects3.Add(new SubjectPlan(App.Subjects[5], 6));
            List<SubjectPlan> subjects4 = new List<SubjectPlan>();
            subjects4.Add(new SubjectPlan(App.Subjects[0], 10));
            subjects4.Add(new SubjectPlan(App.Subjects[1], 14));
            subjects4.Add(new SubjectPlan(App.Subjects[5], 5));
            // Классы
            App.Classes.Add(new Class(0, "10А"));
            App.Classes.Add(new Class(1, "11Б"));
            App.Classes.Add(new Class(2, "11В"));
            App.Classes.Add(new Class(3, "9Г"));
            // Учебные планы
            Syllabus syllabus1 = new Syllabus(0, App.Classes[0], subjects1, teachers1);
            Syllabus syllabus2 = new Syllabus(1, App.Classes[1], subjects2, teachers1);
            Syllabus syllabus3 = new Syllabus(2, App.Classes[2], subjects3, teachers1);
            Syllabus syllabus4 = new Syllabus(3, App.Classes[3], subjects4, teachers1);
            App.Syllabi.Add(syllabus1);
            App.Syllabi.Add(syllabus2);
            App.Syllabi.Add(syllabus3);
            App.Syllabi.Add(syllabus4);
            // Присвоение фитнесс функции
            App.OpenShopPSO.SetData(App.Teachers, App.Syllabi, App.Classrooms);
            App.OpenShopPSO.SetFunction(App.OpenShopPSO);
            // Создать расписания
            ScheduleData scheduleData = new ScheduleData(App.Teachers, App.Syllabi, App.Classrooms);
            App.OpenShopPSO.ScheduleConstructor.MakeSchedules(scheduleData, App.OpenShopPSO.FindBestPriorities());
            // Проверка пробелов между уроками в расписании 
            int k = App.OpenShopPSO.ScheduleEvaluator.FindGapsInAllSchedules();
            int t = 0;

            // Создание расписания для классов
            for (int i = 0; i < App.Syllabi.Count; i++)
            {
                Schedule schedule = App.OpenShopPSO.ScheduleConstructor.SchedulesList[i];
                //SchedulesList.Add(schedule);
                ClassSchedule classSchedule = new ClassSchedule(schedule.Class.Name, DecodeClassSchedule(schedule));
                ClassSchedulesList.Add(classSchedule);
            }

            // Источник
            SchedulesItemsControl.ItemsSource = ClassSchedulesList;
        }

        #region Decode schedules
        /// <summary>
        /// Создание расписания для класса.
        /// </summary>
        /// <param name="schedule">Расписание.</param>
        /// <returns>Расписание.</returns>
        private List<Day> DecodeClassSchedule(Schedule schedule)
        {
            // Инициализация 6 недель
            List<Day> newSchedule = new List<Day>();
            for (int i = 0; i < 6; i++)
            {
                Lesson[] lessons = new Lesson[10];
                newSchedule.Add(new Day(i + 1, lessons));
            }
            // Добавление уроков в расписание
            int indexOfLesson = 0;
            while (indexOfLesson < 60)
            {
                AddLesson(schedule, newSchedule, ref indexOfLesson);
            }
            return newSchedule;
        }

        /// <summary>
        /// Заполнение матрицы расписания школьного класса.
        /// </summary>
        /// <param name="oldSchedule">Поступившее расписание.</param>
        /// <param name="newSchedule">Новое расписание для WPF.</param>
        /// <param name="indexOfLesson">Индекс текущего урока.</param>
        public void AddLesson(Schedule oldSchedule, List<Day> newSchedule, ref int indexOfLesson)
        {
            // Номер урока
            for (int column = 0; column < 10; column++)
            {
                // день
                for (int row = 0; row < 6; row++)
                {
                    if (oldSchedule.Lessons[indexOfLesson] != null)
                    {
                        newSchedule[row].Lessons[column] = new Lesson($"{column + 1}. " +
                            $"{oldSchedule.Lessons[indexOfLesson].Subject.Name}");
                    }
                    else
                    {
                        newSchedule[row].Lessons[column] = new Lesson($"{column + 1}. ----");
                    }
                    indexOfLesson++;
                }
            }
        }
        #endregion

        // Учителя
        private void teachersSchedulesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (App.OpenShopPSO.ScheduleData != null)
            {
                WindowTeachersSchedules window = new WindowTeachersSchedules();
                window.Show();
            }
        }

        private void teachersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowTeachers window = new WindowTeachers();
            window.Show();
        }

        private void classesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowClasses window = new WindowClasses();
            window.Show();
        }

        private void subjectsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSubjects window = new WindowSubjects();
            window.Show();
        }

        private void studyLoadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowStudyLoad window = new WindowStudyLoad();
            window.Show();
        }

        private void syllabiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSyllabi window = new WindowSyllabi();
            window.Show();
        }
        private void syllabiSetLoadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSyllabiSetLoad window = new WindowSyllabiSetLoad();
            window.Show();
        }
    }
}
