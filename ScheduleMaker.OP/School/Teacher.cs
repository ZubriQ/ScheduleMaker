namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Учитель.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Предмет, который ведет учитель.
        /// </summary>
        private string subjectName { get; }

        /// <summary>
        /// Учебный план, в который входит учитель.
        /// </summary>
        private int syllabusId { get; }

        /// <summary>
        /// Конструктор учителя.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subjectName">Название урока.</param>
        public Teacher(int id, string subjectName, int syllabusId)
        {
            this.id = id;
            this.subjectName = subjectName;
            this.syllabusId = syllabusId;
        }

        public Teacher(int id, string subjectName)
        {
            this.id = id;
            this.subjectName = subjectName;
        }

        public int Id => id;

        public string SubjectName => subjectName;

        public int SyllabusId => syllabusId;
    }
}
