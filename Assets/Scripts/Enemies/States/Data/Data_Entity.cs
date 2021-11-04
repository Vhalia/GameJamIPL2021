using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity/Enemies")]
public class Data_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.5f;
    public float groundCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}
