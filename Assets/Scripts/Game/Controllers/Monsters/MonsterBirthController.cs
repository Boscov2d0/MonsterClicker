using System;
using UnityEngine;

namespace MonstersGame
{
    public class MonsterBirthController
    {
        private readonly Monster _monster;
        private readonly GameObject _birthEffect;

        private readonly float _birthTimer;

        private float _currentBirthTimer;

        public bool IsBirth { get; set; }
        public Action BirthAction;

        public MonsterBirthController(Monster monster)
        {
            _monster = monster;
            _birthTimer = monster.BirthTimer;

            if (monster.BirthEffect)
            {
                _birthEffect = monster.BirthEffect;
            }
        }
        public void Init()
        {
            if (_birthEffect)
            {
                _birthEffect.gameObject.SetActive(true);
            }
            _currentBirthTimer = _birthTimer;
            IsBirth = false;
        }
        public void Birth()
        {
            IsBirth = true;

            if (_birthEffect)
            {
                _birthEffect.gameObject.SetActive(false);
            }
            if (!_monster.StartInit)
            {
                _monster.Init();
            }

            BirthAction?.Invoke();
        }
        public void Execute()
        {
            if (!IsBirth)
            {
                _currentBirthTimer -= Time.deltaTime;
                if (_currentBirthTimer <= 0)
                {
                    Birth();
                }
            }
        }
    }
}