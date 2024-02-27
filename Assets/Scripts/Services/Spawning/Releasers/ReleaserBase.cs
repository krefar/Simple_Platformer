using UnityEngine;

namespace Assets.Scripts.Services.Spawning
{
    public class ReleaserBase<T> : MonoBehaviour
        where T : Object, new()
    {
        [SerializeField] private SpawnerBase<T> _spawner;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out T target))
            {
                _spawner.Release(target);
            }
        }
    }
}