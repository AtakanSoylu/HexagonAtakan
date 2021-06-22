using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class SelectManager   : MonoBehaviour
    {
        [SerializeField] private SelectManagerSettings _selectManagerSettings;
        [SerializeField] private GridManagerSettings _gridManagerSettings;


        private void Start()
        {
            CreateAndInitializeScriptableObject();
        }

        public void CreateAndInitializeScriptableObject()
        {
            //Line Start Position
            float narrowLineStartPositionX = _gridManagerSettings.HexagonStartCoordinate.x - _selectManagerSettings.NarrowStartPositionXOffset;
            float wideLineStartPositionX = _gridManagerSettings.HexagonStartCoordinate.x - _selectManagerSettings.WideStartPositionXOffset;
            float lineStartPositionY = _gridManagerSettings.HexagonStartCoordinate.y - (_gridManagerSettings.YCordIncreaseOffset);

            //Hexagon Width Count - 1 (Hexagon width is 8 , selectable x object count is 7 etc.)
            int selectableObjectXCount = _gridManagerSettings.Width - 1;

            //(Hexagon Height Count - 1 ) * 2 (Hexagon height is 9, selectable y object count is 16 etc.)
            int selectableObjectYCount = (_gridManagerSettings.Height - 1) * 2;

            //Mean narrow or wide control
            bool isNarrow = true;



            for (int y = 0; y < selectableObjectYCount; y++)
            {
                float lineStartPositionX = isNarrow == true ? narrowLineStartPositionX : wideLineStartPositionX;
                Vector3 previousPosition = new Vector3(lineStartPositionX, lineStartPositionY);
                
                for (int x = 0; x < selectableObjectXCount ; x++)
                {
                    //x Cord Settings

                    float xIncreaseOffset = isNarrow == true ? _selectManagerSettings.XNarrowOffset : _selectManagerSettings.XWideOffset;
                    float xCord = previousPosition.x + xIncreaseOffset;
                    float yCord = lineStartPositionY - (y * (_gridManagerSettings.YCordIncreaseOffset * 2));

                    Vector3 position = new Vector3(xCord, yCord, 0);

                    if (isNarrow)
                    {
                        Instantiate(_selectManagerSettings.SelectedHexagonPrefab, position, Quaternion.Euler(0, 0, 180));
                    }
                    else
                    {
                        Instantiate(_selectManagerSettings.SelectedHexagonPrefab, position, Quaternion.identity);
                    }

                    isNarrow = !isNarrow;
                    previousPosition = position;
                }
            }
        }
    }
}
