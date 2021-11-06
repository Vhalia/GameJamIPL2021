using UnityEngine;

public class BringerOfDeath : Entity
{
    public BringerOfDeath_IdleState idleState { get; private set; }
    public BringerOfDeath_RunState runState { get; private set; }
    public BringerOfDeath_AggroState aggroState { get; private set; }
    public BringerOfDeath_AttackState attackState { get; private set; }


    [SerializeField] private Data_idleState idleStateData;
    [SerializeField] private Data_RunState runStateData;
    [SerializeField] private Data_AggroState aggroStateData;
    [SerializeField] private Data_AttackState attackStateData;

    public override void Start()
    {
        base.Start();

        idleState = new BringerOfDeath_IdleState(finiteStateMachine, this, "idle",idleStateData, this);
        runState = new BringerOfDeath_RunState(finiteStateMachine, this, "run",runStateData, this);
        aggroState = new BringerOfDeath_AggroState(finiteStateMachine, this, "run",aggroStateData, this);
        attackState = new BringerOfDeath_AttackState(finiteStateMachine, this, "attack",attackStateData, this);

        finiteStateMachine.Initialize(idleState);
    }
}
