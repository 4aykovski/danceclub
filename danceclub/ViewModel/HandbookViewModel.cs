using danceclub.Commands;
using danceclub.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace danceclub.ViewModel
{
    public class HandbookViewModel : ViewModelBase
    {
        private string _selectedHandbook;
        public string SelectedHandbook 
        {
            get { return _selectedHandbook; }
            set { _selectedHandbook = value; OnPropertyChanged(nameof(SelectedHandbook)); }
        }
        public ObservableCollection<String> AllowedHandbooks
        {
            get
            {
                var handbooks = new ObservableCollection<String>(new List<String>()
                {
                    "DanceType",
                    "GroupDanceType",
                    "Groups",
                    "GroupStudent",
                    "Schedule",
                    "Students",
                    "StudentSchedule",
                    "Teacher",
                });
                return handbooks;
            }
        }

        private ObservableCollection<Object> _dataGrid;

        public ObservableCollection<Object> DataGrid {
            get { return _dataGrid; }
            set
            {
                _dataGrid = value;
                OnPropertyChanged(nameof(DataGrid));
            }
        }

        public ICommand LoadHandbookCommand { get; }
        public ICommand SaveHandbookCommand { get; }
        public ICommand ExportHandbookCommand { get; }

        public HandbookViewModel(DataContext context)
        {
            LoadHandbookCommand = new LoadHandbookCommand(this, context);
            SaveHandbookCommand = new SaveHandbookCommand();
            ExportHandbookCommand = new ExportHandbookCommand(this);
        }

    }
}
