using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HexagonAtakan.Manager;

namespace HexagonAtakan.Selectable
{

    public class SelectableObjectController : MonoBehaviour
    {
        [SerializeField] private SearchManager _searchManager;
        [SerializeField] private SelectableObjectControllerSettings _selectableControllerSettings;

        private WaitForSeconds _rotationDelay;
        private Quaternion _targetRot;

        private bool _rotating;
        public int _rotateCount;
        public bool _foundedHexGroup;



        private void Start()
        {
            _rotationDelay = new WaitForSeconds(_selectableControllerSettings.DelayBetweenRotations);
            _targetRot = transform.localRotation;
            _rotating = false;
            _rotateCount = 0;
            _foundedHexGroup = false;
            _searchManager = GameObject.Find("SearchManager").GetComponent<SearchManager>();
        }

        //Start rotate with angle
        public void StartRotate(float angle)
        {
            if (_rotating == false)
            {
                _rotating = true;
                StartCoroutine(Rotate(_selectableControllerSettings.RotationTime, angle));
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

            if (angle == 120.0f)
            {
                transform.GetComponent<SelectableObject>().ChildHexagonsRotateRight();
            }
            else if (angle == -120.0f)
            {
                transform.GetComponent<SelectableObject>().ChildHexagonsRotateLeft();
            }

            //Mean if founded group stop rotation
            _searchManager.SearchSceneHexagonGroup();
            if (_searchManager.foundedHex == true)
            {
                _rotateCount = 3;
            }
            else
            {
                //Add rotate count
                _rotateCount++;
            }
        }


    }
}
