using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexagonAtakan.Hexagon;
using HexagonAtakan.Manager;

namespace HexagonAtakan.Selectable
{
    public enum SelectableObjectType { LeftBig, RightBig }

    public class SelectableObject : MonoBehaviour
    {
        [SerializeField] public SelectableObjectType _selectableObjectType;

        [SerializeField] private GridManager _gridManager;
        public Transform _childTransform;
        public Dictionary<int, Vector2> _childHexagonsDictionary;
        public HexagonController[] _childHexagonArray;
        public bool _searching = true;

        private int _connectedHexagonCount;

        private void Awake()
        {
            _gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
            _childHexagonArray = new HexagonController[3];
            _childHexagonsDictionary = new Dictionary<int, Vector2>();
            _connectedHexagonCount = 0;
        }


        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.GetComponent<HexagonController>() != null)
            {
                if (_connectedHexagonCount < 3)
                {
                    _childHexagonArray[_connectedHexagonCount] = coll.GetComponent<HexagonController>();
                    _childHexagonsDictionary.Add(_connectedHexagonCount, coll.GetComponent<HexagonController>().GetArrayPosition());
                    _connectedHexagonCount++;
                }
            }
        }

        //Adjusting child hexagons array
        public void ChangeChildHexagons()
        {
            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                _childHexagonArray[i] = _gridManager._hexagonBaseArray[(int)_childHexagonsDictionary[i].x, (int)_childHexagonsDictionary[i].y];
            }
            _gridManager.FixScene();
        }

        //Array to child
        public void AdjustmentChildHexagonActive()
        {

            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                _childHexagonArray[i].transform.SetParent(transform);
            }
        }

        //deleting child
        public void AdjustmentChildHexagonDeactive()
        {
            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                _childHexagonArray[i].transform.SetParent(null);
            }
        }

        public void FixChildHexagon()
        {
            AdjustmentChildHexagonDeactive();
            AdjustmentChildHexagonActive();
        }

        public void ChildHexagonsRotateRight()
        {
            if (_selectableObjectType == SelectableObjectType.LeftBig)
            {
                ChangeHexagonsArray(_childHexagonArray[0], _childHexagonArray[1]);
                ChangeHexagonsArray(_childHexagonArray[0], _childHexagonArray[2]);
                ChangeChildHexagons();
            }
            else if (_selectableObjectType == SelectableObjectType.RightBig)
            {
                ChangeHexagonsArray(_childHexagonArray[0], _childHexagonArray[1]);
                ChangeHexagonsArray(_childHexagonArray[1], _childHexagonArray[2]);
                ChangeChildHexagons();
            }
        }
        public void ChildHexagonsRotateLeft()
        {
            if (_selectableObjectType == SelectableObjectType.LeftBig)
            {
                ChangeHexagonsArray(_childHexagonArray[0], _childHexagonArray[1]);
                ChangeHexagonsArray(_childHexagonArray[1], _childHexagonArray[2]);
                ChangeChildHexagons();
            }
            else if (_selectableObjectType == SelectableObjectType.RightBig)
            {
                ChangeHexagonsArray(_childHexagonArray[0], _childHexagonArray[1]);
                ChangeHexagonsArray(_childHexagonArray[2], _childHexagonArray[0]);
                ChangeChildHexagons();
            }
        }


        public void ChangeHexagonsArray(HexagonController hexagonA , HexagonController hexagonB)
        {
            //basic change system ( will change)
            HexagonController tempHexagonA ;
            tempHexagonA = hexagonA;

            int hexagonBPositionX = hexagonB.XPosition;
            int hexagonBPositionY = hexagonB.YPosition;

            HexagonController tempHexagonB ;
            tempHexagonB = hexagonB;

            //Transfer hexB to hexA
            _gridManager._hexagonBaseArray[tempHexagonA.XPosition, tempHexagonA.YPosition] = hexagonB;
            _gridManager._hexagonBaseArray[tempHexagonA.XPosition, tempHexagonA.YPosition].SetArrayPosition(hexagonA.XPosition, hexagonA.YPosition);


            //Transfer hexA to hexB
            _gridManager._hexagonBaseArray[hexagonBPositionX, hexagonBPositionY] = tempHexagonA;
            _gridManager._hexagonBaseArray[hexagonBPositionX, hexagonBPositionY].SetArrayPosition(hexagonBPositionX, hexagonBPositionY);
        }

    }
}
