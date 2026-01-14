using System.Diagnostics;

namespace MinerEase.Core.Miner;

public class XmrigMinerService : IMinerService
{
    private Process? _process;

    public bool IsRunning => _process != null && !_process.HasExited;

    public void Start()
    {
        if (IsRunning) return;

        var startInfo = new ProcessStartInfo
        {
            FileName = "xmrig",
            Arguments = "--version",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        _process = Process.Start(startInfo);
    }

    public void Stop()
    {
        if (!IsRunning) return;
        _process!.Kill();
        _process = null;
    }
}
