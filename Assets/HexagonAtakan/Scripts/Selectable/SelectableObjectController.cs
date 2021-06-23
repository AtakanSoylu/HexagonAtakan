using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexagonAtakan.Manager;

namespace HexagonAtakan.Selectable
{
    public class SelectableObjectController : MonoBehaviour
    {

        [SerializeField] private SelectableObjectControllerSettings _selectableControllerSettings;

        private WaitForSeconds _rotationDelay;
        private Quaternion _targetRot;

        private bool _rotating;

        private void Start()
        {            
            _rotationDelay = new WaitForSeconds(_selectableControllerSettings.DelayBetweenRotations);
            _targetRot = transform.localRotation;
        }


        public void StartRotate()
        {
            if (_rotating == false)
            {
                _rotating = true;
                StartCoroutine(Rotate(_selectableControllerSettings.RotationTime));
            }
        }


        private IEnumerator Rotate(float rotateTime)
        {
            var startRot = transform.localRotation;
            _targetRot *= Quaternion.AngleAxis(120, Vector3.back);

            float time = 0;

            while (time <= 1)
            {
                transform.localRotation = Quaternion.Lerp(startRot, _targetRot, time);
                time += Time.deltaTime / rotateTime;
                yield return null;
            }

            transform.localRotation = _targetRot;
            
            yield return _rotationDelay;

            _rotating = false;
        }
    }
}
