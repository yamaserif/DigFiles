using NUnit.Framework;
using DigFiles_interpreter.Business;
using System.Collections.Generic;
using DigFiles_interpreter.Classes;
using System;
using System.Text;
using System.IO;

namespace DigFiles_Test
{
    public class TestBusiness
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Actions_GetActions()
        {
            var path = "..\\..\\..\\Test01";
            var actions = new Dictionary<string, string>();

            Actions.GetActions(path, actions);
            Assert.True(actions.ContainsKey("Test01-01") &&
                        actions.ContainsKey("Test01-01-01") &&
                        actions.ContainsKey("Test01-01-02") &&
                        actions.ContainsKey("Test01-02"));
        }

        [Test]
        public void Actions_GetActionId()
        {
            var path = "..\\..\\..\\Test01\\Test01-01\\#Test01-01-02";

            var result = Actions.GetActionId(path);
            Assert.AreEqual(result, "Test01-01-02");
        }

        [Test]
        public void Commands_GetCommand()
        {
            var path = "..\\..\\..\\Test01\\Test01-01\\Test01-01-01\\set.txt";

            var result = Commands.GetCommand(path);
            Assert.AreEqual(result, "set");
        }

        [Test]
        public void Commands_ExeCommand_Set()
        {
            var commandName = "set";
            string[] args = { "10", "1234" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            var runData = new RunData("hoge", variables, actions, new Random());
            Commands.ExeCommand(commandName, args, runData);

            Assert.AreEqual(variables[10], 1234);
        }

        [Test]
        public void Commands_ExeCommand_Copy()
        {
            var commandName = "copy";
            string[] args = { "10", "11" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 1000);
            variables.Add(11, 1234);

            var runData = new RunData("hoge", variables, actions, new Random());
            Commands.ExeCommand(commandName, args, runData);

            Assert.AreEqual(variables[10], 1234);
        }

        [Test]
        public void Commands_ExeCommand_In()
        {
            var commandName = "in";
            string[] args = { "10" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            var runData = new RunData("hoge", variables, actions, new Random());
            Commands.ExeCommand(commandName, args, runData);

            Assert.AreEqual(variables[10], 104);
        }

        [Test]
        public void Commands_ExeCommand_Out()
        {
            var commandName = "out";
            string[] args = { "10" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 104);

            var runData = new RunData("hoge", variables, actions, new Random());

            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                Console.SetOut(writer);
                Commands.ExeCommand(commandName, args, runData);

                using (var reader = new StringReader(builder.ToString()))
                {
                    var consoleMessage = reader.ReadToEnd().Replace("\0", "");

                    Assert.AreEqual(consoleMessage, "h");
                }
            }
        }

        [Test]
        public void Commands_ExeCommand_Loop()
        {
            var commandName = "loop";
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
                Commands.ExeCommand(commandName, args, runData);

                using (var reader = new StringReader(builder.ToString()))
                {
                    var consoleMessage = reader.ReadToEnd().Replace("\0", "");

                    Assert.AreEqual(consoleMessage, "hh");
                }
            }
        }

        [Test]
        public void Commands_ExeCommand_Add()
        {
            var commandName = "add";
            string[] args = { "10", "11" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 14);
            variables.Add(11, 7);

            var runData = new RunData("hoge", variables, actions, new Random());

            Commands.ExeCommand(commandName, args, runData);

            Assert.AreEqual(variables[10], 21);
        }

        [Test]
        public void Commands_ExeCommand_Exception()
        {
            var commandName = "test";
            string[] args = { "" };

            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            var runData = new RunData("hoge", variables, actions, new Random());

            var ex = Assert.Throws<DigFilesException>(() =>
            {
                Commands.ExeCommand(commandName, args, runData);
            });

            Assert.AreEqual(ex.Message, "Undefined command.");
        }

        [Test]
        public void Run_Start()
        {
            var variables = new Dictionary<int, int>();
            var actions = new Dictionary<string, string>();

            variables.Add(10, 104);

            var runData = new RunData("hoge", variables, actions, new Random());

            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder))
            {
                Console.SetOut(writer);
                Run.Start("..\\..\\..\\Test01\\Test01-02\\0-out", runData);

                using (var reader = new StringReader(builder.ToString()))
                {
                    var consoleMessage = reader.ReadToEnd().Replace("\0", "");

                    Assert.AreEqual(consoleMessage, "h");
                }
            }
        }
    }
}