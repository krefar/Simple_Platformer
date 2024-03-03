using Unity.VisualScripting;
using UnityEngine;

public abstract class PickerBase<T> : MonoBehaviour
    where T : Object, new()
{
    public abstract bool Pick(T item);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T itemToPick))
        {
            if (Pick(itemToPick))
            {
                var itemGameObject = itemToPick.GameObject();
                itemGameObject.SetActive(false);
            }
        }
    }
}