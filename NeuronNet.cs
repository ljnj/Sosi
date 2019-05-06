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

        const string Path = "mem.json";

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
            else
                neurons = FileRW.Deserialize<Neuron[]>(Path);

            
        }

        ~NeuronNet()
        {
            FileRW.Serialize(Path, neurons);
        }

        public int getInf (double[,] inp)
        {
            var answers = new double[neurons.Length];

            for (var i=0; i<neurons.Length; i++)
            {
                answers[i] = neurons[i].Handle(inp);
            }
            var answInd = 0;
            for (var i=1; i<answers.Length; i++)
            {
               if ( answers[i] > answers[answInd])
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
