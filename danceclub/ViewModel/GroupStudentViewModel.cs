using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class GroupStudentViewModel : ViewModelBase
    {
        private readonly GroupStudent _groupStudent;

        public int StudentId => _groupStudent.StudentId;
        public int GroupId => _groupStudent.GroupId;
        public GroupStudentViewModel(GroupStudent groupStudent)
        {
            _groupStudent = groupStudent;
        }
    }
}
