using System;
using UnityEngine;
using UnityEngine.Events;

public class EnvironementDetection : MonoBehaviour
{

    [SerializeField] private UnityEvent OnDetectingWall;
    [SerializeField] private UnityEvent OnDetectingLedge;
    [SerializeField] private GameObjectEvent OnDetectingPlayer;
    [SerializeField] private GameObject wallCheck;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private RayCaster aggroCheck;
    [SerializeField] private LayerMask playerLayer;

    private RayCaster _wallCheckRayCaster;
    private RayCaster _groundCheckRayCaster;

    private void FixedUpdate()
    {
        DetectWall();
        DetectLedge();
        if(aggroCheck != null) DetectPlayer();
    }

    private void DetectPlayer()
    {
        GameObject playerGO = aggroCheck.Cast(transform.localScale.x);
        if (playerLayer != (playerLayer | 1 << playerGO.layer))
        {
            OnDetectingPlayer?.Invoke(playerGO);
        }
    }

    private void Awake()
    {
        _wallCheckRayCaster = wallCheck.GetComponent<RayCaster>();
        _groundCheckRayCaster = groundCheck.GetComponent<RayCaster>();
    }

    private void DetectWall()
    {
        if (_wallCheckRayCaster.RayHasTouched())
        {
            OnDetectingWall?.Invoke();
        }
    }

    private void DetectLedge()
    {
        if (!_groundCheckRayCaster.RayHasTouched())
        {
            OnDetectingLedge?.Invoke();
        }
    }
}
