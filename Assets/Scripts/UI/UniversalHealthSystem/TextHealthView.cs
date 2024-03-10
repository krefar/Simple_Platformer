using Assets.Scripts.Status;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthView : HealthViewBase
{
    private TMP_Text _tmpText;
    private Health _healthModel;

    protected override void Awake()
    {
        base.Awake();

        _tmpText = GetComponent<TMP_Text>();
        _healthModel = GetHealthModel();
        _tmpText.text = GetHealthText();
    }

    protected override void Render()
    {
        _tmpText.text = GetHealthText();
    }

    private string GetHealthText()
    {
        return $"{_healthModel.GetCurrentHealh()}/{_healthModel.GetMaxHealh()}";
}
}