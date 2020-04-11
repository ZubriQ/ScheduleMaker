using ScheduleMaker.GA;
using ScheduleMaker.OP.School;
using ScheduleMaker.PSO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleMaker.OP.PSO
{
    public class OpenShopPSO : ICalculator
    {
        public OpenShop OpenShop;

        public PSOController PSOController;

        public Machine[] Teachers => OpenShop.Teachers;

        /// <summary>
        /// Учебные планы.
        /// </summary>
        public Syllabus[] Syllabi;

        public OpenShopPSO(List<Teacher> teachers, Syllabus[] syllabi, ICalculator calculator)
        {
            OpenShop = new OpenShop(teachers);
            Syllabi = syllabi;
            Parameter parameters = new Parameter(-300, 300, 40, OpenShop.CalculateNumberOfLessons(Syllabi));
            PSOController = new PSOController(parameters, calculator);
        }
        public OpenShopPSO(List<Teacher> teachers, Syllabus[] syllabi)
        {
            OpenShop = new OpenShop(teachers);
            Syllabi = syllabi;
        }

        /// <summary>
        /// Фитнесс функция.
        /// </summary>
        /// <param name="calculator">Фитнесс функция.</param>
        public void SetFunction(ICalculator calculator)
        {
            Parameter parameters = new Parameter(-150, 150, 40, OpenShop.CalculateNumberOfLessons(Syllabi));
            PSOController = new PSOController(parameters, calculator);
        }

        public string FunctionName => "Расписание";

        /// <summary>
        /// Найти лучшие приоритеты для вектора уроков.
        /// </summary>
        /// <returns>Возвращает наилучшие приоритеты расположения уроков.</returns>
        public double[] FindBestSchedulesPriorities()
        {
            PSOController.InitializeParticleSwarm();
            PSOController.FindGlobalMinimum(0.729, 1.49445, 1.49445, 600);
            return PSOController.GlobalBestParticle.BestKnownPosition;
        }

        public double Fitness(double[] values)
        {
            //Array.Copy(OpenShop.AllLessons, OpenShop.TempLessons, OpenShop.AllLessons.Length);
            //Array.Sort(values, OpenShop.TempLessons);
            OpenShop.MakeSchedulesWithPriorities(Syllabi, values);
            int gapsCount = OpenShop.FindGapsInAllSchedules();
            return gapsCount;
        }
    }
}
