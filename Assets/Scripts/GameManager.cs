using Configs.LevelConfigs;
using SceneManagment;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : EntryPoint
{
    [SerializeField] private ClickButtonManager _clickButtonManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private HealtBar _healtBar;
    [SerializeField] private Timer _timer;
    [SerializeField] private EndLevelWindow _endLevelWindow;
    [SerializeField] private LevelsConfig levelsConfig;
    private GameEnterParams _gameEnterParams;


    private const string SCENE_LOADER_TAG = "SceneLoader";


    private void OnLevelPassed(bool isPassed) {
        if (isPassed)
            _endLevelWindow.ShowWinLevelWindow();
        else
            _endLevelWindow.ShowLooseLevelWindow();
    }

    private void StartLevel() {
        var levelData = levelsConfig.GetLevel(_gameEnterParams.Location, _gameEnterParams.Level);
        //_timer.Initialize(10f);
        //_timer.OnTimerEnd += _endLevelWindow.ShowLooseLevelWindow;
        //_timer.Play();
        _enemyManager.SpawnEnemy();
    }


    public override void Run(SceneEntryParams enterParams) {
        if (enterParams is not GameEnterParams gameEnterParams)
        {
            Debug.LogError("Game Enter Params are invalid");
            return;
        }

        _gameEnterParams = gameEnterParams;


        _clickButtonManager.Initialize();
        _enemyManager.Initialize(_healtBar, _timer);
        _endLevelWindow.Initialize();
        //_timer.Initialize(10f);

        _clickButtonManager.onClicked += () => _enemyManager.DamageCurrentEnemy(1f);
        _endLevelWindow.OnRestartClicked += RestartLevel;
        _enemyManager.OnLevelPassed += OnLevelPassed;

        StartLevel();
    }


    private void RestartLevel() {
        var sceneLoader = GameObject.FindWithTag(SCENE_LOADER_TAG).GetComponent<SceneLoader>();
        sceneLoader.LoadGameplayScene(_gameEnterParams);
    }
}