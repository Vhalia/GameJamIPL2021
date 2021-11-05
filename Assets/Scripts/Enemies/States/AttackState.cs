
public class AttackState : State
{
    protected Data_AttackState stateData;

    public AttackState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AttackState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
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
