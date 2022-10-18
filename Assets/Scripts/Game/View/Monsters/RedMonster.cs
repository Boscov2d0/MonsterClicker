using UnityEngine;

namespace MonstersGame
{
    public class RedMonster : Monster
    {
        [SerializeField] private float _jumpForse;

        public float JumpForse { get => _jumpForse; set => _jumpForse = value; }
        public bool CanJump { get; set; }

        public override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);

            if (collision.transform.tag == "Floor")
            {
                CanJump = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.transform.tag == "Floor")
            {
                CanJump = false;
            }
        }
    }
}