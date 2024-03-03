using System;
using UnityEngine;

namespace Assets.Scripts.Status
{
    internal class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void Increase(int amount)
        {
            _currentHealth += amount;

            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }

        public void Decrease(int amount)
        {
            if (amount > _currentHealth)
            {
                _currentHealth = 0;
            }
            else
            {
                _currentHealth -= amount;
            }
        }

        public bool IsFull()
        {
            return _currentHealth == _maxHealth;
        }
    }
}
