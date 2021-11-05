using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroState : State
{
    protected Data_AggroState stateData;

    public AggroState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AggroState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
    {
        this.stateData = stateData;
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
