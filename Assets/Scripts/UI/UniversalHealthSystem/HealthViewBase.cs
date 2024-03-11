using Assets.Scripts.Status;
using TMPro;
using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Health { get { return _health; } private set { } }

    private void OnEnable()
    {
        _health.CurrentHealthChanged += Render;
    }

    protected abstract void Render();

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= Render;
    }
}