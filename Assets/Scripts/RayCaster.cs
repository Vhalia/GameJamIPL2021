using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Color color;
    [SerializeField] private LayerMask layersMask;
    [SerializeField] private float distance;
    [SerializeField] private Vector2 direction;

    public bool RayHasTouched(float gameObjectDirection)
    {
        var origin = transform.position + offset;
        var dir = direction * distance * gameObjectDirection;
        Debug.DrawRay(origin, dir, color);
        return Physics2D.Raycast(origin, direction * gameObjectDirection, distance, layersMask);
    }

    public bool RayHasTouched()
    {
        var origin = transform.position + offset;
        var dir = direction * distance;
        Debug.DrawRay(origin, dir, color);
        return Physics2D.Raycast(origin, direction, distance, layersMask);
    }
}
