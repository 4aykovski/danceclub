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
    public class AddTeacherCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddTeacherViewModel _addTeacherViewModel;

        public AddTeacherCommand(AddTeacherViewModel addTeacherViewModel, DataContext context)
        {
            _context = context;
            _addTeacherViewModel = addTeacherViewModel;
        }
        public override void Execute(object? parameter)
        {
            try 
            { 
            Teacher teacher = new Teacher()
            {
                Name = _addTeacherViewModel.Name,
                Surname = _addTeacherViewModel.Surname,
                Email = _addTeacherViewModel.Email,
                Phone = _addTeacherViewModel.Phone,
            };

            _context.Teachers.Add(teacher);
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
