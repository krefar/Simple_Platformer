using Assets.Scripts.Status;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    [RequireComponent(typeof(Health))]
    public class VampiricAffect : AffectBase<VampiricEffect>
    {
        [SerializeField] float _speed = VampiricConst.Speed;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public override void ProcessAffect(VampiricEffect effect)
        {
            var currentHealth = _health.GetCurrentHealh();
            var healthTo = Mathf.MoveTowards(currentHealth, currentHealth - effect.HealthAmont, _speed);

            StartCoroutine(DecreaseHealthTo(healthTo));
        }

        private IEnumerator DecreaseHealthTo(float healthTo)
        {
            var wait = new WaitForEndOfFrame();

            while (_health.GetCurrentHealh() > 0 && _health.GetCurrentHealh() != healthTo)
            {
                _health.Decrease((int)(_health.GetCurrentHealh() - healthTo));

                yield return wait;
            }
        }

        public override bool CanBeAffected(VampiricEffect effect)
        {
            return !_health.IsEmpty();
        }
    }
}