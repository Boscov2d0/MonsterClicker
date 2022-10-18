using System;
using UnityEngine;

namespace MonstersGame
{
    public class PlayerController : IDisposable
    {
        private readonly Player _player;
        private readonly Camera _camera;
        private Ray _ray;
        private RaycastHit _hit;
        private int _forceOfDamage;

        public PlayerController(Player player) 
        {
            _player = player;
            _camera = player.Camera;
            _ray = player.Ray;
            _hit = player.Hit;

            _player.Initialize += Init;

            Init();
        }
        public void Init() 
        {
            _forceOfDamage = _player.ForceOfDamage;
        }
        public void Execute()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.TryGetComponent(out Monster monster))
                    {
                        TapOnMonster(monster);
                    }
                    if (_hit.collider.TryGetComponent(out BoosterView booster))
                    {
                        TapOnBooster(booster);
                    }
                }
            }
        }
        private void TapOnMonster(Monster monster)
        {
            monster.OnTap(_forceOfDamage);
        }

        private void TapOnBooster(BoosterView booster)
        {
            booster.OnTap?.Invoke();
        }
        public void Dispose()
        {
            _player.Initialize -= Init;
        }
    }
}