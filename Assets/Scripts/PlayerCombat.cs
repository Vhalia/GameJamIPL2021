using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask ennemyLayer;
    [SerializeField] private float attackRate;
    [SerializeField] private int weaponDurability;
    [SerializeField] private int damage;

    private bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        if(canAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && weaponDurability > 0)
            {
                StartCoroutine(AttackDelay());
            }
        }

    }

    private IEnumerator AttackDelay()
    {
        canAttack = false;
        Attack();
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }

    private void Attack()
    {
        //Animation
        playerAnimator.SetTrigger("Attack");

        //Detect ennemies
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayer);

        //Deal damage
        foreach (Collider2D ennemy in hitEnnemies)
        {
            ennemy.GetComponent<IHealth>()?.TakeDamage(damage);
        }

        weaponDurability--;
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
