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
        Classes Class;
        public WindowClassesUpdate(Classes @class)
        {
            InitializeComponent();
            Class = @class;
            DataContext = Class;
            label1.Content = "Редактирование " + @class.name + ".";
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            App.DB.SaveChanges();
            Close();
        }
    }
}
