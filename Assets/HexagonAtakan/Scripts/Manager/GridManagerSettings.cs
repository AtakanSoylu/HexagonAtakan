using System.Collections;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    [CreateAssetMenu(menuName = "HexagonAtakan/Manager/Grid Manager Settings")]
    public class GridManagerSettings : ScriptableObject
    {
        [Header("Grid Settings")]
        [SerializeField] private int _width;
        public int Width { get { return _width; } }

        [SerializeField] private int _height;
        public int Height { get { return _height; } }

        [Header("")]
        [SerializeField] private Color[] _hexagonColorArray;
        public Color[] HexagonColor { get { return _hexagonColorArray; } }

        [Header("Prefabs")]
        [SerializeField] private GameObject _hexagonPrefab;
        public GameObject HexagonPrefab { get { return _hexagonPrefab; } }

        [Header("Hexagon Cordinate")]
        [SerializeField] private Vector3 _hexagonStartCordinate;
        public Vector3 HexagonStartCordinate { get { return _hexagonStartCordinate; } }

        [SerializeField] private float _xCordIncreaseOffset;
        public float XCordIncreaseOffset { get { return _xCordIncreaseOffset; } }

        [SerializeField] private float _yCordIncreaseOffset;
        public float YCordIncreaseOffset { get { return _yCordIncreaseOffset; } }

        [SerializeField] private float _yBottomLineOffset;
        public float YBottomLineOffset { get { return _yBottomLineOffset; } }


    }
}