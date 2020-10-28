using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    class NeuralNetwork
    {
        public Topology Topology { get; }
        public List<Layer> Layers { get; }

        public NeuralNetwork(Topology topology)
        {
            //check if topology is null
            if(topology == null)
            {
                throw new Exception("Topology is null");
            }

            Topology = topology;
            Layers = new List<Layer>();

            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();
        }

        public double FeedForward(double[] inputSignals)
        {
            //check if count of inputsSignals equal count of input neurons
            if(inputSignals.Length != Topology.InputCount)
            {
                throw new Exception("Count of input signals doesn't equal count of input neurons");
            }
        }

        private void SendSignalsToInputNeurons(double[] inputSignals)
        {
            for (int i = 0; i < inputSignals.Length; i++)
            {
                var neuron = Layers[0].Neurons[i];

                neuron.FeedForward(inputSignals[i]);
            }
        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();

            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.NeuronsCount, NeuronType.Output);
                outputNeurons.Add(neuron);
            }

            var outputLayer = new Layer(outputNeurons);
            Layers.Add(outputLayer);
        }

        private void CreateHiddenLayers()
        {
            //go through all hidden layers
            for (int i = 0; i < Topology.HiddenLayers.Count; i++)
            {
                var hiddenNeurons = new List<Neuron>();
                var lastLayer = Layers.Last();

                for (int j = 0; j < Topology.HiddenLayers[i]; j++)
                {
                    var neuron = new Neuron(lastLayer.NeuronsCount);
                    hiddenNeurons.Add(neuron);
                }

                var hiddenLayer = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }
        }

        private void CreateInputLayer()
        {
            var inputNeurons = new List<Neuron>();

            for(int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }

            var inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }
    }
}
