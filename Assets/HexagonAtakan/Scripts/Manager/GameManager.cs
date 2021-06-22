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

        //Test
        public Collider2D _previousColiderHit;

        private void Start()
        {
            _gridManager.CreateAndInitializeHexagons();
        }

        private void Update()
        {
            CheckInput();
        }

        //Check input for selectable object
        public void CheckInput()
        {
            Collider2D hit = Physics2D.OverlapPoint(_inputData.MauseClickPosition);

            if (_previousColiderHit != hit)
            {
                if (hit != null)
                {
                    if (hit.GetComponent<SelectableObject>() != null)
                    {
                        hit.GetComponent<SpriteRenderer>().enabled = true;
                        Transform childSprite = hit.GetComponent<SelectableObject>()._childTransform;
                        childSprite.GetComponent<SpriteRenderer>().enabled = true;
                        hit.GetComponent<SelectableObject>().AdjustmentChildHexagonActive();

                        //Previous Sprite Off
                        if (_previousColiderHit != null && _previousColiderHit.GetComponent<SpriteRenderer>() != null)
                        {
                            _previousColiderHit.GetComponent<SpriteRenderer>().enabled = false;
                            Transform previousChildSprite = _previousColiderHit.GetComponent<SelectableObject>()._childTransform;
                            previousChildSprite.GetComponent<SpriteRenderer>().enabled = false;
                            _previousColiderHit.GetComponent<SelectableObject>().AdjustmentChildHexagonDeactive();
                        }
                        _previousColiderHit = hit;
                    }
                }
            }
        }
    }
}