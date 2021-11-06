using UnityEngine;

[CreateAssetMenu(fileName = "newAttackStateData", menuName = "Data/States/Attack State")]
public class Data_AttackState : ScriptableObject
{
    public int damage;
    public float attackRate;
}
