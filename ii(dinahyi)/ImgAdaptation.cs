using System;
using System.Collections.Generic;
using System.Drawing;

namespace ii_dinahyi_
{
    public class ImgAdaptation
    {
       private static Dictionary<int, string> memory = new Dictionary<int, string>();

        public static void Go (string path)
        {

           // NeuronNet nn = new NeuronNet(10, 50, 1);

            var t = ObjToAnother.GetBitmapFromArr(Perfect.ColorFromImg(path), 160);
            
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            t.Save(pathh+"\\he.jpg");

            var miniimg = ObjToAnother.GetBitmapFromArr(Perfect.CuteFunction(Perfect.Gayss(t)), 1);

            miniimg.Save(pathh+"\\mini.jpg");

            Bitmap ArrFrame = new Bitmap(miniimg, new Size(10, 10));

            ArrFrame.Save(pathh+"\\frame.jpg");

            var work = ObjToAnother.GetArrFromBMP(ArrFrame);
            var nn = new NN();
            nn.Check(nn.Answer(work), work);
            //var answer = nn.getInf(work);
            //Console.WriteLine($"it's {answer}, enter the correct answer");
            //var myAnsw = Console.ReadLine();

            //Console.WriteLine(answer == int.Parse(myAnsw) ? "cool" : "your machine learning sucks");
            //if (answer != int.Parse(myAnsw))
            //    nn.Study(work, int.Parse(myAnsw), 1);
            //Console.ReadKey();

            //Stud.IsInMemory(ArrFrame, "mem.txt", "pairsMemory.txt");
            

            //return ArrFrame;
        }
    }
}
