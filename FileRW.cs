using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ii_dinahyi_
{
    class FileRW
    {
        public static void Write(Bitmap ArrFrame)
        {
            var okgo = ObjToAnother.GetArrFromBMP(ArrFrame);
            StreamWriter strw = new StreamWriter("mem.txt", true);
            for (var i = 0; i < okgo.GetLength(0); i++)
            {
                for (var j = 0; j < okgo.GetLength(1); j++)
                {
                    strw.Write(okgo[j, i]);
                }
                //strw.WriteLine();
            }
            strw.WriteLine();
            strw.Close();
        }

        public static void Read(string name)
        {
            string[] str = File.ReadAllLines(name);
            double[,] arr = new double[str.Length, 2500];
            for (var i = 0; i < str.Length; i++)
            {
                char[] t = str[i].ToCharArray();
                for (var j = 0; j < t.Length; j++)
                {
                    arr[i, j] = Double.Parse(t[j].ToString());
                    Console.Write(t[j]);
                    if (((j + 1) % 50) == 0) Console.WriteLine();
                }
            }
        }

    }
}