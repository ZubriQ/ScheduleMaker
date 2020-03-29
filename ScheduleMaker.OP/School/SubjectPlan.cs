namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// План предмета у Учебного плана.
    /// </summary>
    public class SubjectPlan
    {
        /// <summary>
        /// Предмет.
        /// </summary>
        private Subject subject { get; }

        /// <summary>
        /// Количество уроков в неделю.
        /// </summary>
        private int count { get; }

        /// <summary>
        /// Конструктор Плана предмета в Учебном плане.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предмет.</param>
        /// <param name="count">Количество уроков.</param>
        public SubjectPlan(Subject subject, int count)
        {
            this.subject = subject;
            this.count = count;
        }

        public Subject Subject => subject;

        public int Count => count;
    }
}
