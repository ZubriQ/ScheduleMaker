using System.Collections.Generic;
using System.Text;

namespace ScheduleMaker.OP
{
    public class Machine
    {
        /// <summary>
        /// Номер машины.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Какой предмет ведет учитель.
        /// </summary>
        private string subjectName { get; }

        /// <summary>
        /// Список работ / расписание.
        /// </summary>
        private Dictionary<int, Job>[] schedule { get; }

        public Machine(int id, string subjectName)
        {
            this.id = id;
            this.subjectName = subjectName;
            // 6 дней, максимально возможное кол-во уроков 8
            schedule = new Dictionary<int, Job>[6];
            for (int i = 0; i < schedule.Length; i++)
            {
                schedule[i] = new Dictionary<int, Job>(8);
            }
            /*
            emptyJobs = new List<int>[6];
            for (int i = 0; i < emptyJobs.Length; i++)
            {
                emptyJobs[i] = new List<int>(8);
            }*/
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
                    result.Append(" предмет: ");
                    result.Append(job.Value.JobName);
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        public int Id => id;

        public string SubjectName => subjectName;

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
