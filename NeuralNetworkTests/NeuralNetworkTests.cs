using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetwork;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace NeuralNetwork.Tests
{
    [TestClass()]
    public class NeuralNetworkTests
    {
        [TestMethod()]
        public void FeedForwardTest()
        {
            var topology = new Topology(3, 2, 2, 2);
            var network = new NeuralNetwork(topology);
            var inputs = new double[] { 0.1, 0.3, 0.2 };
            var neurons = network.FeedForward(inputs);
            foreach(var neuron in neurons)
            {
                Console.WriteLine(neuron);
            }


        }
    }
}