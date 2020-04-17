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
        List<Subject> Subjects = App.Subjects;
        public WindowSyllabiCreate()
        {
            InitializeComponent();
            classesComboBox.ItemsSource = App.Classes;
            subjectsListBox.ItemsSource = Subjects;
            subjectPlansListBox.ItemsSource = SubjectPlans;
        }

        // Перетащить предмет налево
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LessonsCountTextBox.Text != null && subjectsListBox.SelectedItem != null)
            {
                SubjectPlans.Add(new SubjectPlan(subjectsListBox.SelectedItem
                    as Subject, Convert.ToInt32(LessonsCountTextBox.Text)));
                // не обновляется почему-то..
                subjectPlansListBox.Items.Refresh();
            }
        }

        // Перетащить предмет направо
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTables()
        {
            subjectsListBox.ItemsSource = null;
            subjectsListBox.ItemsSource = Subjects;
            subjectPlansListBox.ItemsSource = null;
            subjectPlansListBox.ItemsSource = SubjectPlans;
        }
    }
}
