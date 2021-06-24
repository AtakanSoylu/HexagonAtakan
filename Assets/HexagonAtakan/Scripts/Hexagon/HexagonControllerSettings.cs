using System.Collections;
using UnityEngine;

namespace HexagonAtakan.Hexagon
{
    [CreateAssetMenu(menuName = "HexagonAtakan/Hexagon/Hexagon Speed Settings")]
    public class HexagonControllerSettings : ScriptableObject
    {
            [SerializeField] private float _hexagonPositionTime = 0.25f;
            public float HexagonPositionTime { get { return _hexagonPositionTime; } }


    }
}