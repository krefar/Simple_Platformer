using Assets.Scripts.Status;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = _health.GetMaxHealh();
        _slider.value = _health.GetCurrentHealh();
    }

    private void Update()
    {
        _slider.value = _health.GetCurrentHealh();
    }
}