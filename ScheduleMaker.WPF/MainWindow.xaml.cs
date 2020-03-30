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
        public List<Schedule> schedulesList;
        public Subject[] subjects;
        public Teacher[] teachers;
        public Syllabus[] syllabuses;

        public List<List<Day>> Schedules = new List<List<Day>>();

        public List<Day> Schedule = new List<Day>();

        public MainWindow()
        {
            InitializeComponent();
            SchedulesListView.ItemsSource = null;

            // Создание Open Shop и Учебного плана
            int teachersCount = 2;
            int subjectsCount = 2;
            int syllabusesCount = 3;
            byte numberOfDays = 6;

            // Определение всех видов предметов
            subjects = new Subject[subjectsCount];
            subjects[0] = new Subject(0, "математика", 11);
            subjects[1] = new Subject(1, "русский язык", 11);

            // Все Учителя в школе
            teachers = new Teacher[teachersCount];
            teachers[0] = new Teacher(0, subjects[0]);
            teachers[1] = new Teacher(1, subjects[1]);

            // Планы предметов в Учебных планах
            SubjectPlan[] subjects1 = new SubjectPlan[subjectsCount];
            subjects1[0] = new SubjectPlan(subjects[0], 10);
            subjects1[1] = new SubjectPlan(subjects[1], 7);
            SubjectPlan[] subjects2 = new SubjectPlan[subjectsCount];
            subjects2[0] = new SubjectPlan(subjects[0], 10);
            subjects2[1] = new SubjectPlan(subjects[1], 7);
            SubjectPlan[] subjects3 = new SubjectPlan[subjectsCount];
            subjects3[0] = new SubjectPlan(subjects[0], 10);
            subjects3[1] = new SubjectPlan(subjects[1], 7);

            // Учебные планы
            Syllabus[] syllabuses = new Syllabus[syllabusesCount];
            Syllabus syllabus1 = new Syllabus(0, "10А", subjects1, teachers);
            Syllabus syllabus2 = new Syllabus(1, "11Б", subjects2, teachers);
            Syllabus syllabus3 = new Syllabus(2, "9Г", subjects3, teachers);
            syllabuses[0] = syllabus1;
            syllabuses[1] = syllabus2;
            syllabuses[2] = syllabus3;

            // Вызов Open Shop
            OpenShop openShop = new OpenShop(teachers);

            // Создание расписания для учебных планов
            schedulesList = new List<Schedule>();
            Schedule schedule1 = openShop.MakeSchedule(syllabus1, numberOfDays);
            schedulesList.Add(schedule1);
            Schedule schedule2 = openShop.MakeSchedule(syllabus2, numberOfDays);
            schedulesList.Add(schedule2);
            Schedule schedule3 = openShop.MakeSchedule(syllabus3, numberOfDays);
            schedulesList.Add(schedule3);




            // тест показа уроков
            CreateSchedule(schedule1);
            CreateSchedule(schedule2);
            CreateSchedule(schedule3);
        }

        private void CreateSchedule(Schedule schedule)
        {
            for (int i = 0; i < 6; i++)
            {
                Lesson[] lessons = new Lesson[8];
                for (int j = 0; j < 8; j++)
                {
                    if (string.IsNullOrEmpty(schedule.Lessons[i, j]))
                    {
                        lessons[j] = new Lesson($"{j + 1}. -----");
                    }
                    else
                    {
                        lessons[j] = new Lesson(schedule.Lessons[i, j]);
                    }
                }
                Schedule.Add(new Day(i + 1, lessons));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SchedulesListView.ItemsSource = schedulesList;
            SchedulesListView.ItemsSource = Schedule;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
