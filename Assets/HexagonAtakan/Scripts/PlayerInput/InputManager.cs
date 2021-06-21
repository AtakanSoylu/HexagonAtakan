using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HexagonAtakan.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;

        private void Update()
        {
            _inputData.ProcessInput();
        }
    }
}
