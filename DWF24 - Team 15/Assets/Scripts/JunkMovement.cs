using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkMover : MonoBehaviour
{
    // Speed at which the junk moves
    [Tooltip("Speed at which the junk moves.")]
    public float speed = 2f;

    // Direction of movement (set by JunkSpawnManager)
    [Tooltip("Direction of movement.")]
    public Vector3 movementDirection = Vector3.left;

    void Update()
    {
        // Move the junk in the specified direction at the assigned speed
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    }

    // Optional: Destroy the junk when it goes off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
