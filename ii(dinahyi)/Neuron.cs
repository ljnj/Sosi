using System;

namespace ii_dinahyi_
{
    public class Neuron
    {
        public double[,] Weight { get; set; }

        public double Handle(double[,] inp)
        {
            double neuronPover = 0;
            for (var j = 0; j < Weight.GetLength(1); j++)
            {
                for (var i = 0; i < Weight.GetLength(0); i++)
                {
                    neuronPover += Weight[i, j] * inp[i, j];

                }
            }
            return 1 / (1 + Math.Pow(Math.E, -neuronPover));
        }

        public void Memory(double[,] inp, double k)
        {
            for (var j = 0; j < Weight.GetLength(1); j++)
            {
                for (var i = 0; i < Weight.GetLength(0); i++)
                {
                    Weight[i, j] += inp[i, j] * k;
                }
            }
        }
    }
}
