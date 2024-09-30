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
    public class AddStudentsCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddStudentsViewModel _addStudentsViewModel;

        public AddStudentsCommand(AddStudentsViewModel addStudentsViewModel, DataContext context)
        {
            _context = context;
            _addStudentsViewModel = addStudentsViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            { 
            Students students = new Students()
            {
                Name = _addStudentsViewModel.Name,
                Surname = _addStudentsViewModel.Surname,
                Email = _addStudentsViewModel.Email,
                Phone = _addStudentsViewModel.Phone,
            };

            _context.Students.Add(students);
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
