using HexagonAtakan.Hexagon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridManagerSettings _gridManagerSettings;
        protected HexagonController[,] _hexagonBaseArray;

        public void Start()
        {
            _hexagonBaseArray = new HexagonController[_gridManagerSettings.Width, _gridManagerSettings.Height];
        }

        //Initialize Hexagon for Game Screen
        public void CreateAndInitializeHexagons()
        {
            Vector3 startPosition = _gridManagerSettings.HexagonStartCoordinate;
            for (int x = 0; x < _gridManagerSettings.Width; x++)
            {
                for (int y = 0; y < _gridManagerSettings.Height; y++)
                {
                    //x Cord Settings
                    float xCord = startPosition.x + (x * _gridManagerSettings.XCordIncreaseOffset);

                    //y Cord Settings
                    float yOffset = x % 2 == 0 ? 1 : -1;
                    float yCord = startPosition.y - (y * _gridManagerSettings.YBottomLineOffset) + (yOffset * _gridManagerSettings.YCordIncreaseOffset);
                    var instatiated = CreateRandomColorHexagon(new Vector3(xCord, yCord, 0));

                    //Add Hexagon to Hexagon Array
                    _hexagonBaseArray[x, y] = instatiated.GetComponent<HexagonController>();
                }
            }
        }

        private GameObject CreateRandomColorHexagon(Vector3 position)
        {
            // Random int for Hexagon Color
            int rand = Random.Range(0, _gridManagerSettings.HexagonColor.Length);

            var instantiated = Instantiate(_gridManagerSettings.HexagonPrefab, position, Quaternion.identity);
            SetColor(instantiated, _gridManagerSettings.HexagonColor[rand]);
            return instantiated as GameObject;
        }

        private void SetColor(GameObject value, Color color)
        {
            value.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
