using System;
using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame
{
    public class GameController : IDisposable
    {
        private readonly UIController _uiController;
        private readonly IncreaseLevelController _levelController;
        private readonly GameSettings _gameSettings;
        private readonly IncreaseLevelSettings _increaseLevelSettings;
        private readonly List<MainMonsterController> _monsterControllers = new List<MainMonsterController>();
        private readonly int _countOfMonsterToLose;

        private int _countOfActiveMonsters;
        private int _killedCounter;
        private int _level = 1;

        public bool GameOn { get; set; }

        public GameController(List<MainMonsterController> monsterControllers, UIController uiController, IncreaseLevelController levelController)
        {
            Time.timeScale = 1;

            _uiController = uiController;
            _uiController.ShowLevel(_level.ToString());
            _uiController.ShowScore(_killedCounter.ToString());

            _levelController = levelController;

            _gameSettings = Resources.Load<GameSettings>("Settings/GameSettings");
            _countOfMonsterToLose = _gameSettings.CountOfMonsterToLose;

            _increaseLevelSettings = Resources.Load<IncreaseLevelSettings>("Settings/IncreaseLevelSettings");

            _monsterControllers = monsterControllers;

            foreach (MainMonsterController monster in _monsterControllers)
            {
                monster.Killed += KillMonster;
                monster.BirthController.BirthAction += AddActiveMonster;
                monster.DeathController.DeathAction += RemoveActiveMonster;
            }

            Init();
        }
        public void CheckActiveMonster()
        {
            if (_countOfActiveMonsters >= _countOfMonsterToLose)
            {
                GameOver();
            }
        }
        public void Dispose()
        {
            foreach (MainMonsterController monster in _monsterControllers)
            {
                monster.Killed -= KillMonster;
                monster.BirthController.BirthAction -= AddActiveMonster;
                monster.DeathController.DeathAction -= RemoveActiveMonster;
            }
        }
        private void KillMonster()
        {
            _killedCounter++;
            _uiController.ShowScore(_killedCounter.ToString());
            LevelChecker();
        }

        private void LevelChecker()
        {
            if (_killedCounter % _increaseLevelSettings.ValueToIncreaseLevel == 0)
            {
                _level++;
                _uiController.ShowLevel(_level.ToString());
                _levelController.IncreaseLevel(_level);
            }
        }
        private void Init()
        {
            _countOfActiveMonsters = 0;
            GameOn = true;
        }
        private void AddActiveMonster()
        {
            _countOfActiveMonsters++;
            CheckActiveMonster();
        }
        private void RemoveActiveMonster()
        {
            _countOfActiveMonsters--;
        }
        private void GameOver()
        {
            GameOn = false;
            Time.timeScale = 0;
            _uiController.ShowGameOver();
        }
    }
}