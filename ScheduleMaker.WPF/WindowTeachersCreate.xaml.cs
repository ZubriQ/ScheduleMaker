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
    /// Логика взаимодействия для WindowTeachersCreate.xaml
    /// </summary>
    public partial class WindowTeachersCreate : Window
    {
        public WindowTeachersCreate()
        {
            InitializeComponent();
            lessonsListBox.ItemsSource = App.Subjects;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: должно быть много предметов
            App.Teachers.Add(new Teacher(App.Teachers.Count, lessonsListBox.SelectedItem as Subject));
        }
    }
}
