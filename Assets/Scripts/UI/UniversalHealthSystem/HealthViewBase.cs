using Assets.Scripts.Status;
using TMPro;
using UnityEngine;

public abstract class HealthViewBase : MonoBehaviour
{
    [SerializeField] private Health _health; 

    protected virtual void Awake()
    {
        _health.CurrentHealthChanged += Render;
    }

    protected abstract void Render();

    protected Health GetHealthModel()
    {
        return _health;
    }

    private void OnDisable()
    {
        _health.CurrentHealthChanged -= Render;
    }
}