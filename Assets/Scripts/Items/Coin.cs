using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int MaxValue = 50;
    private const int MinValue = 1;

    private int _value;

    private void Awake()
    {
        _value = Random.Range(MinValue, MaxValue);
    }

    public int GetValue()
    {
        return _value;
    }
}