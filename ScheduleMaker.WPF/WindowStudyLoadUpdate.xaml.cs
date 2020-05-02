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
using System.Windows.Shapes;

namespace ScheduleMaker.WPF
{
    /// <summary>
    /// Логика взаимодействия для WindowSyllabiUpdate.xaml
    /// </summary>
    public partial class WindowStudyLoadUpdate : Window
    {
        List<SubjectPlan> SubjectPlans = new List<SubjectPlan>();
        List<Subject> Subjects;
        List<Teacher> TeacherPlans = new List<Teacher>();
        List<Teacher> Teachers;

        Syllabus Syllabus;
        public WindowStudyLoadUpdate(Syllabus syllabus)
        {
            InitializeComponent();
            Syllabus = syllabus;
            
            classesComboBox.ItemsSource = App.Classes;
            classesComboBox.SelectedValue = Syllabus.Class;

            Subjects = new List<Subject>(App.Subjects);
            subjectsListBox.ItemsSource = Subjects;

            SubjectPlans = Syllabus.SubjectPlans;
            subjectPlansListBox.ItemsSource = SubjectPlans;

            Label1.Content = $"Редактирование класса {Syllabus.Class.Name}.";
        }

        // Перетащить предмет налево
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsCountTextBox.Text != "" && subjectsListBox.SelectedItem != null)
            {
                SubjectPlans.Add(new SubjectPlan(subjectsListBox.SelectedItem
                    as Subject, Convert.ToInt32(LessonsCountTextBox.Text)));
                Subjects.Remove(subjectsListBox.SelectedItem as Subject);
                RefreshTables();
                LessonsCountTextBox.Text = "";
            }
        }

        // Перетащить предмет направо
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (subjectPlansListBox.SelectedItem != null)
            {
                SubjectPlans.Remove(subjectPlansListBox.SelectedItem as SubjectPlan);
                Subjects.Add((subjectPlansListBox.SelectedItem as SubjectPlan).Subject);
                RefreshTables();
            }
        }


        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (classesComboBox.SelectedItem != null && subjectPlansListBox.Items.Count > 0)
            {
                Syllabus.SubjectPlans = SubjectPlans;
                Syllabus.Class = classesComboBox.SelectedItem as Class;
                Syllabus.Teachers = TeacherPlans;
            }
        }

        // Перетащить учителя налево
        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (teachersListBox.SelectedItem != null)
            {
                TeacherPlans.Add(teachersListBox.SelectedItem as Teacher);
                Teachers.Remove(teachersListBox.SelectedItem as Teacher);
                RefreshTeachersTables();
            }
        }

        // Перетащить учителя направо
        private void RemoveTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (teacherPlansListBox.SelectedItem != null)
            {
                TeacherPlans.Remove(teacherPlansListBox.SelectedItem as Teacher);
                Teachers.Add(teacherPlansListBox.SelectedItem as Teacher);
                RefreshTeachersTables();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTables()
        {
            subjectPlansListBox.Items.Refresh();
            subjectsListBox.Items.Refresh();
        }

        private void RefreshTeachersTables()
        {
            teacherPlansListBox.ItemsSource = null;
            teacherPlansListBox.ItemsSource = TeacherPlans;
            teachersListBox.ItemsSource = null;
            teachersListBox.ItemsSource = Teachers;
        }
    }
}
