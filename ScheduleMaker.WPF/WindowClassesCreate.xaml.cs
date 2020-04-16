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
    /// Логика взаимодействия для WindowClassesCreate.xaml
    /// </summary>
    public partial class WindowClassesCreate : Window
    {
        public WindowClassesCreate()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            App.Classes.Add(new OP.School.Class(App.Classes.Count, nameTextBox.Text));
            Close();
        }
    }
}
