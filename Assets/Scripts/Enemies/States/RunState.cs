using UnityEngine;

public class RunState : State
{
    protected Data_RunState stateData;
    protected bool isDetectingWall;
    protected bool isDetectingGround;

    public RunState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_RunState stateData) : base(finiteStateMachine, entity, animatorBooleanName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);
        isDetectingWall = entity.WallIsDetected();
        isDetectingGround = entity.GroundIsDetected();
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
        entity.SetVelocity(stateData.movementSpeed);
        isDetectingWall = entity.WallIsDetected();
        isDetectingGround = entity.GroundIsDetected();
    }

}
