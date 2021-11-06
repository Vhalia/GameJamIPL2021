
public class BasicEnemy_AggroState : AggroState
{
    private BasicEnemy basicEnemy;

    public BasicEnemy_AggroState(FiniteStateMachine finiteStateMachine, Entity entity, string animatorBooleanName, Data_AggroState stateData, BasicEnemy basicEnemy) : base(finiteStateMachine, entity, animatorBooleanName, stateData)
    {
        this.basicEnemy = basicEnemy;
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
        Rush();
        if (!isPlayerDetected)
        {
            finiteStateMachine.ChangeState(basicEnemy.runState);
        }else if (isPlayerInRange)
        {
            finiteStateMachine.ChangeState(basicEnemy.attackState);
        }
    }

    private void Rush()
    {
        basicEnemy.SetVelocity(stateData.movementSpeed);
    }
}
