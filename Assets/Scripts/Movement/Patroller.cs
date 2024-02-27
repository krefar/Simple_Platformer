using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(SpriteRenderer))]
public class Patroller : MonoBehaviour
{
    private int _currentPointIndex = 0;

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private void OnValidate()
    {
        if (_points.Length == 0)
        {
            print($"{this.gameObject.name} patroller without waypoints");
        }
    }

    private void Update()
    {
        if (_points.Length > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        if (transform.position == _points[_currentPointIndex].position)
        {
            _currentPointIndex = ++_currentPointIndex % _points.Length;
        }

        var nextPosition = Vector2.MoveTowards(transform.position, _points[_currentPointIndex].position, _speed * Time.deltaTime);
        var offsetX = nextPosition.x - transform.position.x;
        transform.position = nextPosition;

        EnsureSpriteRenderer(offsetX);
    }

    private void EnsureSpriteRenderer(float offsetX)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = offsetX < 0;
    }
}
