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
            _inputData.StartClickPosition = new Vector3(1000, 1000);
            _inputData.SelectedObjectPosition = new Vector3(1000, 1000);
        }
        private void Update()
        {
            _inputData.ProcessInput();
        }
    }
}
