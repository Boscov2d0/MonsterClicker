using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

namespace MonstersGame
{
    public class MonstersPoolController
    {
        private readonly Transform _spawnPoint;
        private readonly List<MainMonsterController> _blackMonsterControllers = new List<MainMonsterController>();
        private readonly List<MainMonsterController> _yellowMonsterControllers = new List<MainMonsterController>();
        private readonly List<MainMonsterController> _redMonsterControllers = new List<MainMonsterController>();
        private readonly List<MainMonsterController> _activeMonsters = new List<MainMonsterController>();

        private List<MainMonsterController> _monstersList = new List<MainMonsterController>();

        private readonly float _minXPos;
        private readonly float _maxXPos;
        private readonly float _minZPos;
        private readonly float _maxZPos;

        private int _indexForBlack;
        private int _indexForYellow;
        private int _indexForRed;
        private float _reloadTime;
        private bool _spawned;
        private bool _stopSpawn;

        public int CountOfType { get; set; }
        public float TimeToSpawn { get; set; }

        public Action KillMonster;

        public List<MainMonsterController> MonstersList { get => _monstersList; set => _monstersList = value; }

        public MonstersPoolController(MonstersPoolView monstersPool)
        {
            _spawnPoint = monstersPool.SpawnPoint;

            TimeToSpawn = monstersPool.TimeToSpawn;
            CountOfType = monstersPool.CountOfType;

            _minXPos = monstersPool.MinXObjectPos;
            _maxXPos = monstersPool.MaxXObjectPos;
            _minZPos = monstersPool.MinZObjectPos;
            _maxZPos = monstersPool.MaxZObjectPos;

            foreach (Monster monster in monstersPool.BlackMonsters)
            {
                MainMonsterController monsterController = new MainMonsterController(monster, new MonsterMoveController(monster));
                _blackMonsterControllers.Add(monsterController);
                MonstersList.Add(monsterController);
            }
            foreach (YellowMonster monster in monstersPool.YellowMonsters)
            {
                MainMonsterController monsterController = new MainMonsterController(monster, new MonsterFlyController(monster));
                _yellowMonsterControllers.Add(monsterController);
                MonstersList.Add(monsterController);
            }
            foreach (RedMonster monster in monstersPool.RedMonsters)
            {
                MainMonsterController monsterController = new MainMonsterController(monster, new MonsterJumpController(monster));
                
                _redMonsterControllers.Add(monsterController);
                MonstersList.Add(monsterController);
            }
        }

        public void Init()
        {
            _reloadTime = TimeToSpawn;
        }

        private void Spawn()
        {
            int type = Random.Range(0, CountOfType + 1);

            switch (type)
            {
                case 0:
                    MonsterSpawn(_blackMonsterControllers, ref _indexForBlack);
                    break;
                case 1:
                    MonsterSpawn(_yellowMonsterControllers, ref _indexForYellow);
                    break;
                case 2:
                    MonsterSpawn(_redMonsterControllers, ref _indexForRed);
                    break;
            }
        }

        private void MonsterSpawn(List<MainMonsterController> monstersList, ref int index)
        {
            if (!monstersList[index].IsActive)
            {
                _activeMonsters.Add(monstersList[index]);
                monstersList[index].MonsterTransform.position = new Vector3(_spawnPoint.position.x + Random.Range(_minXPos, _maxXPos),
                                                                            _spawnPoint.position.y + monstersList[index].Monster.StartPositionY,
                                                                            _spawnPoint.position.z + Random.Range(_minZPos, _maxZPos));

                monstersList[index].Init();

                _spawned = true;
            }

            index++;

            if (index >= monstersList.Count)
            {
                index = 0;
            }
        }

        public void SpawnTimer()
        {
            if (_spawned)
            {
                _reloadTime -= Time.deltaTime;
            }
            if (_reloadTime <= 0)
            {
                _reloadTime = TimeToSpawn;
                _spawned = false;

                Spawn();
            }
            if (!_spawned)
            {
                Spawn();
            }
        }

        public void PauseSpawn(bool spawn)
        {
            _stopSpawn = spawn;
        }
        public void Execute()
        {
            if (!_stopSpawn)
            {
                SpawnTimer();
            }

            foreach (MainMonsterController monster in _blackMonsterControllers)
            {
                if (!monster.IsActive)
                {
                    _activeMonsters.Remove(monster);
                }
            }
            foreach (MainMonsterController monster in _yellowMonsterControllers)
            {
                if (!monster.IsActive)
                {
                    _activeMonsters.Remove(monster);
                }
            }
            foreach (MainMonsterController monster in _redMonsterControllers)
            {
                if (!monster.IsActive)
                {
                    _activeMonsters.Remove(monster);
                }
            }

            foreach (MainMonsterController monster in _activeMonsters)
            {
                monster.Execute();
            }
        }
    }
}