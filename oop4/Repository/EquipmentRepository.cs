using System.Collections.Generic;
using System.Linq;
using DuelingClubAppStarWars.Database;
using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Repository.Base;


namespace DuelingClubAppStarWars.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly GalaxyDbContext _db;
        public EquipmentRepository(GalaxyDbContext db) => _db = db;
        public void Add(Equipment entity) => _db.Equipments.Add(entity);
        public Equipment GetById(int id) => _db.Equipments.First(x => x.Id == id);
        public List<Equipment> GetAll() => _db.Equipments.ToList();
        public void Update(Equipment entity)
        {
            var e = GetById(entity.Id);
            e.Name = entity.Name; e.Power = entity.Power;
        }
        public void Delete(int id) => _db.Equipments.Remove(GetById(id));
    }
}