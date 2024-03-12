using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    public class PlayerAttacker : AttackerBase<PlayerDamageReciever>
    {
        protected override int Damage => 30;

        protected override bool IsValidCollider(Collider2D other)
        {
            var isPlayer = other.TryGetComponent(out Player player);

            return base.IsValidCollider(other) && isPlayer && other is not BoxCollider2D;
        }
    }
}