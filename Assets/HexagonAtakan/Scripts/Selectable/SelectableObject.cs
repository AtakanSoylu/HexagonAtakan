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
                if (_connectedHexagonCount < 3)
                {
                    _childHexagonArray[_connectedHexagonCount] = coll.GetComponent<HexagonController>();
                    _connectedHexagonCount++;
                }
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
            }
        }

        public void ChangeChildLocation()
        {

        }
    }
}
