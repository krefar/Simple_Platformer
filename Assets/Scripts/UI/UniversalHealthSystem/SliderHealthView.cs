using Assets.Scripts.Status;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthView : HealthViewBase
{
    protected Slider Slider { get; private set; }

    protected virtual void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    private void Start()
    {
        Slider.minValue = 0;
        Slider.maxValue = Health.GetMaxHealh();
        Slider.value = Health.GetCurrentHealh();
    }

    protected override void Render()
    {
        Slider.value = Health.GetCurrentHealh();
    }
}