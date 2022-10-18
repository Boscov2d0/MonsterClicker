using System;
using UnityEngine;

namespace MonstersGame
{
    public abstract class Monster : MonoBehaviour
    {
        [SerializeField] private int _healthPoints;
        [SerializeField] private float _speed;
        [SerializeField] private float _birthTimer;
        [SerializeField] private float _deathTimer;
        [SerializeField] private float _startPositionY;
        [SerializeField] private bool _startInit;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _monsterTransform;
        [SerializeField] private Transform _monsterBody;
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private ParticleSystem _deathEffect;
        [SerializeField] private GameObject _birthEffect;

        public int HealthPoints { get => _healthPoints; set => _healthPoints = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float BirthTimer { get => _birthTimer; set => _birthTimer = value; }
        public float DeathTimer { get => _deathTimer; set => _deathTimer = value; }
        public float StartPositionY { get => _startPositionY; set => _startPositionY = value; }
        public bool StartInit { get => _startInit; set => _startInit = value; }
        public Transform MonsterTransform { get => _monsterTransform; set => _monsterTransform = value; }
        public Transform MonsterBody { get => _monsterBody; set => _monsterBody = value; }
        public Rigidbody RigidBody { get => _rigidbody; set => _rigidbody = value; }
        public BoxCollider Collider { get => _collider; set => _collider = value; }
        public ParticleSystem DeathEffect { get => _deathEffect; set => _deathEffect = value; }
        public GameObject BirthEffect { get => _birthEffect; set => _birthEffect = value; }

        public Action Obstacle;
        public Action<int> OnTapAction;

        public virtual void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall")
            {
                Obstacle?.Invoke();
            }
        }
        public virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Monster monster))
            {
                Obstacle?.Invoke();
            }
        }
        public virtual void Init() 
        {
            MonsterBody.gameObject.SetActive(true);
            Collider.enabled = true;
            RigidBody.isKinematic = false;
        }
        public void OnTap(int damage) 
        {
            OnTapAction?.Invoke(damage);
        }
    }
}