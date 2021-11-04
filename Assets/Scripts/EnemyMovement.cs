using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyMovement
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float startDirection;

    private float _direction;
    private bool _patrolling;
    private bool _isAggro;
    private GameObject _player;

    private void Awake()
    {
        _direction = startDirection;
        _patrolling = true;
        _isAggro = false;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (_patrolling) MoveWhenPatrolling();
        else if (_isAggro && _player != null) MoveWhenAggro(_player);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void MoveWhenPatrolling()
    {
        _isAggro = false;
        _patrolling = true;
        rb.velocity = new Vector2(_direction * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void MoveWhenAggro(GameObject target)
    {
        _player = target;
        _isAggro = true;
        _patrolling = false;
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
    public void Move();
    public void Flip();
}


