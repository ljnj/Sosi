using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_dinahyi_
{
    public class ImgAdaptation
    {
        public static Image ImgAdapt ()
        {
            var l = Perfect.ColorFromImg("odin.jpg", 2);
            var t = ObjToAnother.GetBitmapFromArr(l, 160);

            t.Save(@"C:\Users\xoxo\Desktop\he.jpg");

            var h = ObjToAnother.GetArrFromBMP(t);
            var hh = Perfect.MedianFilter(h);
            var cut = Perfect.CuteFunction(hh);

            var miniimg = ObjToAnother.GetBitmapFromArr(cut, 1);

            miniimg.Save(@"C:\Users\xoxo\Desktop\mini.jpg");

            Bitmap ArrFrame = new Bitmap(miniimg, new Size(50, 50));

            ArrFrame.Save(@"C:\Users\xoxo\Desktop\Frame.jpg");
            return ArrFrame;
        }
    }
}
