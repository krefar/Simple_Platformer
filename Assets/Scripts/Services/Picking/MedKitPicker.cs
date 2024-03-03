using Assets.Scripts.Services.Storage;
using Assets.Scripts.Status;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class MedKitPicker : PickerBase<MedKit>
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public override bool Pick(MedKit medKit)
    {
        if (_health.IsFull())
        {
            return false;
        }

        _health.Increase(medKit.GetHealAmount());

        return true;
    }
}