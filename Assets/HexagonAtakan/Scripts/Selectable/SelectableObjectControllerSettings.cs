using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HexagonAtakan.Selectable
{
    [CreateAssetMenu(menuName = "HexagonAtakan/Select/Selectable Speed Settings")]
    public class SelectableObjectControllerSettings : ScriptableObject
    {
        [SerializeField] private float _rotationTime = 0.25f;
        public float RotationTime { get { return _rotationTime; } }


        [SerializeField] private float _delayBetweenRotations = 1;
        public float DelayBetweenRotations { get { return _delayBetweenRotations; } }

    }
}
