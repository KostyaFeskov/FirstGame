using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private ClickButtonManager _clickButtonManager;

    public void Awake()
    {
        _clickButtonManager.Initialize();
    }


}
