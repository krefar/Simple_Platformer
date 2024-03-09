using Assets.Scripts.Status;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextHealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.text = $"{_health.GetCurrentHealh()}/{_health.GetMaxHealh()}";
    }
}