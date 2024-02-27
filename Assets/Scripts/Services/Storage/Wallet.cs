using UnityEngine;

namespace Assets.Scripts.Services.Storage
{
    internal class Wallet : ItemsStorage<Coin>
    {
        public override string Name => "Wallet";

        public int GetAmount()
        {
            var result = 0;

            var allCoins = this.GetAllItems();

            foreach ( var coin in allCoins)
            {
                result += coin.Value;
            }

            return result;
        }
    }
}
