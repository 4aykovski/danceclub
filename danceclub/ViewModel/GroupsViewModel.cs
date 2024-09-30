using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class GroupsViewModel : ViewModelBase
    {
        private readonly Groups _groups;

        public int Id => _groups.Id;
        public string Name => _groups.Name;

        public GroupsViewModel(Groups groups)
        {
            _groups = groups;
        }
    }
}
