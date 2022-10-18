using System.Collections.Generic;
using UnityEngine;

namespace MonstersGame 
{
    public class MonstersPoolView : MonoBehaviour
    {
        [SerializeField] private List<BlackMonster> _blackMonsters;
        [SerializeField] private List<YellowMonster> _yellowMonsters;
        [SerializeField] private List<RedMonster> _redMonsters;
        [SerializeField] private Transform _spawnPoint;

        [SerializeField] private float _minXObjectPos;
        [SerializeField] private float _maxXObjectPos;
        [SerializeField] private float _minZObjectPos;
        [SerializeField] private float _maxZObjectPos;
        [SerializeField] private float _timeToSpawn;
        [SerializeField] private int _countOfType;        

        public List<BlackMonster> BlackMonsters { get => _blackMonsters; set => _blackMonsters = value; }
        public List<YellowMonster> YellowMonsters { get => _yellowMonsters; set => _yellowMonsters = value; }
        public List<RedMonster> RedMonsters { get => _redMonsters; set => _redMonsters = value; }
        public Transform SpawnPoint { get => _spawnPoint; set => _spawnPoint = value; }
        public float TimeToSpawn { get => _timeToSpawn; set => _timeToSpawn = value; }
        public int CountOfType { get => _countOfType; set => _countOfType = value; }
        public float MinXObjectPos { get => _minXObjectPos; set => _minXObjectPos = value; }
        public float MaxXObjectPos { get => _maxXObjectPos; set => _maxXObjectPos = value; }
        public float MinZObjectPos { get => _minZObjectPos; set => _minZObjectPos = value; }
        public float MaxZObjectPos { get => _maxZObjectPos; set => _maxZObjectPos = value; }
    }
}