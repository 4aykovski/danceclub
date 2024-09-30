using danceclub.Models;
using danceclub.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danceclub.Commands
{
    public class LoadReportCommand : CommandBase
    {
        private readonly ReportViewModel _reportViewModel;

        private readonly DataContext _context;

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ReportViewModel.SelectedReport))
            {
                OnCanExecuteChanged();
            }
        }

        public LoadReportCommand(ReportViewModel reportViewModel, DataContext context)
        {
            _reportViewModel = reportViewModel;
            _context = context;

            _reportViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_reportViewModel.SelectedReport) &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
