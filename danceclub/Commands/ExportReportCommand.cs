using danceclub.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Utils;

namespace danceclub.Commands
{
    public class ExportReportCommand : CommandBase
    {
        private readonly ReportViewModel _reportViewModel;

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ReportViewModel.SelectedReport) ||  e.PropertyName == nameof(ReportViewModel.DataGrid))
            {
                OnCanExecuteChanged();
            }
        }

        public ExportReportCommand(ReportViewModel reportViewModel)
        {
            _reportViewModel = reportViewModel;

            _reportViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_reportViewModel.SelectedReport) && _reportViewModel.DataGrid?.Count > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (!string.IsNullOrEmpty(_reportViewModel.SelectedReport) && _reportViewModel.DataGrid != null)
            {
                List<Object> data = [.. _reportViewModel.DataGrid];
                try
                {
                    Excel.ListToExcel(data);

                    MessageBox.Show("Successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"something went wrong. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
