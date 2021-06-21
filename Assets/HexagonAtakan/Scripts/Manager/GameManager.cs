using System.Collections;
using UnityEngine;
using HexagonAtakan.PlayerInput;


namespace HexagonAtakan.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private InputData _inputData;

        private void Start()
        {
            _gridManager.InitializeHexagons();
        }

        private void Update()
        {
            
        }


    }
}