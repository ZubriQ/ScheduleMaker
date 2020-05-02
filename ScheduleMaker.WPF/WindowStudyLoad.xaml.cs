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
    /// Логика взаимодействия для WindowSyllabi.xaml
    /// </summary>
    public partial class WindowStudyLoad : Window
    {
        public WindowStudyLoad()
        {
            InitializeComponent();
            syllabiDataGrid.ItemsSource = App.Syllabi;
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowStudyLoadCreate window = new WindowStudyLoadCreate();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (syllabiDataGrid.SelectedItem != null)
            {
                WindowStudyLoadUpdate window = new WindowStudyLoadUpdate(syllabiDataGrid.SelectedItem as Syllabus);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (syllabiDataGrid.SelectedItem != null)
            {
                App.Syllabi.Remove(syllabiDataGrid.SelectedItem as Syllabus);
            }
            RefreshTable();
        }

        private void commandRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTable();
        }

        private void RefreshTable()
        {
            syllabiDataGrid.ItemsSource = null;
            syllabiDataGrid.ItemsSource = App.Syllabi;
        }
    }
}
