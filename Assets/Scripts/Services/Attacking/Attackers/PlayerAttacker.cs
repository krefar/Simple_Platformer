using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    public class PlayerAttacker : AttackerBase<PlayerDamageReciever>
    {
        protected override int Damage => 10;

        protected override bool IsValidCollider(Collider2D collision)
        {
            var isPlayer = collision.TryGetComponent(out Player player);

            return base.IsValidCollider(collision) && isPlayer && collision is not BoxCollider2D;
        }
    }
}