using danceclub.Commands;
using danceclub.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace danceclub.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        private string _selectedReport;
        public string SelectedReport
        {
            get { return _selectedReport; }
            set { _selectedReport = value; OnPropertyChanged(nameof(SelectedReport)); }
        }
        public ObservableCollection<String> AllowedReports
        {
            get
            {
                var reports = new ObservableCollection<String>(new List<String>()
                {
                    "Расписание учеников",
                    "Расписание учителей",
                });
                return reports;
            }
        }

        private ObservableCollection<Object> _dataGrid;

        public ObservableCollection<Object> DataGrid
        {
            get { return _dataGrid; }
            set
            {
                _dataGrid = value;
                OnPropertyChanged(nameof(DataGrid));
            }
        }

        public ICommand LoadReportCommand { get; }
        public ICommand ExportReportCommand { get; }

        public ReportViewModel(DataContext context)
        {
            LoadReportCommand = new LoadReportCommand(this, context);
            ExportReportCommand = new ExportReportCommand(this);
        }
    }
}
