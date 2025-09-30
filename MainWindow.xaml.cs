using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tempo_Detector_2
{
    public partial class MainWindow : Window
    {
        //the time intervals in milliseconds between taps
        private readonly List<double> _tapIntervals = new List<double>();

        //the most recent tap 
        private DateTime _lastTapTime;

        //the number of recent taps including the rolling average
        private const int TapsToAverage = 4;
        
        private readonly System.Windows.Threading.DispatcherTimer _flashTimer = new System.Windows.Threading.DispatcherTimer();
        
        private bool _isIdicicatorOn = false;
        public MainWindow()
        {
            InitializeComponent();
            ResetCalculcation();

            _flashTimer.Tick += FlashTimer_Tick;
        }
        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            if (TempoIndicator.Visibility == Visibility.Visible)
            {
                TempoIndicator.Visibility = Visibility.Collapsed;
            }
            else
            {
                TempoIndicator.Visibility = Visibility.Visible;
            }
        }

        private void TapButton_Click(object sender, RoutedEventArgs e)
        {
            // now = the current time
            DateTime now = DateTime.Now;

            if (_lastTapTime != DateTime.MinValue)
            {
                //interval is the time between the last tap and the current tap
                double interval = (now - _lastTapTime).TotalMilliseconds;
                //adding that time to the list
                _tapIntervals.Add(interval);
            }

            //update the list of taps to grab the next calculation
            _lastTapTime = now;

            //keeping the list from growing indefinitely.  
            while (_tapIntervals.Count > TapsToAverage)
            {
                //removing the oldest interval from the front of the list
                _tapIntervals.RemoveAt(0);
            }

            //we need 2 taps minimal to calculate a tempo
            if (_tapIntervals.Any())
            {
                //whatever is inside of the list, average it
                double averageInterval = _tapIntervals.Average();

                if (averageInterval > 0)
                {
                    // bpm = 60000 ms per minute / average interval time
                    double bpm = 60000 / averageInterval;
                    BPMTextBlock.Text = $"BPM: {bpm:F1}";
                }
            }
            _flashTimer.Stop();
            TempoIndicator.Visibility = Visibility.Collapsed;

            if (_tapIntervals.Any())
            {
                double averageInterval = _tapIntervals.Average();

                if (averageInterval > 0)
                {
                    double bpm = 60000 / averageInterval;
                    BPMTextBlock.Text = $"BPM: {bpm:F1}";

                    _flashTimer.Interval = TimeSpan.FromMilliseconds(averageInterval);

                    _flashTimer.Start();
                }
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetCalculcation();
        }

        private void ResetCalculcation()
        {
            _tapIntervals.Clear();
            _lastTapTime = DateTime.MinValue;
            BPMTextBlock.Text = "Tap to start";

            _flashTimer.Stop();
            TempoIndicator.Visibility= Visibility.Collapsed;
        }
    }
}