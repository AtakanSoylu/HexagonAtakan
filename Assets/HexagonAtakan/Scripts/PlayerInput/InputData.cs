using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.PlayerInput
{
    public enum InputPlatformType { Android , Windows }

    [CreateAssetMenu(menuName = "HexagonAtakan/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public bool LockClick;
        public Vector3 StartClickPosition;
        public Vector3 LastClickPosition;
        public Vector3 UpClickPosition;
        public Vector3 SelectedObjectPosition;
        public float distanceTest;
        public bool isDragable;


        [Header("Platform")]
        [SerializeField] private InputPlatformType _InputPlatformType;

        public void ProcessInput()
        {
            if (_InputPlatformType == InputPlatformType.Android && LockClick==false)
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
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        UpClickPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    }
                }

                if (Vector3.Distance(StartClickPosition, UpClickPosition) < 0.05f)
                {
                    distanceTest = Vector3.Distance(StartClickPosition, UpClickPosition);
                    SelectedObjectPosition = UpClickPosition;
                }
            }
            else if (_InputPlatformType == InputPlatformType.Windows && LockClick == false)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    StartClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

                if (Input.GetMouseButton(0))
                {
                    LastClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    UpClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }

                if(Vector3.Distance(StartClickPosition, UpClickPosition) < 0.05f)
                {
                    distanceTest = Vector3.Distance(StartClickPosition, UpClickPosition);
                    SelectedObjectPosition = UpClickPosition;
                }


            }
        }



    }
}
