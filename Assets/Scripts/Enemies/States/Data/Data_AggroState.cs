using UnityEngine;

[CreateAssetMenu(fileName = "newAggroStateData", menuName = "Data/States/Aggro State")]
public class Data_AggroState : ScriptableObject
{
    public GameObject player;
    public float movementSpeed;
    public Transform playerInRangeAttackCheck;
}
