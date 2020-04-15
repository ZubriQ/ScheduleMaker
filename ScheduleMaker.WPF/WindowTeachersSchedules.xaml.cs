using ScheduleMaker.OP;
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
using System.Windows.Shapes;

namespace ScheduleMaker.WPF
{
    /// <summary>
    /// Логика взаимодействия для WindowTeachersSchedules.xaml
    /// </summary>
    public partial class WindowTeachersSchedules : Window
    {
        public List<TeacherSchedule> teacherSchedules = new List<TeacherSchedule>();

        public WindowTeachersSchedules()
        {
            InitializeComponent();
            DecodeTeachersSchedules(App.OpenShopPSO.Teachers);
            TeachersItemsControl.ItemsSource = teacherSchedules;
        }

        public void DecodeTeachersSchedules(Machine[] teachers)
        {
            for (int t = 0; t < teachers.Length; t++)
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
                    AddLesson(teachers, newSchedule, ref indexOfLesson, t);
                }
                TeacherSchedule teacherSchedule = new TeacherSchedule(teachers[t].Id.ToString(), newSchedule);
                teacherSchedules.Add(teacherSchedule);
            }
        }

        public void AddLesson(Machine[] teachers, List<Day> newSchedule, ref int indexOfLesson, int teacherId)
        {
            // Номер урока
            for (int column = 0; column < 10; column++)
            {
                // День
                for (int row = 0; row < 6; row++)
                {
                    if (teachers[teacherId].Lessons[indexOfLesson] != null)
                    {
                        newSchedule[row].Lessons[column] = new Lesson($"{column + 1}. " +
                            $"{teachers[teacherId].Lessons[indexOfLesson].Subject.Name}");
                    }
                    else
                    {
                        newSchedule[row].Lessons[column] = new Lesson($"{column + 1}. ----");
                    }
                    indexOfLesson++;
                }
            }
        }
    }
}
