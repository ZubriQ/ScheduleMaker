using ScheduleMaker.ADO;
using ScheduleMaker.OS;
using ScheduleMaker.OS.School;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            // Конвертация учебной нагрузки
            List<Syllabus> syllabi = new List<Syllabus>();
            List<Classes> classes = App.DB.Classes.Where(c => c.syllabus_id != null).ToList();
            for (int i = 0; i < classes.Count; i++)
            {
                Class @class = new Class(classes[i].class_id, classes[i].name);
                // Учителя, которые ведут нагрузку
                List<Teacher> teachers = new List<Teacher>();
                foreach (var t in classes[i].Teachers)
                {
                    Subject[] subjects = new Subject[t.Subjects.Count];
                    int j = 0;
                    foreach (var s in t.Subjects)
                    {
                        Subject subject = new Subject(s.subject_id, s.name, Convert.ToInt32(s.difficulty));
                        subjects[j] = subject;
                        j++;
                    }
                    teachers.Add(new Teacher(t.teacher_id, subjects));
                }
                // Нагрузка
                List<SubjectPlan> subjectPlans = new List<SubjectPlan>();
                foreach (var s in classes[i].Syllabi.StudyLoad)
                {
                    var subj = App.DB.Subjects.Single(x => x.subject_id == s.subject_id);
                    Subject subject = new Subject(s.subject_id, subj.name, Convert.ToInt32(subj.difficulty));
                    subjectPlans.Add(new SubjectPlan(subject, s.lessons_count));
                }
                // Добавление плана для класса
                syllabi.Add(new Syllabus(i, @class, subjectPlans, teachers));
            }

            App.OpenShopPSO.SetData(App.DB.Teachers.ToList(), App.DB.Classrooms.ToList(), syllabi);
            App.OpenShopPSO.SetFunction(App.OpenShopPSO);
            ScheduleData scheduleData = App.OpenShopPSO.ConvertData(App.DB.Teachers.ToList(), App.DB.Classrooms.ToList(), syllabi);
            App.OpenShopPSO.ScheduleConstructor.MakeSchedules(
                scheduleData, App.OpenShopPSO.FindBestPriorities());

            // Создание расписания для классов
            for (int i = 0; i < syllabi.Count; i++)
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

        // Расписание учителей
        private void teachersSchedulesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (App.OpenShopPSO.ScheduleData != null)
            {
                WindowTeachersSchedules window = new WindowTeachersSchedules();
                window.Show();
            }
        }

        // Учителя
        private void teachersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowTeachers window = new WindowTeachers();
            window.Show();
        }

        // Классы
        private void classesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowClasses window = new WindowClasses();
            window.Show();
        }

        // Предметы
        private void subjectsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSubjects window = new WindowSubjects();
            window.Show();
        }

        // Учебные планы
        private void syllabiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSyllabi window = new WindowSyllabi();
            window.Show();
        }

        // Назначить нагрузку
        private void syllabiSetLoadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowSyllabiSetLoad window = new WindowSyllabiSetLoad();
            window.Show();
        }

        // Сохранить расписание
        private void saveScheduleButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
