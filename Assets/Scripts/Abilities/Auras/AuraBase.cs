using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class AuraBase<TAffect, TEffect> : AbilityBase
        where TAffect : AffectBase<TEffect>, new()
    {
        [SerializeField] private float _scale;
        
        private SpriteRenderer _spriteRenderer;
        private CircleCollider2D _collider;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<CircleCollider2D>();
            _spriteRenderer.enabled = false;

            transform.localScale = transform.localScale * _scale;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_spriteRenderer.enabled && other.TryGetComponent(out TAffect affected))
            {
                var effect = GetEffect();

                if (affected.CanBeAffected(effect))
                {
                    affected.ProcessAffect(effect);
                    ProcessEffect(effect);
                }
            }
        }

        public void EnableAura()
        {
            _spriteRenderer.enabled = true;
            _collider.enabled = true;
        }

        public void DisableAura()
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
        }

        protected abstract TEffect GetEffect();
        protected abstract void ProcessEffect(TEffect effect);
    }
}