using System.Text;

namespace MinerEase.Core.Miner
{
    public static class XmrigArgumentBuilder
    {
        public static string Build(MinerConfig config)
        {
            var sb = new StringBuilder();

            sb.Append($"-o {config.PoolUrl} ");
            sb.Append($"-u {config.UserWallet}.{config.WorkerName} ");
            sb.Append($"--donate-level={config.DonationPercentage} ");

            if (config.Threads > 0)
                sb.Append($"-t {config.Threads} ");

            sb.Append("--no-color ");
            sb.Append("--print-time=60 ");

            return sb.ToString();
        }
    }
}