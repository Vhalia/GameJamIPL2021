using UnityEngine;

public class BasicEnemy : Entity
{
    public BasicEnemy_IdleState idleState { get; private set; }
    public BasicEnemy_RunState runState { get; private set; }

    [SerializeField] private Data_idleState idleStateData;
    [SerializeField] private Data_RunState runStateData;

    public override void Start()
    {
        base.Start();

        runState = new BasicEnemy_RunState(finiteStateMachine, this, "run", runStateData, this);
        idleState = new BasicEnemy_IdleState(finiteStateMachine, this, "idle", idleStateData, this);

        finiteStateMachine.Initialize(runState);
    }
}
