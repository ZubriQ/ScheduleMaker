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
    /// Логика взаимодействия для WindowLessonsCreate.xaml
    /// </summary>
    public partial class WindowSubjectsCreate : Window
    {
        Subjects Subject;
        public WindowSubjectsCreate()
        {
            InitializeComponent();
            Subject = new Subjects();
            Subject.difficulty = 5;
            DataContext = Subject;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "")
            {
                App.DB.Subjects.Add(Subject);
                App.DB.SaveChanges();
                Close();
            }
        }
    }
}
