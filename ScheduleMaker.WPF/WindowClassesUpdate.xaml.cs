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
    /// Логика взаимодействия для WindowClassesUpdate.xaml
    /// </summary>
    public partial class WindowClassesUpdate : Window
    {
        Class Class;
        public WindowClassesUpdate(Class @class)
        {
            InitializeComponent();
            Class = @class;
            label1.Content = "Редактирование " + @class.Name + ".";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Class.Name = nameTextBox.Text;
            this.Close();
        }
    }
}
