using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CanMove())
        {
            PrepareMoveData();

            var nextPosition = GetNexPosition();
            var offsetX = nextPosition.x - transform.position.x;

            transform.position = nextPosition;

            _spriteRenderer.flipX = offsetX < 0;
        }
    }

    public abstract bool CanMove();

    protected float GetSpeed()
    {
        return _speed;
    }
    
    protected abstract Vector3 GetNexPosition();

    protected virtual void PrepareMoveData()
    {
    }
}