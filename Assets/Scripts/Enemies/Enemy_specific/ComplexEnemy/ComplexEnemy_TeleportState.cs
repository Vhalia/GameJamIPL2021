using UnityEngine;

public class ComplexEnemy_TeleportState : TeleportState
{
    private ComplexEnemy complexEnemy;
    public ComplexEnemy_TeleportState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_TeleportState stateData, ComplexEnemy complexEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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

    public override void TeleportToPlayer()
    {
        base.TeleportToPlayer();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        complexEnemy.transform.position = new Vector2(player.transform.position.x + stateData.offset, complexEnemy.transform.position.y);
        finiteStateMachine.ChangeState(complexEnemy.attackState);
    }
}
