using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.PlayerInput
{
    public enum InputPlatformType { Android , Windows }

    [CreateAssetMenu(menuName = "HexagonAtakan/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public Vector3 StartClickPosition;
        public Vector3 LastClickPosition;
        public bool isDragable = false;

        [Header("Platform")]
        [SerializeField] private InputPlatformType _InputPlatformType;

        public void ProcessInput()
        {
            if (_InputPlatformType == InputPlatformType.Android)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        StartClickPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        LastClickPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    }
                }
            }
            else if (_InputPlatformType == InputPlatformType.Windows)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                if (Input.GetMouseButton(0))
                {
                    LastClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    isDragable = true;
                }
            }
        }



    }
}
