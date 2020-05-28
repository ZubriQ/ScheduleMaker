namespace ScheduleMaker.WPF.Model
{
    public class Day
    {
        /// <summary>
        /// Номер дня.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование дня (Пн. Вт. и т.д.)
        /// </summary>
        public string DayName { get; set; }

        /// <summary>
        /// Уроки дня.
        /// </summary>
        public Lesson[] Lessons { get; set; }

        /// <summary>
        /// Конструктор дня.
        /// </summary>
        /// <param name="id">Номер дня.</param>
        /// <param name="lessons">Уроки.</param>
        public Day(int id, string dayName, Lesson[] lessons)
        {
            Id = id;
            DayName = dayName;
            Lessons = lessons;
        }
    }
}
