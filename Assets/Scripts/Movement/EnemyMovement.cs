using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Patroller))]
    [RequireComponent(typeof(Chaser))]
    public class EnemyMovement : MonoBehaviour
    {
        private Chaser _chaser;
        private Patroller _patroler;

        private void Awake()
        {
            _chaser = GetComponent<Chaser>();
            _patroler = GetComponent<Patroller>();

            _chaser.enabled = false;
            _patroler.enabled = false;
        }

        private void Update()
        {
            if (_chaser.CanMove())
            {
                _chaser.enabled = true;
                _patroler.enabled = false;
            }
            else if (_patroler.CanMove())
            {
                _chaser.enabled = false;
                _patroler.enabled = true;
            }
            else
            {
                _chaser.enabled = false;
                _patroler.enabled = false;
            }
        }
    }
}
