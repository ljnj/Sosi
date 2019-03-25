using System;
using System.Drawing;

namespace ii_dinahyi_
{
    class Perfect
    {
        public static double[,] ColorFromImg(string str)
        {
            Bitmap img = new Bitmap(str);

            int sh = (img.Width > 2050 || img.Height > 2050) ? 10 : (img.Width > 1000 || img.Height > 1000) ? 4 : 1;
            //Console.WriteLine(sh);
            int W = img.Width % sh == 0 ? img.Width : img.Width + (sh - img.Width % sh);
            int H = img.Height % sh == 0 ? img.Height : img.Height + (sh - img.Height % sh);

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
            }
            return res;
        }

        public static double[,] CuteFunction(double[,] A)
        {
            int x = Find.FindX(A.GetLength(1), A.GetLength(0), A, 0);
            int y = Find.FindY(A.GetLength(0), A.GetLength(1), A, 0);
            int xx = Find.FindXX(A.GetLength(1) - 1, A.GetLength(0) - 1, A, 0);
            int yy = Find.FindYY(A.GetLength(0) - 1, A.GetLength(1) - 1, A, 0);

            var mini = Fill(y, x, yy + 1, xx + 1, A);
            var miniDif = new double[mini.GetLength(1), mini.GetLength(0)];
            for (var i=0; i<mini.GetLength(1); i++)
            {
                for (var j=0; j<mini.GetLength(0); j++)
                {
                    miniDif[i, j] = mini[j, i];
                }
            }
            return miniDif;
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
        

        public static double[,] Gayss (Bitmap bmp)
        {
            var inp = ObjToAnother.GetArrFromBMP(bmp);
            var a = inp.GetLength(0);
            var b = inp.GetLength(1);
            var res = new double[a, b];
            int x, y;
            double pointColor = 0;
            for (var i = 0; i < a ; i++)
            {
                for (var j = 0; j < b; j++)
                {
                    int count = 0;
                    var t = new double[9];
                    if (i == 0 || j == 0 || i==a-1 || j==b-1 )
                    {
                        for (x = 0; x <= 1; x++)
                        {
                            for (y = 0; y <= 1; y++)
                            {
                                t[count] = 1;
                                count++;
                            }
                        }
                    }
                    else
                    {
                        for (x = -1; x <= 1; x++)
                        {
                            for (y = -1; y <= 1; y++)
                            {
                                t[count] = inp[i + x, j + y];
                                count++;
                            }
                        }
                    }
                    pointColor = t[0] + 2 * t[1] + t[2] + 2 * t[3] + 4 * t[4] + 2 * t[5] + t[6] + 2 * t[7] + t[8];
                    res[i, j] = pointColor/8;
                }
            }
            return res;
        }
    }
}