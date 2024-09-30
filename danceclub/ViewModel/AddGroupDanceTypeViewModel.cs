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
    public class AddGroupDanceTypeViewModel : ViewModelBase
    {
        private int _danceTypeId;
        public int DanceTypeId
        {
            get { return _danceTypeId; }
            set { _danceTypeId = value; OnPropertyChanged(nameof(DanceTypeId)); OnPropertyChanged(nameof(CanAddGroupDanceType)); }
        }

        private int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; OnPropertyChanged(nameof(GroupId)); OnPropertyChanged(nameof(CanAddGroupDanceType)); }
        }

        public bool CanAddGroupDanceType => _danceTypeId > 0 && _groupId > 0;



        public ICommand AddGroupsDanceTypeCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddGroupDanceTypeViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddGroupsDanceTypeCommand = new AddGroupDanceTypeCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
