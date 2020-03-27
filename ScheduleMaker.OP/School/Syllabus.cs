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
        /// Работы (уроки).
        /// </summary>
        private Job[] jobs { get; }

        /// <summary>
        /// Количество уроков в неделю.
        /// </summary>
        private int jobsCount { get; }

        /// <summary>
        /// Расписание.
        /// </summary>
        private string[,] schedule { get; }

        /// <summary>
        /// Количество дней в неделю.
        /// </summary>
        private byte daysCount { get; }

        /// <summary>
        /// Конструктор Учебного плана.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="className">Наименование класса.</param>
        /// <param name="subjects">Уроки.</param>
        /// <param name="teachers">Учителя.</param>
        /// <param name="daysCount">5 или 6 дневный план.</param>
        public Syllabus(int id, string className, Subject[] subjects, Teacher[] teachers, byte daysCount)
        {
            this.id = id;
            this.className = className;
            this.subjects = subjects;
            this.teachers = teachers;
            this.daysCount = daysCount;
            this.jobsCount = calculateLessonsCount();
            jobs = new Job[jobsCount];
            initializeJobs();
            schedule = new string[6, 8];
            initializeSchedule();
        }

        /// <summary>
        /// Преобразует уроки в работы.
        /// </summary>
        private void initializeJobs()
        {
            int index = 0;
            for (int i = 0; i < Subjects.Length; i++)
            {
                for (int j = 0; j < Subjects[i].Count; j++)
                {
                    Job newJob = new Job(index,
                        Subjects[i].Name,
                        Subjects[i].Difficulty,
                        id);

                    jobs[index] = newJob;
                    index++;
                }
            }
        }

        /// <summary>
        /// Общее количество уроков.
        /// </summary>
        /// <returns>Общее количество уроков.</returns>
        private int calculateLessonsCount()
        {
            int sum = 0;
            for (int i = 0; i < Subjects.Length; i++)
            {
                sum += Subjects[i].Count;
            }
            return sum;
        }

        /// <summary>
        /// Инициализация матрицы расписания.
        /// </summary>
        private void initializeSchedule()
        {
            for (byte i = 0; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    schedule[i, j] = null;
                }
            }
        }

        public int Id => id;

        public string ClassName => className;

        public Subject[] Subjects => subjects;

        public Teacher[] Teachers => teachers;

        public Job[] Jobs => jobs;

        public string[,] Schedule => schedule;

        public byte DaysCount => daysCount;

        public int JobsCount => jobsCount;
    }
}
