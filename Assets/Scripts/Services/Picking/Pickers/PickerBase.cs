using Assets.Scripts.Services.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс для описания поднимающего
/// </summary>
/// <typeparam name="T">Тип поднимаемого</typeparam>
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
