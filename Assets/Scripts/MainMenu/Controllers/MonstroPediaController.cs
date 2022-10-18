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
            _indexLeftPage = 1;  //�������� ������ ����� �������� ��������
            _indexRightPage = 1; //�������� ������ ������ �������� ��������
        }

        public void FirstOpen()
        {
            _monsters[_indexMonsters].IsActive = true;

            //���������� ����� � ������ �������� ��������
            _leftPage[_indexLeftPage].gameObject.SetActive(true);
            _rightPage[_indexRightPage].gameObject.SetActive(true);

            //���������� ����� � ������ �������� ������� �������
            _monsters[_indexMonsters].LeftPage.SetActive(true);
            _monsters[_indexMonsters].RightPage.SetActive(true);

            //����� � ������ �������� ������� ������� �������� � ������ ����� � ������ �������� ��������
            _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
            _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
        }

        public void NextPage()
        {
            if (_indexMonsters < _monsters.Count - 1 && !_turnNextPage && !_turnPrevPage)
            {
                _monsters[_indexMonsters].IsActive = false;
                //�������������� ��������� ������ �������� ��������
                //���������� ��������� ������ �������� ��������
                _rightPage[++_indexRightPage].gameObject.SetActive(true);
                _indexMonsters++; //����� ���������� �������
                                  //���������� ������ �������� ���������� �������, � �������� �� � ��������� ������ �������� ��������
                _monsters[_indexMonsters].RightPage.SetActive(true);
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);

                _indexRightPage--; //����� ������ ������ ��������

                //�������������� ����� �������� ���������� ������� � �������� ����������
                //����� �������� ���������� ������� �������� � ������ ������ �������� ��������
                //������ ������� ����� �������� ���������� ������� ������� ������ �������� ���������� �������
                //����� �������� ���������� ������� �������������� ��� ����������� �� �������� �������� �����
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                _monsters[_indexMonsters].LeftPage.transform.position = _monsters[_indexMonsters].RightPage.transform.position;
                _monsters[_indexMonsters].LeftPage.transform.eulerAngles = new Vector3(0, 180, 0);

                //���������� �������� ��������
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

                //�������������� ���������� ����� �������� ��������
                //���������� ���������� ����� �������� ��������
                _leftPage[--_indexLeftPage].gameObject.SetActive(true);
                _indexMonsters--; //����� ����������� �������
                                  //���������� ����� �������� ����������� �������, � �������� �� � ����������� ����� �������� ��������
                _monsters[_indexMonsters].LeftPage.SetActive(true);
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);

                _indexLeftPage++; //����� ������ ����� ��������

                //�������������� ������ �������� ����������� ������� � �������� ����������
                //������ �������� ����������� ������� �������� � ������ ����� �������� ��������
                //������ ������� ������ �������� ����������� ������� ������� ����� �������� ����������� �������
                //������ �������� ����������� ������� �������������� ��� ����������� �� �������� �������� �����
                _monsters[_indexMonsters].RightPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
                _monsters[_indexMonsters].RightPage.transform.position = _monsters[_indexMonsters].LeftPage.transform.position;
                _monsters[_indexMonsters].RightPage.transform.eulerAngles = new Vector3(0, 180, 0);

                //���������� �������� ��������
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
                _monsters[_indexMonsters].LeftPage.SetActive(true); //���������� ����� �������� ���������� �������

                _indexMonsters--; //������������� �� ������� �������

                _monsters[_indexMonsters].RightPage.SetActive(false); //������������ ������ �������� ������� �������
            }
            if (_rightPage[_indexRightPage].transform.eulerAngles.y >= 355)
            {
                //������������ ����� �������� ������� �������
                _monsters[_indexMonsters].LeftPage.SetActive(false);
                //����� � ������ �������� ������� ������� �������� � ���������� ����� � ������ �������� ��������
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[--_indexLeftPage].transform);
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[--_indexRightPage].transform);

                //������ ������ ���������� ����������, � ��������� - ������!!!

                _indexMonsters++;  //������������� �� ������� �������
                _indexLeftPage++;  //������������� �� ������ ����� �������� ��������
                _indexRightPage++; //������������� �� ������ ������ �������� ��������

                //����� �������� ������� ������� �������� � ������ ����� �������� ��������
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);
                //���������� ������ ������ �������� ����� �������� �� ���� �����
                _rightPage[_indexRightPage].transform.eulerAngles = new Vector3(0, 180, 0);
                //������ �������� ������� ������� �������� � ������ ������ �������� ��������
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);


                _monsters[_indexMonsters].IsActive = true;

                //����� ��������� ������ �������� �������� � ������������
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

                _buttonPrev.gameObject.SetActive(true); //�����������

                _turnNextPage = false;
            }
        }
        private void TurnPrevPage()
        {
            _leftPage[_indexLeftPage].transform.eulerAngles -= new Vector3(0, 3f, 0);

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y >= 269 && _leftPage[_indexLeftPage].transform.eulerAngles.y <= 271)
            {
                _monsters[_indexMonsters].RightPage.SetActive(true); //���������� ������ �������� ����������� �������

                _indexMonsters++; //������������� �� ������� �������

                _monsters[_indexMonsters].LeftPage.SetActive(false); //������������ ����� �������� ������� �������
            }

            if (_leftPage[_indexLeftPage].transform.eulerAngles.y <= 181)
            {
                //������������ ������ �������� ������� �������
                _monsters[_indexMonsters].RightPage.SetActive(false);
                //����� �������� ������� ������� �������� � ����� � ������ ��������� �������� ��������
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[++_indexLeftPage].transform);

                //������ ������ ���������� ���������, � ���������� - ������!!!
                _indexMonsters--;
                _indexLeftPage--;  //������������� �� ������ ����� �������� ��������
                _indexRightPage++; //������������� ��  ������ �������� ��������
                _rightPage[_indexRightPage].gameObject.SetActive(false);
                _indexRightPage--;
                //����� �������� ������� ������� �������� � ������ ����� �������� ��������
                _monsters[_indexMonsters].RightPage.transform.SetParent(_rightPage[_indexRightPage].transform);
                //���������� ������ ������ �������� ����� �������� �� ���� �����
                _leftPage[_indexLeftPage].transform.eulerAngles = new Vector3(0, 0, 0);
                //������ �������� ������� ������� �������� � ������ ������ �������� ��������
                _monsters[_indexMonsters].LeftPage.transform.SetParent(_leftPage[_indexLeftPage].transform);

                //����� ��������� ������ �������� �������� � ������������
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

                _buttonNext.gameObject.SetActive(true); //�����������

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