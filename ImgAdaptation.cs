using System;
using System.Collections.Generic;
using System.Drawing;

namespace ii_dinahyi_
{
    public class ImgAdaptation
    {
       private static Dictionary<int, string> memory = new Dictionary<int, string>();

        public static Image Go (string path)
        {
           
            var l = Perfect.ColorFromImg(path);
            var t = ObjToAnother.GetBitmapFromArr(l, 160);
            
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            t.Save(pathh+"\\he.jpg");
            
            var hh = Perfect.Gayss(t);
           
            var cut = Perfect.CuteFunction(hh);
           
            var miniimg = ObjToAnother.GetBitmapFromArr(cut, 1);

            miniimg.Save(pathh+"\\mini.jpg");

            Bitmap ArrFrame = new Bitmap(miniimg, new Size(50, 50));

            ArrFrame.Save(pathh+"\\frame.jpg");


            Stud.IsInMemory(ArrFrame, "mem.txt", "pairsMemory.txt");
            

            return ArrFrame;
        }
    }
}
