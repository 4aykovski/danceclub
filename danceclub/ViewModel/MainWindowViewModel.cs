using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public HandbookViewModel HandbookViewModel { get; set; }
        public ReportViewModel ReportViewModel { get; set; }

        public MainWindowViewModel(HandbookViewModel handbookViewModel, ReportViewModel reportViewModel)
        {
            HandbookViewModel = handbookViewModel;
            ReportViewModel = reportViewModel;
        }
    }
}
