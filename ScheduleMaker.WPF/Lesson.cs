namespace ScheduleMaker.WPF
{
    public class Lesson
    {
        /// <summary>
        /// Название урока.
        /// </summary>
        public string Name { get; set; }

        public Lesson(string name)
        {
            Name = name;
        }
    }
}
