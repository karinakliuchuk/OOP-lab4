using System.Collections.Generic;
using DuelingClubAppStarWars.Entities;


namespace DuelingClubAppStarWars.Repository.Base
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        List<Player> GetByAccountType(string accountType);
    }
}