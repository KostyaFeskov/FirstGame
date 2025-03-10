using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _winScore;
        private int _loseScore;

        public void Initialize(int win, int lose)
        {
            _winScore = win;
            _loseScore = lose;
        }

        public void winUpdate()
        {
            _winScore++;
        }

        public void looseUpdate()
        {
            _loseScore++;
        }

        private void Update()
        {
            _scoreText.text = $"Win count: {_winScore.ToString()} \n Loose count: {_loseScore.ToString()}";
        }
    }
}