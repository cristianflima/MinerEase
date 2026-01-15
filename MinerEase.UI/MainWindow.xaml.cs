using System.Windows;
using MinerEase.Core.Miner;

namespace MinerEase.UI
{
    public partial class MainWindow : Window
    {
        private readonly IMinerService _minerService;

        public MainWindow()
        {
            InitializeComponent();
            _minerService = new XmrigMinerService();
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_minerService.IsRunning)
            {
                _minerService.Stop();
                StatusText.Text = "Status: Parado";
                StartStopButton.Content = "Iniciar Mineração";
            }
            else
            {
                _minerService.Start();
                StatusText.Text = "Status: Minerando";
                StartStopButton.Content = "Parar Mineração";
            }
        }
    }
}