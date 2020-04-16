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
        Subject Subject;
        public WindowSubjectsUpdate(Subject subject)
        {
            InitializeComponent();
            Subject = subject;
            nameTextBox.Text = subject.Name;
            difficultyTextBox.Text = subject.Difficulty.ToString();
            label1.Content = "Редактирование " + subject.Name + ".";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Subject.Name = nameTextBox.Text;
            Subject.Difficulty = Convert.ToInt32(difficultyTextBox.Text);
            Close();
        }
    }
}
