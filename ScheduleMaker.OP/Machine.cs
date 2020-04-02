using ScheduleMaker.OP.School;
using System.Collections.Generic;
using System.Text;

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
        private Dictionary<sbyte, Job>[] schedule { get; }

        /// <summary>
        /// Количество уроков в матрице <see cref="schedule"/>.
        /// </summary>
        public byte LessonsCount { get; set; }

        /// <summary>
        /// Конструктор учителя (машины).
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предмет, который ведет учитель.</param>
        public Machine(int id, Subject subject)
        {
            this.id = id;
            this.subject = subject;
            // 6 дней, максимально возможное кол-во уроков 8
            schedule = new Dictionary<sbyte, Job>[6];
            for (int i = 0; i < schedule.Length; i++)
            {
                schedule[i] = new Dictionary<sbyte, Job>(8);
            }
            LessonsCount = 0;
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


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < schedule.Length; i++)
            {
                result.Append(i + 1);
                result.Append(" день, уроки: ");
                result.Append(schedule[i].Count);
                result.Append("\n  ");
                foreach (KeyValuePair<sbyte, Job> job in schedule[i])
                {
                    result.Append("№:");
                    result.Append(job.Key + 1);
                    result.Append(" ");
                    result.Append(job.Value.Subject.Name);
                    result.Append(" ");
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        public int Id => id;

        public Subject Subject => subject;

        public Dictionary<sbyte, Job>[] Schedule => schedule;
    }
}
