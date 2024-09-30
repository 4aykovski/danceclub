using danceclub.Commands;
using danceclub.Models;
using danceclub.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace danceclub.ViewModel
{
    public class AddGroupsStudentViewModel : ViewModelBase
    {
        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; OnPropertyChanged(nameof(StudentId)); OnPropertyChanged(nameof(CanAddGroupsStudent)); }
        }

        private int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; OnPropertyChanged(nameof(GroupId)); OnPropertyChanged(nameof(CanAddGroupsStudent)); }
        }

        public bool CanAddGroupsStudent => _studentId > 0 && _groupId > 0;


        public ICommand AddGroupsStudentCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddGroupsStudentViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddGroupsStudentCommand = new AddGroupsStudentCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
