using UnityEngine;

public class BasicEnemy : Entity
{
    public BasicEnemy_IdleState idleState { get; private set; }
    public BasicEnemy_RunState runState { get; private set; }
    public BasicEnemy_AggroState aggroState { get; private set; }
    public BasicEnemy_AttackState attackState { get; private set; }

    [SerializeField] private Data_idleState idleStateData;
    [SerializeField] private Data_RunState runStateData;
    [SerializeField] private Data_AggroState aggroStateData;
    [SerializeField] private Data_AttackState attackStateData;

    public override void Start()
    {
        base.Start();

        runState = new BasicEnemy_RunState(finiteStateMachine, this, "run", runStateData, this);
        idleState = new BasicEnemy_IdleState(finiteStateMachine, this, "idle", idleStateData, this);
        aggroState = new BasicEnemy_AggroState(finiteStateMachine, this, "run", aggroStateData, this);
        attackState = new BasicEnemy_AttackState(finiteStateMachine, this, "attack", attackStateData, this);

        finiteStateMachine.Initialize(runState);
    }
}
