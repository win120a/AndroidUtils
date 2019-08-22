using System.Drawing;

namespace AC.AndroidUtils.Shared
{
    public class AndroidApplication
    {
        public AndroidApplication(string appName, string pkgName, string apkPath, string logoPath)
        {
            PackageName = pkgName;
            AppName = appName;
            ApkPath = apkPath;
            Logo = new Bitmap(logoPath);
        }

        public AndroidApplication(string apkPath)
        {
            ApkPath = apkPath;
            PackageName = AppName = null;
        }

        public string PackageName
        {
            get; private set;
        }

        public string AppName
        {
            get; private set;
        }

        public string ApkPath
        {
            get; private set;
        }

        public Bitmap Logo { get; private set; }

        public string Version { get; private set; }

        public long InternalVersion { get; private set; }
    }
}
