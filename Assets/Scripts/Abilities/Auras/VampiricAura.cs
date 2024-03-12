using Assets.Scripts.Status;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Health))]
    public class VampiricAura : AuraBase<VampiricAffect, VampiricEffect>
    {
        [SerializeField] int _healthAmount;
        [SerializeField] float _speed = VampiricConst.Speed;

        [SerializeField] private Health _health;

        protected override VampiricEffect GetEffect()
        {
            return new VampiricEffect(_healthAmount);
        }

        protected override void ProcessEffect(VampiricEffect effect)
        {
            var currentHealth = _health.GetCurrentHealh();
            var healthTo = Mathf.MoveTowards(currentHealth, currentHealth + effect.HealthAmont, _speed);

            StartCoroutine(IncreaseHealthTo(healthTo));
        }

        private IEnumerator IncreaseHealthTo(float healthTo)
        {
            var wait = new WaitForEndOfFrame();

            while (_health.GetCurrentHealh() != healthTo && !_health.IsFull())
            {
                _health.Increase((int)(healthTo - _health.GetCurrentHealh()));

                yield return wait;
            }
        }
    }
}