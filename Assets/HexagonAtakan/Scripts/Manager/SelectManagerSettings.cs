using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HexagonAtakan.Manager
{
    [CreateAssetMenu(menuName = "HexagonAtakan/Manager/Select Manager Settings")]
    public class SelectManagerSettings : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _selectedHexagonPrefab;
        public GameObject SelectedHexagonPrefab { get { return _selectedHexagonPrefab; } }


        [Header("Coordinate")]
        [SerializeField] private float _xNarrowOffset;
        public float XNarrowOffset { get { return _xNarrowOffset; } }

        [SerializeField] private float _xWideOffset;
        public float XWideOffset { get { return _xWideOffset; } }

        [Header("Start  Position X Offsets")]
        [SerializeField] private float _narrowStartPositionXOffset;
        public float NarrowStartPositionXOffset { get { return _narrowStartPositionXOffset; } }

        [SerializeField] private float _wideStartPositionXOffset;
        public float WideStartPositionXOffset { get { return _wideStartPositionXOffset; } }





    }
}
