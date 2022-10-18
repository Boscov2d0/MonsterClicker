namespace MonstersGame
{
    public class PenBoosterController : BoosterController
    {
        private readonly Player _player;
        private readonly int _valueOfKillPowerBefore;
        private readonly int _valueOfKillPowerWithBoost;

        public PenBoosterController(BoosterPenView booster, Player player) : base(booster)
        {
            _player = player;
            _valueOfKillPowerBefore = player.ForceOfDamage;
            _valueOfKillPowerWithBoost = booster.ValueOfKillPower;
        }
        public override void ActivateBooster()
        {
            if (CanActivateBoost)
            {
                _player.ForceOfDamage = _valueOfKillPowerWithBoost;
                _player.Initialize?.Invoke();
            }

            base.ActivateBooster();
        }
        public override void DeactivateBooster()
        {
            _player.ForceOfDamage = _valueOfKillPowerBefore;
            _player.Initialize?.Invoke();
            base.DeactivateBooster();
        }
    }
}