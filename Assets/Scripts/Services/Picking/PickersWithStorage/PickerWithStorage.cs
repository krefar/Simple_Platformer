using Assets.Scripts.Services.Storage;
using Unity.VisualScripting;
using UnityEngine;

public class PickerWithStorage<T> : PickerBase<T>
    where T : Object, new()
{
    private ItemsStorage<T> _storage;

    public PickerWithStorage(ItemsStorage<T> storage)
    {
        _storage = storage;
    }

    public override bool Pick(T item)
    {
        _storage.Add(item);

        return true;
    }
}