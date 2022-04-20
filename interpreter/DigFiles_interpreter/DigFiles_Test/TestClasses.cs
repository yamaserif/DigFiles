using DigFiles_interpreter.Business;
using DigFiles_interpreter.Classes;
using DigFiles_interpreter.Classes.Command;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DigFiles_Test
{
    public class TestClasses
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetCommand()
        {
            string[] args = { "10", "1234" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            var runData = new RunData("hoge", variables, actions, new Random());
            var command = new SetCommand(args, runData);
            command.Execute();

            Assert.AreEqual(variables[10], 1234);
        }

        [Test]
        public void CopyCommand()
        {
            string[] args = { "10", "11" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 1000);
            variables.Add(11, 1234);

            var runData = new RunData("hoge", variables, actions, new Random());
            var command = new CopyCommand(args, runData);
            command.Execute();

            Assert.AreEqual(variables[10], 1234);
        }

        [Test]
        public void InCommand()
        {
            string[] args = { "10" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            var runData = new RunData("hoge", variables, actions, new Random());
            var command = new InCommand(args, runData);
            command.Execute();

            Assert.AreEqual(variables[10], 104);
        }

        [Test]
        public void OutCommand()
        {
            string[] args = { "10" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 104);

            var runData = new RunData("hoge", variables, actions, new Random());

            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                Console.SetOut(writer);
                var command = new OutCommand(args, runData);
                command.Execute();

                using (var reader = new StringReader(builder.ToString()))
                {
                    var consoleMessage = reader.ReadToEnd().Replace("\0", "");

                    Assert.AreEqual(consoleMessage, "h");
                }
            }
        }

        [Test]
        public void LoopCommand()
        {
            string[] args = { "0", "1", "Test01-02" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(0, 0);
            variables.Add(1, 2);
            variables.Add(2, -1);
            variables.Add(10, 104);
            actions.Add("Test01-02", "..\\..\\..\\Test01\\Test01-02");

            var runData = new RunData("hoge", variables, actions, new Random());

            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                Console.SetOut(writer);
                var command = new LoopCommand(args, runData);
                command.Execute();

                using (var reader = new StringReader(builder.ToString()))
                {
                    var consoleMessage = reader.ReadToEnd().Replace("\0", "");

                    Assert.AreEqual(consoleMessage, "hh");
                }
            }
        }

        [Test]
        public void AddCommand()
        {
            string[] args = { "10", "11" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 14);
            variables.Add(11, 7);

            var runData = new RunData("hoge", variables, actions, new Random());

            var command = new AddCommand(args, runData);
            command.Execute();

            Assert.AreEqual(variables[10], 21);
        }
    }
}