using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadPanel;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _rulesButton;
        [SerializeField] private Button _monstroPediaButton;
        [SerializeField] private Button _exitGameButton;

        public GameObject LoadPanel { get => _loadPanel; set => _loadPanel = value; }
        public Button StartGameButton { get => _startGameButton; set => _startGameButton = value; }
        public Button RulesButton { get => _rulesButton; set => _rulesButton = value; }
        public Button MonstroPediaButton { get => _monstroPediaButton; set => _monstroPediaButton = value; }
        public Button ExitGameButton { get => _exitGameButton; set => _exitGameButton = value; }
    }
}