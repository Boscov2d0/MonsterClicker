using UnityEngine;

namespace MonstersGame
{
    public class BoosterPenView : BoosterView
    {
        [SerializeField] private int _valueOfKillPower;
        public int ValueOfKillPower { get => _valueOfKillPower; set => _valueOfKillPower = value; }
    }
}