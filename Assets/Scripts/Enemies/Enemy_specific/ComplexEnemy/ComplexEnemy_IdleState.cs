using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexEnemy_IdleState : IdleState

{
    private ComplexEnemy complexEnemy;

    public ComplexEnemy_IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_idleState stateData, ComplexEnemy complexEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
    {
        this.complexEnemy = complexEnemy;
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
    }


}
