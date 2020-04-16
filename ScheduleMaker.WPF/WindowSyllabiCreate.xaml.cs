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
        public WindowSyllabiCreate()
        {
            InitializeComponent();
            classesComboBox.ItemsSource = App.Classes;
            var subjects = App.Subjects;
            subjectsListBox.ItemsSource = subjects;
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
