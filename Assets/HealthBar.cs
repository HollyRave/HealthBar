using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _healPower;
    [SerializeField] private float _damagePower;
    [SerializeField] private float _animationDuration;
    [SerializeField] private ButtonController _buttonController;

    [SerializeField] private Slider _slider;

    private float currentHealth;
    private float resultHealth;

    private void OnEnable()
    {
        _buttonController.HealButtonClicked += Heal;
        _buttonController.DamageButtonClicked += TakeDamage;
    }

    private void OnDisable()
    {
        _buttonController.HealButtonClicked -= Heal;
        _buttonController.DamageButtonClicked -= TakeDamage;
    }

    private void Start()
    {
        currentHealth = _slider.maxValue;
    }

    public void Heal()
    {
        if (currentHealth + _healPower > _maxHealth || currentHealth + _healPower == _maxHealth)
        {
            resultHealth = _maxHealth;
        }
        else
        {
            resultHealth = currentHealth += _healPower;
        }

        StartCoroutine(ChangeValue());
        
        currentHealth = resultHealth;
    }

    private void TakeDamage()
    {
        if (currentHealth - _damagePower < _minHealth || currentHealth - _damagePower == _minHealth)
        {
            resultHealth = _minHealth;
        }
        else
        {
            resultHealth = currentHealth - _damagePower;
        }

        StartCoroutine(ChangeValue());
        
        currentHealth = resultHealth;
    }

    private IEnumerator ChangeValue()
    {
        
        while (_slider.value != resultHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, resultHealth, _animationDuration * Time.deltaTime);
            yield return null;
        }

        yield return null;
    }
}
