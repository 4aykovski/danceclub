using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class StudentSchedulteViewModel : ViewModelBase
    {
        private readonly StudentSchedule _studentSchedule;

        public int StudentId => _studentSchedule.StudentId;
        public int ScheduleId => _studentSchedule.ScheduleId;

        public StudentSchedulteViewModel(StudentSchedule studentSchedule)
        {
            _studentSchedule = studentSchedule;
        }
    }
}
