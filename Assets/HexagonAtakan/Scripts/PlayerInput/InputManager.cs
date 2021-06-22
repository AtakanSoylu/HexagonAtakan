using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HexagonAtakan.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;

        private void Start()
        {
            //Mean dont select anything (Default)
            _inputData.MauseClickPosition = new Vector3(1000, 1000);
        }
        private void Update()
        {
            _inputData.ProcessInput();
        }
    }
}
