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

            var mini = Fill(y, x, yy + 1, xx + 1, A);
            var miniDif = MakeAPerfect(mini);
            return miniDif;
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

        public static double[,] MedianFilter(double[,] original)
        {
            var a = original.GetLength(0);
            var b = original.GetLength(1);
            var changed = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                    changed[i, j] = LittleArrays(original, i, j);
            }
            return changed;
        }

        private static double LittleArrays(double[,] arr, int x, int y)
        {
            double med;
            List<double> lilList = new List<double>();
            for (int i = -1; i <= 6; i ++)
                for (int j = -1; j <= 6; j ++)
                    try
                    {
                        lilList.Add(arr[x + i, y + j]);
                    }
                    catch
                    {
                        continue;
                    }
            lilList.Sort();
            med = lilList[lilList.Count / 2];
            if (lilList.Count % 2 == 0)
                med = (lilList[lilList.Count / 2] + lilList[(lilList.Count / 2) - 1]) / 2;
            return med;
        }
    }
}

