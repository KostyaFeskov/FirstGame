using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform _enemiesContainer;

        [SerializeField] private EnemiesConfig _enemiesConfig;
        private EnemyData _currentEnemyData;
        private Enemy _currentEnemy;
        private HealtBar _healtBar;

        public void Initialize(HealtBar healtBar)
        {
            _healtBar = healtBar;
            SpawnEnemy();
        }

        public void SpawnEnemy()
        {
            _currentEnemyData = _enemiesConfig.Enemies[0];
            _currentEnemy = Instantiate(_enemiesConfig.EnemyPrefab, _enemiesContainer);
            _currentEnemy.Initialize(_currentEnemyData);

            InitHpBar();
        }

        private void InitHpBar()
        {
            _healtBar.ShowHpBar();
            _healtBar.SetMaxValue(_currentEnemyData.Health);
            _currentEnemy.OnDamaged += _healtBar.DecreaseValue;
            _currentEnemy.OnDead += _healtBar.Hide;
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
}