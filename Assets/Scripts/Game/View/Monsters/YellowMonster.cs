using UnityEngine;

namespace MonstersGame
{
    public class YellowMonster : Monster
    {
        [SerializeField] private float _heightFly;
        [SerializeField] private float _flyAmplitude;
        public float HeightFly { get => _heightFly; set => _heightFly = value; }
        public float FlyAmplitude { get => _flyAmplitude; set => _flyAmplitude = value; }
    }
}