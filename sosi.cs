
using System;
using System.Drawing;

namespace ii_dinahyi_
{
    class Program
    {
        private static readonly ImageConverter _imageConverter = new ImageConverter();

        static double[,] ColorFromImg(string str, int sh)
        {
            Bitmap img = new Bitmap(str);
            int W = img.Width % sh == 0 ? img.Width : img.Width + (sh - img.Width % sh);
            int H = img.Height % sh == 0 ? img.Height : img.Height + (sh - img.Height % sh);

            Console.Write("\n " + img.Width + "   " + img.Height + " \n");
            Console.Write("\n " + W + "   " + H + " \n");
            double[,] res = new double[H / sh, W / sh];
            for (int i = 0; i < H; i += sh)
            {
                for (int j = 0; j < W; j += sh)
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
                }
            }
            return bitmap;
        }
        
        public static int[,] CuteFunction(double[,] A)
        {
            int x=0;
            int y=0;
            int xx = 0;
            int yy = 0;
            int k = 0;


            for (var i = 0; i < A.GetLength(1); i++)
            {
                for (var j = 0; j < A.GetLength(0); j++)
                {
                    Console.Write(A[j, i]);
                }
                Console.WriteLine();
            }



            //var hh = A.GetLength(0) > A.GetLength(1) ? A.GetLength(0) : A.GetLength(1);
            //var 
            for(int i = 0; i < A.GetLength(1); i++)
            {
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    if (A[j, i]== 0)
                    {
                        x = i;
                        k++;
                        break;
                    }
                }
                if (k != 0) break;
            }
            k = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i,j] == 0)
                    {
                        y = i;
                        k++;
                        break;
                    }
                }
                if (k != 0) break;
            }
            Console.Write("\n " + x + "   " + y + " \n");
        

        k = 0;
            for (int i = A.GetLength(1)-1; i >=0; i--)
            {
                for (int j = A.GetLength(0)-1; j >=0; j--)
                {
                    if (A[j, i] == 0)
                    {
                        xx = i;
                        k++;
                        break;
                    }
                }
                if (k != 0) break;
            }
            k = 0;
            for (int i = A.GetLength(0)-1; i >= 0; i--)
            {
                for (int j = A.GetLength(1)-1; j >= 0; j--)
                {
                    if (A[i,j] == 0)
                    {
                        yy = i;
                        k++;
                        break;
                    }
                }
                if (k != 0) break;
            }
            Console.WriteLine(xx + "   " + yy );

            var returnArr = new int[xx - x, yy - y];
            return returnArr;
        }

        /////razbit na f-tsii i tebe ebalo///////////


        public static double[,] GetArrFromBMP(Bitmap im)
        {
            double[,] arr = new double[im.Width, im.Height];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    int color = (im.GetPixel(i, j).R + im.GetPixel(i, j).G + im.GetPixel(i, j).B) / 3;
                    arr[i, j] = color > 0 ? 1 : 0;
                }
            }
            return arr;
        }

        static void Main(string[] args)
        {
            var l = ColorFromImg("ept.jpg", 2);
            var t = GetBitmapFromArr(l);
            t.Save(@"C:\Users\xoxo\Desktop\he.jpg");
            var h= GetArrFromBMP(t);
            CuteFunction(h);
            Console.ReadLine();
        }
    }
}
