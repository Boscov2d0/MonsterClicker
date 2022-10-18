using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MonstroPediaController : IDisposable
    {
        private readonly List<MonstersBioView> _monsters = new List<MonstersBioView>();
        private readonly List<MonsterBioAnimationController> _monstersBiosAnimationControllers = new List<MonsterBioAnimationController>();
        private readonly List<GameObject> _leftPage = new List<GameObject>();
        private readonly List<GameObject> _rightPage = new List<GameObject>();

        private readonly Button _buttonNext;
        private readonly Button _buttonPrev;
        private readonly Button _buttonExit;

        private int _indexLeftPage;
        private int _indexRightPage;
        private int _indexMonsters;

        private bool _turnNextPage;
        private bool _turnPrevPage;

        public MonsteroPediaView MonsteroPediaView { get; }

        public MonstroPediaController(MonsteroPediaView monsteroPedia)
        {
            MonsteroPediaView = monsteroPedia;
            _monsters = monsteroPedia.Monsters;
            _leftPage = monsteroPedia.LeftPage;
            _rightPage = monsteroPedia.RightPage;

            _buttonNext = monsteroPedia.ButtonNext;
            _buttonPrev = monsteroPedia.ButtonPrev;
            _buttonExit = monsteroPedia.ButtonExit;

            _buttonNext.onClick.AddListener(NextPage);
            _buttonPrev.onClick.AddListener(PrevPage);
            _buttonExit.onClick.AddListener(Exit);
            _buttonPrev.gameObject.SetActive(false);

            foreach (MonstersBioView monstersBioView in _monsters)
            {
                MonsterBioAnimationController monsterBioAnimationController = new MonsterBioAnimationController(monstersBioView);
                _monstersBiosAnimationControllers.Add(monsterBioAnimationController);
            }

            Initialized();
        }

        public void FixedExecute()
        {
            if (MonsteroPediaView.IsActive)
            {
                foreach (MonsterBioAnimationController monsterBioAnimationController in _monstersBiosAnimationControllers)
                {
                    if (monsterBioAnimationController.MonstersBioView.IsActive)
                    {
                        monsterBioAnimationController.Execute();
                    }
                }
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
            _indexLeftPage = 1;  //Выбираем данную левую страницу дневника
            _indexRightPage = 1; //Выбираем данную правую страницу дневника
        }

        public void FirstOpen()
        {
            _monsters[_indexMonsters].IsActive = true;

            //Активируем левую и правую страницы дневника
            _leftPage[_indexLeftPage].gameObject.SetActive(true);
            _rightPage[_indexRightPage].gameObject.SetActive(true);

            //Активируем левую и правую страницы первого монстра
            _monsters[_indexMonsters].LeftPage.SetActive(true);
            _monsters[_indexMonsters].RightPage.SetActive(true);

            //Левую и правую страницы первого монстра помещаем в данную левую и правую страницы дневника
            _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
            _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
        }

        public void NextPage()
        {
            if (_indexMonsters < _monsters.Count - 1 && !_turnNextPage && !_turnPrevPage)
            {
                _monsters[_indexMonsters].IsActive = false;
                //Подготавливаем следующую правую страницу дневника
                //Активируем следующую правую страницу дневника
                _rightPage[++_indexRightPage].gameObject.SetActive(true);
                _indexMonsters++; //Берем следующего монстра
                                  //Активируем правую страницу следующего монстра, и помещаем ее в следующую правую страницу дневника
                _monsters[_indexMonsters].RightPage.SetActive(true);
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);

                _indexRightPage--; //Берем данную правую страницу

                //Подготавливаем левую страницу следующего монстра к анимации переворота
                //Левую страницу следующего монстра помещаем в данную правую страницу дневника
                //Задаем позиции левой страницы следующего монстра позицию правой страницы следующего монстра
                //Левую страницу следующего монстра переворачиваем для отображения на анимации открытия листа
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                _monsters[_indexMonsters].LeftPage.transform.position = _monsters[_indexMonsters].RightPage.transform.position;
                _monsters[_indexMonsters].LeftPage.transform.eulerAngles = new Vector3(0, 180, 0);

                //Активируем открытие страницы
                _turnNextPage = true;
            }
        }
        public void PrevPage()
        {
            if (_indexMonsters > 0 && !_turnNextPage && !_turnPrevPage)
            {
                _monsters[_indexMonsters].IsActive = false;
                _indexRightPage++;
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                _rightPage[_indexRightPage].gameObject.SetActive(true);
                _indexRightPage--;
                _rightPage[_indexRightPage].gameObject.SetActive(false);

                //Подготавливаем предыдущую левую страницу дневника
                //Активируем предыдущую левую страницу дневника
                _leftPage[--_indexLeftPage].gameObject.SetActive(true);
                _indexMonsters--; //Берем предыдущего монстра
                                  //Активируем левую страницу предыдущего монстра, и помещаем ее в предыдущего левую страницу дневника
                _monsters[_indexMonsters].LeftPage.SetActive(true);
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);

                _indexLeftPage++; //Берем данную левую страницу

                //Подготавливаем правую страницу предыдущего монстра к анимации переворота
                //Правую страницу предыдущего монстра помещаем в данную левую страницу дневника
                //Задаем позиции правой страницы предыдущего монстра позицию левой страницы предыдущего монстра
                //Правую страницу предыдущего монстра переворачиваем для отображения на анимации открытия листа
                _monsters[_indexMonsters].RightPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
                _monsters[_indexMonsters].RightPage.transform.position = _monsters[_indexMonsters].LeftPage.transform.position;
                _monsters[_indexMonsters].RightPage.transform.eulerAngles = new Vector3(0, 180, 0);

                //Активируем открытие страницы
                _turnPrevPage = true;
            }
        }
        public void Exit() 
        {
            MonsteroPediaView.IsActive = false;
            MonsteroPediaView.gameObject.SetActive(false);
        }

        private void TurnNextPage()
        {
            _rightPage[_indexRightPage].transform.eulerAngles += new Vector3(0, 3f, 0);

            if (_rightPage[_indexRightPage].transform.eulerAngles.y >= 269 && _rightPage[_indexRightPage].transform.eulerAngles.y <= 271)
            {
                _monsters[_indexMonsters].LeftPage.SetActive(true); //Активируем левую страницу следующего монстра

                _indexMonsters--; //Переключаемся на данного монстра

                _monsters[_indexMonsters].RightPage.SetActive(false); //Деактивируем правую страницу данного монстра
            }
            if (_rightPage[_indexRightPage].transform.eulerAngles.y >= 355)
            {
                //Деактивируем левую страницу данного монстра
                _monsters[_indexMonsters].LeftPage.SetActive(false);
                //Левую и правую страницы данного монстра помещаем в предыдущую левую и правую страницы дневника
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[--_indexLeftPage].transform);
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[--_indexRightPage].transform);

                //Данный монстр становится предыдущим, а следующий - данным!!!

                _indexMonsters++;  //Переключаемся на данного монстра
                _indexLeftPage++;  //Переключаемся на данную левую страницу дневника
                _indexRightPage++; //Переключаемся на данную правую страницу дневника

                //Левую страницу данного монстра помещаем в данную левую страницу дневника
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
                //Возвращаем данную правую страницу после открытия на свое место
                _rightPage[_indexRightPage].transform.eulerAngles = new Vector3(0, 180, 0);
                //Правую страницу данного монстра помещаем в данную правую страницу дневника
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);


                _monsters[_indexMonsters].IsActive = true;

                //Берем следующую правую страницу дневника и деактивируем
                _indexRightPage++;
                _rightPage[_indexRightPage].gameObject.SetActive(false);

                if (_indexMonsters < _monsters.Count - 1)
                {
                    _indexMonsters++;
                    _indexLeftPage++;

                    _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
                    _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);

                    _indexMonsters--;
                }
                else
                {
                    _buttonNext.gameObject.SetActive(false);
                }
                Initialized();

                _buttonPrev.gameObject.SetActive(true); //Переместить

                _turnNextPage = false;
            }
        }
        private void TurnPrevPage()
        {
            _leftPage[_indexLeftPage].transform.eulerAngles -= new Vector3(0, 3f, 0);

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y >= 269 && _leftPage[_indexLeftPage].transform.eulerAngles.y <= 271)
            {
                _monsters[_indexMonsters].RightPage.SetActive(true); //Активируем правую страницу предыдущего монстра

                _indexMonsters++; //Переключаемся на данного монстра

                _monsters[_indexMonsters].LeftPage.SetActive(false); //Деактивируем левую страницу данного монстра
            }

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y <= 181)
            {
                //Деактивируем правую страницу данного монстра
                _monsters[_indexMonsters].RightPage.SetActive(false);
                //Левую страницу данного монстра помещаем в левую и правую следующие страницы дневника
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[++_indexLeftPage].transform);

                //Данный монстр становится следующим, а предыдущий - данным!!!
                _indexMonsters--;
                _indexLeftPage--;  //Переключаемся на данную левую страницу дневника
                _indexRightPage++; //Переключаемся на  правую страницу дневника
                _rightPage[_indexRightPage].gameObject.SetActive(false);
                _indexRightPage--;
                //Левую страницу данного монстра помещаем в данную левую страницу дневника
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                //Возвращаем данную правую страницу после открытия на свое место
                _leftPage[_indexLeftPage].transform.eulerAngles = new Vector3(0, 0, 0);
                //Правую страницу данного монстра помещаем в данную правую страницу дневника
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);

                //Берем следующую правую страницу дневника и деактивируем
                _indexLeftPage--;
                //_indexRightPage--;
                _leftPage[_indexLeftPage].gameObject.SetActive(false);
                _rightPage[_indexRightPage].gameObject.SetActive(true);


                _monsters[_indexMonsters].IsActive = true;

                if (_indexMonsters > 0)
                {
                    _indexMonsters--;
                    _indexRightPage--;

                    _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                    _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);

                    _indexMonsters++;
                }
                else
                {
                    _buttonPrev.gameObject.SetActive(false);
                }

                Initialized();

                _buttonNext.gameObject.SetActive(true); //Переместить

                _turnPrevPage = false;
            }
        }

        public void Dispose()
        {
            _buttonNext.onClick.RemoveAllListeners();
            _buttonPrev.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }
    }
}