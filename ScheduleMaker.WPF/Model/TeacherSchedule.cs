using System.Collections.Generic;

namespace ScheduleMaker.WPF.Model
{
    public class TeacherSchedule
    {
        /// <summary>
        /// Расписание Учителя.
        /// </summary>
        public List<Day> Schedule { get; set; }

        /// <summary>
        /// Ф.И.О. Учителя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Конструктор Учителя.
        /// </summary>
        /// <param name="teacherName">Ф.И.О. Учителя.</param>
        /// <param name="schedule">Расписание.</param>
        public TeacherSchedule(string teacherName, List<Day> schedule)
        {
            Schedule = schedule;
            FullName = teacherName;
        }
    }
}
