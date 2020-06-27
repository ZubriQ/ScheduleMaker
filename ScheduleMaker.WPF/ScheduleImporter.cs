using Microsoft.Office.Interop.Excel;
using ScheduleMaker.WPF.Model;
using System;
using System.Collections.Generic;

namespace ScheduleMaker.WPF
{
    public class ScheduleImporter
    {
        Application Excel;
        Workbook WorkBook;
        Worksheet WorkSheet;

        List<ClassSchedule> SchedulesList;
        public ScheduleImporter(List<ClassSchedule> classSchedules)
        {
            if (classSchedules.Count == 0)
            {
                throw new Exception("Отсутствуют расписания. " +
                    "Сначала создайте или загрузите их из БД.");
            }
            Excel = new Application();
            Excel.DisplayAlerts = false;
            Excel.Visible = false;
            WorkBook = Excel.Workbooks.Add(Type.Missing);
            WorkSheet = (Worksheet)WorkBook.ActiveSheet;
            WorkSheet.Name = "Расписание";
            WorkSheet.Cells.Font.Size = 12;
            SchedulesList = classSchedules;
        }

        public void Import()
        {
            CreateTables();
            CreateDays();
            FillInTables();
            // Сохранение
            WorkBook.SaveAs("Расписание " + DateTime.Now.Day + '.' +
                            DateTime.Now.Month + '.' + DateTime.Now.Year + ' ' +
                            DateTime.Now.Hour + '-' + DateTime.Now.Minute + '-' +
                            DateTime.Now.Second + ".xlsx");
            WorkBook.Close();
            Excel.Quit();
        }

        private void FillInTables()
        {
            for (int i = 0; i <SchedulesList.Count; i++)
            {
                int indexOfLesson = 0;
                while (indexOfLesson < 48)
                {
                    AddLessons(ref indexOfLesson, i);
                }
            }
        }

        private void AddLessons(ref int indexOfLesson, int id)
        {
            // день
            for (int day = 0; day < 6; day++)
            {
                // урок
                for (int lsn = 0; lsn < 8; lsn++)
                {
                    if (SchedulesList[id].Schedule[day].Lessons[lsn] != null)
                    {
                        WorkSheet.Cells[3 + lsn, 1 + day + id * 7] =
                            SchedulesList[id].Schedule[day].Lessons[lsn].Name;
                    }
                    else
                    {
                        WorkSheet.Cells[3 + lsn, 1 + day + id * 7] = "----";
                    }
                    indexOfLesson++;
                }
            }
        }

        // Именование дней в таблицах
        private void CreateDays()
        {
            for (int s = 0; s < SchedulesList.Count; s++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    WorkSheet.Cells[2, i + s * 7] = App.DayNames[i];
                }
                WorkSheet.Range[WorkSheet.Cells[1, 1 + s * 7],
                        WorkSheet.Cells[2, 6 + s * 7]].HorizontalAlignment = XlHAlign.xlHAlignCenter;
            }
        }

        // Создание таблиц
        private void CreateTables()
        {
            Borders border;
            for (int i = 1; i <= SchedulesList.Count; i++)
            {
                Range cellRange = WorkSheet.Range[WorkSheet.Cells[1, 1 + ((i - 1) * 7)],
                                                  WorkSheet.Cells[10, 6 + ((i - 1) * 7)]];
                WorkSheet.Range[WorkSheet.Cells[1, 1 + ((i - 1) * 7)],
                                WorkSheet.Cells[1, 6 + ((i - 1) * 7)]].Merge();
                WorkSheet.Cells[1, 1 + ((i - 1) * 7)] = SchedulesList[i - 1].ClassName;
                cellRange.EntireColumn.AutoFit();
                border = cellRange.Borders;
                border.Weight = 2d;
            }
        }
    }
}
