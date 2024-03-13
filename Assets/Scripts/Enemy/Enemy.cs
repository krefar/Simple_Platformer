using Assets.Scripts.Status;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour
    {
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.CurrentHealthChanged += EnsureDeath;
        }

        private void EnsureDeath()
        {
            if (_health.IsEmpty())
            {
                Destroy(gameObject);
            }
        }

        private void OnDisable()
        {
            _health.CurrentHealthChanged -= EnsureDeath;
        }
    }
}