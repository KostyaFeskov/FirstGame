using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {
    [SerializeField] private ClickButtonManager _clickButtonManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private HealtBar _healtBar;
    [SerializeField] private Timer _timer;
    [SerializeField] private EndLevelWindow _endLevelWindow;


    public void Awake()
    {
        _clickButtonManager.Initialize();
        _enemyManager.Initialize(_healtBar);
        _endLevelWindow.Initialize();
        _timer.Initialize(10f);

        _clickButtonManager.onClicked += () => _enemyManager.DamageCurrentEnemy(1f);
        _endLevelWindow.OnRestartClicked += StartLevel;
        _enemyManager.OnLevelPassed += OnLevelPassed;
        
        StartLevel();
    }

    private void OnLevelPassed()
    {
            _endLevelWindow.ShowWinLevelWindow();
            _timer.Stop();
    }

    private void StartLevel()
    {
        _timer.Initialize(10f);
        _timer.OnTimerEnd += _endLevelWindow.ShowLooseLevelWindow;
        _timer.Play();
        _enemyManager.SpawnEnemy();
    }



}
