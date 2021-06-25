using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HexagonAtakan.Hexagon
{
    public class HexagonController : MonoBehaviour
    {
        [SerializeField] private HexagonControllerSettings _hexagonControllerSettings;


        [SerializeField] private int _xPosition;
        public int XPosition { get { return _xPosition; } }

        [SerializeField] private int _yPosition;
        public int YPosition { get { return _yPosition; } }

        [SerializeField] private Color _hexColor;
        public Color HexColor { get { return _hexColor; } set { _hexColor = value; } }

        public Vector2 GetArrayPosition()
        {
            return new Vector2(XPosition, YPosition);
        }

        public void SetArrayPosition(int x, int y)
        {
            _xPosition = x;
            _yPosition = y;
        }

        private void Update()
        {
            transform.GetComponent<SpriteRenderer>().color = HexColor;

            if (Input.GetKeyDown(KeyCode.L))
            {
                StartLerpPositionIEnumerator(new Vector2(6, 4));
            }
        }


        public void StartLerpPositionIEnumerator(Vector2 targetPosition)
        {
            StartCoroutine(LerpPosition(targetPosition));
        }

        IEnumerator LerpPosition(Vector2 targetPosition)
        {
            float time = 0;
            Vector2 startPosition = transform.position;

            while (time < _hexagonControllerSettings.HexagonPositionTime)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, time / _hexagonControllerSettings.HexagonPositionTime);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}