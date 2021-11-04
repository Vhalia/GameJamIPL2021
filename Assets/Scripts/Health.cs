using UnityEngine;

public class Health : MonoBehaviour, IHealth
{

    [SerializeField] private int maxHealth;
    [SerializeField] private string animDieName;
    [SerializeField] private string animHurtName;
    [SerializeField] private Animator animator;
    private int _currentHealth;

    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        animator.SetTrigger(animHurtName);
        if (_currentHealth <= 0) 
            Die();
    }

    public void Die()
    {
        animator.SetTrigger(animDieName);
        Destroy(gameObject);
    }
}
