public class BringerOfDeath_AggroState : AggroState
{

    private BringerOfDeath bringerOfDeath;

    public BringerOfDeath_AggroState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AggroState stateData, BringerOfDeath bringerOfDeath) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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
        Rush();
        if (!isPlayerDetected)
        {
            finiteStateMachine.ChangeState(bringerOfDeath.runState);
        }else if (isPlayerInRange)
        {
            finiteStateMachine.ChangeState(bringerOfDeath.attackState);
        }
    }

    private void Rush()
    {
        bringerOfDeath.SetVelocity(stateData.movementSpeed);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
