using danceclub.Models;
using danceclub.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace danceclub.Commands
{
    public class LoadHandbookCommand : CommandBase
    {
        private readonly HandbookViewModel _handbookViewModel;

        private readonly DataContext _context;

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandbookViewModel.SelectedHandbook))
            {
                OnCanExecuteChanged();
            }
        }

        public LoadHandbookCommand(HandbookViewModel handbookViewModel, DataContext context)
        {
            _handbookViewModel = handbookViewModel;
            _context = context;

            _handbookViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_handbookViewModel.SelectedHandbook) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            string selectedHandbook = _handbookViewModel.SelectedHandbook;

            if (string.IsNullOrEmpty(selectedHandbook))
            {
                MessageBox.Show("handbook don't selected", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ObservableCollection<Object> loadedReport = new ObservableCollection<Object>();

            switch (selectedHandbook) {
                case "Teacher":
                    {
                        List<Teacher> report = _context.Teachers.ToList();

                        foreach (Teacher reportItem in report)
                        {
                            TeacherViewModel teacherViewModel = new TeacherViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "DanceType":
                    {
                        List<DanceType> report = _context.DanceTypes.ToList();

                        foreach (DanceType reportItem in report)
                        {
                            DanceTypeViewModel teacherViewModel = new DanceTypeViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "GroupDanceType":
                    {
                        List<GroupDanceType> report = _context.GroupDanceTypes.ToList();

                        foreach (GroupDanceType reportItem in report)
                        {
                            GroupDanceTypeViewModel teacherViewModel = new GroupDanceTypeViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "Groups":
                    {
                        List<Groups> report = _context.Groups.ToList();

                        foreach (Groups reportItem in report)
                        {
                            GroupsViewModel teacherViewModel = new GroupsViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "GroupStudent":
                    {
                        List<GroupStudent> report = _context.GroupStudents.ToList();

                        foreach (GroupStudent reportItem in report)
                        {
                            GroupStudentViewModel teacherViewModel = new GroupStudentViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "Schedule":
                    {
                        List<Schedule> report = _context.Schedules.ToList();

                        foreach (Schedule reportItem in report)
                        {
                            ScheduleViewModel teacherViewModel = new ScheduleViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "Students":
                    {
                        List<Students> report = _context.Students.ToList();

                        foreach (Students reportItem in report)
                        {
                            StudentsViewModel teacherViewModel = new StudentsViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                case "StudentSchedule":
                    {
                        List<StudentSchedule> report = _context.StudentSchedules.ToList();

                        foreach (StudentSchedule reportItem in report)
                        {
                            StudentSchedulteViewModel teacherViewModel = new StudentSchedulteViewModel(reportItem);
                            loadedReport.Add(teacherViewModel);
                        }

                        break;
                    }
                default:
                    MessageBox.Show("wrong handbook", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
            }

            _handbookViewModel.DataGrid = loadedReport;
        }
    }
}
