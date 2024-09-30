using danceclub.Models;
using danceclub.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace danceclub.Commands
{
    public class LoadReportCommand : CommandBase
    {
        private readonly ReportViewModel _reportViewModel;

        private readonly DataContext _context;

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ReportViewModel.SelectedReport))
            {
                OnCanExecuteChanged();
            }
        }

        public LoadReportCommand(ReportViewModel reportViewModel, DataContext context)
        {
            _reportViewModel = reportViewModel;
            _context = context;

            _reportViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_reportViewModel.SelectedReport) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            string selectedReport = _reportViewModel.SelectedReport;

            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("select report", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ObservableCollection<Object> loadedReport = new ObservableCollection<Object>();

            switch (selectedReport)
            {
                case "Расписание учеников":
                {
                    var report = (from students in _context.Students
                                  join groupStudent in _context.GroupStudents on students.Id equals groupStudent.StudentId
                                  join scheduleStundet in _context.StudentSchedules on students.Id equals scheduleStundet.StudentId
                                  select new
                                  {
                                      Name = students.Name,
                                      Surname = students.Surname,
                                      groupName = groupStudent.Groups.Id,
                                      Date = scheduleStundet.Schedules.Date,
                                      Duration = scheduleStundet.Schedules.Duration,
                                      DanceType = scheduleStundet.Schedules.DanceType.Name,
                                  }).ToList();


                        foreach (var reportItem in report)
                    {
                        loadedReport.Add(reportItem);
                    }

                    break;
                }
                case "Расписание учителей":
                    {
                        var report = (from teacher in _context.Teachers
                                      join Schedule in _context.Schedules on teacher.Id equals Schedule.TeacherId
                                      select new
                                      {
                                          Name = teacher.Name,
                                          Surname = teacher.Surname,
                                          Date = Schedule.Date,
                                          Duration = Schedule.Duration,
                                          DanceType = Schedule.DanceType.Name,
                                      }).ToList();

                        foreach (var reportItem in report)
                        {
                            loadedReport.Add(reportItem);
                        }

                        break;
                    }
                default:
                    MessageBox.Show("wrong report", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

            }

            _reportViewModel.DataGrid = loadedReport;
        }
    }
}
