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
        /// <summary>
        /// Данные для создания расписаний.
        /// </summary>
        public ScheduleData ScheduleData;

        /// <summary>
        /// Констурктор расписаний.
        /// </summary>
        public ScheduleConstructor ScheduleConstructor;

        /// <summary>
        /// Оценщик расписаний.
        /// </summary>
        public ScheduleEvaluator ScheduleEvaluator;

        /// <summary>
        /// PSO.
        /// </summary>
        public PSOController PSOController;

        public Machine[] Teachers => ScheduleData.Teachers;

        public OpenShopPSO(List<Teacher> teachers, Syllabus[] syllabi, ICalculator calculator)
        {
            ScheduleData = new ScheduleData(teachers, syllabi);
            Parameter parameters = new Parameter(-300, 300, 40, ScheduleData.LessonsCount);
            PSOController = new PSOController(parameters, calculator);
        }

        /// <summary>
        /// Конструктор установки исходных данных.
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        /// <param name="syllabi">Учебные планы.</param>
        public OpenShopPSO(List<Teacher> teachers, Syllabus[] syllabi)
        {
            ScheduleData = new ScheduleData(teachers, syllabi);
            ScheduleConstructor = new ScheduleConstructor();
            ScheduleEvaluator = new ScheduleEvaluator();
        }

        public OpenShopPSO() 
        {
            ScheduleConstructor = new ScheduleConstructor();
            ScheduleEvaluator = new ScheduleEvaluator();
        }

        /// <summary>
        /// Фитнесс функция.
        /// </summary>
        /// <param name="calculator">Фитнесс функция.</param>
        public void SetFunction(ICalculator calculator)
        {
            Parameter parameters = new Parameter(-150, 150, 40, ScheduleData.LessonsCount);
            PSOController = new PSOController(parameters, calculator);
        }

        public void SetData(List<Teacher> teachers, Syllabus[] syllabi)
        {
            ScheduleData = new ScheduleData(teachers, syllabi);
        }

        /// <summary>
        /// Найти лучшие приоритеты для вектора уроков.
        /// </summary>
        /// <returns>Возвращает наилучшие приоритеты расположения уроков.</returns>
        public double[] FindBestPriorities()
        {
            PSOController.InitializeParticleSwarm();
            PSOController.FindGlobalMinimum(0.729, 1.49445, 1.49445, 600);
            return PSOController.GlobalBestParticle.BestKnownPosition;
        }

        public double Fitness(double[] values)
        {
            //Array.Copy(OpenShop.AllLessons, OpenShop.TempLessons, OpenShop.AllLessons.Length);
            //Array.Sort(values, OpenShop.TempLessons);
            ScheduleConstructor.MakeSchedules(ScheduleData, values);
            int gapsCount = ScheduleEvaluator.EstimateSchedule(ScheduleConstructor.SchedulesList);
            return gapsCount;
        }
    }
}
