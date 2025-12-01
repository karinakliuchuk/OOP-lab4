using System.Collections.Generic;
using System.Linq;
using DuelingClubAppStarWars.Database;
using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Repository.Base;


namespace DuelingClubAppStarWars.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GalaxyDbContext _db;
        public PlayerRepository(GalaxyDbContext db) => _db = db;


        public void Add(Player entity) => _db.Players.Add(entity);
        public Player GetById(int id) => _db.Players.First(x => x.Id == id);
        public List<Player> GetAll() => _db.Players.ToList();
        public void Update(Player entity)
        {
            var p = GetById(entity.Id);
            p.Name = entity.Name; p.AccountType = entity.AccountType; p.Rating = entity.Rating;
        }
        public void Delete(int id) => _db.Players.Remove(GetById(id));
        public List<Player> GetByAccountType(string accountType) => _db.Players.Where(p => p.AccountType == accountType).ToList();
    }
}