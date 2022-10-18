using UnityEngine;
using UnityEngine.UI;

namespace MonstersGame
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _mainMenuButtonInGGPanel;
        [SerializeField] private Text _score;
        [SerializeField] private Text _level;
        
        public GameObject GameOverPanel { get => _gameOverPanel; set => _gameOverPanel = value; }
        public Button RestartButton { get => _restartButton; set => _restartButton = value; }
        public Button MeinMenuButton { get => _mainMenuButton; set => _mainMenuButton = value; }
        public Button MainMenuButtonInGGPanel { get => _mainMenuButtonInGGPanel; set => _mainMenuButtonInGGPanel = value; }
        public Text Score { get => _score; set => _score = value; }
        public Text Level { get => _level; set => _level = value; }
    }
}