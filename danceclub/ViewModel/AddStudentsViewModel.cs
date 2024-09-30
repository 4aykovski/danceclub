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
    public class AddStudentsViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(nameof(Surname)); OnPropertyChanged(nameof(CanAddStudent)); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); OnPropertyChanged(nameof(CanAddStudent)); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); OnPropertyChanged(nameof(CanAddStudent)); }
        }

        public bool CanAddStudent => !string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_surname) && !string.IsNullOrEmpty(_phone) && !string.IsNullOrEmpty(_email);


        public ICommand AddStudentCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddStudentsViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddStudentCommand = new AddStudentsCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
