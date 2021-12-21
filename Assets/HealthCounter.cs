using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeText;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeText;
    }

    private void ChangeText(float health)
    {
        _text.text = health.ToString();
    }
}
