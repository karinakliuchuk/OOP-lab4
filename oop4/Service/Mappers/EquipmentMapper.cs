using DuelingClubAppStarWars.Entities;
using DuelingClubAppStarWars.Service.Views;
using DuelingClubAppStarWars.Service.Views;


namespace oop4.Service.Mappers
{
    public static class EquipmentMapper { public static EquipmentView ToView(Equipment e) => new EquipmentView { 
        Id = e.Id, 
        Name = e.Name, 
        Power = e.Power }; 
    }
}