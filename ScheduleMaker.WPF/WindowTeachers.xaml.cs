using ScheduleMaker.ADO;
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
    /// Логика взаимодействия для WindowTeachers.xaml
    /// </summary>
    public partial class WindowTeachers : Window
    {
        public WindowTeachers()
        {
            InitializeComponent();
            teachersDataGrid.ItemsSource = App.DB.Teachers.OrderBy(t => t.second_name).ToList();
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowTeachersCreate window = new WindowTeachersCreate();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (teachersDataGrid.SelectedItem != null)
            {
                WindowTeachersUpdate window = new WindowTeachersUpdate(teachersDataGrid.SelectedItem as Teachers);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (teachersDataGrid.SelectedItem != null)
            {
                App.DB.Teachers.Remove(teachersDataGrid.SelectedItem as Teachers);
                App.DB.SaveChanges();
                RefreshTable();
            }
        }

        private void commandRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            teachersDataGrid.ItemsSource = null;
            teachersDataGrid.ItemsSource = App.DB.Teachers.OrderBy(t => t.second_name).ToArray();
        }
    }
}
