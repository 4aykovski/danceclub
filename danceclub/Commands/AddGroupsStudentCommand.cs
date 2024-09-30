using danceclub.Models;
using danceclub.ViewModel;
using System.Windows;


namespace danceclub.Commands
{
    public class AddGroupsStudentCommand : CommandBase
    {
        private readonly DataContext _context;
        private readonly AddGroupsStudentViewModel _addGroupsStudentViewModel;

        public AddGroupsStudentCommand(AddGroupsStudentViewModel addGroupsStudentViewModel, DataContext context)
        {
            _context = context;
            _addGroupsStudentViewModel = addGroupsStudentViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            { 
            GroupStudent groupStudents = new GroupStudent()
            {
                GroupId = _addGroupsStudentViewModel.GroupId,
                StudentId = _addGroupsStudentViewModel.StudentId,
            };

            _context.GroupStudents.Add(groupStudents);
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
