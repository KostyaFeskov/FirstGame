using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _enemiesContainer;

    [SerializeField] private EnemiesConfig _enemiesConfig;
    private EnemyData _currentEnemyData;
    private Enemy _currentEnemy;
    private HealtBar _healtBar;

    public event UnityAction OnLevelPassed;

    public void Initialize(HealtBar healtBar)
    {
        _healtBar = healtBar;
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        _currentEnemyData = _enemiesConfig.Enemies[0];
        InitHpBar();
        if (_currentEnemy == null)
        {
            _currentEnemy = Instantiate(_enemiesConfig.EnemyPrefab, _enemiesContainer);    
            _currentEnemy.OnDead += () => OnLevelPassed?.Invoke();
            _currentEnemy.OnDamaged += _healtBar.DecreaseValue;
            _currentEnemy.OnDead += _healtBar.Hide;
        }
        _currentEnemy.Initialize(_currentEnemyData);

    }

    private void InitHpBar()
    {
        _healtBar.ShowHpBar();
        _healtBar.SetMaxValue(_currentEnemyData.Health);

    }

    public void DamageCurrentEnemy(float damage)
    {
        _currentEnemy.DoDamage(damage);
    }

    public void SubscribeOnCurrentEnemyDamaged(UnityAction<float> callback)
    {
        if (_currentEnemy != null) 
        {
            _currentEnemy.OnDamaged += callback;
        }
    }
}