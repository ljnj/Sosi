using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace ii_dinahyi_
{
    class Stud
    {
        public static void IsInMemory(Bitmap bmp, string name, string pairsName)
        {
            var isit = true;
            if (!File.Exists(name)) File.Create(name).Close();
            if (!File.Exists(pairsName)) File.Create(pairsName).Close();
            string[] str = File.ReadAllLines(name);
            Dictionary<int, string> memory = new Dictionary<int, string>();
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
            string[] pairs = File.ReadAllLines(pairsName);
            for (var j=0; j<pairs.Length; j++)
            {
                char[] temp = pairs[j].ToCharArray();
                if (temp.Length != 0)
                {
                    string s = "";
                    for (var i=2; i<temp.Length; i++)
                    {
                        s += temp[i];
                    }
                        memory.Add(Int32.Parse( temp[0].ToString()), s);
                }
            }

            if (it.Length == 0)
            {
                FileRW.Write(bmp);
                FileRW.Read("mem.txt");
                Console.WriteLine("Memory if empty. What is it?");
                var s = Console.ReadLine();
                memory.Add(0, s);
                FileRW.Write(0, s, pairsName);
                isit = false;
            }
            else
            {
                var counter = 0;
                for (var i = 0; i < it.Length; i++)
                {
                    if (it[i] / 2500 > 0.85)
                    {
                        Console.WriteLine("It is " + memory[i]);
                        isit = false;
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (counter == it.Length)
                {
                    Console.WriteLine("Unknown symbol. What is it?");
                    var s = Console.ReadLine();
                    memory.Add(it.Length, s);
                    FileRW.Write(it.Length, s, pairsName);
                }
            }
            
            if (isit)
            {
                 FileRW.Write(bmp);
                 FileRW.Read("mem.txt");
            }
        }
    }
}