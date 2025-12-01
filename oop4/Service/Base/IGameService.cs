using System.Collections.Generic;
using DuelingClubAppStarWars.Service.Views;


namespace DuelingClubAppStarWars.Service.Base
{
    public interface IGameService
    {
        List<GameView> GetAll();
        GameView GetById(int id);
    }
}