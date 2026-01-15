using System.Reflection;

namespace MinerEase.Core.Miner
{
    public static class XmrigExtractor
    {
        private const string XmrigExeName = "xmrig.exe";

        public static string EnsureXmrigExtracted()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var baseDir = Path.Combine(appData, "MinerEase", "xmrig");

            Directory.CreateDirectory(baseDir);

            var targetPath = Path.Combine(baseDir, XmrigExeName);

            if (File.Exists(targetPath))
                return targetPath;

            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = assembly.GetManifestResourceNames()
                .FirstOrDefault(r => r.EndsWith(XmrigExeName));

            if (resourceName == null)
                throw new Exception("Recurso xmrig.exe não encontrado no assembly.");

            using var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write);

            resourceStream!.CopyTo(fileStream);

            return targetPath;
        }
    }
}