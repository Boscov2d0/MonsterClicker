using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame 
{
    public class IncreaseLevelController
    {
        private readonly List<MainMonsterController> _mainMonsterControllers = new List<MainMonsterController>();
        private readonly MonstersPoolController _monstersPoolController;
        private readonly IncreaseLevelSettings _levelSettings;
        private readonly GameSettings _gameSettings;

        public IncreaseLevelController(MonstersPoolController monstersPoolController)
        {
            _mainMonsterControllers = monstersPoolController.MonstersList;

            _monstersPoolController = monstersPoolController;

            _levelSettings = Resources.Load<IncreaseLevelSettings>("Settings/IncreaseLevelSettings");
            _gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
        }
        
        public void IncreaseLevel(int levelsHard)
        {
            if (levelsHard % _levelSettings.LevelToIncreaseSpeed == 0)
            {
                IncreaseSpeed();
            }
            if (levelsHard % _levelSettings.LevelToDecreaseSpawnTimer == 0)
            {
                DecreaseSpawnTimer();
            }
            if (levelsHard % _levelSettings.LevelToAddNewMonsterType == 0)
            {
                AddNewMonsterType();
            }
            if (levelsHard % _levelSettings.LevelToIncreaseHealthPoint == 0)
            {
                IncreaseHealthPoint();
            }
        }

        private void AddNewMonsterType()
        {
            if (_monstersPoolController.CountOfType < _gameSettings.CountOfMonsterType)
            {
                _monstersPoolController.CountOfType++;
            }
        }
        private void IncreaseSpeed()
        {
            foreach (MainMonsterController monsterController in _mainMonsterControllers) 
            {
                monsterController.IncreaseSpeed();
            }
        }
        private void IncreaseHealthPoint()
        {
            foreach (MainMonsterController monsterController in _mainMonsterControllers)
            {
                monsterController.IncreaseHealthPoint();
            }
        }
        private void DecreaseSpawnTimer() 
        {
            _monstersPoolController.TimeToSpawn -= _levelSettings.TimeOfDecreaseSpawnTimer;
            _monstersPoolController.Init();
        }
    }
}