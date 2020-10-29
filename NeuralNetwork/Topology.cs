using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Topology
    {
        public int InputCount { get; } //count of input neurons
        public int OutputCount { get; } //count of output neurons
        public List<int> HiddenLayers { get; } //count of hidden layers

        public Topology(int inputCount, int outputCount, params int[] hiddenLayers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            HiddenLayers = new List<int>();
            //each number in hiddenLayers array represents count of neurons on layers respectively
            HiddenLayers.AddRange(hiddenLayers);
        }
    }
}
