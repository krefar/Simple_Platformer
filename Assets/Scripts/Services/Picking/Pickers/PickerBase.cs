using Assets.Scripts.Services.Storage;
using UnityEngine;

public abstract class PickerBase<T> : MonoBehaviour
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
}
