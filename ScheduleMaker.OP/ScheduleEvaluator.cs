using System.Collections.Generic;

namespace ScheduleMaker.OP
{
    public class ScheduleEvaluator
    {
        /// <summary>
        /// Расписание, которое нужно оценить
        /// </summary>
        private List<Schedule> Schedules;

        public ScheduleEvaluator()
        {
            Schedules = null;
        }

        /// <summary>
        /// Оценить расписания.
        /// </summary>
        /// <returns>Возвращает оценку расписания.</returns>
        public int EstimateSchedule(List<Schedule> schedules)
        {
            Schedules = schedules;
            return FindGapsInAllSchedules();
        }

        /// <summary>
        /// Подсчитать кол-во пробелов во всех расписаниях.
        /// </summary>
        /// <returns>Возвращает кол-во пробелов.</returns>
        public int FindGapsInAllSchedules()
        {
            int gapsCount = 0;
            for (int i = 0; i < Schedules.Count; i++)
            {
                FindGaps(i, ref gapsCount);
            }
            return gapsCount;
        }

        /// <summary>
        /// Находит пробелы в одном расписании.
        /// </summary>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        /// <param name="gapsCount">Кол-во пробелов.</param>
        private void FindGaps(int scheduleId, ref int gapsCount)
        {
            int[] left = new int[6];
            int[] right = new int[6];
            for (byte day = 0; day < 6; day++)
            {
                FindFirstLesson(ref left, day, scheduleId);
                FindLastLesson(ref right, day, scheduleId);
            }
            CalculateGaps(left, right, ref gapsCount, scheduleId);
        }

        /// <summary>
        /// Узнать индекс начального урока в дне.
        /// </summary>
        /// <param name="left">Массив со значением для каждого дня. Индекс самого левого урока.</param>
        /// <param name="day">День.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void FindFirstLesson(ref int[] left, byte day, int scheduleId)
        {
            for (byte job = 0; job < 10; job++)
            {
                if (Schedules[scheduleId].Lessons[day + (job * 6)] != null)
                {
                    left[day] = day + job * 6;
                    break;
                }
            }
        }

        /// <summary>
        /// Узнать индекс последнего урока в дне.
        /// </summary>
        /// <param name="right">Массив со значением для каждого дня. Индекс самого правого урока.</param>
        /// <param name="day">День.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void FindLastLesson(ref int[] right, byte day, int scheduleId)
        {
            for (sbyte job = 9; job >= 0; job--)
            {
                if (Schedules[scheduleId].Lessons[day + (job * 6)] != null)
                {
                    right[day] = day + job * 6;
                    break;
                }
            }
        }

        /// <summary>
        /// Подсчет пробелов в каждом дне между/>
        /// </summary>
        /// <param name="left">Левое значение.</param>
        /// <param name="right">Правое значение.</param>
        /// <param name="gapsCount">Кол-во пробелов.</param>
        /// <param name="scheduleId">Расписание, в котором идет подсчет.</param>
        private void CalculateGaps(int[] left, int[] right, ref int gapsCount, int scheduleId)
        {
            for (int day = 0; day < 6; day++)
            {
                for (int job = left[day]; job < right[day]; job += 6)
                {
                    if (Schedules[scheduleId].Lessons[job] == null)
                    {
                        gapsCount++;
                    }
                }
            }
        }
    }
}
