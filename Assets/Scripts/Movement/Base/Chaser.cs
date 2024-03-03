using System;
using UnityEngine;

public class Chaser : MovementBase
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _detectRange;

    private void OnValidate()
    {
        if (_target == null)
        {
            print($"{this.gameObject.name} chaser without target");
        }
    }

    public override bool CanMove()
    {
        return Vector3.Distance(_target.position, transform.position) < _detectRange;
    }

    protected override Vector3 GetNexPosition()
    {
        var moveTo = Vector2.MoveTowards(transform.position, _target.position, GetSpeed() * Time.deltaTime);
        moveTo.y = transform.position.y;

        return moveTo;
    }
}