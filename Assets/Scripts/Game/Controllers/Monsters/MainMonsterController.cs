using System;
using UnityEngine;

namespace MonstersGame
{
    public class MainMonsterController
    {
        private readonly IMonsterMovement _monsterMovement;
        private readonly IncreaseLevelSettings _increaseLevelSettings;

        public Monster Monster { get; set; }
        public Transform MonsterTransform { get; set; }

        public MonsterBirthController BirthController { get; set; }
        public MonsterDeathController DeathController { get; set; }

        public bool IsActive { get; set; }

        public Action Killed;
        public MainMonsterController(Monster monster, IMonsterMovement monsterMovement)
        {
            Monster = monster;
            _monsterMovement = monsterMovement;
            MonsterTransform = monster.MonsterTransform;
            BirthController = new MonsterBirthController(Monster);
            DeathController = new MonsterDeathController(Monster);

            _increaseLevelSettings = Resources.Load<IncreaseLevelSettings>("Settings/IncreaseLevelSettings");
        }
        public void Init()
        {
            if (Monster.StartInit)
            {
                Monster.Init();
            }
            DeathController.Init();
            _monsterMovement.Init();
            BirthController.Init();
            IsActive = true;
        }
        public void Execute()
        {
            BirthController.Execute();

            if (!DeathController.IsDeath && BirthController.IsBirth)
            {
                _monsterMovement.Movement();
            }

            if (DeathController.IsDeath)
            {
                IsActive = false;
                Killed?.Invoke();
            }

            DeathController.Execute();
        }
        public void MomentoMori()
        {
            if (IsActive)
            {
                DeathController.OnHitChange(Monster.HealthPoints);
            }
        }
        public void IncreaseSpeed() 
        {
            Monster.Speed += _increaseLevelSettings.ValueOfIncreaseSpeed;
            _monsterMovement.Init();
        }
        public void IncreaseHealthPoint()
        {
            Monster.HealthPoints *= _increaseLevelSettings.ValueOfIncreaseHealthPoint;
            _monsterMovement.Init();
        }
    }
}