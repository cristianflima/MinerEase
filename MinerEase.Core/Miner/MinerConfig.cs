namespace MinerEase.Core.Miner
{
    public class MinerConfig
    {
        // Wallet principal do usuário
        public string UserWallet { get; set; } = string.Empty;

        // Seu endereço Monero (doação)
        public string DonationWallet { get; set; } = string.Empty;

        // Percentual de doação (ex: 2 = 2%)
        public int DonationPercentage { get; set; } = 2;

        // Pool principal
        public string PoolUrl { get; set; } = "pool.hashvault.pro:443";

        // Nome do worker
        public string WorkerName { get; set; } = "MinerEase";

        // Threads (0 = automático)
        public int Threads { get; set; } = 0;
    }
}