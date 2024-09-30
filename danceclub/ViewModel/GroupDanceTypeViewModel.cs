using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class GroupDanceTypeViewModel : ViewModelBase
    {
        private readonly GroupDanceType groupDanceType;
        public int DanceTypeId => groupDanceType.DanceTypeId;
        public int GroupId => groupDanceType.GroupId;
        public GroupDanceTypeViewModel(GroupDanceType groupDanceType)
        {
            this.groupDanceType = groupDanceType;
        }

    }
}
