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
        /// База данных SQL Server
        /// </summary>
        public static ScheduleMakerEntities DB = new ScheduleMakerEntities();

        /// <summary>
        /// Алгоритм для составления расписаний
        /// </summary>
        public static OpenShopPSO OpenShopPSO = new OpenShopPSO();

        /// <summary>
        /// Старое
        /// </summary>
        public static List<Syllabus> Syllabi = new List<Syllabus>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Subject> Subjects = new List<Subject>();
        public static List<Class> Classes = new List<Class>();
        public static List<Classroom> Classrooms = new List<Classroom>();
    }
}
