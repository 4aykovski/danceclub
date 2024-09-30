using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly Schedule _schedule;

        public int Id => _schedule.Id;
        public string Date => _schedule.Date;
        public DateTime Duration => _schedule.Duration;
        public int TeacherId => _schedule.TeacherId;
        public int DanceTypeId => _schedule.DanceTypeId;

        public ScheduleViewModel(Schedule schedule)
        {
            _schedule = schedule;
        }
    }
}
