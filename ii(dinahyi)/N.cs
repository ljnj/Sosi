using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_dinahyi_
{
    public class N
    {

       // private static double[,] weight = new double[10, 10];

        public double[,] Fill(double[,] weight)
        {
                    var t = new Random();
            for (var i = 0; i < weight.GetLength(0); i++)
            {
                for (var j = 0; j < weight.GetLength(1); j++)
                {

                    weight[i, j] = Math.Round(t.NextDouble(), 3);
                    
                }

            }
            return weight;
        }

        //public  double[,] Weight
        //{
        //    get
        //    {
        //        return Fill();
        //    }

        //    set
        //    {
        //        for (var i=0; i<weight.GetLength(1); i++)
        //        {
        //            for(var j=0; j<weight.GetLength(0); j++)
        //            {
        //                Weight[i, j] = weight[i, j];
        //            }
        //        }
        //    }
        //}

        public  double[,] Weight = new double[50, 50];

        
        public double GetPower(double[,] input)
        {
            double temp = 0;
           // double power = temp;
            for (var j = 0; j < input.GetLength(1); j++)
            {
                for (var i = 0; i < input.GetLength(0); i++)
                {
                    temp += input[i, j] * Weight[i, j];
                }
                //temp = 1 / (1 + Math.Exp(-temp));
                //power = temp;
                //temp = 0;
            }
            return temp;
        }

        public void Backpropagation(double learningRate, double[,] inp, int temp)
        {
            //var temp = neurons[0].getpower(inp);
            //for (var i = 0; i < neurons.length; i++)
            //{
            //    if (neurons[i].getpower(inp) > temp)
            //        temp = neurons[i].getpower(inp);
            //}


            var weightDelta = 1 / (1 + Math.Exp(-temp)) * (1 - 1 / (1 + Math.Exp(-temp)));

            for (var i = 0; i < Weight.GetLength(0); i++)
            {
                for (var j = 0; j < Weight.GetLength(1); j++)
                {
                    Weight[i, j] = Weight[i, j] - GetPower(inp) * weightDelta * learningRate;
                }
            }
            
        }

        public void MemoryWhitPower (double[,] inp, int memPower)
        {
            for (var j=0; j<Weight.GetLength(0); j++)
            {
                for (var i=0; i<Weight.GetLength(1); i++)
                {
                    Weight[i, j] +=0.5*( inp[i, j] - Weight[i,j]);
                }
            }
        }

       
    }
}