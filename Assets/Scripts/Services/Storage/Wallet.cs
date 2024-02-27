using Assets.Scripts.Services.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
