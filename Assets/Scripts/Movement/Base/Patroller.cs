using UnityEngine;

public class Patroller : MovementBase
{
    private int _currentPointIndex = 0;

    [SerializeField] private Transform[] _points;

    private void OnValidate()
    {
        if (_points == null || _points.Length == 0)
        {
            print($"{this.gameObject.name} patroller without waypoints");
        }
    }

    public override bool CanMove()
    {
        return _points.Length > 0;
    }

    protected override void PrepareMoveData()
    {
        if (transform.position == _points[_currentPointIndex].position)
        {
            _currentPointIndex = ++_currentPointIndex % _points.Length;
        }
    }

    protected override Vector3 GetNexPosition()
    {
        return Vector2.MoveTowards(transform.position, _points[_currentPointIndex].position, GetSpeed() * Time.deltaTime);
    }
}
