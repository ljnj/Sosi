using System;
using System.Drawing;

namespace ii_dinahyi_
{
    class Program
    {
        private static readonly ImageConverter _imageConverter = new ImageConverter();

        static double[,] ColorFromImg (string str, int sh)
        {
            Bitmap img = new Bitmap(str);
	int W = 0; int H = 0;
	if (img.Width % sh != 0)  W = img.Width + (sh - (img.Width % sh)); 
		else W = img.Width;
	if (img.Height % sh != 0)  H = img.Height + (sh - (img.Height % sh)); 
		else H = img.Height;
		Console.Write("\n " + img.Width + "   " + img.Height + " \n");
		Console.Write("\n " + W + "   " + H + " \n");
            double[,] res = new double[H / sh, W / sh];
            for (int i = 0; i < H; i+=sh)
            {
                for (int j = 0; j < W; j+=sh)
                {
                    int s = 0;
                    for (var h = 0; h < sh; h++)
                    {
                        for (var e = 0; e < sh; e++)
                        {
                            Color pixel = img.GetPixel(j, i);
                            s += (pixel.R + pixel.G + pixel.B) / 3;
                        }
                    }
                    s /= sh * sh;
                    res[i / sh, j / sh] = s;
                   //Console.Write(s < 10 ? "  " + s + " " : s >= 10 && s < 100 ? " " + s + " " : s + " ");
                }
                //Console.Write("\n\n");
            }
            return res;
        }
        
        public static Bitmap GetBitmapFromArr(double[,] array)
        {
            Bitmap bitmap = new Bitmap(array.GetLength(1), array.GetLength(0));
            for (int x = 0; x < array.GetLength(1); x++)
            {
                for (int y = 0; y < array.GetLength(0); y++)
                {
                    if (array[y, x] < 140)
                        bitmap.SetPixel(x, y, Color.Black);
                    else
                        bitmap.SetPixel(x, y, Color.White);
                    // Convert.ToString(Convert.ToInt32(array[x, y]), 16);

                    // bitmap.SetPixel(x, y, Color.FromArgb((int)array[x, y]));
                }
            }
            return bitmap;
        }

////////////////////////////////////////////////////////////////
public static void CuteFunction(double[,] A)
        {
	     //double[,] res = new double[H / sh, W / sh];
		int x; int y; int k = 0;

	      for (int i = 0; i < A.GetLength(0); i++){
                 for (int j = 0; j < A.GetLength(1); j++){
					if (A[i,j] == 0) {x = j; k++; break;}
				}
		if(k!=0) break;
			}
	k = 0;
	      for (int i = 0; i < A.GetLength(1); i++){
				for (int j = 0; j < A.GetLength(0); j++){
					if (A[i,j] == 0) {y = j; k++; break;}
				}
		if(k!=0) break;
			}
	    Console.Write("\n " + x + "   " + y + " \n");
	}
////////////////////////////////////////////////////////////////

        static void Main(string[] args)
        {
            var l = ColorFromImg("1.jpg", 1);
            var t = GetBitmapFromArr(l);
            t.Save(@"chlenik.jpg");
	    Cutefunction(l);
        }
    }
}
