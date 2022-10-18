using UnityEngine;

namespace MonstersGame
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private int _countOfMonsterToLose;
        public int CountOfMonsterToLose { get => _countOfMonsterToLose; set => _countOfMonsterToLose = value; }
    }
}