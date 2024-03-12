using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    public abstract class AttackerBase<T> : MonoBehaviour
        where T : DamageRecieverBase, new()
    {
        protected abstract int Damage { get; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsValidCollider(other) && other.TryGetComponent(out T damageReciever))
            {
                damageReciever.TakeDamage(Damage);
            }
        }

        protected virtual bool IsValidCollider(Collider2D other)
        {
            return true;
        }
    }
}