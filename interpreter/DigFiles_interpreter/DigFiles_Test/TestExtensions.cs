using DigFiles_interpreter.Classes;
using DigFiles_interpreter.Classes.Command;
using DigFiles_interpreter.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DigFiles_Test
{
    public class TestExtensions
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetVariable()
        {
            var variables = new Dictionary<int, int>();
            var random = new Random();

            variables.Add(0, 1234);

            var data0 = variables.GetVariable(0, random);

            Assert.AreEqual(data0, 1234);
        }

        [Test]
        public void GetVariable_Random()
        {
            var variables = new Dictionary<int, int>();
            var random = new Random();

            var data0 = variables.GetVariable(0, random);
            var data1 = variables.GetVariable(1, random);
            var data2 = variables.GetVariable(2, random);

            Assert.IsTrue(data0 != data1 ||
                          data0 != data2);
        }
    }
}