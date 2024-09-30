using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class TeacherViewModel : ViewModelBase
    {
        private readonly Teacher _teacher;

        public int Id => _teacher.Id;
        public string Name => _teacher.Name;
        public string Surname => _teacher.Surname;
        public string Phone => _teacher.Phone;
        public string Email => _teacher.Email;
        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher;
        }
    }
}
