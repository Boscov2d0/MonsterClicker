using UnityEngine;

namespace MonstersGame
{
    [CreateAssetMenu(fileName = nameof(IncreaseLevelSettings), menuName = "GameSettings/" + nameof(IncreaseLevelSettings))]
    public class IncreaseLevelSettings : ScriptableObject
    {
        [Tooltip("¬еличина, кратноц которой увеличиваетс€ уровень")]
        [SerializeField] private int _valueToIncreaseLevel;

        const string text = " аждый уровень, кратный параметрам ниже будет увеличивать/уменьшать/добавл€ть соответствующий показатель";

        [Tooltip(text)]
        [SerializeField] private int _levelToIncreaseSpeed;
        [Tooltip(text)]
        [SerializeField] private int _levelToDecreaseSpawnTimer;
        [Tooltip(text)]
        [SerializeField] private int _levelToAddNewMonsterType;
        [Tooltip(text)]
        [SerializeField] private int _levelToIncreaseHealthPoint;

        [Tooltip("¬еличина, на которую увеличитс€ скорость")]
        [SerializeField] private float _ValueOfIncreaseSpeed;
        [Tooltip(" оличество времени, на которое будет уменьшатьс€ врем€ спавна")]
        [SerializeField] private float _timeOfDecreaseSpawnTimer;
        [Tooltip("¬еличина, в которую увеличитс€ Health Point")]
        [SerializeField] private int _valueOfIncreaseHealthPoint;

        public int ValueToIncreaseLevel { get => _valueToIncreaseLevel; set => _valueToIncreaseLevel = value; }
        public int LevelToIncreaseSpeed { get => _levelToIncreaseSpeed; set => _levelToIncreaseSpeed = value; }
        public int LevelToDecreaseSpawnTimer { get => _levelToDecreaseSpawnTimer; set => _levelToDecreaseSpawnTimer = value; }
        public int LevelToAddNewMonsterType { get => _levelToAddNewMonsterType; set => _levelToAddNewMonsterType = value; }
        public int LevelToIncreaseHealthPoint { get => _levelToIncreaseHealthPoint; set => _levelToIncreaseHealthPoint = value; }
        public float ValueOfIncreaseSpeed { get => _ValueOfIncreaseSpeed; set => _ValueOfIncreaseSpeed = value; }
        public float TimeOfDecreaseSpawnTimer { get => _timeOfDecreaseSpawnTimer; set => _timeOfDecreaseSpawnTimer = value; }
        public int ValueOfIncreaseHealthPoint { get => _valueOfIncreaseHealthPoint; set => _valueOfIncreaseHealthPoint = value; }
    }
}