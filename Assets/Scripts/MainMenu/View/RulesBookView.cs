using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class RulesBookView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _pages;
        [SerializeField] private List<GameObject> _leftPage;
        [SerializeField] private List<GameObject> _rightPage;

        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonPrev;
        [SerializeField] private Button _buttonExit;

        public List<GameObject> Pages { get => _pages; set => _pages = value; }
        public List<GameObject> LeftPage { get => _leftPage; set => _leftPage = value; }
        public List<GameObject> RightPage { get => _rightPage; set => _rightPage = value; }
        public Button ButtonNext { get => _buttonNext; set => _buttonNext = value; }
        public Button ButtonPrev { get => _buttonPrev; set => _buttonPrev = value; }
        public Button ButtonExit { get => _buttonExit; set => _buttonExit = value; }

        public bool IsActive { get; set; }
    }
}