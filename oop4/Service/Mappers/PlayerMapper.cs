using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Service.Views;
using DuelingClubAppStarWars.Service.Views;


namespace DuelingClubAppStarWars.Service.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerView ToView(Player p) => new PlayerView { 
            Id = p.Id, 
            Name = p.Name, 
            AccountType = p.AccountType, 
            Rating = p.Rating 
        };
        public static Player ToEntity(PlayerView v) => new Player { 
            Id = v.Id, 
            Name = v.Name, 
            AccountType = v.AccountType, 
            Rating = v.Rating };
    }
}