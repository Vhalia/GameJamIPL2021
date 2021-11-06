

public class BringerOfDeath_IdleState : IdleState
{
    private BringerOfDeath bringerOfDeath;

    public BringerOfDeath_IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_idleState stateData, BringerOfDeath bringerOfDeath) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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
        if (bringerOfDeath.idleState.isIdleTimeOver)
        {
            finiteStateMachine.ChangeState(bringerOfDeath.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
