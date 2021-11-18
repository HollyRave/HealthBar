using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            currentHealth = _maxHealth;
        }
        else
        {
            currentHealth += _healPower;
        }
        Debug.Log("Значение слайдера до изменения - " + _slider.value);
        _slider.value = Mathf.MoveTowards(_slider.value, resultHealth, _animationDuration * Time.deltaTime);
        Debug.Log("Значение слайдера после изменения - " + _slider.value);

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
        Debug.Log("Значение слайдера до изменения - " + _slider.value);
        _slider.value = Mathf.MoveTowards(_slider.value, resultHealth, _animationDuration * Time.deltaTime);
        Debug.Log("Значение слайдера после изменения - " + _slider.value);
        currentHealth = resultHealth;
    }
}
