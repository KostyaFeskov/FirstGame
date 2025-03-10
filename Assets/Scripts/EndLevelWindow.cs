using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EndLevelWindow : MonoBehaviour
    {
        [SerializeField] private GameObject _looseLevelWindow;
        [SerializeField] private GameObject _winLevelWindow;
        
        [SerializeField] private Button _loseRestartButton;
        [SerializeField] private Button _winRestartButton;
        
        [SerializeField] private Score _score;
        
        public event UnityAction OnRestartClicked;

        public void Initialize()
        {
            _loseRestartButton.onClick.AddListener(Restart);
            _winRestartButton.onClick.AddListener(Restart);
        }

        public void ShowLooseLevelWindow()
        {
            gameObject.SetActive(true);
            _looseLevelWindow.SetActive(true);
            _winLevelWindow.SetActive(false);
            _score.looseUpdate();
        }

        public void ShowWinLevelWindow()
        {
            gameObject.SetActive(true);
            _looseLevelWindow.SetActive(false);
            _winLevelWindow.SetActive(true);
            _score.winUpdate();
        }
        
        private void Restart()
        {
            OnRestartClicked?.Invoke();
            gameObject.SetActive(false);
        }

    }
}