using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private Transform[] points = null;
    [SerializeField] private float speed = 1;

    private int targetPoint = 1;

    protected override void OnPlayerEnter()
    {
        // Control animation
    }

    protected override void OnPlayerExit()
    {
       // Exit animation
    }

    private void FixedUpdate()
    {
        if (transform.position.Equals(points[targetPoint]))
        {
            targetPoint = targetPoint == points.Length - 1 ? 0 : targetPoint + 1;
        }

        transform.position = Vector3.MoveTowards(transform.position, points[targetPoint].position, speed);
    }
}
