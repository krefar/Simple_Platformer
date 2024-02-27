using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _value;

    public int Value { get => _value; }

    private void Awake()
    {
        _value = Random.Range(0, 50);
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