using UnityEngine;

namespace MonstersGame
{
    //Нужно ли использовать паттерн Facade
    public class Main : MonoBehaviour
    {
        private readonly Reference _reference = new Reference();

        private Camera _camera;
        private UIView _uI;
        private Player _player;
        private MonstersPoolView _monstersPool;

        private GameController _gameController;
        private PlayerController _playerController;
        private UIController _uIController;
        private MonstersPoolController _monstersPoolController;
        private IncreaseLevelController _increaseLevelController;

        //Boosters
        private BoosterPenView _boosterPen;
        private BoosterPencilView _boosterPencil;
        private BoosterEraserView _boosterEraser;

        private PenBoosterController _penController;
        private PencilBoosterController _pencilController;
        private EraserBoosterController _eraserController;

        private void Awake()
        {
            _reference.CreateObject("Game/DirectionalLight");
            _reference.CreateObject("Game/GameTable");
            _reference.CreateObject("Game/GameArea");

            _camera = _reference.Camera;
            _player = _reference.Player;
            _player.Camera = _camera;
            _uI = _reference.GameCanvas;
            _monstersPool = _reference.MonstersPool;

            //Controllers
            _playerController = new PlayerController(_player);
            _monstersPoolController = new MonstersPoolController(_monstersPool);
            _increaseLevelController = new IncreaseLevelController(_monstersPoolController);
            _uIController = new UIController(_uI);
            _gameController = new GameController(_monstersPoolController.MonstersList, _uIController, _increaseLevelController);

            //Boosters
            _boosterPen = _reference.GetComponent<BoosterPenView>("Game/Pen");
            _boosterPencil = _reference.GetComponent<BoosterPencilView>("Game/Pencil");
            _boosterEraser = _reference.GetComponent<BoosterEraserView>("Game/Eraser");

            _penController = new PenBoosterController(_boosterPen, _player);
            _pencilController = new PencilBoosterController(_boosterPencil, _monstersPoolController);
            _eraserController = new EraserBoosterController(_boosterEraser, _monstersPoolController.MonstersList);
        }
        private void Update()
        {
            if (_gameController.GameOn)
            {
                _playerController.Execute();
            }
        }
        private void FixedUpdate()
        {
            if (_gameController.GameOn)
            {
                _monstersPoolController.Execute();

                //Boosters
                _penController.Execute();
                _pencilController.Execute();
                _eraserController.Execute();
            }
        }
    }
}