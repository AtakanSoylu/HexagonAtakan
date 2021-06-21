using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HexagonAtakan.Manager
{
    [CreateAssetMenu(menuName = "HexagonAtakan/Manager/Select Manager Settings")]
    public class SelectManagerSettings : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject _selectedHexagonRightPrefab;
        public GameObject SelectedHexagonRightPrefab { get { return _selectedHexagonRightPrefab; } }

        [SerializeField] private GameObject _selectedHexagonLeftPrefab;
        public GameObject SelectedHexagonLeftPrefab { get { return _selectedHexagonLeftPrefab; } }

        [Header("Coordinate")]
        [SerializeField] private Vector3 _hexagonStartCoordinate;
        public Vector3 HexagonStartCoordinate { get { return _hexagonStartCoordinate; } }

    }
}
