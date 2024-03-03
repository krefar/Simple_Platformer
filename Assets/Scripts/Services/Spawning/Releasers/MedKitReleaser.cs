using Assets.Scripts.Status;
using UnityEngine;

namespace Assets.Scripts.Services.Spawning
{
    [RequireComponent(typeof(Health))]
    public class MedKitReleaser : ReleaserBase<MedKit>
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        protected override bool NeedRelease(Collider2D collision)
        {
            var isMedKit = collision.TryGetComponent(out MedKit medKit);

            return isMedKit && !_health.IsFull();
        }
    }
}