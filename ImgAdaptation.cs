using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace ii_dinahyi_
{
    public class ImgAdaptation
    {
        public static Image Go (string path)
        {
            Stopwatch stW = new Stopwatch();
            stW.Start();
            var l = Perfect.ColorFromImg(path, 1);
            stW.Stop();
            Console.WriteLine( "time1 = " + stW.Elapsed.Milliseconds);
            var t = ObjToAnother.GetBitmapFromArr(l, 160);

            Random r = new Random();
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(pathh);
            t.Save(pathh+"\\he.jpg");

            stW.Start();
            var hh = Perfect.Gayss(t);
            stW.Stop();
            Console.WriteLine("time2 = " + stW.Elapsed.Milliseconds);
            
            stW.Start();
            var cut = Perfect.CuteFunction(hh);
            stW.Stop();
            Console.WriteLine("time3 = " + stW.Elapsed.Milliseconds);

            var miniimg = ObjToAnother.GetBitmapFromArr(cut, 1);

            miniimg.Save(pathh+"\\mini.jpg");

            Bitmap ArrFrame = new Bitmap(miniimg, new Size(50, 50));

            ArrFrame.Save(pathh+"\\frame.jpg");


           
            //stW.Start();
            //stW.Stop();
            //Console.WriteLine("time5 = " + stW.Elapsed.Milliseconds);

            Stud.IsInMemory(ArrFrame, "mem.txt");
            FileRW.Read("mem.txt");

            return ArrFrame;
        }
    }
}
