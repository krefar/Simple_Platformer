using Assets.Scripts.Status;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthView : HealthViewBase
{
    private TMP_Text _tmpText;

    private void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
        _tmpText.text = GetHealthText();
    }

    protected override void Render()
    {
        _tmpText.text = GetHealthText();
    }

    private string GetHealthText()
    {
        return $"{Health.GetCurrentHealh()}/{Health.GetMaxHealh()}";
    }
}