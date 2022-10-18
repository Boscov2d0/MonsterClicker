using UnityEngine;

namespace MonstersGame 
{
    public class MonsterJumpController : MonsterMoveController, IMonsterMovement
    {
        private readonly RedMonster _redMonster;
        private readonly Transform _monsterTransform;
        private readonly Rigidbody _rigidbody;
        private readonly float _jumpForse;

        public MonsterJumpController(RedMonster redMonster) : base(redMonster)
        {
            _redMonster = redMonster;
            _monsterTransform = redMonster.MonsterTransform;
            _rigidbody = redMonster.RigidBody;
            _jumpForse = redMonster.JumpForse;
        }
        public void Jump()
        {
            _rigidbody.AddForce(_monsterTransform.up * _jumpForse, ForceMode.Impulse);
        }

        public override void Movement()
        {
            base.Movement();

            if (_redMonster.CanJump)
            {
                Jump();
            }
        }
    } 
}