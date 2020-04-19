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
            Close();
        }

        // Добавить нового учителя
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (lessonsListBox.SelectedItem != null)
            {
                Subject[] subjects = new Subject[lessonsListBox.SelectedItems.Count];
                var selectedItems = lessonsListBox.SelectedItems;
                for (int i = 0; i < subjects.Length; i++)
                {
                    subjects[i] = selectedItems[i] as Subject;
                }
                App.Teachers.Add(new Teacher(App.Teachers.Count, subjects));
                Close();
            }
        }
    }
}
