using System;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace ii_dinahyi_
{
    class FileRW
    {
        public static void Write(Bitmap ArrFrame)
        {
            StreamWriter strw = new StreamWriter("mem.txt", true);
            var okgo = ObjToAnother.GetArrFromBMP(ArrFrame);
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

        public static void Write (int k, string v, string name)
        {
            StreamWriter strw = new StreamWriter(name, true);
            strw.Write(k.ToString()+" "+ v);
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

        public static void Serialize<T>(string path, T obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj));
        }
        public static T Deserialize<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

    }
}