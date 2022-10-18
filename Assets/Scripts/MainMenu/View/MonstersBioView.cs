using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    [Serializable]
    public class StatesList
    {
        public List<Image> Avatars;
    }
    
    public class MonstersBioView : MonoBehaviour
    {
        [SerializeField] private GameObject _leftPage;
        [SerializeField] private GameObject _rightPage;
        [SerializeField] private List<StatesList> _state;
        [SerializeField] private float _minTimeOfOpenEyes;
        [SerializeField] private float _maxTimeOfOpenEyes;
        [SerializeField] private float _minTimeOfCloseEyes;
        [SerializeField] private float _maxTimeOfCloseEyes;
        [SerializeField] private float _minTimeOfChangeState;
        [SerializeField] private float _maxTimeOfChangeState;
        [SerializeField] private bool _randomState;
        [SerializeField] private bool _lastState;

        public GameObject LeftPage { get => _leftPage; set => _leftPage = value; }
        public GameObject RightPage { get => _rightPage; set => _rightPage = value; }
        public List<StatesList> States { get => _state; set => _state = value; }
        public float MinTimeOfOpenEyes { get => _minTimeOfOpenEyes; set => _minTimeOfOpenEyes = value; }
        public float MaxTimeOfOpenEyes { get => _maxTimeOfOpenEyes; set => _maxTimeOfOpenEyes = value; }
        public float MinTimeOfCloseEyes { get => _minTimeOfCloseEyes; set => _minTimeOfCloseEyes = value; }
        public float MaxTimeOfCloseEyes { get => _maxTimeOfCloseEyes; set => _maxTimeOfCloseEyes = value; }
        public float MinTimeOfChangeState { get => _minTimeOfChangeState; set => _minTimeOfChangeState = value; }
        public float MaxTimeOfChangeState { get => _maxTimeOfChangeState; set => _maxTimeOfChangeState = value; }
        public bool RandomState { get => _randomState; set => _randomState = value; }
        public bool LastState { get => _lastState; set => _lastState = value; }
        public bool IsActive { get; set; }
    }
}