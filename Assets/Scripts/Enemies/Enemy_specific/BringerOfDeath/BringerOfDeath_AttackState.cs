using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeath_AttackState : AttackState
{

    private BringerOfDeath bringerOfDeath;
    public BringerOfDeath_AttackState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AttackState stateData, BringerOfDeath bringerOfDeath) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
    {
        this.bringerOfDeath = bringerOfDeath;
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
        if (!isPlayerInRange && entity.AttackAnimationEnded)
        {
            finiteStateMachine.ChangeState(bringerOfDeath.aggroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
