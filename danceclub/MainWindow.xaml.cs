using danceclub.Models;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace danceclub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsPlaying = false;
        private bool IsUserDraggingSlider = false;

        private readonly DispatcherTimer Timer = new() { Interval = TimeSpan.FromSeconds(0.1) };
        private readonly OpenFileDialog MediaOpenDialog = new()
        {
            Title = "Open a media file",
            Filter = "Media Files (*.mp3,*.mp4)|*.mp3;*.mp4"
        };

        public MainWindow()
        {
            InitializeComponent();

            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (Player.Source != null && Player.NaturalDuration.HasTimeSpan && !IsUserDraggingSlider)
            {
                ProgressSlider.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
                ProgressSlider.Value = Player.Position.TotalSeconds;
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MediaOpenDialog.ShowDialog() == true)
            {
                Player.Source = new Uri(MediaOpenDialog.FileName);

                Player.Play();
                IsPlaying = true;
            }
        }

        #region Media Controls

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Player?.Source != null)
            {
                Player.Play();
                IsPlaying = true;
            }
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
                Player.Pause();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsPlaying)
            {
                Player.Stop();
                IsPlaying = false;
            }
        }

        private void ProgressSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            IsUserDraggingSlider = true;
        }

        private void ProgressSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            IsUserDraggingSlider = false;
            Player.Position = TimeSpan.FromSeconds(ProgressSlider.Value);
        }

        private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            StatusLbl.Text = TimeSpan.FromSeconds(ProgressSlider.Value).ToString(@"hh\:mm\:ss");
        }

        #endregion
    }
}