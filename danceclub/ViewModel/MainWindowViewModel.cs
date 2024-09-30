using danceclub.Stores;
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

        private readonly ModalNavigationStore _modalNavigationStore;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public MainWindowViewModel(HandbookViewModel handbookViewModel, ReportViewModel reportViewModel, ModalNavigationStore modalNavigationStore)
        {
            HandbookViewModel = handbookViewModel;
            ReportViewModel = reportViewModel;
            _modalNavigationStore = modalNavigationStore;

            _modalNavigationStore.CurrentViewModelChanged += NavigationStoreCurrentViewModelChanged;
        }

        private void NavigationStoreCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
