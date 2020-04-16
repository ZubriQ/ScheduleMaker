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
    /// Логика взаимодействия для WindowLessons.xaml
    /// </summary>
    public partial class WindowLessons : Window
    {
        public WindowLessons()
        {
            InitializeComponent();
            lessonsDataGrid.ItemsSource = App.Subjects;
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowLessonsCreate window = new WindowLessonsCreate();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lessonsDataGrid.SelectedItem != null)
            {
                WindowLessonsUpdate window = new WindowLessonsUpdate(lessonsDataGrid.SelectedItem as Subject);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lessonsDataGrid.SelectedItem != null)
            {
                App.Subjects.Remove(lessonsDataGrid.SelectedItem as Subject);
            }
            RefreshTable();
        }

        private void commandRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            lessonsDataGrid.ItemsSource = null;
            lessonsDataGrid.ItemsSource = App.Subjects;
        }
    }
}
