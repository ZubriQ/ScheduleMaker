using System.Collections.Generic;

namespace ScheduleMaker.OP
{
    public class Job
    {
        /// <summary>
        /// Позиция.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Название работы.
        /// (Вид урока)
        /// </summary>
        private string jobName { get; }

        /// <summary>
        /// Сложность работы (урока).
        /// </summary>
        private int jobDifficulty { get; }

        private int syllabusId { get; }

        public Job(int id, string jobName, int jobDifficulty, int syllabusId)
        {
            this.id = id;
            this.jobName = jobName;
            this.jobDifficulty = jobDifficulty;
            this.syllabusId = syllabusId;
        }

        public int Id => id;

        public string JobName => jobName;

        public int JobDifficulty => jobDifficulty;

        public int SyllabusId => syllabusId;

        public override string ToString()
        {
            return $"id:{id}, предмет:{jobName}, сложность:{jobDifficulty}.";
        }

        /*
        /// <summary>
        /// Требуемые операции (над каждой машиной? (возможно только 1 операция будет)).
        /// </summary>
        private List<int> operations { get; }

        /// <summary>
        /// Завершенные операции.
        /// </summary>
        private List<int> processedEmptyJobs { get; }

        /// <summary>
        /// Время / Номер машины
        /// </summary>
        private Dictionary<int, int> processed { get; }

        public List<int> GetOperations => operations;

        public List<int> GetProcessedOperations => processedEmptyJobs;

        public Dictionary<int, int> GetProcessed => processed;*/
    }
}
