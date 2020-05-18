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
    /// Логика взаимодействия для WindowTeachersUpdate.xaml
    /// </summary>
    public partial class WindowTeachersUpdate : Window
    {
        Teachers Teacher;
        List<Subjects> Subjects;
        public WindowTeachersUpdate(Teachers teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            DataContext = Teacher;
            // Загрузить предметы в правую таблицу
            InitializeSubjects();

            label1.Content = "Редактирование " + teacher.second_name + " " + teacher.first_name + " " + teacher.middle_name + ".";
        }

        private void InitializeSubjects()
        {
            var subjects = Teacher.Subjects.ToList();
            Subjects = App.DB.Subjects.ToList();
            for (int i = 0; i < subjects.Count; i++)
            {
                Subjects.Remove(subjects[i]);
            }
            DataGrid2.ItemsSource = Subjects;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.Items.Count > 0)
            {
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
