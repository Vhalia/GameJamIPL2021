using UnityEngine;

public class ComplexEnemy : Entity
{
    public ComplexEnemy_IdleState idleState { get; private set; }
    public ComplexEnemy_TeleportState teleportState { get; private set; }
    public ComplexEnemy_AttackState attackState { get; private set; }
    public ComplexEnemy_AggroState aggroState { get; private set; }

    [SerializeField] private Data_idleState idleStateData;
    [SerializeField] private Data_TeleportState teleportStateData;
    [SerializeField] private Data_AggroState aggroStateData;
    [SerializeField] private Data_AttackState attackStateData;

    public override void Start()
    {
        base.Start();

        teleportState = new ComplexEnemy_TeleportState(finiteStateMachine, this, "teleport", teleportStateData, this);
        idleState = new ComplexEnemy_IdleState(finiteStateMachine, this, "idle", idleStateData, this);
        aggroState = new ComplexEnemy_AggroState(finiteStateMachine, this, "idle", aggroStateData, this);
        attackState = new ComplexEnemy_AttackState(finiteStateMachine, this, "attack", attackStateData, this);

        finiteStateMachine.Initialize(idleState);
    }
}