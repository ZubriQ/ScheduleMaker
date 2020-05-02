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
    /// Логика взаимодействия для WindowLessonsUpdate.xaml
    /// </summary>
    public partial class WindowSubjectsUpdate : Window
    {
        Subjects Subject;
        public WindowSubjectsUpdate(Subjects subject)
        {
            InitializeComponent();
            Subject = subject;
            DataContext = Subject;
            label1.Content = "Редактирование " + subject.name + ".";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                App.DB.SaveChanges();
                Close();
            } 
        }
    }
}
