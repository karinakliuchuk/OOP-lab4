using System.Collections.Generic;
using DuelingClubAppStarWars.Entities;


namespace DuelingClubAppStarWars.Database
{
    public class GalaxyDbContext
    {
        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
        public List<Equipment> Equipments { get; set; }


        public GalaxyDbContext()
        {
            Players = new();
            Games = new();
            Equipments = new();
            SeedData();
        }


        private void SeedData()
        {
            Players.Add(new Player { Id = 1, Name = "Luke Skywalker", AccountType = "JediOrder", Rating = 1500 });
            Players.Add(new Player { Id = 2, Name = "Darth Vader", AccountType = "GalacticEmpire", Rating = 1600 });


            Games.Add(new Game { Id = 1, Title = "Battle of Yavin", Planet = "Yavin" });
            Games.Add(new Game { Id = 2, Title = "Training on Dagobah", Planet = "Dagobah" });


            Equipments.Add(new Equipment { Id = 1, Name = "Lightsaber", Power = 100 });
            Equipments.Add(new Equipment { Id = 2, Name = "Blaster", Power = 40 });
        }
    }
}