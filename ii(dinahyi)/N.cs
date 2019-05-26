using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ii_dinahyi_
{
    public class N
    {

        private static double[,] weight = new double[100, 10];
        static double[,] Fill()
        {
            for (var i = 0; i < weight.GetLength(0); i++)
            {
                for (var j = 0; j < weight.GetLength(1); j++)
                {
                    var t = new Random();
                    weight[i, j] = Math.Round(t.NextDouble(), 3);
                }

            }
            return weight;
        }

        public static double[,] Weight
        {
            get
            {
                return Fill();
            }
            set
            {
                for (var i = 0; i < weight.GetLength(0); i++)
                {
                    for (var j = 0; j < weight.GetLength(1); j++)
                        weight[i, j] = Weight[i, j];
                }
            }
        }

       

        public double GetPower(double[,] input)
        {
            double temp = 0;
            double power = temp;
            for (var i = 0; i < input.GetLength(0); i++)
            {
                for (var j = 0; j < input.GetLength(1); j++)
                {
                    temp += input[i, j] * Weight[i, j];
                }
                temp = 1 / (1 + Math.Exp(-temp));
                power = temp;
                temp = 0;
            }
            return power;
        }
    }
}