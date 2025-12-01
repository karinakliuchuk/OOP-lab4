namespace DuelingClubAppStarWars
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}