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
    public class AddScheduleCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddScheduleViewModel _addScheduleViewModel;

        public AddScheduleCommand(AddScheduleViewModel addScheduleViewModel, DataContext context)
        {
            _context = context;
            _addScheduleViewModel = addScheduleViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            { 
            Schedule schedule = new Schedule()
            {
                Date = _addScheduleViewModel.Date,
                Duration = _addScheduleViewModel.Duration,
                TeacherId = _addScheduleViewModel.TeacherId,
                DanceTypeId = _addScheduleViewModel.DanceTypeId,
            };

            _context.Schedules.Add(schedule);
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
