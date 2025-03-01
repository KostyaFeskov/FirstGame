using UnityEngine;
using UnityEngine.Serialization;

public class ClickButtonManager : MonoBehaviour
{
    [SerializeField] private ClickButton clickButton;
    [SerializeField] private ClickButtonConfig _buttonConfig;

    
    public void Initialize()
    {
        clickButton.Initialize(_buttonConfig.DefaultSprite, _buttonConfig.ButtonCollors);
        clickButton.SubscribeOnClick(ShowClick);
    }

    private void ShowClick()
    {
        Debug.Log("Click");
    }
}
