using UnityEngine;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        private Reference _reference = new Reference();

        private MainMenuView _mainCanvas;
        private RulesBookView _rulesBook;
        private MonsteroPediaView _monsteroPedia;

        private MainMenuControler _mainMenuControler;
        private RulesBookController _rulesBookController;
        private MonstroPediaController _monstroPediaController;

        private void Awake()
        {
            _reference.CreateObject("MainMenu/DirectionalLight");
            _reference.CreateObject("MainMenu/MainCamera");
            _reference.CreateObject("MainMenu/MyTable");
            _reference.CreateObject("MainMenu/GameObject");

            _rulesBook = _reference.CanvasRules;
            _monsteroPedia = _reference.CanvasMonstroPedia;
            _mainCanvas = _reference.MainCanvas;

            _rulesBookController = new RulesBookController(_rulesBook);
            _monstroPediaController = new MonstroPediaController(_monsteroPedia);
            _mainMenuControler = new MainMenuControler(_mainCanvas, _rulesBookController, _monstroPediaController);
        }

        private void FixedUpdate()
        {
            _rulesBookController.FixedExecute();
            _monstroPediaController.FixedExecute();
        }
    }
}