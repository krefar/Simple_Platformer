using Assets.Scripts.Player;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        var moveX = Input.GetAxis(Horizontal) * _moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);

        EnsureAnimator(moveX);
    }

    private void EnsureAnimator(float moveX)
    {
        var animator = GetComponent<Animator>();
        var isRunning = moveX != 0;

        animator.SetBool(PlayerAnimations.IsRunning, isRunning);
    }
}
