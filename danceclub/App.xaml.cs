using danceclub.Models;
using danceclub.Stores;
using danceclub.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace danceclub;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly DataContext _context;
    private readonly ModalNavigationStore _modalNavigationStore;

    public App()
    {
        _context = new DataContext();
        _modalNavigationStore = new ModalNavigationStore();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        HandbookViewModel handbookViewModel = new HandbookViewModel(_context, _modalNavigationStore);
        ReportViewModel reportViewModel = new ReportViewModel(_context);

        MainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(handbookViewModel, reportViewModel, _modalNavigationStore)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}