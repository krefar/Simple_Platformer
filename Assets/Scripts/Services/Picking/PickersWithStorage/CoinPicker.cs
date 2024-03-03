using Assets.Scripts.Services.Storage;

public class CoinPicker : PickerWithStorage<Coin>
{
    public CoinPicker()
        : base(new Wallet())
    {
    }
}