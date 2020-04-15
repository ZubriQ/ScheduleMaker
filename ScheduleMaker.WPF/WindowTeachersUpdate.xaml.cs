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
    /// Логика взаимодействия для WindowTeachersUpdate.xaml
    /// </summary>
    public partial class WindowTeachersUpdate : Window
    {
        Teacher Teacher;
        public WindowTeachersUpdate(Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            lessonsListBox.ItemsSource = App.Subjects;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Subject[]
            Teacher.Update(lessonsListBox.SelectedItem as Subject);
            this.Close();
        }
    }
}
