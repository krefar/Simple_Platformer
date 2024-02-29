using Assets.Scripts.Player;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private int _jumpCount = 1;

    private int _currentJump;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private bool _needJump;
    private float _moveOffsetX;

    private void Awake()
    {
        _currentJump = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_moveOffsetX != 0)
        {
            ProcessMove();
        }

        if (_needJump)
        {
            ProcessJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider is BoxCollider2D footCollider)
        {
            if (collision.contacts.Any(contact => contact.normal == Vector2.up || contact.normal == Vector2.down))
            {
                _currentJump = 0;
            }
        }
    }

    public void Jump()
    {
        _needJump = true;
    }
    
    public void Move(float offsetX)
    {
        _moveOffsetX = offsetX;
    }

    private void ProcessJump()
    {
        if (_currentJump++ <= _jumpCount)
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        _needJump = false;
    }

    private void ProcessMove()
    {
        var translateTo = _moveOffsetX * _moveSpeed * Time.deltaTime;
        transform.Translate(translateTo, 0, 0);

        _spriteRenderer.flipX = _moveOffsetX < 0;
        _animator.SetBool(PlayerAnimations.IsRunning, _moveOffsetX != 0);

        _moveOffsetX = 0;
    }
}