using Assets.Scripts.Status;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthView : HealthViewBase
{
    private Slider _slider;
    private Health _healthModel;

    protected override void Awake()
    {
        base.Awake();

        _healthModel = GetHealthModel();
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = _healthModel.GetMaxHealh();
        _slider.value = _healthModel.GetCurrentHealh();
    }

    protected Slider GetSlider()
    {
        return _slider;
    }

    protected override void Render()
    {
        _slider.value = _healthModel.GetCurrentHealh();
    }
}