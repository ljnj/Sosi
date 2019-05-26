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
            return neuronPover;
        }

        public void Memory(double[,] inp, int k)
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
