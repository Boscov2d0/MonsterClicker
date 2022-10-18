using System;
using UnityEngine;

namespace MonstersGame
{
    public class MonsterDeathController : IDisposable
    {
        private readonly Monster _monster;
        private readonly Transform _body;
        private readonly ParticleSystem _deathEffect;
        private readonly BoxCollider _collider;
        private readonly Rigidbody _rigidbody;

        private readonly float _deathTimer;

        private int _maxHealthPoint;
        private int _currentHealthPoint;
        private float _currentDeathTimer;
        private bool _preDeath;

        public bool IsDeath { get; set; }
        public Action DeathAction;

        public MonsterDeathController(Monster monster)
        {
            _monster = monster;
            _monster.OnTapAction += OnHitChange;
            _maxHealthPoint = monster.HealthPoints;
            _body = monster.MonsterBody;
            _deathEffect = monster.DeathEffect;
            _collider = monster.Collider;
            _rigidbody = monster.RigidBody;
            _deathTimer = monster.DeathTimer;
        }
        public void Init() 
        {
            _maxHealthPoint = _monster.HealthPoints;
            _deathEffect.gameObject.SetActive(false);
            _currentHealthPoint = _maxHealthPoint;
            _currentDeathTimer = _deathTimer;
            IsDeath = false;
        }
        public void Execute() 
        {
            if (_preDeath) 
            {
                _currentDeathTimer -= Time.deltaTime;
                if (_currentDeathTimer <= 0) 
                {
                    Death();
                }
            }
        }
        public void OnHitChange(int damage)
        {
            _currentHealthPoint -= damage;
            CheckHP();
        }
        public void Dispose()
        {
            _monster.OnTapAction -= OnHitChange;
        }
        private void CheckHP()
        {
            if (_currentHealthPoint <= 0)
            {
                PreDeath();
            }
        }
        private void PreDeath()
        {
            _rigidbody.isKinematic = true;
            _collider.enabled = false;

            _body.gameObject.SetActive(false);
            _deathEffect.gameObject.SetActive(true);

            _preDeath = true;
        }
        private void Death()
        {
            _preDeath = false;
            IsDeath = true;
            _monster.transform.position = new Vector3(0, 0, 0);
            DeathAction?.Invoke();
        }
    }
}