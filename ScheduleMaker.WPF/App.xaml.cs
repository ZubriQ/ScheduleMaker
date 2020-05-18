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
        public static OpenShopPSO OpenShopPSO = new OpenShopPSO();
    }
}
