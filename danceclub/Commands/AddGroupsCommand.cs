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
    public class AddGroupsCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddGroupsViewModel _addGroupsViewModel;

        public AddGroupsCommand(AddGroupsViewModel addGroupsViewModel, DataContext context)
        {
            _context = context;
            _addGroupsViewModel = addGroupsViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            { 
            Groups groups = new Groups()
            {
                Name = _addGroupsViewModel.Name,
            };

            _context.Groups.Add(groups);
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
