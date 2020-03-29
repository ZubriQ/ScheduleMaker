namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Уникальный ключ.
        /// </summary>
        private int id { get; }

        /// <summary>
        /// Название предмета.
        /// </summary>
        private string name { get; }

        /// <summary>
        /// Сложность предмета.
        /// </summary>
        private int difficulty { get; } // пока что не используется

        /// <summary>
        /// Конструктор предмета.
        /// </summary>
        /// <param name="id">Уникальный ключ.</param>
        /// <param name="name">Название предмета.</param>
        /// <param name="difficulty">Сложность предмета.</param>
        public Subject(int id, string name, int difficulty)
        {
            this.id = id;
            this.name = name;
            this.difficulty = difficulty;
        }

        public int Id => id;

        public string Name => name;

        public int Difficulty => difficulty;
    }
}
