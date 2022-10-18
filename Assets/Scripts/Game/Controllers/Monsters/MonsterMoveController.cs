using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonstersGame
{
    public class MonsterMoveController : IMonsterMovement, IDisposable
    {
        private readonly Monster _monster;
        private readonly Transform _monsterTransform;
        private readonly float _speed;

        private float _positionX;
        private float _positionZ;

        public MonsterMoveController(Monster monster)
        {
            _monster = monster;
            _monster.Obstacle += ChangeDirection;
            _monsterTransform = monster.MonsterTransform;

            _speed = monster.Speed;
        }
        public void ChangeDirection()
        {
            _positionX *= -1f;
            _positionZ *= -1f;
        }

        public void Init()
        {
            _positionX = Random.Range(-1f, 1f);
            _positionZ = Random.Range(-1f, 1f);
        }

        public virtual void Movement()
        {
            _monsterTransform.position += new Vector3(_positionX * _speed, 0, _positionZ * _speed);
        }

        public void Dispose()
        {
            _monster.Obstacle -= ChangeDirection;
        }
    }
}