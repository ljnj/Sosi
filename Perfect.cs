using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_dinahyi_
{
    class Perfect
    {

        public static double[,] ColorFromImg(string str, int sh)
        {
            Bitmap img = new Bitmap(str);
            int W = img.Width % sh == 0 ? img.Width : img.Width + (sh - img.Width % sh);
            int H = img.Height % sh == 0 ? img.Height : img.Height + (sh - img.Height % sh);

            Console.Write("\n " + img.Width + "   " + img.Height + " \n");
            Console.Write("\n " + W + "   " + H + " \n");
            double[,] res = new double[H / sh, W / sh];
            for (int i = 0; i < W; i += sh)
            {
                for (int j = 0; j < H; j += sh)
                {
                    int s = 0;
                    s = (img.GetPixel(i, j).R + img.GetPixel(i, j).G + img.GetPixel(i, j).B) / 3;
                    //Console.Write (i/sh + "  !  " + j/sh + " *" + s + "*\n");
                    res[j / sh, i / sh] = s;
                    //Console.Write(s < 10 ? "  " + s + " " : s >= 10 && s < 100 ? " " + s + " " : s + " ");
                }
                //Console.Write("\n\n");
            }
            return res;
        }
        public static double[,] CuteFunction(double[,] A)
        {
            int x = Find.FindX(A.GetLength(1), A.GetLength(0), A, 0);
            int y = Find.FindY(A.GetLength(0), A.GetLength(1), A, 0);
            int xx = Find.FindXX(A.GetLength(1) - 1, A.GetLength(0) - 1, A, 0);
            int yy = Find.FindYY(A.GetLength(0) - 1, A.GetLength(1) - 1, A, 0);

            Console.Write("\n " + x + "   " + y + " \n");
            Console.WriteLine(xx + "   " + yy);

            var mini = Perfect.Fill(y, x, yy + 1, xx + 1, A);
            return mini;
        }

        public static double[,] MakeAPerfect(double[,] A)
        {
            double[,] Per = new double[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(1); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    Per[i, j] = A[j, i];
                }
            }
            return Per;
        }

        public static double[,] Frame(string str)
        {
            Bitmap img = new Bitmap(str);
            var difH = img.Height % 50;
            var difW =  img.Width % 50;

            int W = difW < 20 ? img.Width - img.Width % 50 : img.Width + (50 - difW);
            int H = difH < 20 ? img.Height - img.Height % 50 : img.Height + (50-difH);
            int shx = W / 50;
            int shy = H / 50;
           // Console.Write("\n\n " + W + "   " + H + "  !  " + H / shy + "   " + W / shx + "  !  " + shy + "   " + shx + "\n");
            double[,] res = new double[W / shx, H / shy];
            for (int i = 0; i < W; i += shx)
            {
                if (i >= img.Width)
                {
                    i -= shx; i++;
                    if (i == img.Width)
                        break;
                }
                for (int j = 0; j < H; j += shy)
                {
                    if (j >= img.Height)
                    {
                        j -= shy; j++;
                        if (j == img.Height)
                            break;
                    }
                    int s = 0;
                    s = (img.GetPixel(i, j).R + img.GetPixel(i, j).G + img.GetPixel(i, j).B) / 3;
                    res[j / shy, i / shx] = s;
                    //res[i / shx, j / shy] = s;
                    //Console.Write(s < 10 ? "  " + s + " " : s >= 10 && s < 100 ? " " + s + " " : s + " ");
                }
            }
            return res;
        }

        public static double[,] Fill(int x, int y, int xx, int yy, double[,] A)
        {
            var w = xx - x;
            var h = yy - y;
            var retArr = new double[w, h];
            for (var i = 0; i < w; i++)
            {
                for (var j = 0; j < h; j++)
                {
                    retArr[i, j] = A[i + x, j + y];
                }
            }
            return retArr;
        }

        
    }
}
