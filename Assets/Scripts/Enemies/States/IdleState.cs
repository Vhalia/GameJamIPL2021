using UnityEngine;

public class IdleState : State
{

    protected Data_idleState stateData;
    protected float idleTime;
    protected bool isIdleTimeOver;

    public bool FlipAfterIdle { protected get; set; }

    public IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_idleState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (FlipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
