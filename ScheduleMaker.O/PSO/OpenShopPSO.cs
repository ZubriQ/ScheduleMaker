using ScheduleMaker.GA;
using ScheduleMaker.OP.School;
using ScheduleMaker.PSO;
using System.Collections.Generic;

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

        public OpenShopPSO(List<Teacher> teachers, List<Syllabus> syllabi, List<Classroom> classrooms, ICalculator calculator)
        {
            ScheduleData = new ScheduleData(teachers, syllabi, classrooms);
            Parameter parameters = new Parameter(-300, 300, 40, ScheduleData.LessonsCount);
            PSOController = new PSOController(parameters, calculator);
        }

        /// <summary>
        /// Конструктор установки исходных данных.
        /// </summary>
        /// <param name="teachers">Учителя.</param>
        /// <param name="syllabi">Учебные планы.</param>
        public OpenShopPSO(List<Teacher> teachers, List<Syllabus> syllabi, List<Classroom> classrooms)
        {
            ScheduleData = new ScheduleData(teachers, syllabi, classrooms);
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

        public void SetData(List<Teacher> teachers, List<Syllabus> syllabi, List<Classroom> classrooms)
        {
            ScheduleData = new ScheduleData(teachers, syllabi, classrooms);
        }

        /// <summary>
        /// Найти лучшие приоритеты для вектора уроков.
        /// </summary>
        /// <returns>Возвращает наилучшие приоритеты расположения уроков.</returns>
        public double[] FindBestPriorities()
        {
            PSOController.InitializeParticleSwarm();
            PSOController.FindGlobalMinimum(0.729, 1.49445, 1.49445, 350);
            return PSOController.GlobalBestParticle.BestKnownPosition;
        }

        public double Fitness(double[] values)
        {
            ScheduleConstructor.MakeSchedules(ScheduleData, values);
            int gapsCount = ScheduleEvaluator.EstimateSchedule(ScheduleConstructor.SchedulesList);
            return gapsCount;
        }
    }
}
