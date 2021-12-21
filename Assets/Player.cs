using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _healPower;
    [SerializeField] private float _damagePower;
    [SerializeField] private ButtonController _buttonController;

    private float _currentHealth;

    public event UnityAction<float> HealthChanged;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

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

    public void Heal()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _healPower, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damagePower, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}
