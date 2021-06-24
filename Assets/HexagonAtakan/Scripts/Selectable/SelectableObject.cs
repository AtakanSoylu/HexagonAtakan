using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexagonAtakan.Hexagon;
using HexagonAtakan.Manager;

namespace HexagonAtakan.Selectable
{
    public class SelectableObject : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        public Transform _childTransform;
        public HexagonController[] _childHexagonArray;
        public bool _searching = true;

        private int _connectedHexagonCount;

        private void Awake()
        {
            _gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
            _childHexagonArray = new HexagonController[3];
            _connectedHexagonCount = 0;
        }


        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.GetComponent<HexagonController>() != null)
            {
                bool isThere = false;
                for (int i = 0; i < _childHexagonArray.Length; i++)
                {
                    if(_childHexagonArray[i] == coll.GetComponent<HexagonController>())
                    {
                        isThere = true;
                    }
                }

                if (!isThere)
                {
                    _childHexagonArray[_connectedHexagonCount] = coll.GetComponent<HexagonController>();

                    _connectedHexagonCount++;
                }
                if (_connectedHexagonCount == 3) _connectedHexagonCount = 0;
            }
        }

        public void AdjustmentChildHexagonActive()
        {
            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                _childHexagonArray[i].transform.SetParent(transform);
            }
        }

        public void AdjustmentChildHexagonDeactive()
        {
            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                _childHexagonArray[i].transform.SetParent(null);
                _connectedHexagonCount = 0;
            }
        }

        public void ChangeChildLocation()
        {
            int[,] tempLocations = new int[_childHexagonArray.Length, 2];

            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                tempLocations[i, 0] = _childHexagonArray[i].XPosition;
                tempLocations[i, 1] = _childHexagonArray[i].YPosition;
            }

            for (int i = 0; i < _childHexagonArray.Length; i++)
            {
                if (i == 0)
                    _childHexagonArray[i].SetPosition(tempLocations[_childHexagonArray.Length - 1, 0], tempLocations[_childHexagonArray.Length - 1, 1]);
                else
                    _childHexagonArray[i].SetPosition(tempLocations[i - 1, 0], tempLocations[i - 1, 1]);
            }

        }
    }
}
