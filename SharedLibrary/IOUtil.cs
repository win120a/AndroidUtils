/*
    This is a part of AndroidUtils.

    Copyright (C) 2011-2019 Andy Cheung

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.IO;
using System;
using System.Text;

namespace AC.AndroidUtils.Shared
{
    public sealed class IOUtil
    {
        public const string LF = "\n";
        public const string CRLF = "\r\n";

        private IOUtil() { }
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

        public static string GenerateRandomFileName(string ext)
        {
            /*
             * Steps:
             * (1) Generate a random number in [Second, Year) range.
             * (2) If it is odd, add a letter to the filename.
             * (3) If it is even, add a number.
             * (4) Run 6 times.
             */

            StringBuilder builder = new StringBuilder();
            Random rand = new Random();
            char[] aplhC = { 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f' };

            for(int i = 0; i < 6; i++)
            {
                int num1 = rand.Next(DateTime.Now.Second, DateTime.Now.Year);

                bool alph = (num1 % 2) != 0;

                if (alph)
                {
                    int num2 = rand.Next(0, 12);   // [0, 12)

                    builder.Append(aplhC[num2]);
                }
                else
                {
                    int num2 = rand.Next(0, 11);   // [0, 11)   (i.e. 1~10)
                    builder.Append(num2);
                }
            }

            builder.Append(ext == "" ? "" : ".").Append(ext);

            return builder.ToString();
        }

        public static string GetTempPath()
        {
            return Environment.GetEnvironmentVariable("Temp");
        }

        public static string GetRandomDirectoryInTemp()
        {
            string randomD = GenerateRandomFileName("");

            string temp = GetTempPath();

            return temp + "\\" + randomD;
        }

        public static string ReadFileToEnd(string filePath)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using(StreamReader sr = new StreamReader(filePath))
            {
                string line;

                while((line = sr.ReadLine()) != null)
                {
                    stringBuilder.AppendLine(line);
                }
            }

            return stringBuilder.ToString();
        }

        public static string CRLFToLF(string crlfText) => crlfText.Replace(CRLF, LF);

        public static string LFToCRLF(string lfText) => lfText.Replace(LF, CRLF);
    }
}
