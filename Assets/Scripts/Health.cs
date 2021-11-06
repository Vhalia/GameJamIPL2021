using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{

    [SerializeField] private int maxHealth;
    [SerializeField] private string animHurtName;
    [SerializeField] private string animDieName;
    [SerializeField] private Animator animator;
    [SerializeField] private float invincibilityDuration;
    [SerializeField] private float fallAfterDeadDuration;
    [SerializeField] UnityEvent onDeath;
    [SerializeField] IntEvent onDamage;

    private bool isDead = false;
    private int _currentHealth;
    private bool canBeDamaged = true;

    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth <= 0) return;
        if (canBeDamaged)
        {
            StartCoroutine(LoseHealthDelay(damage));
        }
        
    }

    //Invincibility time after getting hurt
    private IEnumerator LoseHealthDelay(int damage)
    {
        canBeDamaged = false;
        LoseHealth(damage);
        yield return new WaitForSeconds(invincibilityDuration);
        canBeDamaged = true;
    }

    private void LoseHealth(int damage)
    {
        _currentHealth -= damage;
        animator.SetTrigger(animHurtName);
        onDamage?.Invoke(damage);
        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        StartCoroutine(FallAfterDeadDelay());
        
    }

    private IEnumerator FallAfterDeadDelay()
    {
        //Trigger dead animation
        if (!isDead)
        {
            animator.SetTrigger(animDieName);
            isDead = true;
        }

        //Disable controller scripts
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in scripts)
        {
            if (script != this)
                script.enabled = false;
        }

        //Delay to allow object to fall after dying
        yield return new WaitForSeconds(fallAfterDeadDuration);

        //Destroy rigidbody
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Destroy(body);

        //Remove colliders
        Collider2D[] colliders = GetComponents<Collider2D>();
        if (colliders.Length == 0)
            colliders = GetComponentsInChildren<Collider2D>();

        foreach (Collider2D coll in colliders)
        {
            coll.enabled = false;
        }
        onDeath?.Invoke();

        //Disable this script
        this.enabled = false;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
}
