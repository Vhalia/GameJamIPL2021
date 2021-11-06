
public class BringerOfDeath_RunState : RunState
{
    private BringerOfDeath bringerOfDeath;

    public BringerOfDeath_RunState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_RunState stateData, BringerOfDeath bringerOfDeath) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
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
        if (isDetectingWall || !isDetectingGround)
        {
            bringerOfDeath.idleState.FlipAfterIdle = true;
            finiteStateMachine.ChangeState(bringerOfDeath.idleState);
        }
        else if (isPlayerDetected) 
        {
            finiteStateMachine.ChangeState(bringerOfDeath.aggroState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
