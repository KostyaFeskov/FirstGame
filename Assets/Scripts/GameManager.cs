using SceneManagment;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : EntryPoint {
    [SerializeField] private ClickButtonManager _clickButtonManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private HealtBar _healtBar;
    [SerializeField] private Timer _timer;
    [SerializeField] private EndLevelWindow _endLevelWindow;
    
    private const string SCENE_LOADER_TAG = "SceneLoader";

    
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


    public override void Run(SceneEntryParams enterParams) {
        _clickButtonManager.Initialize();
        _enemyManager.Initialize(_healtBar);
        _endLevelWindow.Initialize();
        _timer.Initialize(10f);

        _clickButtonManager.onClicked += () => _enemyManager.DamageCurrentEnemy(1f);
        _endLevelWindow.OnRestartClicked += RestartLevel;
        _enemyManager.OnLevelPassed += OnLevelPassed;
        
        StartLevel();
    }

    private void RestartLevel() {
        var sceneLoader = GameObject.FindWithTag(SCENE_LOADER_TAG).GetComponent<SceneLoader>();
        sceneLoader.LoadGameplayScene();
    }
}
