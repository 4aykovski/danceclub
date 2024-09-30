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
    public class AddDanceTypeViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); OnPropertyChanged(nameof(CanAddDanceType)); }
        }

        public bool CanAddDanceType => !string.IsNullOrEmpty(_name);


        public ICommand AddDanceTypeCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDanceTypeViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddDanceTypeCommand = new AddDanceTypeCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
