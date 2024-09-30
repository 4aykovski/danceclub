using System.Collections.ObjectModel;
using System.Windows.Input;

namespace danceclub.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        public string SelectedReport { get; set; }
        public ObservableCollection<String> AllowedReports
        {
            get
            {
                var reports = new ObservableCollection<String>(new List<String>()
                {
                });
                SelectedReport = reports.FirstOrDefault(report => report == "Teacher");
                return reports;
            }
        }

        private readonly ObservableCollection<Object> _dataGrid;
        public IEnumerable<Object> DataGrid => _dataGrid;

        public ICommand LoadReportCommand { get; }
        public ICommand ExportReportCommand { get; }
    }
}
