namespace MinerEase.Core.Miner;

public interface IMinerService
{
    void Start();
    void Stop();
    bool IsRunning { get; }
}
