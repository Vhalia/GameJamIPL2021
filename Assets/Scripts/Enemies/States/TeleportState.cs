
public class TeleportState : State
{
    protected bool isDetectingPlayer;
    protected Data_TeleportState stateData;
    public TeleportState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_TeleportState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
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

    public override void TeleportToPlayer()
    {
        base.TeleportToPlayer();
        
    }

}
