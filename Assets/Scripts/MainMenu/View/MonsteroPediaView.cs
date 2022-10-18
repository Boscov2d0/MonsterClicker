using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MonsteroPediaView : MonoBehaviour
    {
        [SerializeField] private List<MonstersBioView> _monsters = new List<MonstersBioView>();
        [SerializeField] private List<GameObject> _leftPage = new List<GameObject>();
        [SerializeField] private List<GameObject> _rightPage = new List<GameObject>();

        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonPrev;
        [SerializeField] private Button _buttonExit;

        public List<MonstersBioView> Monsters { get => _monsters; set => _monsters = value; }
        public List<GameObject> LeftPage { get => _leftPage; set => _leftPage = value; }
        public List<GameObject> RightPage { get => _rightPage; set => _rightPage = value; }
        public Button ButtonNext { get => _buttonNext; set => _buttonNext = value; }
        public Button ButtonPrev { get => _buttonPrev; set => _buttonPrev = value; }
        public Button ButtonExit { get => _buttonExit; set => _buttonExit = value; }

        public bool IsActive { get; set; }
    }
}