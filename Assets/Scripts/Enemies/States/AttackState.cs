
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
        gameObjectInAttackRange = entity.ObjectInRangeOfAttack();
        if (gameObjectInAttackRange != null)
        {
            Debug.Log("Colliqion" + gameObjectInAttackRange);
        }
    }
}
