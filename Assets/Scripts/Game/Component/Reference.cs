using UnityEngine;

namespace MonstersGame
{
    public class Reference
    {
        private Player _player;
        private UIView _gameCanvas;
        private MonstersPoolView _monstersPool;
        private Camera _camera;

        public T GetComponent<T>(string path)
        {
            GameObject _directionalLightPrefab = Resources.Load<GameObject>(path);
            GameObject directionalLight = Object.Instantiate(_directionalLightPrefab);
            return directionalLight.GetComponent<T>();
        }
        public void CreateObject(string path)
        {
            GameObject _directionalLightPrefab = Resources.Load<GameObject>(path);
            Object.Instantiate(_directionalLightPrefab);
        }
        public Player Player
        {
            get
            {
                Player _playerPrefab = Resources.Load<Player>("Game/Player");
                _player = Object.Instantiate(_playerPrefab);
                return _player;
            }
        }
        public UIView GameCanvas
        {
            get
            {
                UIView _canvasPrefab = Resources.Load<UIView>("UI/Game/Canvas");
                _gameCanvas = Object.Instantiate(_canvasPrefab);
                return _gameCanvas;
            }
        }
        public MonstersPoolView MonstersPool
        {
            get
            {
                MonstersPoolView _monstersPoolPrefab = Resources.Load<MonstersPoolView>("Game/MonstersPool");
                _monstersPool = Object.Instantiate(_monstersPoolPrefab);
                return _monstersPool;
            }
        }
        public Camera Camera
        {
            get
            {
                Camera _cameraPrefab = Resources.Load<Camera>("Game/Camera");
                _camera = Object.Instantiate(_cameraPrefab);
                return _camera;
            }
        }
    }
}