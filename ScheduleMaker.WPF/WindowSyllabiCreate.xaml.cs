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
    public partial class WindowSyllabiCreate : Window
    {
       
        List<SubjectPlan> SubjectPlans = new List<SubjectPlan>();
        List<Subject> Subjects;
        public WindowSyllabiCreate()
        {
            InitializeComponent();
            Subjects = new List<Subject>(App.Subjects);
            classesComboBox.ItemsSource = App.Classes;
            subjectsListBox.ItemsSource = Subjects;
            subjectPlansListBox.ItemsSource = SubjectPlans;
            
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

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (classesComboBox.SelectedItem != null && subjectPlansListBox.Items.Count > 0)
            {
                App.Syllabi.Add(new Syllabus(App.Syllabi.Count, classesComboBox.SelectedItem as Class, SubjectPlans));
                Close();
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
    }
}
