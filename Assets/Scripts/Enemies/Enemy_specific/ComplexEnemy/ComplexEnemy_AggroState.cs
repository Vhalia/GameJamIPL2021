
public class ComplexEnemy_AggroState : AggroState
{
    ComplexEnemy complexEnemy;
    public ComplexEnemy_AggroState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AggroState stateData, ComplexEnemy complexEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
    {
        this.complexEnemy = complexEnemy;
    }

    public override void Enter()
    {
        base.Enter();
        finiteStateMachine.ChangeState(complexEnemy.teleportState);
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
