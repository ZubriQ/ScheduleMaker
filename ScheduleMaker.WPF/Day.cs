namespace ScheduleMaker.WPF
{
    public class Day
    {
        /// <summary>
        /// Номер дня.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уроки дня.
        /// </summary>
        public Lesson[] Lessons { get; set; }

        /// <summary>
        /// Конструктор дня.
        /// </summary>
        /// <param name="id">Номер дня.</param>
        /// <param name="lessons">Уроки.</param>
        public Day(int id, Lesson[] lessons)
        {
            Id = id;
            Lessons = lessons;
        }
    }
}
