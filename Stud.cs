using System;
using System.Drawing;
using System.IO;

namespace ii_dinahyi_
{
    class Stud
    {
        public static void IsInMemory (Bitmap bmp, string name)
        {
            string[] str = File.ReadAllLines(name);
            var arr = ObjToAnother.GetArrFromBMP(bmp);
           
            var temp = new char[2500];
            var g = 0;
            for (var i=0; i<arr.GetLength(0); i++)
            {
                for (var j=0; j<arr.GetLength(1); j++)
                {
                    temp[g] =Char.Parse( arr[j,i].ToString());
                    g++;
                }
            }
                var it = new double[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                char[] t = str[i].ToCharArray();
                for (var j = 0; j < t.Length; j++)
                {
                    if (temp[j] == t[j])
                        it[i]++;
                }
                Console.WriteLine("----------------" + it[i] / 25 + "%-----------------------------------");
            }
            var isit = true;
            for (var i=0; i<it.Length; i++)
            {

                if (it[i] / 2500 > 0.85)
                    isit = false;
            }
            if (isit)
                FileRW.Write(bmp);
        }

    }
}
