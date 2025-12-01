using System;
using DuelingClubAppStarWars.Service.Base;
using DuelingClubAppStarWars.Service.Views;

namespace DuelingClubAppStarWars
{
    public class AddPlayerCommand : ICommand
    {
        private readonly IPlayerService _playerService;
        public string Name => "add-player";

        public AddPlayerCommand(IPlayerService playerService) => _playerService = playerService;

        public void Execute()
        {
            Console.Write("Enter player name: ");
            var name = Console.ReadLine();
            Console.Write("Enter account type (JediOrder/GalacticEmpire): ");
            var accountType = Console.ReadLine();
            Console.Write("Enter rating: ");
            var rating = int.Parse(Console.ReadLine());

            var player = new PlayerView { Name = name, AccountType = accountType, Rating = rating };
            _playerService.AddPlayer(player);
            Console.WriteLine("Player added successfully!");
        }
    }
}