using Assets.Scripts.Services.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ����� ��� �������� ������������
/// </summary>
/// <typeparam name="T">��� ������������</typeparam>
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
