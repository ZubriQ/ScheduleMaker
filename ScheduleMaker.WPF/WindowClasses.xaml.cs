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
    /// Логика взаимодействия для WindowClasses.xaml
    /// </summary>
    public partial class WindowClasses : Window
    {
        public WindowClasses()
        {
            InitializeComponent();
            classesDataGrid.ItemsSource = App.DB.Classes.OrderBy(s => s.name).ToArray();
        }

        private void commandCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowClassesCreate window = new WindowClassesCreate();
            window.Show();
        }

        private void commandUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (classesDataGrid.SelectedItem != null)
            {
                WindowClassesUpdate window = new WindowClassesUpdate(classesDataGrid.SelectedItem as Classes);
                window.Show();
            }
        }

        private void commandDelete_Click(object sender, RoutedEventArgs e)
        {
            if (classesDataGrid.SelectedItem != null)
            {
                App.DB.Classes.Remove(classesDataGrid.SelectedItem as Classes);
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
            classesDataGrid.ItemsSource = null;
            classesDataGrid.ItemsSource = App.DB.Classes.OrderBy(s => s.name).ToArray();
        }

        private void commandQuickCreate_Click(object sender, RoutedEventArgs e)
        {
            WindowClassesQuickCreate window = new WindowClassesQuickCreate();
            window.Show();
        }

        private void commandEditLoad_Click(object sender, RoutedEventArgs e)
        {
            if (classesDataGrid.SelectedItem != null)
            {
                WindowSyllabiSetLoad window = new WindowSyllabiSetLoad(classesDataGrid.SelectedItem as Classes);
                window.Show();
            }
        }

        private void commandDeleteLoad_Click(object sender, RoutedEventArgs e)
        {
            if (classesDataGrid.SelectedItem != null)
            {
                var @class = classesDataGrid.SelectedItem as Classes;
                foreach (var t in @class.Teachers.Where(t => t is Teachers).ToList())
                {
                    @class.Teachers.Remove(t);
                }
                @class.syllabus_id = null;
                App.DB.SaveChanges();
                RefreshTable();
            }
        }
    }
}
