using HexagonAtakan.Hexagon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private GridManagerSettings _gridManagerSettings;
        public HexagonController[,] _hexagonBaseArray;

        public void Awake()
        {
            _hexagonBaseArray = new HexagonController[_gridManagerSettings.Width, _gridManagerSettings.Height];
        }


        //Initialize Hexagon for Game Screen
        public void CreateAndInitializeHexagons()
        {
            for (int x = 0; x < _gridManagerSettings.Width; x++)
            {
                for (int y = 0; y < _gridManagerSettings.Height; y++)
                {
                    CreateHexagonWithXY(x, y);
                }
            }
        }
        public void CreateHexagonWithXY(int x,int y)
        {
            Vector3 startPosition = _gridManagerSettings.HexagonStartCoordinate;
            //x Cord Settings
            float xCord = startPosition.x + (x * _gridManagerSettings.XCordIncreaseOffset);

            //y Cord Settings
            float yOffset = x % 2 == 0 ? 1 : -1;
            float yCord = startPosition.y - (y * _gridManagerSettings.YBottomLineOffset) + (yOffset * _gridManagerSettings.YCordIncreaseOffset);
            var instantiated = CreateRandomColorHexagon(new Vector3(xCord, yCord), x, y);
        }

        public GameObject CreateRandomColorHexagon(Vector3 position,int x,int y)
        {
            // Random int for Hexagon Color
            int rand = Random.Range(0, _gridManagerSettings.HexagonColor.Length);

            var instantiated = Instantiate(_gridManagerSettings.HexagonPrefab, position, Quaternion.identity);
            SetColor(instantiated, _gridManagerSettings.HexagonColor[rand]);
            instantiated.GetComponent<HexagonController>().HexColor = _gridManagerSettings.HexagonColor[rand];

            //Add Hexagon to Hexagon Array
            instantiated.GetComponent<HexagonController>().SetArrayPosition(x, y);
            _hexagonBaseArray[x, y] = instantiated.GetComponent<HexagonController>();
            return instantiated as GameObject;
        }

        private void SetColor(GameObject value, Color color)
        {
            value.GetComponent<SpriteRenderer>().color = color;
        }

        //Fix Hexagons Positions (Temporary)
        public void FixScene()
        {
            for (int x = 0; x < _gridManagerSettings.Width; x++)
            {
                for (int y = 0; y < _gridManagerSettings.Height; y++)
                {
                    Vector3 startPosition = _gridManagerSettings.HexagonStartCoordinate;
                    //x Cord Settings
                    float xCord = startPosition.x + (x * _gridManagerSettings.XCordIncreaseOffset);

                    //y Cord Settings
                    float yOffset = x % 2 == 0 ? 1 : -1;
                    float yCord = startPosition.y - (y * _gridManagerSettings.YBottomLineOffset) + (yOffset * _gridManagerSettings.YCordIncreaseOffset);

                    //Fix Hexagons Positions
                    _hexagonBaseArray[x, y].transform.position = new Vector3(xCord, yCord);
                }
            }
        }
    }
}
