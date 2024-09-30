using danceclub.ViewModel;
using System.ComponentModel;
using System.Windows;
using Utils;

namespace danceclub.Commands
{
    public class ExportHandbookCommand : CommandBase
    {
        private readonly HandbookViewModel _handbookViewModel;

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(HandbookViewModel.SelectedHandbook) || e.PropertyName == nameof(HandbookViewModel.DataGrid))
            {
                OnCanExecuteChanged();
            }
        }

        public ExportHandbookCommand(HandbookViewModel handbookViewModel)
        {
            _handbookViewModel = handbookViewModel;

            _handbookViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_handbookViewModel.SelectedHandbook) && _handbookViewModel.DataGrid != null &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (!string.IsNullOrEmpty(_handbookViewModel.SelectedHandbook) && _handbookViewModel.DataGrid != null)
            {
                List<Object> data = [.. _handbookViewModel.DataGrid];
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
