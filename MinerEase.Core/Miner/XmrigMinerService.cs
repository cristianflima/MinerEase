using System.Diagnostics;

namespace MinerEase.Core.Miner
{
    public class XmrigMinerService : IMinerService
    {
        private Process? _process;
        private string? _xmrigPath;

        public bool IsRunning => _process != null && !_process.HasExited;

        public void Initialize()
        {
            _xmrigPath = XmrigExtractor.EnsureXmrigExtracted();
        }

        public void Start()
        {
            if (_xmrigPath == null)
                throw new InvalidOperationException("Minerador não inicializado.");

            if (IsRunning)
                return;

            var startInfo = new ProcessStartInfo
            {
                FileName = _xmrigPath,
                Arguments = "--help",
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