using Assets.Scripts.Services.Storage;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PickerBase<T> : MonoBehaviour
    where T : Object, new()
{
    private ItemsStorage<T> _storage;

    public PickerBase(ItemsStorage<T> storage)
    {
        _storage = storage;
    }

    public void Pick(T item)
    {
        _storage.Add(item);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T itemToPick))
        {
            Pick(itemToPick);

            var itemGameObject = itemToPick.GameObject();
            itemGameObject.SetActive(false);
        }
    }
}