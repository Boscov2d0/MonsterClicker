using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace MainMenu {
    public class MainMenuControler : IDisposable
    {
        private GameObject _loadPanel;
        private Button _startGameButton;
        private Button _rulesButton;
        private Button _monstroPediaButton;
        private Button _exitGameButton;

        private RulesBookController _rulesBook;
        private MonstroPediaController _monstroPedia;

        public GameObject LoadPanel { get => _loadPanel; }
        public MainMenuControler(MainMenuView mainMenu, RulesBookController rulesBook, MonstroPediaController monstroPedia) 
        {
            _loadPanel = mainMenu.LoadPanel;

            _startGameButton = mainMenu.StartGameButton;
            _rulesButton = mainMenu.RulesButton;
            _monstroPediaButton = mainMenu.MonstroPediaButton;
            _exitGameButton = mainMenu.ExitGameButton;

            _startGameButton.onClick.AddListener(StartGame);
            _rulesButton.onClick.AddListener(Rules);
            _monstroPediaButton.onClick.AddListener(OpenMonstroPedia);
            _exitGameButton.onClick.AddListener(ExitGame);

            _monstroPedia = monstroPedia;
            _rulesBook = rulesBook;

            _loadPanel.SetActive(false);
            _rulesBook.RulesBookView.gameObject.SetActive(false);
            _monstroPedia.MonsteroPediaView.gameObject.SetActive(false);
        }

        private void StartGame() 
        {
            SceneManager.LoadScene(1);
        }
        private void OpenMonstroPedia()
        {
            _monstroPedia.MonsteroPediaView.gameObject.SetActive(true);
            _monstroPedia.MonsteroPediaView.IsActive = true;
            _monstroPedia.FirstOpen();
        }
        private void Rules()
        {
            _rulesBook.RulesBookView.gameObject.SetActive(true);
            _rulesBook.RulesBookView.IsActive = true;
            _rulesBook.FirstOpen();
        }
        private void ExitGame()
        {
            Application.Quit();
        }

        public void Dispose()
        {
            _startGameButton.onClick.RemoveListener(StartGame);
            _rulesButton.onClick.RemoveListener(Rules);
            _monstroPediaButton.onClick.RemoveListener(OpenMonstroPedia);
            _exitGameButton.onClick.RemoveListener(ExitGame);
        }
    }
}