using System;

namespace DuelingClubAppStarWars
{
    public class HelpCommand : ICommand
    {
        public string Name => "help";

        public void Execute()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("show-players - Display all players");
            Console.WriteLine("add-player - Add a new player");
            Console.WriteLine("run-simulation - Run game simulation");
            Console.WriteLine("help - Show this help");
        }
    }
}