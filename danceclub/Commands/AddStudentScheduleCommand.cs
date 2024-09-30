using danceclub.Models;
using danceclub.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace danceclub.Commands
{
    public class AddStudentScheduleCommand : CommandBase
    {

        private readonly DataContext _context;
        private readonly AddStudentScheduleViewModel _addStudentScheduleViewModel;

        public AddStudentScheduleCommand(AddStudentScheduleViewModel addStudentScheduleViewModel, DataContext context)
        {
            _context = context;
            _addStudentScheduleViewModel = addStudentScheduleViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            { 
            StudentSchedule studentSchedule = new StudentSchedule()
            {
                ScheduleId = _addStudentScheduleViewModel.ScheduleId,
                StudentId = _addStudentScheduleViewModel.StudentId,
            };

            _context.StudentSchedules.Add(studentSchedule);
            _context.SaveChanges();
            MessageBox.Show("Successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
            catch (Exception ex)
            { 
                MessageBox.Show($"something went wrong. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _context.ChangeTracker.Clear();

            }
        }
    }
}
