using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Service.Views;
using DuelingClubAppStarWars.Service.Views;


namespace DuelingClubAppStarWars.Service.Mappers
{
    public static class GameMapper { public static GameView ToView(Game g) => new GameView { 
        Id = g.Id, 
        Title = g.Title, 
        Planet = g.Planet }; 
    }
}