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
    public class AddDanceTypeCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddDanceTypeViewModel _addDanceTypeViewModel;

        public AddDanceTypeCommand(AddDanceTypeViewModel addDanceTypeViewModel, DataContext context)
        {
            _context = context;
            _addDanceTypeViewModel = addDanceTypeViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                DanceType danceType = new DanceType()
                {
                    Name = _addDanceTypeViewModel.Name,
                };

                _context.DanceTypes.Add(danceType);
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
