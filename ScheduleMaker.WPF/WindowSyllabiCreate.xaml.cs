using ScheduleMaker.ADO;
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
    /// Логика взаимодействия для WindowSyllabiCreate.xaml
    /// </summary>
    public partial class WindowSyllabiCreate : Window
    {
        Syllabi Syllabus;
        List<StudyLoad> StudyLoad = new List<StudyLoad>();
        List<Subjects> Subjects;
        public WindowSyllabiCreate()
        {
            InitializeComponent();
            Syllabus = new Syllabi();
            DataContext = Syllabus;
            Subjects = new List<Subjects>(App.DB.Subjects.OrderBy(s => s.name).ToList());
            DataGrid1.ItemsSource = null;
            DataGrid2.ItemsSource = Subjects;
        }

        private void CalculateLoad()
        {
            int sum = 0;
            foreach(var s in StudyLoad)
            {
                sum += s.lessons_count;
            }
            SubjectsLoadLabel.Content = sum;
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
                StudyLoad.Add(studyLoad);
                Subjects.Remove(DataGrid2.SelectedItem as Subjects);

                LessonsCountTextBox.Text = "";
                SubjectsCountLabel.Content = StudyLoad.Count;
                CalculateLoad();

                RefreshTables();
            }
        }

        private void RemoveSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                StudyLoad.Remove(DataGrid1.SelectedItem as StudyLoad);
                Subjects.Add((DataGrid1.SelectedItem as StudyLoad).Subjects);
                SubjectsCountLabel.Content = StudyLoad.Count;
                CalculateLoad();

                RefreshTables();
            }
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (YearTextBox.Text != "" && DescriptionTextBox.Text != "" && CreatorsTextBox.Text != "")
            {
                Syllabus.date_of_creation = DateTime.Now;
                App.DB.Syllabi.Add(Syllabus);
                App.DB.StudyLoad.AddRange(StudyLoad);
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
            DataGrid2.ItemsSource = Subjects.OrderBy(s => s.name);
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = StudyLoad;
        }
    }
}
