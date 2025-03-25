using Configs.EnemyConfig;
using Configs.LevelConfigs;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;

    [SerializeField] private EnemiesConfig _enemiesConfig;
    private EnemyData _currentEnemyData;
    private Enemy _currentEnemy;
    private HealtBar _healtBar;
    private LevelData _levelData;
    private int _currentEnemyIndex;
    private Timer _timer;

    public event UnityAction<bool> OnLevelPassed; 

    public void Initialize(HealtBar healtBar, Timer timer) {
        _healtBar = healtBar;
        _timer = timer;
        //SpawnEnemy();
    }

    public void StartLevel(LevelData levelData) {
        _levelData = levelData;
        _currentEnemyIndex = -1;
        
        if (_currentEnemy == null)
        {
            _currentEnemy = Instantiate(_enemiesConfig.EnemyPrefab, _enemiesContainer);
            _currentEnemy.OnDead += SpawnEnemy;
            _currentEnemy.OnDamaged += _healtBar.DecreaseValue;
            //_currentEnemy.OnDead += _healtBar.Hide;
        }
        
        SpawnEnemy();
    }

    public void SpawnEnemy() {
        _currentEnemyIndex++;
        _timer.Stop();

        if (_currentEnemyIndex >= _levelData.Enemies.Count)
        {
            OnLevelPassed?.Invoke(true);
            return;
        }
        var currentEnemy = _levelData.Enemies[_currentEnemyIndex];
        _timer.SetActive(currentEnemy.IsBoss);
        if (currentEnemy.IsBoss)
        {
            _timer.Initialize(currentEnemy.BossTime);
            _timer.OnTimerEnd += () => OnLevelPassed?.Invoke(false);
        }
        
        InitHpBar(currentEnemy.Hp);
        
        _currentEnemyData = _enemiesConfig.GetEnemy(currentEnemy.Id);
        _currentEnemy.Initialize(_currentEnemyData.Sprite, currentEnemy.Hp);
    }

    private void InitHpBar(float health) {
        _healtBar.ShowHpBar();
        _healtBar.SetMaxValue(health);
    }

    public void DamageCurrentEnemy(float damage) {
        _currentEnemy.DoDamage(damage);
    }

    public void SubscribeOnCurrentEnemyDamaged(UnityAction<float> callback) {
        if (_currentEnemy != null)
        {
            _currentEnemy.OnDamaged += callback;
        }
    }
}