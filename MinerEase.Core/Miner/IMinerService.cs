namespace MinerEase.Core.Miner;

public interface IMinerService
{
    void Initialize();
    void Start();
    void Stop();
    bool IsRunning { get; }
}
