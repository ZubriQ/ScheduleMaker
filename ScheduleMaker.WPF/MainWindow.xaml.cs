using ScheduleMaker.OP;
using ScheduleMaker.OP.School;
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
        /// Список расписаний школьных классов.
        /// </summary>
        public List<Schedule> SchedulesList = new List<Schedule>();

        /// <summary>
        /// Список учебных планов.
        /// </summary>
        public List<Syllabus> Syllabuses = new List<Syllabus>();

        /// <summary>
        /// Список всех учителей в школе.
        /// </summary>
        public List<Teacher> Teachers = new List<Teacher>();

        /// <summary>
        /// Список расписаний для каждого школьного класса.
        /// </summary>
        public List<ClassSchedule> ClassSchedulesList = new List<ClassSchedule>();

        /// <summary>
        /// Все предметы в школе.
        /// </summary>
        public Subject[] subjects;

        /// <summary>
        /// Open Shop.
        /// </summary>
        public OpenShop OpenShop;

        public Random rnd = new Random();

        // Параметры Open Shop и Учебного плана
        public int TeachersCount = 2;
        public int SubjectsCount = 2;
        public int SyllabusesCount = 4;

        public MainWindow()
        {
            InitializeComponent();

            // Определение всех видов предметов
            subjects = new Subject[SubjectsCount];
            subjects[0] = new Subject(0, "математика", 11);
            subjects[1] = new Subject(1, "русский язык", 11);

            // Все Учителя в школе
            Teachers.Add(new Teacher(0, subjects[0]));
            Teachers.Add(new Teacher(1, subjects[1]));

            // Вызов Open Shop
            OpenShop = new OpenShop(Teachers);
        }

        /// <summary>
        /// Создание расписания для класса.
        /// </summary>
        /// <param name="schedule">Расписание.</param>
        /// <returns>Расписание.</returns>
        private List<Day> CreateSchedule(Schedule schedule)
        {
            List<Day> Schedule = new List<Day>();
            for (int i = 0; i < 6; i++)
            {
                Lesson[] lessons = new Lesson[8];
                for (int j = 0; j < 8; j++)
                {
                    AddClassSchedules(schedule, lessons, i, j);
                }
                Schedule.Add(new Day(i + 1, lessons));
            }
            return Schedule;
        }

        /// <summary>
        /// Добавить расписания классов.
        /// </summary>
        /// <param name="schedule">Расписание.</param>
        /// <param name="lessons">Уроки.</param>
        /// <param name="i">Итератор 1 (день).</param>
        /// <param name="j">Итератор 2 (номер урока).</param>
        public void AddClassSchedules(Schedule schedule, Lesson[] lessons, int i, int j)
        {
            if (string.IsNullOrEmpty(schedule.Lessons[i, j]))
            {
                lessons[j] = new Lesson($"{j + 1}. ----");
            }
            else
            {
                lessons[j] = new Lesson(schedule.Lessons[i, j]);
            }
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            // Если расписание уже создано, то обнулить текущее
            if (SchedulesItemsControl.ItemsSource != null)
            {
                ClassSchedulesList.Clear();
                Syllabuses.Clear();
                Teachers.Clear();
                SchedulesList.Clear();
                Teachers.Add(new Teacher(0, subjects[0]));
                Teachers.Add(new Teacher(1, subjects[1]));
                OpenShop = new OpenShop(Teachers);
                SchedulesItemsControl.ItemsSource = null;
            }
            byte NumberOfDays = 6;
            // Планы предметов в Учебных планах
            SubjectPlan[] subjects1 = new SubjectPlan[SubjectsCount];
            subjects1[0] = new SubjectPlan(subjects[0], 10);
            subjects1[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects2 = new SubjectPlan[SubjectsCount];
            subjects2[0] = new SubjectPlan(subjects[0], 10);
            subjects2[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects3 = new SubjectPlan[SubjectsCount];
            subjects3[0] = new SubjectPlan(subjects[0], 18);
            subjects3[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects4 = new SubjectPlan[SubjectsCount];
            subjects4[0] = new SubjectPlan(subjects[0], 10);
            subjects4[1] = new SubjectPlan(subjects[1], 18);

            // Учебные планы
            Syllabus syllabus1 = new Syllabus(0, "10А", subjects1);
            Syllabus syllabus2 = new Syllabus(1, "11Б", subjects2);
            Syllabus syllabus3 = new Syllabus(2, "9Г", subjects3);
            Syllabus syllabus4 = new Syllabus(3, "11В", subjects4);
            Syllabuses.Add(syllabus1);
            Syllabuses.Add(syllabus2);
            Syllabuses.Add(syllabus3);
            Syllabuses.Add(syllabus4);

            // Создание расписания для классов
            for (int i = 0; i < SyllabusesCount; i++)
            {
                Schedule schedule = OpenShop.MakeSchedule(Syllabuses[i], NumberOfDays);
                SchedulesList.Add(schedule);
                ClassSchedule classSchedule = new ClassSchedule(schedule.ClassName, CreateSchedule(schedule));
                ClassSchedulesList.Add(classSchedule);
            }

            // Источник
            SchedulesItemsControl.ItemsSource = ClassSchedulesList;
        }

        private void randomScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            // Если расписание уже создано, то обнулить текущее
            if(SchedulesItemsControl.ItemsSource != null)
            {
                ClassSchedulesList.Clear();
                Syllabuses.Clear();
                Teachers.Clear();
                SchedulesList.Clear();
                Teachers.Add(new Teacher(0, subjects[0]));
                Teachers.Add(new Teacher(1, subjects[1]));
                OpenShop = new OpenShop(Teachers);
                SchedulesItemsControl.ItemsSource = null;
            }
            byte NumberOfDays = 6;
            // Планы предметов в Учебных планах
            SubjectPlan[] subjects1 = new SubjectPlan[SubjectsCount];
            subjects1[0] = new SubjectPlan(subjects[0], 10);
            subjects1[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects2 = new SubjectPlan[SubjectsCount];
            subjects2[0] = new SubjectPlan(subjects[0], 10);
            subjects2[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects3 = new SubjectPlan[SubjectsCount];
            subjects3[0] = new SubjectPlan(subjects[0], 18);
            subjects3[1] = new SubjectPlan(subjects[1], 10);
            SubjectPlan[] subjects4 = new SubjectPlan[SubjectsCount];
            subjects4[0] = new SubjectPlan(subjects[0], 10);
            subjects4[1] = new SubjectPlan(subjects[1], 18);

            // Учебные планы
            Syllabus syllabus1 = new Syllabus(0, "10А", subjects1);
            Syllabus syllabus2 = new Syllabus(1, "11Б", subjects2);
            Syllabus syllabus3 = new Syllabus(2, "9Г", subjects3);
            Syllabus syllabus4 = new Syllabus(3, "11В", subjects4);
            var randomizedLessons1 = syllabus1.Lessons.OrderBy(x => rnd.Next()).ToArray();
            var randomizedLessons2 = syllabus1.Lessons.OrderBy(x => rnd.Next()).ToArray();
            var randomizedLessons3 = syllabus1.Lessons.OrderBy(x => rnd.Next()).ToArray();
            var randomizedLessons4 = syllabus1.Lessons.OrderBy(x => rnd.Next()).ToArray();
            syllabus1.SetLessons(randomizedLessons1);
            syllabus1.SetLessons(randomizedLessons2);
            syllabus1.SetLessons(randomizedLessons3);
            syllabus1.SetLessons(randomizedLessons4);

            Syllabuses.Add(syllabus1);
            Syllabuses.Add(syllabus2);
            Syllabuses.Add(syllabus3);
            Syllabuses.Add(syllabus4);

            // Создание расписания для классов
            for (int i = 0; i < SyllabusesCount; i++)
            {
                Schedule schedule = OpenShop.MakeSchedule(Syllabuses[i], NumberOfDays);
                SchedulesList.Add(schedule);
                ClassSchedule classSchedule = new ClassSchedule(schedule.ClassName, CreateSchedule(schedule));
                ClassSchedulesList.Add(classSchedule);
            }

            // Источник
            SchedulesItemsControl.ItemsSource = ClassSchedulesList;
        }

        // учителя
        private void showTeachersButton_Click(object sender, RoutedEventArgs e)
        {
            WindowTeachers window = new WindowTeachers(OpenShop.Machines);
            window.Show();
        }
    }
}
