
public class ComplexEnemy_AttackState : AttackState
{

    private ComplexEnemy complexEnemy;

    public ComplexEnemy_AttackState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AttackState stateData, ComplexEnemy complexEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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
    }
}
