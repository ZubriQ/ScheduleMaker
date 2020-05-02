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
    /// Логика взаимодействия для WindowClassesQuickCreate.xaml
    /// </summary>
    public partial class WindowClassesQuickCreate : Window
    {
        public char[] Letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'к', 'л',
                                             'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 
                                             'ы', 'ю', 'я', };

        public WindowClassesQuickCreate()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (countTextBox.Text != "" && yearTextBox.Text != "")
            {
                int count = Convert.ToInt32(countTextBox.Text);
                for (int i = 0; i < count; i++)
                {
                    string className = yearTextBox.Text + Letters[i];
                    // Проверяется: нет ли совпадений в БД
                    if (!App.DB.Classes.Any(s => s.name == className))
                    {
                        Classes @class = new Classes();
                        @class.name = className;
                        App.DB.Classes.Add(@class);
                    }
                }
                App.DB.SaveChanges();
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
