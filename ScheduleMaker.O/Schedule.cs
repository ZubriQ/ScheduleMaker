using ScheduleMaker.OP.School;

namespace ScheduleMaker.OP
{
    /// <summary>
    /// Расписание Учебного плана.
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Ключ Учебного плана.
        /// </summary>
        private int syllabusId { get; }

        /// <summary>
        /// Школьный класс.
        /// </summary>
        public Class Class { get; }

        /// <summary>
        /// Уроки.
        /// </summary>
        private Job[] lessons { get; }

        /// <summary>
        /// Конструктор расписания.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="syllabusId">Ключ Учебного плана.</param>
        /// <param name="class">Школьный класс.</param>
        public Schedule(int id, int syllabusId, Class @class)
        {
            this.id = id;
            this.syllabusId = syllabusId;
            this.Class = @class;
            this.lessons = new Job[60];
        }

        public void ClearLessons()
        {
            for (int i = 0; i < 60; i++)
            {
                lessons[i] = null;
            }
        }

        public int Id => id;

        public int SyllabusId => syllabusId;

        public Job[] Lessons => lessons;
    }
}
