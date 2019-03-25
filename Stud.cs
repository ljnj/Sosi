using System;
using System.Drawing;
using System.IO;

namespace ii_dinahyi_
{
    class Stud
    {
        public static void IsInMemory(Bitmap bmp, string name)
        {
            if (!File.Exists(name)) File.Create(name).Close();
            string[] str = File.ReadAllLines(name);
            var arr = ObjToAnother.GetArrFromBMP(bmp);
            
            var it = new double[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                char[] t = str[i].ToCharArray();
                int h = 0, w = 0;
                for (var j = 0; j < t.Length; j++)
                {
                    if (arr[w, h] == Double.Parse(t[j].ToString()))
                        it[i]++;
                    if (w == 49)
                    {
                        h++;
                        w = -1;
                    }
                    w++;
                }
                Console.WriteLine("----------------" + it[i] / 25 + "%-----------------------------------");
            }

            var isit = true;
            for (var i = 0; i < it.Length; i++)
            {

                if (it[i] / 2500 > 0.85)
                    isit = false;
            }
            if (isit)
                FileRW.Write(bmp);
        }

    }
}