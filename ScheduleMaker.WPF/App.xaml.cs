using ScheduleMaker.ADO;
using ScheduleMaker.OS.PSO;
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
    /// Логика взаимодействия для WPF-приложения.
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
        public static SchoolPSO OpenShopPSO = new SchoolPSO();

        public static Dictionary<int, string> DayNames = new Dictionary<int, string>
        {
            {1, "Пн.\t" },
            {2, "Вт.\t" },
            {3, "Ср.\t" },
            {4, "Чт.\t" },
            {5, "Пт.\t" },
            {6, "Сб.\t" }
        };
    }
}
