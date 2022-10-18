using UnityEngine;

namespace MonstersGame
{
    [CreateAssetMenu(fileName = nameof(IncreaseLevelSettings), menuName = "GameSettings/" + nameof(IncreaseLevelSettings))]
    public class IncreaseLevelSettings : ScriptableObject
    {
        [Tooltip("��������, ������� ������� ������������� �������")]
        [SerializeField] private int _valueToIncreaseLevel;

        const string text = "������ �������, ������� ���������� ���� ����� �����������/���������/��������� ��������������� ����������";

        [Tooltip(text)]
        [SerializeField] private int _levelToIncreaseSpeed;
        [Tooltip(text)]
        [SerializeField] private int _levelToDecreaseSpawnTimer;
        [Tooltip(text)]
        [SerializeField] private int _levelToAddNewMonsterType;
        [Tooltip(text)]
        [SerializeField] private int _levelToIncreaseHealthPoint;

        [Tooltip("��������, �� ������� ���������� ��������")]
        [SerializeField] private float _ValueOfIncreaseSpeed;
        [Tooltip("���������� �������, �� ������� ����� ����������� ����� ������")]
        [SerializeField] private float _timeOfDecreaseSpawnTimer;
        [Tooltip("��������, � ������� ���������� Health Point")]
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