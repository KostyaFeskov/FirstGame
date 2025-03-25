using System;

namespace Configs.LevelConfigs {
    [Serializable]
    public struct EnemySpawnData {
        public string Id;
        public float Hp;
        public bool IsBoss;
        public float BossTime;
    }
}