using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DealDamage(collision.gameObject);
    }

    public void DealDamage(GameObject go)
    {
        var healthController = go.GetComponent<IHealth>();
        healthController?.TakeDamage(damage);
    }
}
