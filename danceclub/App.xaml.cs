using danceclub.Models;
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

    public App()
    {
        _context = new DataContext();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        HandbookViewModel handbookViewModel = new HandbookViewModel(_context);
        ReportViewModel reportViewModel = new ReportViewModel(_context);

        MainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel(handbookViewModel, reportViewModel)
        };
        MainWindow.Show();

        base.OnStartup(e);
    }
}