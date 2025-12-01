using DuelingClubAppStarWars.Database;
using DuelingClubAppStarWars.Repository;
using DuelingClubAppStarWars.Service;
using DuelingClubAppStarWars.Service.Base;
using DuelingClubAppStarWars.Service.Views;
using DuelingClubAppStarWars.Database;
using DuelingClubAppStarWars.Repository;
using oop4.Service;
using DuelingClubAppStarWars.Service.Base;
using System;

namespace oop4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Ініціалізуємо DB/context
            var db = new GalaxyDbContext();

            // Репозиторії
            var playerRepo = new PlayerRepository(db);
            var gameRepo = new GameRepository(db);
            var equipmentRepo = new EquipmentRepository(db);

            // Сервіси
            var playerService = new PlayerService(playerRepo, equipmentRepo);
            var gameService = new GameService(gameRepo);

            // Команди (реалізації інтерфейсу ICommand)
            var commands = new ICommand[]
            {
                new ShowPlayersCommand(playerService),
                new AddPlayerCommand(playerService),
                new RunSimulationCommand(playerService, gameService),
                new HelpCommand()
            };

            var consoleApp = new CommandConsole(commands);

            Console.WriteLine("Star Wars Duel Club — Console Admin Interface");
            consoleApp.Run();
        }
    }

    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }

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

            // Simple simulation logic
            foreach (var game in games)
            {
                Console.WriteLine($"Simulating game: {game.Title} on {game.Planet}");
            }
        }
    }

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
            Console.WriteLine("exit - Exit the application");
        }
    }
}