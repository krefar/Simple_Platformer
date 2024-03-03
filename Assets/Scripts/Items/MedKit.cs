using UnityEngine;

public class MedKit : MonoBehaviour
{
    private const int DefaultHealAmount = 75;

    private int _healAmount;

    private void Awake()
    {
        _healAmount = DefaultHealAmount;
    }

    public int GetHealAmount()
    {
        return _healAmount;
    }
}