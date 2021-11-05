using UnityEngine;

public class ComplexEnemy : Entity
{
    public ComplexEnemy_IdleState idleState { get; private set; }
    public ComplexEnemy_TeleportState teleportState { get; private set; }

    [SerializeField] private Data_idleState idleStateData;
    [SerializeField] private Data_TeleportState teleportStateData;

    public override void Start()
    {
        base.Start();

        teleportState = new ComplexEnemy_TeleportState(finiteStateMachine, this, "teleport", teleportStateData, this);
        idleState = new ComplexEnemy_IdleState(finiteStateMachine, this, "idle", idleStateData, this);

        finiteStateMachine.Initialize(idleState);
    }
}