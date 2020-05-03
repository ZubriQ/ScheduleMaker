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
    /// Логика взаимодействия для WindowSyllabi.xaml
    /// </summary>
    public partial class WindowSyllabi : Window
    {
        public WindowSyllabi()
        {
            InitializeComponent();
            syllabiDataGrid.ItemsSource = App.DB.Syllabi.OrderBy(s => s.year).ToArray();
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowSyllabiCreate window = new WindowSyllabiCreate();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (syllabiDataGrid.SelectedItem != null)
            {
                WindowSyllabiUpdate window = new WindowSyllabiUpdate(syllabiDataGrid.SelectedItem as Syllabi);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (syllabiDataGrid.SelectedItem != null)
            {
                App.DB.Syllabi.Remove(syllabiDataGrid.SelectedItem as Syllabi);
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
            syllabiDataGrid.ItemsSource = null;
            syllabiDataGrid.ItemsSource = App.DB.Syllabi.OrderBy(s => s.year).ToArray();
        }
    }
}
