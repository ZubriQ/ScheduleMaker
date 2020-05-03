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
    /// Логика взаимодействия для WindowSyllabiSetLoad.xaml
    /// </summary>
    public partial class WindowSyllabiSetLoad : Window
    {
        List<Teachers> TeachersLoad = new List<Teachers>();
        List<Teachers> Teachers = new List<Teachers>(App.DB.Teachers.ToList());
        public WindowSyllabiSetLoad()
        {
            InitializeComponent();
            InitializeInitialData();
        }

        public WindowSyllabiSetLoad(Classes @class)
        {
            InitializeComponent();
            InitializeInitialData();
            ClassComboBox.SelectedValue = @class;
            if (@class.Teachers.Count > 0)
            {
                TeachersLoad.AddRange(@class.Teachers);
                RemoveExtraTeachers(@class);
            }
        }

        private void InitializeInitialData()
        {
            ClassComboBox.ItemsSource = App.DB.Classes.OrderBy(s => s.name).ToArray();
            SyllabusComboBox.ItemsSource = App.DB.Syllabi.ToArray();
            DataGrid1.ItemsSource = TeachersLoad;
            DataGrid2.ItemsSource = Teachers;
        }

        private void RemoveExtraTeachers(Classes @class)
        {
            foreach (var t in @class.Teachers.ToList())
            {
                Teachers.Remove(t);
            }
        }

        private void AddTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null)
            {
                TeachersLoad.Add(DataGrid2.SelectedItem as Teachers);
                Teachers.Remove(DataGrid2.SelectedItem as Teachers);
                RefreshTables();
            }
        }

        private void RemoveTeacherButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                Teachers.Add(DataGrid1.SelectedItem as Teachers);
                TeachersLoad.Remove(DataGrid1.SelectedItem as Teachers);
                RefreshTables();
            }
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClassComboBox.SelectedItem != null && SyllabusComboBox.SelectedItem
                != null && TeachersLoad.Count > 0)
            {
                var @class = ClassComboBox.SelectedItem as Classes;
                @class.syllabus_id = (SyllabusComboBox.SelectedItem as Syllabi).syllabus_id;
                for (int i = 0; i < DataGrid1.Items.Count; i++)
                {
                    @class.Teachers.Add(TeachersLoad[i]);
                }
                App.DB.SaveChanges();
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTables()
        {
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = TeachersLoad;
            DataGrid2.ItemsSource = null;
            DataGrid2.ItemsSource = Teachers;
        }
    }
}
