using System;
using UnityEngine;

namespace MonstersGame
{
    public class BoosterController : IBooster, IDisposable
    {
        private readonly BoosterColorController _colorController;

        private readonly BoosterView _booster;
        private readonly Material _boostMaterial;

        private readonly float _timeOfBoostWork;
        private readonly float _timeOfBoostReload;
        private readonly float _timerOfReload;
        
        private float _timerOfWork;

        private bool _boostWasActivate;

        public bool CanActivateBoost;

        public BoosterController(BoosterView booster) 
        {
            _booster = booster;
            _boostMaterial = booster.Material;
            _timeOfBoostWork = booster.TimeOfBoostWork;
            _timeOfBoostReload = booster.TimeOfBoostReload;

            _booster.OnTap += ActivateBooster;

            _timerOfReload = _timeOfBoostReload;

            _colorController = new BoosterColorController(_timerOfReload, _timeOfBoostReload, _boostMaterial);
        }
        public virtual void ActivateBooster()
        {
            if (CanActivateBoost)
            {
                _boostWasActivate = true;
                CanActivateBoost = false;
            }
        }
        public virtual void DeactivateBooster()
        {
            _boostWasActivate = false;
        }
        public void TimeOfBoostWork()
        {
            _timerOfWork += Time.deltaTime;

            if (_timerOfWork >= _timeOfBoostWork)
            {
                _timerOfWork = 0;
                DeactivateBooster();
            }
        }
        public void Execute()
        {
            if (_boostWasActivate)
            {
                _colorController.ChangeMaterial();
                TimeOfBoostWork();
            }

            if (!CanActivateBoost)
            {
                CanActivateBoost = _colorController.ReloadBoost();
            }
        }
        public void Dispose()
        {
            _booster.OnTap -= ActivateBooster;
        }
    }
}