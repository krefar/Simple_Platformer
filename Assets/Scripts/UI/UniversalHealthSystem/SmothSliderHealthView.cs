using Assets.Scripts.Status;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SmothSliderHealthView : SliderHealthView
{
    [SerializeField] private float _speed;

    protected override void Render()
    {
        StartCoroutine(RenderSmooth());
    }

    private IEnumerator RenderSmooth()
    {
        var wait = new WaitForEndOfFrame();

        while (Slider.value != Health.GetCurrentHealh())
        {
            Slider.value = Mathf.MoveTowards(Slider.value, Health.GetCurrentHealh(), _speed * Time.deltaTime);

            yield return wait;
        }
    }
}