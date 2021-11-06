using UnityEngine;

public class BasicEnemy_IdleState : IdleState
{
    private BasicEnemy basicEnemy;

    public BasicEnemy_IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_idleState stateData, BasicEnemy basicEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
    {
        this.basicEnemy = basicEnemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(basicEnemy.idleState.isIdleTimeOver)
        {
            finiteStateMachine.ChangeState(basicEnemy.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(isPlayerDetected)
        {

            finiteStateMachine.ChangeState(basicEnemy.aggroState);
        }
    }
}
