using Assets.Scripts.Status;
using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    [RequireComponent(typeof(Health))]
    public abstract class DamageRecieverBase : MonoBehaviour
    {
        private Health _health;

        protected abstract string RecieverTitle { get; }

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void TakeDamage(int damage)
        {
            var modifiedDamage = ModifyDamage(damage);
            print($"{RecieverTitle} take {modifiedDamage} damage");

            _health.Decrease(modifiedDamage);
        }

        protected virtual int ModifyDamage(int damage)
        {
            return damage;
        }
    }
}
