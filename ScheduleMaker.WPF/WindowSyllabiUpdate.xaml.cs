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
    /// Логика взаимодействия для WindowSyllabiUpdate.xaml
    /// </summary>
    public partial class WindowSyllabiUpdate : Window
    {
        Syllabus Syllabus;
        public WindowSyllabiUpdate(Syllabus syllabus)
        {
            InitializeComponent();
            Syllabus = syllabus;
        }
    }
}
