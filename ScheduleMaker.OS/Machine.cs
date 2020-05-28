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
        public Subject[] Subjects { get; set; }

        /// <summary>
        /// Список работ / расписание.
        /// </summary>
        public Job[] Lessons { get; set; }

        /// <summary>
        /// Конструктор учителя (машины).
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="subject">Предметы, который ведет учитель.</param>
        public Machine(int id, Subject[] subjects)
        {
            this.id = id;
            Subjects = subjects;
            // TODO: не инициализировать в Syllabus, т.к. не используются там
            Lessons = new Job[60];
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
                Lessons[i] = null;
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
                for (int i = 0; i < Subjects.Length; i++)
                {
                    result += Subjects[i].Name;
                    if (i < Subjects.Length - 1)
                    {
                        result += ", ";
                    }
                }
                return result;
            }
        }

        public int Id => id;
    }
}
