using ScheduleMaker.ADO;
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
    /// Логика взаимодействия для WindowTeachersCreate.xaml
    /// </summary>
    public partial class WindowTeachersCreate : Window
    {
        Teachers Teacher;
        List<Subjects> Subjects;
        public WindowTeachersCreate()
        {
            InitializeComponent();
            Teacher = new Teachers();
            DataContext = Teacher;
            Subjects = new List<Subjects>(App.DB.Subjects.ToList());
            DataGrid2.ItemsSource = Subjects;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Добавить нового учителя
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.Items.Count > 0 && nameTextBox.Text != "" && secondNameTextBox.Text != "")
            {
                App.DB.Teachers.Add(Teacher);
                App.DB.SaveChanges();
                Close();
            }
        }

        private void AddElementButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null)
            {
                Teacher.Subjects.Add(DataGrid2.SelectedItem as Subjects);
                Subjects.Remove(DataGrid2.SelectedItem as Subjects);
                RefreshTables();
            }
        }

        private void RemoveElementButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                Teacher.Subjects.Remove(DataGrid1.SelectedItem as Subjects);
                Subjects.Add(DataGrid1.SelectedItem as Subjects);
                RefreshTables();
            }
        }

        private void RefreshTables()
        {
            DataGrid2.ItemsSource = null;
            DataGrid2.ItemsSource = Subjects;
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = Teacher.Subjects;
        }
    }
}
