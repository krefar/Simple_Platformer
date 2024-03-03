using UnityEngine;

namespace Assets.Scripts.Services.Attacking
{
    [RequireComponent(typeof(Player))]
    public class PlayerDamageReciever : DamageRecieverBase
    {
        protected override string RecieverTitle => "Player";

        protected override int ModifyDamage(int damage)
        {
            return damage / 2;
        }
    }
}