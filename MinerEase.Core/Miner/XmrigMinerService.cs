using System.Diagnostics;

namespace MinerEase.Core.Miner
{
    public class XmrigMinerService : IMinerService
    {
        private Process? _process;
        private string? _xmrigPath;
        private MinerConfig? _config;

        public bool IsRunning => _process != null && !_process.HasExited;

        public void Initialize()
        {
            _xmrigPath = XmrigExtractor.EnsureXmrigExtracted();

            //  Configuração inicial (temporária)
            _config = new MinerConfig
            {
                UserWallet = "49DpRjNErnyMdHxczMX4nLG3redJL2hhb5qTXi6WpR3qbANEVPuBFdEMdoH6cAKepaMvJJ77huB41VzYezkBqojDAqiGUqK",
                DonationWallet = "46UPXFzCPUnRh7Si3dprTTNYbrURU1daKhfxEsQFzTmv9AbAoVRG3CiCJZQLGKg6FrPEvHfGBThGqgAoqVyNEttsEK8f4Lo",
                DonationPercentage = 2
            };
        }

        public void Start()
        {
            if (_xmrigPath == null || _config == null)
                throw new InvalidOperationException("Minerador não inicializado.");

            if (IsRunning)
                return;

            var args = XmrigArgumentBuilder.Build(_config);

            var startInfo = new ProcessStartInfo
            {
                FileName = _xmrigPath,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            _process = Process.Start(startInfo);
        }

        public void Stop()
        {
            if (IsRunning)
            {
                _process!.Kill(true);
                _process = null;
            }
        }
    }
}