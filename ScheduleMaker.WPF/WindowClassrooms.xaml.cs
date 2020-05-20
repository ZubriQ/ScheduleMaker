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
    /// Логика взаимодействия для WindowClassrooms.xaml
    /// </summary>
    public partial class WindowClassrooms : Window
    {
        public WindowClassrooms()
        {
            InitializeComponent();
            classroomsDataGrid.ItemsSource = App.DB.Classrooms.OrderBy(s => s.name).ToList();
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowClassroomsCrtUpd window = new WindowClassroomsCrtUpd();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (classroomsDataGrid.SelectedItem != null)
            {
                WindowClassroomsCrtUpd window = new WindowClassroomsCrtUpd(classroomsDataGrid.SelectedItem as Classrooms);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (classroomsDataGrid.SelectedItem != null)
            {
                App.DB.Classrooms.Remove(classroomsDataGrid.SelectedItem as Classrooms);
                App.DB.SaveChanges();
            }
            RefreshTable();
        }

        private void commandRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            classroomsDataGrid.ItemsSource = null;
            classroomsDataGrid.ItemsSource = App.DB.Classrooms.OrderBy(s => s.name).ToList();
        }
    }
}
