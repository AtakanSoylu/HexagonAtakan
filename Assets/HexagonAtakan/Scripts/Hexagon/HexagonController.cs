using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HexagonAtakan.Hexagon
{
    public class HexagonController : MonoBehaviour
    {
        [SerializeField] private int _xPosition;
        public int XPosition { get { return _xPosition; } }

        [SerializeField] private int _yPosition;
        public int YPosition { get { return _yPosition; } }

        [SerializeField] private Color _hexColor;
        public Color HexColor { get { return _hexColor; } set { _hexColor = value; } }

        public void SetPosition(int x,int y)
        {
            _xPosition = x;
            _yPosition = y;
        }

        private void Update()
        {
            transform.GetComponent<SpriteRenderer>().color = HexColor;
        }


    }
}