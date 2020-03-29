using ScheduleMaker.OP.School;

namespace ScheduleMaker.OP
{
    /// <summary>
    /// Урок (работа).
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Предмет.
        /// </summary>
        private Subject subject { get; }

        /// <summary>
        /// Учебный план, к которому пренадлежит урок.
        /// </summary>
        private int syllabusId { get; } // пока что не используется

        /// <summary>
        /// Конструктор урока (работы).
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предмет.</param>
        /// <param name="syllabusId">Ключ Учебного плана.</param>
        public Job(int id, Subject subject, int syllabusId)
        {
            this.id = id;
            this.subject = subject;
            this.syllabusId = syllabusId;
        }

        public int Id => id;

        public Subject Subject => subject;

        public int SyllabusId => syllabusId;

        public override string ToString()
        {
            return $"id:{id}, предмет:{subject}, сложность:{subject.Difficulty}.";
        }
    }
}
