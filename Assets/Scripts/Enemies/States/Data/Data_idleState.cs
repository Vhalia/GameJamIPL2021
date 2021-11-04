using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/States/Idle State")]
public class Data_idleState : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
