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
    /// Логика взаимодействия для WindowSyllabiCreate.xaml
    /// </summary>
    public partial class WindowStudyLoadCreate : Window
    {
        List<SubjectPlan> SubjectPlans = new List<SubjectPlan>();
        List<Subject> Subjects;
        List<Teacher> TeacherPlans = new List<Teacher>();
        List<Teacher> Teachers;
        public WindowStudyLoadCreate()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            classesComboBox.ItemsSource = App.Classes;
            subjectPlansListBox.ItemsSource = SubjectPlans;
            Subjects = new List<Subject>(App.Subjects);
            subjectsListBox.ItemsSource = Subjects;
            teacherPlansListBox.ItemsSource = TeacherPlans;
            Teachers = new List<Teacher>(App.Teachers);
            teachersListBox.ItemsSource = Teachers;
        }

        // Перетащить предмет налево
        private void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsCountTextBox.Text != "" && subjectsListBox.SelectedItem != null)
            {
                SubjectPlans.Add(new SubjectPlan(subjectsListBox.SelectedItem
                    as Subject, Convert.ToInt32(LessonsCountTextBox.Text)));
                Subjects.Remove(subjectsListBox.SelectedItem as Subject);
                RefreshSubjectsTables();
                LessonsCountTextBox.Text = "";
            }
        }

        // Перетащить предмет направо
        private void RemoveSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (subjectPlansListBox.SelectedItem != null)
            {
                SubjectPlans.Remove(subjectPlansListBox.SelectedItem as SubjectPlan);
                Subjects.Add((subjectPlansListBox.SelectedItem as SubjectPlan).Subject);
                RefreshSubjectsTables();
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

        // Добавить Учебный план
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (classesComboBox.SelectedItem != null && subjectPlansListBox.Items.Count > 0)
            {
                App.Syllabi.Add(new Syllabus(App.Syllabi.Count, classesComboBox.SelectedItem as Class, SubjectPlans, TeacherPlans));
                Close();
            }
        }

        private void RefreshSubjectsTables()
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
