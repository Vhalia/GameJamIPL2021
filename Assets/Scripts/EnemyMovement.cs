using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float startDirection;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private GameObject wallCheck;

    private RayCaster _groundCheckRayCaster;
    private RayCaster _wallCheckRayCaster;
    private float _direction;

    private void Awake()
    {
        _direction = startDirection;
        _groundCheckRayCaster = groundCheck.GetComponent<RayCaster>();
        _wallCheckRayCaster = wallCheck.GetComponent<RayCaster>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
        DetectWall();
        DetectLedge();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_direction * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        _direction = Scaler.x;
    }

    private void DetectWall()
    {
        if (_wallCheckRayCaster.Cast())
        {
            Flip();
        }
    }

    private void DetectLedge()
    {
        if (!_groundCheckRayCaster.Cast())
        {
            Flip();
        }
    }
}
