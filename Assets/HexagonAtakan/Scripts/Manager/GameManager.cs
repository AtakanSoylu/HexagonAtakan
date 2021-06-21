using System.Collections;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;

        private void Start()
        {
            _gridManager.CreateHexagons();
        }
        
        


    }
}