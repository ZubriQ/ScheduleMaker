using System.Collections.Generic;

namespace ScheduleMaker.WPF
{
    public class ClassSchedule
    {
        /// <summary>
        /// Расписание класса.
        /// </summary>
        public List<Day> Schedule { get; set; }

        /// <summary>
        /// Название школьного класса.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Конструктор расписания.
        /// </summary>
        /// <param name="className">Название школьного класса.</param>
        /// <param name="schedule">Расписание класса.</param>
        public ClassSchedule(string className, List<Day> schedule)
        {
            Schedule = schedule;
            ClassName = className;
        }
    }
}
