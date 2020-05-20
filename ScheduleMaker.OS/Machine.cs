using ScheduleMaker.OS.School;

namespace ScheduleMaker.OS
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
        /// Предметы, который ведет учитель.
        /// </summary>
        public Subject[] Subject { get; set; }

        /// <summary>
        /// Список работ / расписание.
        /// </summary>
        private Job[] lessons { get; }

        /// <summary>
        /// Конструктор учителя (машины).
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предметы, который ведет учитель.</param>
        public Machine(int id, Subject[] subject)
        {
            this.id = id;
            Subject = subject;
            // TODO: не инициализировать в Syllabus, т.к. не используются там
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

        /// <summary>
        /// Возвращает список всех предметов
        /// </summary>
        public string AllSubjects
        {
            get
            {
                string result = "";
                for (int i = 0; i < Subject.Length; i++)
                {
                    result += Subject[i].Name;
                    if (i < Subject.Length - 1)
                    {
                        result += ", ";
                    }
                }
                return result;
            }
        }

        public int Id => id;

        public Job[] Lessons => lessons;
    }
}
