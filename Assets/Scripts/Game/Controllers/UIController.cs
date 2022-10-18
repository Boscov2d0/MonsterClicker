using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MonstersGame
{
    public class UIController : IDisposable
    {
        private readonly GameObject _gameOverPanel;
        private readonly Button _restartButton;
        private readonly Button _mainMenuButton;
        private readonly Button _mainMenuButtonInGGPanel;
        private readonly Text _score;
        private readonly Text _level;

        public UIController(UIView uIView)
        {
            _gameOverPanel = uIView.GameOverPanel;

            _restartButton = uIView.RestartButton;
            _restartButton.onClick.AddListener(ButtonRestart);

            _mainMenuButton = uIView.MeinMenuButton;
            _mainMenuButton.onClick.AddListener(ButtonMainMenu);

            _mainMenuButtonInGGPanel = uIView.MainMenuButtonInGGPanel;
            _mainMenuButtonInGGPanel.onClick.AddListener(ButtonMainMenu);

            _level = uIView.Level;
            _score = uIView.Score;
        }
        public void ShowLevel(string str)
        {
            _level.text = str;
        }
        public void ShowScore(string str)
        {
            _score.text = str;
        }
        public void ShowGameOver()
        {
            _gameOverPanel.SetActive(true);
        }
        public void Dispose()
        {
            _restartButton.onClick.RemoveAllListeners();
            _mainMenuButton.onClick.RemoveAllListeners();
            _mainMenuButtonInGGPanel.onClick.RemoveAllListeners();
        }
        private void ButtonRestart()
        {
            SceneManager.LoadScene(1);
        }
        private void ButtonMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}