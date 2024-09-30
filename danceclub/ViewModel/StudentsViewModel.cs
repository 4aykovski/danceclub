using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        private readonly Students _student;

        public int Id => _student.Id;
        public string Name => _student.Name;
        public string Phone => _student.Phone;
        public string Surname => _student.Surname;
        public string Email => _student.Email;

        public StudentsViewModel(Students student)
        {
            _student = student;
        }
    }
}
