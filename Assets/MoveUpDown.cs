using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    public float moveSpeed = 2f;   // Speed of the up and down movement
    public float moveDistance = 1f; // Distance to move up and down

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new position using a sine wave to create an up and down motion
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // Update the position of the transform
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
