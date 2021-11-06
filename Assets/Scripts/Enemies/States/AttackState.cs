
using System;
using System.Collections;
using UnityEngine;

public class AttackState : State
{
    protected Data_AttackState stateData;

    protected GameObject gameObjectInAttackRange;

    public AttackState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AttackState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        gameObjectInAttackRange = entity.ObjectInRangeOfAttack();
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (gameObjectInAttackRange != null && entity.CanTriggerAttack)
        {
            gameObjectInAttackRange.GetComponent<IHealth>()?.TakeDamage(stateData.damage);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        gameObjectInAttackRange = entity.ObjectInRangeOfAttack();
    }
}
