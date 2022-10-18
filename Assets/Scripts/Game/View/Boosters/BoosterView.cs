using System;
using UnityEngine;

namespace MonstersGame
{
    public class BoosterView : MonoBehaviour
    {
        [SerializeField] private Material _material;
        [SerializeField] private float _timeOfBoostWork;
        [SerializeField] private float _timeOfBoostReload;

        public Material Material { get => _material; set => _material = value; }
        public float TimeOfBoostWork { get => _timeOfBoostWork; set => _timeOfBoostWork = value; }
        public float TimeOfBoostReload { get => _timeOfBoostReload; set => _timeOfBoostReload = value; }

        public Action OnTap;
    }
}