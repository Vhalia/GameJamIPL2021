using UnityEngine;

public class BasicEnemy_AttackState : AttackState
{
    private BasicEnemy basicEnemy;

    public BasicEnemy_AttackState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AttackState stateData, BasicEnemy basicEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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
        if (!isPlayerInRange)
        {
            finiteStateMachine.ChangeState(basicEnemy.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
