using UnityEngine;
using UnityEngine.Events;

public class EnvironementDetection : MonoBehaviour
{

    [SerializeField] private UnityEvent OnDetectingWall;
    [SerializeField] private UnityEvent OnDetectingLedge;
    [SerializeField] private GameObject wallCheck;
    [SerializeField] private GameObject groundCheck;

    private RayCaster _wallCheckRayCaster;
    private RayCaster _groundCheckRayCaster;

    private void FixedUpdate()
    {
        DetectWall();
        DetectLedge();
    }

    private void Awake()
    {
        _wallCheckRayCaster = wallCheck.GetComponent<RayCaster>();
        _groundCheckRayCaster = groundCheck.GetComponent<RayCaster>();
    }

    private void DetectWall()
    {
        if (_wallCheckRayCaster.Cast())
        {
            OnDetectingWall?.Invoke();
        }
    }

    private void DetectLedge()
    {
        if (!_groundCheckRayCaster.Cast())
        {
            OnDetectingLedge?.Invoke();
        }
    }
}
