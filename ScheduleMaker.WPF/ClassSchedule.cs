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
        /// <param name="className">Расписание класса.</param>
        /// <param name="schedule">Название школьного класса.</param>
        public ClassSchedule(string className, List<Day> schedule)
        {
            Schedule = schedule;
            ClassName = className;
        }
    }
}
