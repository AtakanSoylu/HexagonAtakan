using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private float _score;
        public float Score { get { return _score; } }

        [SerializeField] private TextMeshProUGUI _scoreTextUI;
        public TextMeshProUGUI ScoreTextUI { get { return _scoreTextUI; } }

        private void Start()
        {
            _score = 0;
        }


        private void Update()
        {
            _scoreTextUI.text = _score.ToString();
        }

        public void IncreaseScore(int brokenHexagonCount)
        {
            _score += brokenHexagonCount * 5;
        }
    }
}
