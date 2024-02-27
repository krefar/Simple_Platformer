using Assets.Scripts.Player;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private const string _horizontal = "Horizontal";
    private int _currentJumpCount;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private int _jumpCount = 1;

    private void Awake()
    {
        _currentJumpCount = _jumpCount;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider is BoxCollider2D footCollider)
        {
            if (collision.contacts.Any(contact => contact.normal == Vector2.up || contact.normal == Vector2.down))
            {
                _currentJumpCount = _jumpCount;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentJumpCount-- > 0)
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        var offsetX = Input.GetAxis(_horizontal) * _moveSpeed * Time.deltaTime;
        transform.Translate(offsetX, 0, 0);

        EnsureAnimator(offsetX);
        EnsureSpriteRenderer(offsetX);
    }

    private void EnsureSpriteRenderer(float offsetX)
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = offsetX < 0;
    }

    private void EnsureAnimator(float moveX)
    {
        var animator = GetComponent<Animator>();

        animator.SetBool(PlayerAnimations.IsRunning, moveX != 0);
    }
}
