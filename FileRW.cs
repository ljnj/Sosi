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
            StreamWriter strw = new StreamWriter("mem.txt");
            //strw.WriteLine("0");
            for (var i = 0; i < okgo.GetLength(0); i++)
            {
                for (var j = 0; j < okgo.GetLength(1); j++)
                {
                    strw.Write(okgo[i, j]);
                }
                strw.WriteLine();
            }
            strw.Close();
        }

        public static void Read (string name)
        {
            string[] str = File.ReadAllLines(name);
            double[,] arr = new double[50, 50];
            for (var i=0; i<50; i++)
            {
                char[] t = str[i].ToCharArray();
                for (var j=0; j<50; j++)
                {
                    arr[i, j] = Double.Parse(t[j].ToString());
                }
            }
            for (var i=0; i<50; i++)
            {
                for (var j=0; j<50; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
