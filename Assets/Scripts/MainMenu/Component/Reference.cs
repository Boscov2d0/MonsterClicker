using UnityEngine;

namespace MainMenu
{
    public class Reference
    {
        private MainMenuView _mainCanvas;
        private MonsteroPediaView _canvasMonstroPedia;
        private RulesBookView _canvasRules;

        public void CreateObject(string path)
        {
            GameObject _directionalLightPrefab = Resources.Load<GameObject>(path);
            Object.Instantiate(_directionalLightPrefab);
        }

        public MainMenuView MainCanvas 
        {
            get
            {
                GameObject _canvasPrefab = Resources.Load<GameObject>("UI/MainMenu/MainCanvas");
                _mainCanvas = Object.Instantiate(_canvasPrefab).GetComponent<MainMenuView>();
                return _mainCanvas;
            }
        }
        public MonsteroPediaView CanvasMonstroPedia
        {
            get
            {
                GameObject _canvasMonstroPediaPrefab = Resources.Load<GameObject>("UI/MainMenu/CanvasMonstroPedia");
                _canvasMonstroPedia = Object.Instantiate(_canvasMonstroPediaPrefab).GetComponent<MonsteroPediaView>();
                return _canvasMonstroPedia;
            }
        }
        public RulesBookView CanvasRules
        {
            get
            {
                GameObject _canvasRulesPrefab = Resources.Load<GameObject>("UI/MainMenu/CanvasRules");
                _canvasRules = Object.Instantiate(_canvasRulesPrefab).GetComponent<RulesBookView>();
                return _canvasRules;
            }
        }
    }
}