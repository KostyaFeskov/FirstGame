using System.Collections.Generic;
using UnityEngine;

namespace Configs.EnemyConfig
{
    [CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configs/EnemiesConfig")]
    public class EnemiesConfig : ScriptableObject
    {
        public List<EnemyData> Enemies;
        public Enemy EnemyPrefab;

        public EnemyData GetEnemy(string id) {
            foreach (var enemyData in Enemies)
            {
                if (enemyData.Id == id) return enemyData;
            }

            return default;
        } 
    }
}