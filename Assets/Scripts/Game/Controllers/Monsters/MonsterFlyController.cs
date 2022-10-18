using UnityEngine;

namespace MonstersGame
{
    public class MonsterFlyController : MonsterMoveController, IMonsterMovement
    {
        private readonly Transform _monsterTransform;
        private readonly float _heightFly;
        private readonly float _flyAmplitude;

        public MonsterFlyController(YellowMonster yellowMonster) : base(yellowMonster) 
        {
            _monsterTransform = yellowMonster.MonsterTransform;
            _heightFly = yellowMonster.HeightFly;
            _flyAmplitude = yellowMonster.FlyAmplitude;
        }
        public void Fly()
        {
            _monsterTransform.position = 
                new Vector3(_monsterTransform.position.x, Mathf.PingPong(Time.time * _flyAmplitude, _heightFly), _monsterTransform.position.z);
        }

        public override void Movement()
        {
            base.Movement();
            Fly();
        }
    }
}