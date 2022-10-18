namespace MonstersGame
{
    public interface IBooster
    {
        void ActivateBooster();
        void DeactivateBooster();
        void TimeOfBoostWork();
        void Execute();
    }
}