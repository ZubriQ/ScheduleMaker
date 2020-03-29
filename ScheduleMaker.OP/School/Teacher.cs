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
        private Subject subject { get; } // Пока что Учитель ведет только 1 предмет

        //private string teacherName

        /// <summary>
        /// Учитель
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предмет.</param>
        public Teacher(int id, Subject subject)
        {
            this.id = id;
            this.subject = subject;
        }

        public int Id => id;

        public Subject Subject => subject;
    }
}
