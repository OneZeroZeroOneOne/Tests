using System.IO;
using System.Runtime.InteropServices;

namespace Tests.Bll.Services
{
    public class AttachmentPathProvider
    {
        public string Path;
        public static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public string GetPath()
        {
            return Path;
        }

        public void ConfigurePath()
        {
            Path = IsLinux ? "/root" : Directory.GetCurrentDirectory() + @"\wwwroot";
        }
    }
}