using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ii_dinahyi_
{
    public class NeuronNet
    {
        public Neuron[] neurons { get; set; }

        const string Path = "Neurons.txt";

        public NeuronNet(int count, int w, int h)
        {
            if (!File.Exists(Path))
            {
                neurons = new Neuron[count];
                for (var i = 0; i < neurons.Length; i++)
                {
                    neurons[i] = new Neuron
                    {
                        Weight = new double[w, h]
                    };
                }

            }
        }

        public int getInf (double[,] inp)
        {
            var arr = new double[neurons.Length];

            for (var i=0; i<neurons.Length; i++)
            {
                arr[i] = neurons[i].Handle(inp);
            }
            var answInd = 0;
            for (var i=1; i<arr.Length; i++)
            {
               if ( arr[i] > arr[answInd])
                    answInd = i;
            }
            return answInd;
        }

        public void Study (double[,] inp, int right, int k)
        {
            neurons[right].Memory(inp, 1);
        }
    }
}
