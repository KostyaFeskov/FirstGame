using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private ClickButtonManager _clickButtonManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private HealtBar _healtBar;

    public void Awake()
    {
        _clickButtonManager.Initialize();
        _enemyManager.Initialize(_healtBar);

        _clickButtonManager.onClicked += () => _enemyManager.DamageCurrentEnemy(1f);
    }


}
