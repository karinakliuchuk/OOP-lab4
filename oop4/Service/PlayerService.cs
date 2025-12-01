using System.Collections.Generic;
using System.Linq;
using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Repository.Base;
using DuelingClubAppStarWars.Service.Base;
using DuelingClubAppStarWars.Service.Mappers;
using DuelingClubAppStarWars.Service.Views;

namespace DuelingClubAppStarWars.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepo;
        private readonly IEquipmentRepository _equipmentRepo;

        public PlayerService(IPlayerRepository playerRepo, IEquipmentRepository equipmentRepo)
        {
            _playerRepo = playerRepo;
            _equipmentRepo = equipmentRepo;
        }

        public List<PlayerView> GetAll() => _playerRepo.GetAll().Select(PlayerMapper.ToView).ToList();

        public PlayerView GetById(int id) => PlayerMapper.ToView(_playerRepo.GetById(id));

        public void AddPlayer(PlayerView player) => _playerRepo.Add(PlayerMapper.ToEntity(player));

        public List<PlayerView> GetByAccountType(string accountType) =>
            _playerRepo.GetByAccountType(accountType).Select(PlayerMapper.ToView).ToList();

        public void ApplyEquipmentToPlayer(int playerId, int equipmentId)
        {
            var player = _playerRepo.GetById(playerId);
            var equipment = _equipmentRepo.GetById(equipmentId);
            player.Rating += equipment.Power;
            _playerRepo.Update(player);
        }
    }
}