namespace MonstersGame
{
    public class PencilBoosterController : BoosterController
    {
        private readonly MonstersPoolController _monstersPool;

        public PencilBoosterController(BoosterPencilView booster, MonstersPoolController monstersPool) : base(booster) 
        {
            _monstersPool = monstersPool;
        }
        public override void ActivateBooster()
        {
            if (CanActivateBoost)
            {
                _monstersPool.PauseSpawn(true);
            }

            base.ActivateBooster();
        }
        public override void DeactivateBooster()
        {
            _monstersPool.PauseSpawn(false);
            base.DeactivateBooster();
        }
    }
}