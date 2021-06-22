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

            if (hit != null)
            {
                if (hit.GetComponent<SelectableObject>() != null)
                {
                    hit.GetComponent<SpriteRenderer>().enabled = true;
                    Transform childSprite = hit.GetComponent<SelectableObject>()._childTransform;
                    childSprite.GetComponent<SpriteRenderer>().enabled = true;

                }
            }

        }


    }
}