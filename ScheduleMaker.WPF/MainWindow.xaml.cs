using ScheduleMaker.ADO;
using ScheduleMaker.OS;
using ScheduleMaker.OS.School;
using ScheduleMaker.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        // Создать расписание
        private async void MakeSheduleButton_Click(object sender, RoutedEventArgs e)
        {
            OutputLabel.Content = "Идет конвертация данных из БД. Пожалуйста, подождите...";
            DeleteOldSchedules();
            // Конвертация учебной нагрузки в классы Алгоритма
            List<Syllabus> syllabi = new List<Syllabus>();
            List<Classes> classes = App.DB.Classes.Where(c => c.syllabus_id != null).ToList();
            await Task.Run(() =>
            {
                InitializeSyllabi(syllabi, classes);
            });
            // Внести данные и создать расписание на основе данных
            OutputLabel.Content = "Создается расписание. Пожалуйста, подождите...";
            await Task.Run(() =>
            {
                FindPerfectSchedule(syllabi);
            });
            // Создание расписаний для классов
            DecodeSchedules(syllabi.Count);
            // Источник
            SchedulesItemsControl.ItemsSource = ClassSchedulesList;
            // TODO: Добавить оценку полученного расписания?
            OutputLabel.Content = "Расписание успешно создано.";
        }

        /// <summary>
        /// Инициализация данных для алгоритма
        /// </summary>
        /// <param name="syllabi">Учебные планы</param>
        /// <param name="classes">Классы</param>
        private void InitializeSyllabi(List<Syllabus> syllabi, List<Classes> classes)
        {
            for (int i = 0; i < classes.Count; i++)
            {
                Classes @class = classes[i];
                Class newClass = new Class(@class.class_id, classes[i].name);
                // Учителя, которые ведут нагрузку
                List<Machine> teachers = new List<Machine>();
                MakeTeachers(@class, teachers);
                // Создание нагрузки
                List<SubjectPlan> subjectPlans = new List<SubjectPlan>();
                MakeSubjectPlans(@class, subjectPlans);
                // Добавление плана для класса
                syllabi.Add(new Syllabus(i, newClass, subjectPlans, teachers));
            }
        }

        private void MakeTeachers(Classes @class, List<Machine> teachers)
        {
            foreach (var t in @class.Teachers)
            {
                Subject[] subjects = new Subject[t.Subjects.Count];
                int j = 0;
                foreach (var s in t.Subjects)
                {
                    Subject subject = new Subject(s.subject_id, s.name, Convert.ToInt32(s.difficulty));
                    subjects[j] = subject;
                    j++;
                }
                teachers.Add(new Machine(t.teacher_id, subjects));
            }
        }

        private void MakeSubjectPlans(Classes @class, List<SubjectPlan> subjectPlans)
        {
            foreach (var s in @class.Syllabi.StudyLoad)
            {
                var subj = App.DB.Subjects.Single(x => x.subject_id == s.subject_id);
                Subject subject = new Subject(s.subject_id, subj.name, Convert.ToInt32(subj.difficulty));
                subjectPlans.Add(new SubjectPlan(subject, s.lessons_count));
            }
        }

        private void FindPerfectSchedule(List<Syllabus> syllabi)
        {
            App.OpenShopPSO.SetData(App.DB.Teachers.ToList(), App.DB.Classrooms.ToList(), syllabi);
            App.OpenShopPSO.SetFunction(App.OpenShopPSO);
            App.OpenShopPSO.ScheduleConstructor.MakeSchedules(
                App.OpenShopPSO.ScheduleData, App.OpenShopPSO.FindBestPriorities());
        }

        private void DecodeSchedules(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Schedule schedule = App.OpenShopPSO.ScheduleConstructor.SchedulesList[i];
                ClassSchedule classSchedule = new ClassSchedule(schedule.Class.Name, 
                                                                DecodeClassSchedule(schedule));
                ClassSchedulesList.Add(classSchedule);
            }
        }

        // Сохранить расписание
        private void SaveScheduleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Удаление старых временных расписаний, если таковые имеются
        /// </summary>
        private void DeleteOldSchedules()
        {
            if (ClassSchedulesList.Count > 0)
            {
                App.OpenShopPSO = new OS.PSO.OpenShopPSO();
                ClassSchedulesList.Clear();
                SchedulesItemsControl.ItemsSource = null;
            }
        }

        #region Decode of schedules
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
                Lesson[] lessons = new Lesson[8];
                newSchedule.Add(new Day(i + 1, lessons));
            }
            // Добавление уроков в расписание
            int indexOfLesson = 0;
            while (indexOfLesson < 48)
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
            for (int column = 0; column < 8; column++)
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

        #region Windows' opening
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

        // Кабинеты
        private void classroomsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            WindowClassrooms window = new WindowClassrooms();
            window.Show();
        }
        #endregion
    }
}
