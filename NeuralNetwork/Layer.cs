using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }
        public NeuronType LayerType { get; }
        public int NeuronsCount => Neurons?.Count ?? 0;
        

        public Layer(List<Neuron> neurons, NeuronType type = NeuronType.Hidden)
        {
            //check if neurons list is null
            if(neurons == null)
            {
                throw new Exception("Neurons list is null");
            }

            LayerType = type;

            //check the type matching of neurons and layer
            foreach (var neuron in neurons)
            {
                if(neuron.NeuronType != LayerType)
                {
                    throw new Exception("Type of neuron and type of layer doesn't equal");
                }
            }

            Neurons = new List<Neuron>(neurons);
        }

        public double[] GetSignals()
        {
            var signals = new double[NeuronsCount];

            for (int i = 0; i < signals.Length; i++)
            {
                var neuron = Neurons[i];

                signals[i] = neuron.Output;
            }

            return signals;
        }
    }
}
