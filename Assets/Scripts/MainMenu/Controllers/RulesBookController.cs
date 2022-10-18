using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class RulesBookController : IDisposable
    {
        private readonly List<GameObject> _pages = new List<GameObject>();
        private readonly List<GameObject> _leftPage = new List<GameObject>();
        private readonly List<GameObject> _rightPage = new List<GameObject>();

        private readonly Button _buttonNext;
        private readonly Button _buttonPrev;
        private readonly Button _buttonExit;

        private int _indexLeftPage;
        private int _indexRightPage;
        private int _indexPages;

        private bool _turnNextPage;
        private bool _turnPrevPage;

        public RulesBookView RulesBookView { get; }

        public RulesBookController(RulesBookView rulesBook)
        {
            RulesBookView = rulesBook;

            _pages = rulesBook.Pages;
            _leftPage = rulesBook.LeftPage;
            _rightPage = rulesBook.RightPage;

            _buttonNext = rulesBook.ButtonNext;
            _buttonPrev = rulesBook.ButtonPrev;
            _buttonExit = rulesBook.ButtonExit;

            _buttonNext.onClick.AddListener(NextPage);
            _buttonPrev.onClick.AddListener(PrevPage);
            _buttonExit.onClick.AddListener(Exit);

            Initialized();
        }

        public void FixedExecute()
        {
            if (RulesBookView.IsActive)
            {
                if (_turnNextPage)
                {
                    TurnNextPage();
                }
                if (_turnPrevPage)
                {
                    TurnPrevPage();
                }
            }
        }

        public void Initialized()
        {
            _indexLeftPage = 1;  //¬ыбираем данную левую страницу дневника
            _indexRightPage = 1; //¬ыбираем данную правую страницу дневника
            SetActiveButtons();
        }

        public void FirstOpen()
        {
            //јктивируем левую и правую страницы дневника
            _leftPage[_indexLeftPage].SetActive(true);
            _rightPage[_indexRightPage].SetActive(true);

            _pages[_indexPages].SetActive(true);
            _pages[_indexPages].transform.SetParent(_leftPage[_indexLeftPage].transform);

            _indexPages++;

            _pages[_indexPages].SetActive(true);
            _pages[_indexPages].transform.SetParent(_rightPage[_indexRightPage].transform);
        }

        public void NextPage()
        {
            if (_indexPages < _pages.Count - 1 && !_turnNextPage && !_turnPrevPage)
            {
                OpenNextPageFirstStep();

                _turnNextPage = true;
            }
        }
        public void PrevPage()
        {
            if (_indexPages > 0 && !_turnNextPage && !_turnPrevPage)
            {
                OpenPrevPageFirstStep();

                _turnPrevPage = true;
            }
        }
        public void Exit()
        {
            RulesBookView.IsActive = false;
            RulesBookView.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _buttonNext.onClick.RemoveListener(NextPage);
            _buttonPrev.onClick.RemoveListener(PrevPage);
            _buttonExit.onClick.RemoveListener(Exit);
        }

        private void TurnNextPage()
        {
            _rightPage[_indexRightPage].transform.eulerAngles += new Vector3(0, 3f, 0);

            if (_rightPage[_indexRightPage].transform.eulerAngles.y >= 269 && _rightPage[_indexRightPage].transform.eulerAngles.y <= 271)
            {
                OpenNextPageSecondStep();
            }
            if (_rightPage[_indexRightPage].transform.eulerAngles.y >= 355)
            {
                OpenNextPageThirdStep();

                Initialized();

                _turnNextPage = false;
            }
        }
        private void TurnPrevPage()
        {
            _leftPage[_indexLeftPage].transform.eulerAngles -= new Vector3(0, 3f, 0);

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y >= 269 && _leftPage[_indexLeftPage].transform.eulerAngles.y <= 271)
            {
                OpenPrevPageSecondStep();
            }

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y <= 181)
            {
                OpenPrevPageThirdStep();

                Initialized();

                _turnPrevPage = false;
            }
        }

        #region OpenNextPageStepsVoids
        /// <summary>
        /// ѕодготавливаем следующие сраницы дл€ отображени€ и страницу дл€ переворачивани€
        /// </summary>
        private void OpenNextPageFirstStep() 
        {
            _indexPages += 2;
            _pages[_indexPages].transform.SetParent(_rightPage[++_indexRightPage].transform);
            _rightPage[_indexRightPage].SetActive(true);
            _pages[_indexPages].SetActive(true);

            _indexRightPage--;
            _indexPages--;
            _pages[_indexPages].transform.SetParent(_rightPage[_indexRightPage].transform);
            _pages[_indexPages].transform.eulerAngles = new Vector3(0, 180, 0);
            _pages[_indexPages].transform.position = _pages[--_indexPages].transform.position;
        }
        /// <summary>
        /// ѕереворачиваем страницу до середины и мен€ем на ней изображение
        /// </summary>
        private void OpenNextPageSecondStep() 
        {
            _pages[_indexPages].SetActive(false);
            _indexPages++;
            _pages[_indexPages].SetActive(true);
        }
        private void OpenNextPageThirdStep()
        {
            _indexPages--;
            _indexPages--;
            _pages[_indexPages].SetActive(false);

            _pages[_indexPages].transform.SetParent(_leftPage[--_indexLeftPage].transform);
            _indexPages++;
            _pages[_indexPages].transform.SetParent(_rightPage[--_indexRightPage].transform);

            _indexPages++;
            _indexLeftPage++;
            _indexRightPage++;

            _pages[_indexPages].transform.SetParent(_leftPage[_indexLeftPage].transform);
            _rightPage[_indexRightPage].transform.eulerAngles = new Vector3(0, 180, 0);

            _indexPages++;
            _pages[_indexPages].transform.SetParent(_rightPage[_indexRightPage].transform);

            _indexRightPage++;
            _rightPage[_indexRightPage].SetActive(false);
        }
        #endregion

        #region OpenPrevPageStepsVoids
        private void OpenPrevPageFirstStep() 
        {
            _rightPage[_indexRightPage].SetActive(false);
            _rightPage[++_indexRightPage].SetActive(true);
            _pages[_indexPages].transform.SetParent(_rightPage[_indexRightPage].transform);
            _indexPages -= 3;
            _leftPage[--_indexLeftPage].SetActive(true);
            _pages[_indexPages].SetActive(true);
            _indexPages++;
            _indexLeftPage++;

            _pages[_indexPages].transform.SetParent(_leftPage[_indexLeftPage].transform);
            _pages[_indexPages].transform.eulerAngles = new Vector3(0, 180, 0);
            _indexPages++;
        }
        private void OpenPrevPageSecondStep() 
        {
            _pages[_indexPages].SetActive(false);
            _pages[_indexPages].transform.SetParent(_leftPage[++_indexLeftPage].transform);
            _indexLeftPage--;
            _indexPages--;
            _pages[_indexPages].SetActive(true);
        }
        private void OpenPrevPageThirdStep() 
        {
            _indexPages++;
            _indexPages++;
            _pages[_indexPages].SetActive(false);
            _indexPages--;
            _indexPages--;
            _leftPage[--_indexLeftPage].SetActive(false);
            _rightPage[_indexRightPage].SetActive(false);
            _indexLeftPage++;
            _pages[_indexPages].transform.SetParent(_rightPage[--_indexRightPage].transform);
            _rightPage[_indexRightPage].SetActive(true);
            _leftPage[_indexLeftPage].transform.eulerAngles = new Vector3(0, 0, 0);
            _pages[--_indexPages].transform.SetParent(_leftPage[_indexLeftPage].transform);

            _indexPages++;
        }
        #endregion
        private void SetActiveButtons()
        {
            bool isActiveButton;
            isActiveButton = _indexPages > 1 ? true : false;
            _buttonPrev.gameObject.SetActive(isActiveButton);
            isActiveButton = _indexPages == _pages.Count - 1 ? false : true;
            _buttonNext.gameObject.SetActive(isActiveButton);
        }
    }
}