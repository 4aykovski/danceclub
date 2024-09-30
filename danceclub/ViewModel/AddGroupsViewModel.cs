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
    public class AddGroupsViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); OnPropertyChanged(nameof(CanAddGroups)); }
        }

        public bool CanAddGroups => !string.IsNullOrEmpty(_name);


        public ICommand AddGroupsCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddGroupsViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddGroupsCommand = new AddGroupsCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
