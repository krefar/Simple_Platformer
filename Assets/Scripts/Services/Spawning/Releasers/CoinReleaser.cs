using UnityEngine;

namespace Assets.Scripts.Services.Spawning
{
    public class CoinReleaser : ReleaserBase<Coin>
    {
        protected override bool NeedRelease(Collider2D collision)
        {
            var isCoin = collision.TryGetComponent(out Coin coin);

            return isCoin;
        }
    }
}