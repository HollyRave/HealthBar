using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _healButton;
    [SerializeField] private Button _damageButton;
    
    public event UnityAction HealButtonClicked; 
    public event UnityAction DamageButtonClicked; 


    private void OnEnable()
    {
        _healButton.onClick.AddListener(OnHealButtonClick);
        _damageButton.onClick.AddListener(OnDamageButtonClick);
    }

    private void OnDisable()
    {
        _healButton.onClick.RemoveListener(OnHealButtonClick);
        _damageButton.onClick.RemoveListener(OnDamageButtonClick);
    }

    private void OnHealButtonClick()
    {
        HealButtonClicked?.Invoke();
    }

    private void OnDamageButtonClick()
    {
        DamageButtonClicked?.Invoke();
    }
}
