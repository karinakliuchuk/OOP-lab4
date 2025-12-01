using System.Collections.Generic;
using System.Linq;
using DuelingClubAppStarWars.Database;
using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Repository.Base;


namespace DuelingClubAppStarWars.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly GalaxyDbContext _db;
        public GameRepository(GalaxyDbContext db) => _db = db;
        public void Add(Game entity) => _db.Games.Add(entity);
        public Game GetById(int id) => _db.Games.First(x => x.Id == id);
        public List<Game> GetAll() => _db.Games.ToList();
        public void Update(Game entity)
        {
            var g = GetById(entity.Id);
            g.Title = entity.Title; g.Planet = entity.Planet;
        }
        public void Delete(int id) => _db.Games.Remove(GetById(id));
    }
}