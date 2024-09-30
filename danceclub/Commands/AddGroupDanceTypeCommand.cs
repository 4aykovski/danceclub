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
    public class AddGroupDanceTypeCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddGroupDanceTypeViewModel _addGroupDanceTypeViewModel;

        public AddGroupDanceTypeCommand(AddGroupDanceTypeViewModel addGroupDanceTypeViewModel, DataContext context)
        {
            _context = context;
            _addGroupDanceTypeViewModel = addGroupDanceTypeViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {

            
            GroupDanceType groupDanceType = new GroupDanceType()
            {
               GroupId = _addGroupDanceTypeViewModel.GroupId,
               DanceTypeId = _addGroupDanceTypeViewModel.DanceTypeId
            };

            _context.GroupDanceTypes.Add(groupDanceType);
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
