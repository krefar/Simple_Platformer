using Assets.Scripts.Status;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmothSliderHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _speed;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = _health.GetMaxHealh();
        _slider.value = _health.GetCurrentHealh();
    }

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _health.GetCurrentHealh(), _speed * Time.deltaTime);
    }
}