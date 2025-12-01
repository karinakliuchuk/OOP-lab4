using System.Collections.Generic;
using System.Linq;
using DuelingClubAppStarWars.Repository.Base;
using DuelingClubAppStarWars.Service.Base;
using DuelingClubAppStarWars.Service.Mappers;
using DuelingClubAppStarWars.Service.Views;

namespace DuelingClubAppStarWars.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepo;

        public GameService(IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        public List<GameView> GetAll() =>
            _gameRepo.GetAll().Select(GameMapper.ToView).ToList();

        public GameView GetById(int id) =>
            GameMapper.ToView(_gameRepo.GetById(id));
    }
}