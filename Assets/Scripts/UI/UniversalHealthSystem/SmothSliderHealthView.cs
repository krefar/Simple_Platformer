using Assets.Scripts.Status;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmothSliderHealthView : SliderHealthView
{
    [SerializeField] private float _speed;

    private Slider _baseSlider;
    private Health _baseHealthModel;

    protected override void Awake()
    {
        base.Awake();

        _baseSlider = GetSlider();
        _baseHealthModel = GetHealthModel();
    }

    protected override void Render()
    {
        StartCoroutine(RenderSmooth());
    }

    private IEnumerator RenderSmooth()
    {
        var wait = new WaitForEndOfFrame();

        while (_baseSlider.value != _baseHealthModel.GetCurrentHealh())
        {
            _baseSlider.value = Mathf.MoveTowards(_baseSlider.value, _baseHealthModel.GetCurrentHealh(), _speed * Time.deltaTime);

            yield return wait;
        }
    }
}