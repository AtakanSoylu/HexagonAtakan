using System.Collections;
using UnityEngine;
using HexagonAtakan.PlayerInput;
using HexagonAtakan.Selectable;
using HexagonAtakan.Hexagon;

namespace HexagonAtakan.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private InputData _inputData;
        [SerializeField] private SearchManager _searchManager;


        public SelectableObject _activeSelectableObject;
        public Collider2D _selectedHexagonsHit;
        public Collider2D _previousColiderHit;

        private void Start()
        {
            _gridManager.CreateAndInitializeHexagons();
        }

        private void Update()
        {
            CheckInput();
            RotateSelectedObject();
        }

        //Check input for selectable object
        public void CheckInput()
        {
            _selectedHexagonsHit = Physics2D.OverlapPoint(_inputData.SelectedObjectPosition);

            if (_previousColiderHit != _selectedHexagonsHit)
            {
                if (_selectedHexagonsHit != null)
                {
                    if (_selectedHexagonsHit.GetComponent<SelectableObject>() != null)
                    {
                        _activeSelectableObject = _selectedHexagonsHit.GetComponent<SelectableObject>();
                        _inputData.isDragable = true;

                        //Previous Sprite Renderer Deactive
                        if (_previousColiderHit != null && _previousColiderHit.GetComponent<SpriteRenderer>() != null)
                        {
                            _previousColiderHit.GetComponent<SpriteRenderer>().enabled = false;
                            Transform previousChildSprite = _previousColiderHit.GetComponent<SelectableObject>()._childTransform;
                            previousChildSprite.GetComponent<SpriteRenderer>().enabled = false;
                            _previousColiderHit.GetComponent<SelectableObject>().ChangeChildHexagons();
                            _previousColiderHit.GetComponent<SelectableObject>().AdjustmentChildHexagonDeactive();
                        }



                        //Current Sprite Renderer Active
                        _activeSelectableObject.GetComponent<SpriteRenderer>().enabled = true;
                        Transform childSprite = _activeSelectableObject._childTransform;
                        childSprite.GetComponent<SpriteRenderer>().enabled = true;
                        _activeSelectableObject.ChangeChildHexagons();
                        _activeSelectableObject.AdjustmentChildHexagonActive();



                        _previousColiderHit = _selectedHexagonsHit;
                    }
                }
            }
        }

        public void RotateSelectedObject()
        {
            if (_inputData.isDragable == true)
            {
                if (_activeSelectableObject != null)
                {
                    //3 tour rotate
                    if (_activeSelectableObject.GetComponent<SelectableObjectController>()._rotateCount < 3)
                        RotateDirection();
                    else
                    {
                        _activeSelectableObject.ChangeChildHexagons();
                        _activeSelectableObject.FixChildHexagon();
                        StopRotate();
                    }

                }
            }
        }

        public void StopRotate()
        {
            _inputData.LockClick = false;
            _inputData.StartClickPosition = _inputData.LastClickPosition;
            _activeSelectableObject.GetComponent<SelectableObjectController>()._rotateCount = 0;
        }

        public void RotateDirection()
        {
            Vector3 centerPosition = _activeSelectableObject.transform.position;

            //120 is Right Rotate, -120 is Left Rotate
            float rightRotateAngre = 120.0f;
            float leftRotateAngre = -120.0f;
            float inputTolerance = 1.0f;
            if (centerPosition.y < _inputData.StartClickPosition.y)
            {
                if (_inputData.StartClickPosition.x + inputTolerance < _inputData.LastClickPosition.x)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(rightRotateAngre);
                }
                else if (_inputData.StartClickPosition.x > _inputData.LastClickPosition.x + inputTolerance)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(leftRotateAngre);
                }
                else if (_inputData.StartClickPosition.y > _inputData.LastClickPosition.y + inputTolerance)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(rightRotateAngre);
                }
                else if (_inputData.StartClickPosition.y + inputTolerance < _inputData.LastClickPosition.y)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(leftRotateAngre);

                }
            }
            else if (centerPosition.y > _inputData.StartClickPosition.y)
            {
                if (_inputData.StartClickPosition.x + inputTolerance < _inputData.LastClickPosition.x)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(leftRotateAngre);
                }
                else if (_inputData.StartClickPosition.x > _inputData.LastClickPosition.x + inputTolerance)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(rightRotateAngre);

                }
                else if (_inputData.StartClickPosition.y > _inputData.LastClickPosition.y + inputTolerance)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(leftRotateAngre);
                }
                else if (_inputData.StartClickPosition.y + inputTolerance < _inputData.LastClickPosition.y)
                {
                    _inputData.LockClick = true;
                    _activeSelectableObject.GetComponent<SelectableObjectController>().StartRotate(rightRotateAngre);
                }
            }
        }





    }
}