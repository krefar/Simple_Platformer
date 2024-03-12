using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    public class EnemyAttacker : AttackerBase<EnemyDamageReciever>
    {
        protected override int Damage => 10;
    }
}