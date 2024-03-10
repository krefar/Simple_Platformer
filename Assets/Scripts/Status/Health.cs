using System;
using UnityEngine;

namespace Assets.Scripts.Status
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        
        private int _currentHealth;

        public event Action CurrentHealthChanged;

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

            CurrentHealthChanged?.Invoke();
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

            CurrentHealthChanged?.Invoke();
        }

        public bool IsFull()
        {
            return _currentHealth == _maxHealth;
        }

        public int GetCurrentHealh()
        {
            return _currentHealth;
        }
        
        public int GetMaxHealh()
        {
            return _maxHealth;
        }
    }
}
