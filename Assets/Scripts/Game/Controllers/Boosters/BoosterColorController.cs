using UnityEngine;

namespace MonstersGame
{
    public class BoosterColorController
    {
        private readonly Material _boostMaterial;
        private readonly float _timeOfBoostReload;

        private float _timerOfReload;

        public BoosterColorController(float timerOfReload, float timeOfBoostReload, Material boostMaterial)
        {
            _boostMaterial = boostMaterial;
            _timerOfReload = timerOfReload;
            _timeOfBoostReload = timeOfBoostReload;
        }
        public bool ReloadBoost()
        {
            _timerOfReload -= Time.deltaTime;

            if (_timerOfReload >= 0)
            {
                _boostMaterial.color = Color.Lerp(Color.white, Color.red, _timerOfReload / _timeOfBoostReload);
                return false;
            }
            else
            {
                _boostMaterial.SetColor("_Color", Color.white);
                _timerOfReload = _timeOfBoostReload;
                return true;
            }
        }
        public void ChangeMaterial()
        {
            _boostMaterial.SetColor("_Color", Color.red);
        }
    }
}