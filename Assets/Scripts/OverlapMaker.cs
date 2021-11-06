using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapMaker : MonoBehaviour
{
    [SerializeField] private GameObject hitBoxAttack;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsPlayer;

    public GameObject OverlapHitGameObject()
    {
        Collider2D collider = Physics2D.OverlapCircle(hitBoxAttack.transform.position, radius, whatIsPlayer);
        return collider ? collider.attachedRigidbody.gameObject : null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitBoxAttack.transform.position, radius);
    }
}
