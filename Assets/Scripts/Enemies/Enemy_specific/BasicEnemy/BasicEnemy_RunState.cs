using UnityEngine;

public class BasicEnemy_RunState : RunState
{

    private BasicEnemy basicEnemy;

    public BasicEnemy_RunState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_RunState stateData, BasicEnemy basicEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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

        if (isDetectingWall || !isDetectingGround)
        {
            basicEnemy.idleState.FlipAfterIdle = true;
            finiteStateMachine.ChangeState(basicEnemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(isPlayerDetected)
        {
            Debug.Log(basicEnemy + " run -> aggro ");
            finiteStateMachine.ChangeState(basicEnemy.aggroState);
        }
    }
}
