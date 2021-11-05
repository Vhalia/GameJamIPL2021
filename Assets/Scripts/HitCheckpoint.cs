using UnityEngine;

public class HitCheckpoint : MonoBehaviour
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


    private void Enter(GameObject checkpoint)
    {
        _isBusy = true;
        OnEnter?.Invoke(checkpoint);
    }
}
