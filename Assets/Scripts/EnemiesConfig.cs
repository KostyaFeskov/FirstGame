using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configs/EnemiesConfig")]
public class EnemiesConfig: ScriptableObject
{
    public List<EnemyData> Enemies;
    public Enemy EnemyPrefab;
}