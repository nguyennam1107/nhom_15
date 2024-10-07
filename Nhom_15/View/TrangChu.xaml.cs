using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nhom_15.View
{
    /// <summary>
    /// Interaction logic for TrangChu.xaml
    /// </summary>
    public partial class TrangChu : UserControl
    {
        private readonly string[] _playList = { "D:\\NetFramework\\Nhom_15\\Nhom_15\\Music\\1.mp3", "D:\\NetFramework\\Nhom_15\\Nhom_15\\Music\\2.mp3", "D:\\NetFramework\\Nhom_15\\Nhom_15\\Music\\3.mp3" };
        private int _currentTrackIndex = 0;
        public TrangChu()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlayCurrentTrack();
        }

        private void PlayCurrentTrack()
        {
            if (_playList.Length > 0)
            {
                mediaElement.Source = new Uri(_playList[_currentTrackIndex], UriKind.Relative);
                mediaElement.Play();
                ShowPauseButton();
            }
        }

        private void ShowPlayButton()
        {
            PlayButton.Visibility = Visibility.Visible;
            PauseButton.Visibility = Visibility.Collapsed;
        }

        private void ShowPauseButton()
        {
            PlayButton.Visibility = Visibility.Collapsed;
            PauseButton.Visibility = Visibility.Visible;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            ShowPauseButton();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            ShowPlayButton();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            ShowPlayButton();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTrackIndex = (_currentTrackIndex + 1) % _playList.Length;
            PlayCurrentTrack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTrackIndex = (_currentTrackIndex - 1 + _playList.Length) % _playList.Length;
            PlayCurrentTrack();
        }
    }
}
