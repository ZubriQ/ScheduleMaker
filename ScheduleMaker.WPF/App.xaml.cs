using ScheduleMaker.OP.PSO;
using ScheduleMaker.OP.School;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ScheduleMaker.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Список учебных планов
        /// </summary>
        public static List<Syllabus> Syllabi = new List<Syllabus>();

        /// <summary>
        /// Список всех учителей в школе
        /// </summary>
        public static List<Teacher> Teachers = new List<Teacher>();

        /// <summary>
        /// Список предметов в школе
        /// </summary>
        public static List<Subject> Subjects = new List<Subject>();

        /// <summary>
        /// Алгоритм
        /// </summary>
        public static OpenShopPSO OpenShopPSO = new OpenShopPSO();

        /// <summary>
        /// Школьные классы
        /// </summary>
        public static List<Class> Classes = new List<Class>();
    }
}
