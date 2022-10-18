using UnityEngine;

namespace MonstersGame
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "GameSettings/" + nameof(GameSettings))]
    public class GameSettings : ScriptableObject
    {
        [Tooltip("Условие поражения: количество монстров на поле, указанное ниже")]
        [SerializeField] private int _countOfMonsterToLose;
        [SerializeField] private int _countOfMonsterType;
        public int CountOfMonsterToLose { get => _countOfMonsterToLose; set => _countOfMonsterToLose = value; }
        public int CountOfMonsterType { get => _countOfMonsterType; set => _countOfMonsterType = value; }
    }
}