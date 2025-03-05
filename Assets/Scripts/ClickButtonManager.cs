using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ClickButtonManager : MonoBehaviour
{
    [SerializeField] private ClickButton clickButton;
    [SerializeField] private ClickButtonConfig _buttonConfig;

    public event UnityAction onClicked;
    
    public void Initialize()
    {
        clickButton.Initialize(_buttonConfig.DefaultSprite, _buttonConfig.ButtonCollors);
        clickButton.SubscribeOnClick(() => onClicked?.Invoke());
    }

    private void ShowClick()
    {
        Debug.Log("Click");
    }
}
