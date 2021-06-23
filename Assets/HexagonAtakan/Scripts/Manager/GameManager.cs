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



        // Testing
        [SerializeField] private float _rotationTime = 2f;
        [SerializeField] private float _delayBetweenRotations = 1f;

        private WaitForSeconds _rotationDelay;
        private Quaternion _targetRot;

        private bool _rotating;
        ///******/////
        


        private void Start()
        {
            _gridManager.CreateAndInitializeHexagons();

            _rotationDelay = new WaitForSeconds(_delayBetweenRotations);
        }

        private void Update()
        {
            CheckInput();
            RotateSelectedObject();
        }

        //Check input for selectable object
        public void CheckInput()
        {
            _selectedHexagons = Physics2D.OverlapPoint(_inputData.StartClickPosition);

            if (_previousColiderHit != _selectedHexagons)
            {
                if (_selectedHexagons != null)
                {
                    if (_selectedHexagons.GetComponent<SelectableObject>() != null)
                    {
                        _selectedHexagons.GetComponent<SpriteRenderer>().enabled = true;
                        Transform childSprite = _selectedHexagons.GetComponent<SelectableObject>()._childTransform;
                        childSprite.GetComponent<SpriteRenderer>().enabled = true;
                        _selectedHexagons.GetComponent<SelectableObject>().AdjustmentChildHexagonActive();

                        //Previous Sprite Off
                        if (_previousColiderHit != null && _previousColiderHit.GetComponent<SpriteRenderer>() != null)
                        {
                            _previousColiderHit.GetComponent<SpriteRenderer>().enabled = false;
                            Transform previousChildSprite = _previousColiderHit.GetComponent<SelectableObject>()._childTransform;
                            previousChildSprite.GetComponent<SpriteRenderer>().enabled = false;
                            _previousColiderHit.GetComponent<SelectableObject>().AdjustmentChildHexagonDeactive();
                        }
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


                        
                        _selectedHexagons.GetComponent<SelectableObjectController>().StartRotate();
                    }
                }
            }
        }


    }
}