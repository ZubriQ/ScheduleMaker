namespace ScheduleMaker.OP.School
{
    /// <summary>
    /// Предмет.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Название предмета.
        /// </summary>
        private string name { get; }

        /// <summary>
        /// Сложность предмета.
        /// </summary>
        private int difficulty { get; } // пока что не используется

        /// <summary>
        /// Количество уроков в неделю.
        /// </summary>
        private int count { get; }

        /// <summary>
        /// Конструктор предмета.
        /// </summary>
        /// <param name="name">Название предмета.</param>
        /// <param name="difficulty">Сложность предмета.</param>
        /// <param name="count">Количество уроков.</param>
        public Subject(string name, int difficulty, int count)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.count = count;
        }

        public string Name => name;

        public int Difficulty => difficulty;

        public int Count => count;
    }
}
