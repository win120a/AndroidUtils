using System.IO;

namespace AC.AndroidUtils.Shared
{
    public class IOUtil
    {
        public static void WriteBytesToFile(byte[] data, string pathToFile)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(pathToFile, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                foreach (byte b in data)
                {
                    bw.Write(b);
                }
                bw.Flush();
                bw.Close();
            }
        }
    }
}
