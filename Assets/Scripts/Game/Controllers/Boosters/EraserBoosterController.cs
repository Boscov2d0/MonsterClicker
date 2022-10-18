using System.Collections.Generic;

namespace MonstersGame
{
    public class EraserBoosterController : BoosterController
    {
        private readonly List<MainMonsterController> _monstersList;

        public EraserBoosterController(BoosterEraserView booster, List<MainMonsterController> monstersList) : base(booster)
        {
            _monstersList = monstersList;
        }
        public override void ActivateBooster()
        {            
            if (CanActivateBoost)
            {
                foreach (MainMonsterController monsterController in _monstersList)
                {
                    monsterController.MomentoMori();
                }
            }

            base.ActivateBooster();
        }
    }
}