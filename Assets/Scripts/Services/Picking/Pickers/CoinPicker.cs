using Assets.Scripts.Services.Storage;

public class CoinPicker : PickerBase<Coin>
{
    public CoinPicker()
        : base(new Wallet())
    {
    }
}