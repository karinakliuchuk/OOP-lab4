using System;
using DuelingClubAppStarWars.Service.Base;

namespace DuelingClubAppStarWars
{
    public class RunSimulationCommand : ICommand
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        public string Name => "run-simulation";

        public RunSimulationCommand(IPlayerService playerService, IGameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public void Execute()
        {
            var players = _playerService.GetAll();
            var games = _gameService.GetAll();

            Console.WriteLine("Running simulation...");
            Console.WriteLine($"Found {players.Count} players and {games.Count} games");

            foreach (var game in games)
            {
                Console.WriteLine($"Simulating game: {game.Title} on {game.Planet}");
            }
        }
    }
}
