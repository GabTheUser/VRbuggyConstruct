using UnityEngine;

public class MoveToObjectAndLookAtPlayer : MonoBehaviour
{
    public Transform target;            // The initial target point to move towards.
    public Transform playerToLookAt;    // The player (or another object) to look at when reaching the target.
    public float moveSpeed = 5.0f;     // The speed at which the object moves.

    private bool hasReachedTarget = false;

    private void Update()
    {
        // If we haven't reached the target yet, move towards it.
        if (!hasReachedTarget && target != null)
        {
            // Calculate the direction from the current position to the target position
            Vector3 direction = target.position - transform.position;

            // Check if the object has reached the target
            if (direction.magnitude > 0.1f)
            {
                // Normalize the direction vector and move the object towards the target
                Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
                transform.Translate(moveVector);
            }
            else
            {
                hasReachedTarget = true;
            }
        }

        // When we have reached the target, look at the player.
        if (hasReachedTarget && playerToLookAt != null)
        {
            // Calculate the rotation to look at the player, but keep the X and Z rotation locked.
            Quaternion lookRotation = Quaternion.LookRotation(playerToLookAt.position - transform.position);
            lookRotation.x = 0f; // Lock the X rotation.
            lookRotation.z = 0f; // Lock the Z rotation.
            transform.rotation = lookRotation;
        }
    }
}
