using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Neuron
    {
        public double Output { get; private set; }
        public double[] Inputs { get; private set; } //output values of neurons, that connected with neuron
        public NeuronType NeuronType { get; }
        public double[] Weights { get; private set; } //input weights of neuron

        public Neuron(int inputCount, NeuronType neuronType = NeuronType.Hidden)
        {
            NeuronType = neuronType;
            Weights = new double[inputCount];
            Inputs = new double[inputCount];

            InitializeWeightsRandomValue(inputCount);
        }

        public double FeedForward(double[] inputs)
        {
            //initize inputs
            for(int i = 0; i < inputs.Length; i++)
            {
                Inputs[i] = inputs[i];
            }

            var sum = 0.0;
            for(int i = 0; i < inputs.Length; i++)
            {
                sum += Inputs[i] * Weights[i];
            }

            if(NeuronType != NeuronType.Input)
            {
                Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }

            return Output;
        }

        private void InitializeWeightsRandomValue(int inputCount)
        {
            var rnd = new Random();

            if(NeuronType == NeuronType.Input)
            {
                for (int i = 0; i < Weights.Length; i++)
                {
                    Weights[i] = 1;
                }
            }
            else
            {
                for (int i = 0; i < Weights.Length; i++)
                {
                    Weights[i] = rnd.NextDouble();
                }
            }
        }

        private double Sigmoid(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        public override string ToString()
        {
            return Output.ToString();
        }

    }
}
