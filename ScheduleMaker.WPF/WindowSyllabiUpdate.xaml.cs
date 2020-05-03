using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScheduleMaker.WPF
{
    /// <summary>
    /// Логика взаимодействия для WindowSyllabiUpdate.xaml
    /// </summary>
    public partial class WindowSyllabiUpdate : Window
    {
        Syllabi Syllabus;
        List<Subjects> Subjects;
        List<StudyLoad> StudyLoads;
        int StudyLoadCount;
        public WindowSyllabiUpdate(Syllabi syllabus)
        {
            InitializeComponent();
            Syllabus = syllabus;
            DataContext = Syllabus;

            InitializeSubjects();
            StudyLoads = App.DB.StudyLoad.Where(s => s.syllabus_id == syllabus.syllabus_id).ToList();
            DataGrid1.ItemsSource = StudyLoads;
            StudyLoadCount = CalculateLoad(StudyLoads);
            SubjectsCountLabel.Content = DataGrid1.Items.Count;
            SubjectsLoadLabel.Content = StudyLoadCount;
        }

        private void InitializeSubjects()
        {
            var subjects = Syllabus.StudyLoad.ToList();
            Subjects = new List<Subjects>(App.DB.Subjects.OrderBy(s => s.name).ToList());
            foreach(var s in subjects)
            {
                Subjects.Remove(s.Subjects);
            }
            DataGrid2.ItemsSource = Subjects;
        }

        private int CalculateLoad(List<StudyLoad> studyLoad)
        {
            int sum = 0;
            foreach (var s in studyLoad)
            {
                sum += s.lessons_count;
            }
            return sum;
        }

        private void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null && LessonsCountTextBox.Text != "")
            {
                StudyLoad studyLoad = new StudyLoad
                {
                    syllabus_id = Syllabus.syllabus_id,
                    subject_id = (DataGrid2.SelectedItem as Subjects).subject_id,
                    quarter = 1,
                    lessons_count = Convert.ToInt32(LessonsCountTextBox.Text),
                    Subjects = DataGrid2.SelectedItem as Subjects
                };
                StudyLoads.Add(studyLoad);
                Subjects.Remove(DataGrid2.SelectedItem as Subjects);

                LessonsCountTextBox.Text = "";
                SubjectsCountLabel.Content = DataGrid1.Items.Count;
                StudyLoadCount += studyLoad.lessons_count;

                RefreshTables();
            }
        }

        private void RemoveSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                Subjects.Add((DataGrid1.SelectedItem as StudyLoad).Subjects);
                StudyLoads.Remove(DataGrid1.SelectedItem as StudyLoad);
                SubjectsCountLabel.Content = DataGrid1.Items.Count;
                StudyLoadCount -= (DataGrid1.SelectedItem as StudyLoad).lessons_count;
                RefreshTables();
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (YearTextBox.Text != "" && DescriptionTextBox.Text != "" && CreatorsTextBox.Text != "")
            {
                Syllabus.date_of_creation = DateTime.Now;
                App.DB.SaveChanges();
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTables()
        {
            DataGrid2.ItemsSource = null;
            DataGrid2.ItemsSource = Subjects;
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = StudyLoads;
        }
    }
}
