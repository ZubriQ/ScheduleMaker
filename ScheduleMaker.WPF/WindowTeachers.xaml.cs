using ScheduleMaker.OP;
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
    /// Логика взаимодействия для WindowTeachers.xaml
    /// </summary>
    public partial class WindowTeachers : Window
    {
        public List<TeacherSchedule> teacherSchedules = new List<TeacherSchedule>();

        public WindowTeachers(Machine[] teachers)
        {
            InitializeComponent();
            ConvertSchedules(teachers);
            TeachersItemsControl.ItemsSource = teacherSchedules;
        }

        public void ConvertSchedules(Machine[] teachers)
        {
            for (int t = 0; t < teachers.Length; t++)
            {
                List<Day> Schedule = new List<Day>();
                for (int i = 0; i < 6; i++)
                {
                    Lesson[] lessons = new Lesson[8];
                    for (sbyte j = 0; j < 8; j++)
                    {
                        if (!teachers[t].Schedule[i].ContainsKey(j))
                        {
                            lessons[j] = new Lesson($"{j + 1}. ----");
                        }
                        else
                        {
                            lessons[j] = new Lesson($"{j + 1}. {teachers[t].Schedule[i][j]}");
                        }
                    }
                    Schedule.Add(new Day(i + 1, lessons));
                }
                TeacherSchedule teacherSchedule = new TeacherSchedule(teachers[t].Id.ToString(), Schedule);
                teacherSchedules.Add(teacherSchedule);
            }
        }

    }
}
