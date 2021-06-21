using HexagonAtakan.Hexagon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridManagerSettings _gridManagerSettings;

        protected HexagonBase[,] _hexagonBaseArray;

        public void Start()
        {
            _hexagonBaseArray = new HexagonBase[_gridManagerSettings.Width, _gridManagerSettings.Height];
        }

        public void CreateHexagons()
        {
            Vector3 startPosition = _gridManagerSettings.HexagonStartCordinate;
            for (int x = 0; x < _gridManagerSettings.Width; x++)
            {
                for (int y = 0; y < _gridManagerSettings.Height; y++)
                {
                    //x Cord Settings
                    float xCordIncrease = 0.58f;
                    float xCord = startPosition.x + (x * xCordIncrease);

                    //y Cord Settings
                    float yCordIncreaseOffset = 0.16f;
                    float yDownLineOffset = 0.64f;
                    float yOffset = x % 2 == 0 ? 1 : -1;
                    float yCord = startPosition.y - (y * yDownLineOffset) + (yOffset * yCordIncreaseOffset);

                    var instatiated = CreateRandomColorHexagon(new Vector3(xCord, yCord, 0));

                    //Add Hexagon to Hexagon Array
                    _hexagonBaseArray[x, y] = instatiated.GetComponent<HexagonBase>();
                }
            }
        }

        private GameObject CreateRandomColorHexagon(Vector3 position)
        {
            // Random int for hexagon color
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