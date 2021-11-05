using UnityEngine;

public class HitTrap : MonoBehaviour
{
    [SerializeField] private GameObjectEvent OnEnter;
    [SerializeField] private LayerMask playerLayer;
    private bool _isBusy;

    private void Update()
    {
        _isBusy = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBusy || playerLayer != (playerLayer | 1 << other.gameObject.layer)) return;
        Enter(other.gameObject);
    }


    private void Enter(GameObject player)
    {
        _isBusy = true;
        OnEnter?.Invoke(player);
    }
}
