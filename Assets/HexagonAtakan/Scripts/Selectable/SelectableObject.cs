using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexagonAtakan.Hexagon;

namespace HexagonAtakan.Selectable
{
    public class SelectableObject : MonoBehaviour
    {
        public Transform _childTransform;

        private HexagonController[] _connectedHexagonArray;

        private int _connectedHexagonCount;

        private void Awake()
        {
            _connectedHexagonArray = new HexagonController[3];
            _connectedHexagonCount = 0;
        }


        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.GetComponent<HexagonController>() != null)
            {
                _connectedHexagonArray[_connectedHexagonCount] = coll.GetComponent<HexagonController>();
                _connectedHexagonCount++;
                if (_connectedHexagonCount == 3) _connectedHexagonCount = 0;
            }
        }

        public void AdjustmentChildHexagonActive()
        {
            for (int i = 0; i < _connectedHexagonArray.Length; i++)
            {
                _connectedHexagonArray[i].transform.SetParent(transform);
            }
        }

        public void AdjustmentChildHexagonDeactive()
        {
            for (int i = 0; i < _connectedHexagonArray.Length; i++)
            {
                _connectedHexagonArray[i].transform.SetParent(null);
            }
        }
    }
}
