using System.Collections;
using System.Collections.Generic;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!isPlayerInRange)
        {
            Debug.Log(basicEnemy + " attack -> run");
            finiteStateMachine.ChangeState(basicEnemy.runState);
        }
    }
}