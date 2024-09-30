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
    public class AddScheduleViewModel : ViewModelBase
    {
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); OnPropertyChanged(nameof(CanAddSchedule)); }
        }

        private DateTime _duration;
        public DateTime Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged(nameof(Duration)); OnPropertyChanged(nameof(CanAddSchedule)); }
        }

        private int _teacheId;
        public int TeacherId
        {
            get { return _teacheId; }
            set { _teacheId = value; OnPropertyChanged(nameof(TeacherId)); OnPropertyChanged(nameof(CanAddSchedule)); }
        }

        private int _danceTypeId;
        public int DanceTypeId
        {
            get { return _danceTypeId; }
            set { _danceTypeId = value; OnPropertyChanged(nameof(DanceTypeId)); OnPropertyChanged(nameof(CanAddSchedule)); }
        }

        public bool CanAddSchedule => !string.IsNullOrEmpty(_date) && !string.IsNullOrEmpty(_duration.ToString()) && _teacheId > 0 && _danceTypeId > 0;


        public ICommand AddScheduleCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddScheduleViewModel(ModalNavigationStore modalNavigationStore, DataContext context)
        {
            AddScheduleCommand = new AddScheduleCommand(this, context);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
        }
    }
}
