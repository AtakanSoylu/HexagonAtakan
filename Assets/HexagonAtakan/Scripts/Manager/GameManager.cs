using System.Collections;
using UnityEngine;
using HexagonAtakan.PlayerInput;
using HexagonAtakan.Selectable;

namespace HexagonAtakan.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private InputData _inputData;

        private Collider2D _selectedHexagons;
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
            _selectedHexagons = Physics2D.OverlapPoint(_inputData.SelectedObjectPosition);

            if (_previousColiderHit != _selectedHexagons)
            {
                if (_selectedHexagons != null)
                {
                    if (_selectedHexagons.GetComponent<SelectableObject>() != null)
                    {

                        //Previous Sprite Off
                        if (_previousColiderHit != null && _previousColiderHit.GetComponent<SpriteRenderer>() != null)
                        {
                            _previousColiderHit.GetComponent<SpriteRenderer>().enabled = false;
                            Transform previousChildSprite = _previousColiderHit.GetComponent<SelectableObject>()._childTransform;
                            previousChildSprite.GetComponent<SpriteRenderer>().enabled = false;
                            _previousColiderHit.GetComponent<SelectableObject>().AdjustmentChildHexagonDeactive();
                        }

                        _selectedHexagons.GetComponent<SpriteRenderer>().enabled = true;
                        Transform childSprite = _selectedHexagons.GetComponent<SelectableObject>()._childTransform;
                        childSprite.GetComponent<SpriteRenderer>().enabled = true;
                        _selectedHexagons.GetComponent<SelectableObject>().AdjustmentChildHexagonActive();

                        _previousColiderHit = _selectedHexagons;
                    }
                }
            }
        }

        public void RotateSelectedObject()
        {
            if (_inputData.isDragable == true)
            {
                if (_selectedHexagons != null)
                {
                    if (_selectedHexagons.GetComponent<SelectableObject>() != null)
                    {
                        RotateDirection();
                    }
                }
            }
        }

        public void RotateDirection()
        {
            Vector3 centerPosition = _selectedHexagons.transform.position;
            Debug.Log(centerPosition);

            //120 is Right Rotate, -120 is Left Rotate
            if (centerPosition.y < _inputData.StartClickPosition.y)
            {
                if(_inputData.StartClickPosition.x + 1  < _inputData.LastClickPosition.x)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(120);
                }
                else if (_inputData.StartClickPosition.x > _inputData.LastClickPosition.x + 1)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(-120);

                }
                else if(_inputData.StartClickPosition.y > _inputData.LastClickPosition.y + 1)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(120);
                }
                else if(_inputData.StartClickPosition.y + 1 < _inputData.LastClickPosition.y)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(-120);
                }
            }
            else if(centerPosition.y > _inputData.StartClickPosition.y)
            {
                if(_inputData.StartClickPosition.x + 1 < _inputData.LastClickPosition.x)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(-120);
                }
                else if(_inputData.StartClickPosition.x > _inputData.LastClickPosition.x + 1)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(120);
                }
                else if(_inputData.StartClickPosition.y > _inputData.LastClickPosition.y + 1)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(-120);
                }
                else if(_inputData.StartClickPosition.y + 1 < _inputData.LastClickPosition.y)
                {
                    _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate(120);
                }
            }
        }


    }
}