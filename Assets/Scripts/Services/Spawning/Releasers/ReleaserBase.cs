using UnityEngine;

namespace Assets.Scripts.Services.Spawning
{
    public abstract class ReleaserBase<T> : MonoBehaviour
        where T : Object, new()
    {
        [SerializeField] private SpawnerBase<T> _spawner;
        protected abstract bool NeedRelease(Collider2D collision);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out T target) && NeedRelease(collision))
            {
                _spawner.Release(target);
            }
        }
    }
}