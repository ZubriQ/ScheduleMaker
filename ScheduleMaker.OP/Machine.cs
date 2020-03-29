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
        private Dictionary<int, Job>[] schedule { get; }

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
            schedule = new Dictionary<int, Job>[6];
            for (int i = 0; i < schedule.Length; i++)
            {
                schedule[i] = new Dictionary<int, Job>(8);
            }
            LessonsCount = 0;
        }
        /*
        /// <summary>
        /// Проверяет поместится ли заданное количество Уроков у Учителя.
        /// </summary>
        /// <param name="lessonsCount">Количество Уроков одного вида.</param>
        /// <returns>Занят ли учитель.</returns>
        public bool CanHandle(int lessonsCount)
        {
            int remainingSpace = 0;
            for (byte i = 0; i < 6; i++)
            {
                remainingSpace += schedule[i].Count;
            }
            return lessonsCount > (48 - remainingSpace);
        }*/

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
                foreach (KeyValuePair<int, Job> job in schedule[i])
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

        public Dictionary<int, Job>[] Schedule => schedule;

        /*
        public List<int>[] EmptyJobs => emptyJobs; // не используется.

        /// <summary>
        /// Списки пустых мест.
        /// </summary>
        private List<int>[] emptyJobs { get; } // не используется



        // Зачем это?
        
        private int time { get; }
        public int Time => time;

        /// <summary>
        /// Заполненность Машины.
        /// </summary>
        /// <param name="day">День.</param>
        /// <returns>Возвращает количество выполненных работ.</returns>
        public int CompletedJobs(int day)
        {
            return schedule[day].Count + emptyJobs[day].Count;
        }

        /// <summary>
        /// Завершена ли Работа.
        /// </summary>
        /// <param name="job">Работа (урок).</param>
        /// <returns>Завершена ли работа.</returns>
        public bool IsJobCompleted(Job job)
        {
            return false; // если jobs или emptyJobs содержат job - return true
        }
        */
    }
}
