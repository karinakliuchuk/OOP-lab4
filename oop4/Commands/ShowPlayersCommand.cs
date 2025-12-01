using System;
using DuelingClubAppStarWars.Service.Base;

namespace DuelingClubAppStarWars
{
    public class ShowPlayersCommand : ICommand
    {
        private readonly IPlayerService _playerService;
        public string Name => "show-players";

        public ShowPlayersCommand(IPlayerService playerService) => _playerService = playerService;

        public void Execute()
        {
            var players = _playerService.GetAll();
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Id}: {player.Name} ({player.AccountType}) - Rating: {player.Rating}");
            }
        }
    }
}