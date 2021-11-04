using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public int FacingDirection { get; private set; }


    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform groundCheck;


    public FiniteStateMachine finiteStateMachine;
    public Data_Entity entityData;

    private RayCaster _wallCheckCast;
    private RayCaster _groundCheckCast;

    public virtual void Start()
    {
        _wallCheckCast = wallCheck.GetComponent<RayCaster>();
        _groundCheckCast = groundCheck.GetComponent<RayCaster>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        FacingDirection = 1;
        if (Rigidbody == null || Animator == null) throw new MissingFieldException("No rigidbody or animator find in entity");
        finiteStateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        finiteStateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        finiteStateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        Rigidbody.velocity = new Vector2(FacingDirection * velocity * Time.fixedDeltaTime, Rigidbody.velocity.y);
    }

    public virtual bool WallIsDetected()
    {
        return _wallCheckCast.RayHasTouched();
    }

    public virtual bool GroundIsDetected()
    {
        return _groundCheckCast.RayHasTouched();
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
}
