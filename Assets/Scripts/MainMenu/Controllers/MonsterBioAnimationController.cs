using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class MonsterBioAnimationController
    {
        private readonly List<StatesList> _states = new List<StatesList>();

        private readonly float _minTimeOfOpenEyes;
        private readonly float _maxTimeOfOpenEyes;
        private readonly float _minTimeOfCloseEyes;
        private readonly float _maxTimeOfCloseEyes;
        private readonly float _minTimeOfChangeState;
        private readonly float _maxTimeOfChangeState;

        private float _closeOpenTimer;
        private float _stateTimer;
        private int _indexOfState;
        private int _indexOfEyes;

        private bool _closeEyes;
        private bool _lastState;
        private bool _randomState;

        public MonstersBioView MonstersBioView { get; }

        public MonsterBioAnimationController(MonstersBioView monstersBio)
        {
            MonstersBioView = monstersBio;
            _states = monstersBio.States;
            _minTimeOfOpenEyes = monstersBio.MinTimeOfOpenEyes;
            _maxTimeOfOpenEyes = monstersBio.MaxTimeOfOpenEyes;
            _minTimeOfCloseEyes = monstersBio.MinTimeOfCloseEyes;
            _maxTimeOfCloseEyes = monstersBio.MaxTimeOfCloseEyes;
            _minTimeOfChangeState = monstersBio.MinTimeOfChangeState;
            _maxTimeOfChangeState = monstersBio.MaxTimeOfChangeState;
            _randomState = monstersBio.RandomState;
            _lastState = monstersBio.LastState;

            Init();
        }

        private void Init()
        {
            _stateTimer = Random.Range(_minTimeOfChangeState, _maxTimeOfChangeState);
            _closeOpenTimer = Random.Range(_minTimeOfOpenEyes, _maxTimeOfOpenEyes);
        }
        public void Execute()
        {
            if (_lastState)
            {
                if (_indexOfState < _states.Count - 1)
                {
                    TimerForChangeState();
                }
            }
            else 
            {
                TimerForChangeState();
            }

            OpenCloseEyesTimer();
        }

        private void OpenCloseEyesTimer()
        {
            _closeOpenTimer -= Time.deltaTime;

            if (_closeOpenTimer <= 0)
            {
                if (_closeEyes)
                {
                    OpenEyes();
                }
                else
                {
                    CloseEyes();
                }
            }
        }
        private void TimerForChangeState()
        {
            _stateTimer -= Time.deltaTime;

            if (_stateTimer <= 0)
            {
                foreach (var item in _states[_indexOfState].Avatars)
                {
                    item.gameObject.SetActive(false);
                }

                if (_randomState)
                {
                    _indexOfState = Random.Range(0, _states.Count);
                }
                else
                {
                    _indexOfState++;

                    if (_indexOfState == _states.Count)
                    {
                        _indexOfState = 0;
                    }
                }

                _indexOfEyes = 0;

                _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(true);

                _stateTimer = Random.Range(_minTimeOfChangeState, _maxTimeOfChangeState);
            }
        }
        private void CloseEyes()
        {
            _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(false);
            _indexOfEyes++;
            if (_indexOfEyes >= _states[_indexOfState].Avatars.Count) 
            {
                _indexOfEyes = _states[_indexOfState].Avatars.Count - 1;
            }
            _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(true);
            _closeEyes = true;
            _closeOpenTimer = Random.Range(_minTimeOfCloseEyes, _maxTimeOfCloseEyes);
        }
        private void OpenEyes()
        {
            _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(false);
            _indexOfEyes--;
            if (_indexOfEyes < 0)
            {
                _indexOfEyes = 0;
            }
            _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(true);
            _closeEyes = false;
            _closeOpenTimer = Random.Range(_minTimeOfOpenEyes, _maxTimeOfOpenEyes);
        }
        public void WakeUp()
        {
            if (_indexOfState == _states.Count - 1)
            {
                foreach (var item in _states[_indexOfState].Avatars)
                {
                    item.gameObject.SetActive(false);
                }
                _indexOfState = 0;
                _indexOfEyes = 0;
                _states[_indexOfState].Avatars[_indexOfEyes].gameObject.SetActive(true);
                _stateTimer = Random.Range(_minTimeOfChangeState, _maxTimeOfChangeState);
            }
        }
    }
}