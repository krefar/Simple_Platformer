using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyDamageReciever : DamageRecieverBase
    {
        protected override string RecieverTitle => name;

        protected override int ModifyDamage(int damage)
        {
            return damage * 2;
        }
    }
}