using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;
    public event UnityAction<float> CheckStartCountHealth;

    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _healPower;
    [SerializeField] private float _damagePower;
    [SerializeField] private ButtonController _buttonController;

    private float _currentHealth;
    private float _resultHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        CheckStartCountHealth?.Invoke(_currentHealth);
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
        _resultHealth = Mathf.Clamp(_currentHealth + _healPower, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_resultHealth);

        _currentHealth = _resultHealth;
    }

    private void TakeDamage()
    {
        _resultHealth = Mathf.Clamp(_currentHealth - _damagePower, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_resultHealth);

        _currentHealth = _resultHealth;
    }
}
