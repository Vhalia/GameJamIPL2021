using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float startDirection;

    private float _direction;

    private void Awake()
    {
        _direction = startDirection;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(_direction * speed * Time.fixedDeltaTime, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    public void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        _direction = Scaler.x;
    }
}

public interface IEnemyMovement
{

}
