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

        //Start rotate with angle
        public void StartRotate(float angle)
        {
            if (_rotating == false)
            {
                _rotating = true;
                StartCoroutine(Rotate(_selectableControllerSettings.RotationTime,angle));
            }
        }


        private IEnumerator Rotate(float rotateTime, float angle)
        {
            var startRot = transform.localRotation;
            _targetRot *= Quaternion.AngleAxis(angle, Vector3.back);

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
