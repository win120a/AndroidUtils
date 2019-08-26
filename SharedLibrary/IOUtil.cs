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

        public static string GenerateRandomFileName(string ext)
        {
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
                    int num2 = rand.Next(0, 11);   // [0, 11)
                    builder.Append(num2);
                }
            }

            builder.Append(".").Append(ext);

            return builder.ToString();
        }
    }
}
