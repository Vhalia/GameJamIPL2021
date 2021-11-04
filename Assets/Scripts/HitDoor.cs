using UnityEngine;
using UnityEngine.Events;

public class HitDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private LayerMask playerLayer;
    private bool _isBusy;

    private void Update()
    {
        _isBusy = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBusy || playerLayer != (playerLayer | 1 << other.gameObject.layer)) return;
        Enter();
    }


    private void Enter()
    {
        _isBusy = true;
        OnEnter?.Invoke();
    }

}