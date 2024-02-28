using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int MaxValue = 50;
    private const int MinValue = 1;

    private int _value;

    public int Value { get => _value; }

    private void Awake()
    {
        _value = Random.Range(MinValue, MaxValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinPicker coinPicker))
        {
            coinPicker.Pick(this);
            gameObject.SetActive(false);
        }
    }
}