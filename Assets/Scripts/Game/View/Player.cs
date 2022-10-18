using System;
using UnityEngine;

namespace MonstersGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _forceOfDamage;

        private Ray _ray;
        private RaycastHit _hit;

        public int ForceOfDamage { get => _forceOfDamage; set => _forceOfDamage = value; }
        public Ray Ray { get => _ray; set => _ray = value; }
        public RaycastHit Hit { get => _hit; set => _hit = value; }
        public Camera Camera { get; set; }
        public Action Initialize;
    }
}