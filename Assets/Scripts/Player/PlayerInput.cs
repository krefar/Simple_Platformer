using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.Jump();
        }

        var offsetX = Input.GetAxis(Horizontal);

        _player.Move(offsetX);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _player.CastVampiricAura();
        }
    }
}