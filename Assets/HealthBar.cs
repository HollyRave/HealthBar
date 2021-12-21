using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += StartChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= StartChangeValue;
    }

    private void StartChangeValue(float resultHealth)
    {
        StartCoroutine(ChangeValue(resultHealth));
    }

    private IEnumerator ChangeValue(float resultHealth)
    {
        while (_slider.value != resultHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, resultHealth, _animationDuration * Time.deltaTime);
            yield return null;
        }
    }
}
