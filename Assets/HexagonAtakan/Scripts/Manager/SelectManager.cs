using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class SelectManager : MonoBehaviour
    {
        [SerializeField] private SelectManagerSettings _selectManagerSettings;
        [SerializeField] private GridManagerSettings _gridManagerSettings;


        private void Start()
        {
            CreateAndInitializeScriptableObject();
        }

        public void CreateAndInitializeScriptableObject()
        {
            //düzelt atakan isimleri magic number hallet
            float startPositionX = _gridManagerSettings.HexagonStartCoordinate.x + 0.20f;
            float startPositionY = _gridManagerSettings.HexagonStartCoordinate.y - _gridManagerSettings.YCordIncreaseOffset;

            //Hexagon Width Count - 1
            int selectableObjectWidth = _gridManagerSettings.Width - 1;

            //(Hexagon Height Count - 1 ) * 2 //DUZELT
            int selectableObjectHeight = (_gridManagerSettings.Height - 1) * 2;


            for (int x = 0; x < selectableObjectWidth ; x++)
            {
                //x Cord Settings
                //float xWideOffset = 
                float xCord = startPositionX + (x * _gridManagerSettings.XCordIncreaseOffset);
            }


        }
    }
}
/*for (int y = 0; y < selectableObjectHeight; y++)
                {
                    //x Cord Settings
                    float xCord = startPositionX + (x * _gridManagerSettings.XCordIncreaseOffset);


                    //y Cord Settings
                    float yCord = startPositionY + (y * _gridManagerSettings.XCordIncreaseOffset);


                }
*/