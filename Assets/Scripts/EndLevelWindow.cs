using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndLevelWindow : MonoBehaviour
{
    [SerializeField] private GameObject _looseLevelWindow;
    [SerializeField] private GameObject _winLevelWindow;
    [SerializeField] private TextMeshProUGUI _endLevelText;
    [SerializeField] private Button _restartButton;

        
    [SerializeField] private Score _score;
        
    public event UnityAction OnRestartClicked;

    public void Initialize()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    public void ShowLooseLevelWindow()
    {
        gameObject.SetActive(true);
        _looseLevelWindow.SetActive(true);
        _winLevelWindow.SetActive(false);
        _endLevelText.text = "Restart";
        _score.looseUpdate();
    }

    public void ShowWinLevelWindow()
    {
        gameObject.SetActive(true);
        _looseLevelWindow.SetActive(false);
        _winLevelWindow.SetActive(true);
        _endLevelText.text = "New game";
        _score.winUpdate();
    }
        
    private void Restart()
    {
        OnRestartClicked?.Invoke();
        gameObject.SetActive(false);
    }

}