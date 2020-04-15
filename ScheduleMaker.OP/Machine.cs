using ScheduleMaker.OP.School;

namespace ScheduleMaker.OP
{
    /// <summary>
    /// Учитель (машина).
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// Ключ 
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Предмет, который ведет учитель.
        /// </summary>
        private Subject subject { get; }

        /// <summary>
        /// Список работ / расписание.
        /// </summary>
        private Job[] lessons { get; }

        /// <summary>
        /// Конструктор учителя (машины).
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предмет, который ведет учитель.</param>
        public Machine(int id, Subject subject)
        {
            this.id = id;
            this.subject = subject;
            lessons = new Job[60];
        }

        /// <summary>
        /// Проверяет поместится ли заданное количество Уроков у Учителя.
        /// </summary>
        /// <param name="lessonsCount">Количество Уроков одного вида.</param>
        /// <returns>Занят ли учитель.</returns>
        public bool CanHandle(int lessonsCount)
        {
            return lessonsCount > (48 - lessonsCount);
        }

        public void ClearLessons()
        {
            for (int i = 0; i < 60; i++)
            {
                lessons[i] = null;
            }
        }

        public int Id => id;

        public Subject Subject => subject;

        public Job[] Lessons => lessons;
    }
}
