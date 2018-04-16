using CommandPattern;
using CommandPattern.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandDirector
    {
        public CommandRespiratory CommandRespiratory { get; set; }
        public string Title { get; set; }

        public CommandDirector(CommandRespiratory cr)
        {
            CommandRespiratory = cr;
            Title = "";
        }

        public CommandDirector()
        {
        }

        public void Start()
        {
            Console.Clear();
            Runner();
        }

        private void Runner()
        {
            PrintTitle();
            Console.Write("L ");
            string[] input = Console.ReadLine().GetParams(); // TODO Add proper input check.

            DirectCommand(input);

            if (!input[0].Equals("exit"))
            {
                Runner();
            }
            else
            {
                Console.Clear();
            }

        }

        public void DirectCommand(string[] input)
        {
            string inputHandler = input[0];

            try // Try running command.
            {
                if (CommandRespiratory.InputHandleExists(inputHandler))
                {
                    ICommand cmd = CommandRespiratory.GetFunction(inputHandler).Invoke(input.Skip(1).ToArray());
                    cmd.Execute();
                }
            }
            catch (CommandException e)
            {
                Console.WriteLine(e);
            }

        }

        private void PrintTitle()
        {
            if (!String.IsNullOrEmpty(Title) && Console.CursorTop == 0) // Display title if it exists.
            {
                Console.WriteLine(Title);
            }
        }

        private void Commands()
        {

        }

    }
}
