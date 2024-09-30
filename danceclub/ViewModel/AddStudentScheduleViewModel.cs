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
    public class AddStudentScheduleViewModel : ViewModelBase
    {
        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set { _studentId = value; OnPropertyChanged(nameof(StudentId)); OnPropertyChanged(nameof(CanAddStudentSchedule)); }
        }

        private int _scheduleId;
        public int ScheduleId
        {
            get { return _scheduleId; }
            set { _scheduleId = value; OnPropertyChanged(nameof(ScheduleId)); OnPropertyChanged(nameof(CanAddStudentSchedule)); }
        }

        public bool CanAddStudentSchedule => _studentId > 0 && _scheduleId > 0;


        public ICommand AddStudentScheduleCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddStudentScheduleViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddStudentScheduleCommand = new AddStudentScheduleCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
