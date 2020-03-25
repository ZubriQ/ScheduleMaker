namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Учебный план.
    /// </summary>
    public class Syllabus
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Название класса.
        /// </summary>
        private string className { get; }

        /// <summary>
        /// Уроки.
        /// </summary>
        private Subject[] subjects { get; }

        /// <summary>
        /// Учителя.
        /// </summary>
        private Teacher[] teachers { get; }

        /// <summary>
        /// Конструктор Учебного плана.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="className">Наименование класса.</param>
        /// <param name="subjects">Уроки.</param>
        /// <param name="teachers">Учителя.</param>
        public Syllabus(int id, string className, Subject[] subjects, Teacher[] teachers)
        {
            this.id = id;
            this.className = className;
            this.subjects = subjects;
            this.teachers = teachers;
        }

        public int Id => id;

        public string ClassName => className;

        public Subject[] Subjects => subjects;

        public Teacher[] Teachers => teachers;
    }
}
