using danceclub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class DanceTypeViewModel : ViewModelBase
    {
        private readonly DanceType _danceType;

        public int Id => _danceType.Id;
        public string Name => _danceType.Name;

        public DanceTypeViewModel(DanceType danceType)
        {
            _danceType = danceType;
        }
    }
}
