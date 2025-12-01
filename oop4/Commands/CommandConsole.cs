using System;

namespace DuelingClubAppStarWars
{
    public class CommandConsole
    {
        private readonly ICommand[] _commands;

        public CommandConsole(ICommand[] commands) => _commands = commands;

        public void Run()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim().ToLower();

                if (input == "exit") break;

                var command = Array.Find(_commands, c => c.Name == input);
                if (command != null)
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("Unknown command. Type 'help' for available commands.");
                }
            }
        }
    }
}