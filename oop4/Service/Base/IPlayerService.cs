using System.Collections.Generic;
using DuelingClubAppStarWars.Service.Views;


namespace DuelingClubAppStarWars.Service.Base
{
    public interface IPlayerService
    {
        List<PlayerView> GetAll();
        PlayerView GetById(int id);
        void AddPlayer(PlayerView player);
        List<PlayerView> GetByAccountType(string accountType);
        void ApplyEquipmentToPlayer(int playerId, int equipmentId);
    }
}