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
        public Syllabus[] Syllabuses;

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
        public int gaps = 0;

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

            // Кол-во Учебных планов
            Syllabuses = new Syllabus[SyllabusesCount];

            // Вызов Open Shop
            OpenShop = new OpenShop(Teachers);
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            // Если расписание уже создано, то обнулить текущее
            if (SchedulesItemsControl.ItemsSource != null)
            {
                ClassSchedulesList.Clear();
                Syllabuses = new Syllabus[SyllabusesCount];
                Teachers.Clear();
                SchedulesList.Clear();
                Teachers.Add(new Teacher(0, subjects[0]));
                Teachers.Add(new Teacher(1, subjects[1]));
                OpenShop = new OpenShop(Teachers);
                SchedulesItemsControl.ItemsSource = null;
            }
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
            // Классы
            Class class1 = new Class(0, "10А");
            Class class2 = new Class(0, "11Б");
            Class class3 = new Class(0, "11В");
            Class class4 = new Class(0, "9Г");
            // Учебные планы
            Syllabus syllabus1 = new Syllabus(0, class1, subjects1);
            Syllabus syllabus2 = new Syllabus(1, class2, subjects2);
            Syllabus syllabus3 = new Syllabus(2, class3, subjects3);
            Syllabus syllabus4 = new Syllabus(3, class4, subjects4);
            Syllabuses[0] = syllabus1;
            Syllabuses[1] = syllabus2;
            Syllabuses[2] = syllabus3;
            Syllabuses[3] = syllabus4;
            // Создать расписания в Open Shop'e
            OpenShop.MakeSchedules(Syllabuses);

            // Создание расписания для классов
            for (int i = 0; i < SyllabusesCount; i++)
            {
                Schedule schedule = OpenShop.SchedulesList[i];
                SchedulesList.Add(schedule); // надо ли
                ClassSchedule classSchedule = new ClassSchedule(schedule.Class.Name, DecodeClassSchedule(schedule));
                ClassSchedulesList.Add(classSchedule);
            }

            // Источник
            SchedulesItemsControl.ItemsSource = ClassSchedulesList;
        }

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

        // учителя
        private void showTeachersButton_Click(object sender, RoutedEventArgs e)
        {
            WindowTeachers window = new WindowTeachers(OpenShop.Teachers);
            window.Show();
        }
    }
}
