using ScheduleMaker.ADO;
using ScheduleMaker.OS.School;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для WindowClassroomsCreate.xaml
    /// </summary>
    public partial class WindowClassroomsCrtUpd : Window
    {
        List<Subjects> Subjects = new List<Subjects>(App.DB.Subjects.OrderBy(s => s.name).ToList());
        List<Subjects> ClassroomsSubjects = new List<Subjects>();
        public Classrooms Classroom;

        /// <summary>
        /// Добавление нового кабинета
        /// </summary>
        public WindowClassroomsCrtUpd()
        {
            InitializeComponent();
            InitializeInitialData();
            Title = "Управление кабинетами - Добавлене нового кабинета";
            
            HeaderLabel.Content = "Добавить новый кабинет.";
        }

        /// <summary>
        /// Изменение кабинета
        /// </summary>
        /// <param name="classroom">Кабинет</param>
        public WindowClassroomsCrtUpd(Classrooms classroom)
        {
            InitializeComponent();
            InitializeInitialData();
            DataContext = classroom;
            Classroom = classroom;
            if (classroom.Subjects.Count > 0)
            {
                ClassroomsSubjects.AddRange(classroom.Subjects);
                RemoveExtraTeachers(classroom);
            }
            Title = "Управление кабинетами - Изменение кабинета";
            HeaderLabel.Content = "Изменение кабинета " + classroom.name + '.';
            Border1.BorderBrush = Brushes.Khaki;
        }

        private void InitializeInitialData()
        {
            DataGrid1.ItemsSource = ClassroomsSubjects;
            DataGrid2.ItemsSource = Subjects;
        }

        private void RemoveExtraTeachers(Classrooms classroom)
        {
            foreach (var c in classroom.Subjects.ToList())
            {
                Subjects.Remove(c);
            }
        }

        private void AddElementButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null)
            {
                ClassroomsSubjects.Add(DataGrid2.SelectedItem as Subjects);
                Subjects.Remove(DataGrid2.SelectedItem as Subjects);
                RefreshTables();
            }
        }

        private void RemoveElementButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                Subjects.Add(DataGrid1.SelectedItem as Subjects);
                ClassroomsSubjects.Remove(DataGrid1.SelectedItem as Subjects);
                RefreshTables();
            }
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            // Добавление
            if (nameTextBox.Text != "" && Classroom == null)
            {
                Classroom = new Classrooms();
                Classroom.name = nameTextBox.Text;
                Classroom.Subjects = ClassroomsSubjects;
                App.DB.Classrooms.Add(Classroom);
            }
            // Изменение
            else if (nameTextBox.Text != "" && Classroom != null)
            {
                Classroom.Subjects = ClassroomsSubjects;
                App.DB.Classrooms.AddOrUpdate(Classroom);
            }
            App.DB.SaveChanges();
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshTables()
        {
            DataGrid1.ItemsSource = null;
            DataGrid1.ItemsSource = ClassroomsSubjects;
            DataGrid2.ItemsSource = null;
            DataGrid2.ItemsSource = Subjects;
        }
    }
}
